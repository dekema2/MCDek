using System;
using System.ComponentModel;
using System.Linq;
using MCDek.Gui.MapEditor;
using MCLawl;

namespace MCDek
{

    public enum MapGenTheme
    {
        Arctic,
        Desert,
        Forest,
        Hell,
        Swamp
    }

    public enum MapGenTemplate
    {
        Archipelago,
        Atoll,
        Bay,
        Default,
        Dunes,
        Flat,
        Hills,
        Ice,
        Island,
        Lake,
        Mountains,
        Peninsula,
        River,
        Streams
    }

    public sealed class MapGenerator
    {
        MapGeneratorArgs args;
        Random rand;
        Noise noise;
        float[,] heightmap, blendmap, slopemap;

        const int WaterCoveragePasses = 10;
        const float CliffsideBlockThreshold = 0.01f;

        // theme-dependent vars
        byte bWaterSurface, bGroundSurface, bWater, bGround, bSeaFloor, bBedrock, bDeepWaterSurface, bCliff;
        int groundThickness = 5, seaFloorThickness = 3;

        public MapGenerator(MapGeneratorArgs _args)
        {
            args = _args;
            args.Validate();
            if (!args.customWaterLevel)
            {
                args.waterLevel = (args.dimH - 1) / 2;
            }
            rand = new Random(args.seed);
            noise = new Noise(args.seed, NoiseInterpolationMode.Bicubic);
            ApplyTheme(args.theme);
            EstimateComplexity();
        }

        public Level Generate()
        {
            GenerateHeightmap();
            return GenerateMap();
        }

        public static void GenerationTask(object task)
        {
            ((MapGenerator)task).Generate();
            GC.Collect(GC.MaxGeneration, GCCollectionMode.Optimized);
        }

        public static void GenerateFlatgrass(Level map)
        {
            for (int i = 0; i < map.width; i++)
            {
                for (int j = 0; j < map.depth; j++)
                {
                    for (int k = 0; k < ((map.height / 2) - 1); k++)
                    {
                        if (k < ((map.height / 2) - 5))
                        {
                            map.SetTile(i, j, k, Block.rock);
                        }
                        else
                        {
                            map.SetTile(i, j, k, Block.dirt);
                        }
                    }
                    map.SetTile(i, j, (map.height / 2) - 1, Block.grass);
                }
            }
        }

        #region Progress Reporting
        public ProgressChangedEventHandler ProgressCallback;

        int progressTotalEstimate = 0, progressRunningTotal = 0;

        private void EstimateComplexity()
        {
            this.progressTotalEstimate = 10;
            if (this.args.useBias)
            {
                this.progressTotalEstimate += 2;
            }
            if (this.args.layeredHeightmap)
            {
                this.progressTotalEstimate += 10;
            }
            if (this.args.marbledHeightmap)
            {
                this.progressTotalEstimate++;
            }
            if (this.args.invertHeightmap)
            {
                this.progressTotalEstimate++;
            }
            if (this.args.matchWaterCoverage)
            {
                this.progressTotalEstimate += 2;
            }
            if ((this.args.belowFuncExponent != 1f) || (this.args.aboveFuncExponent != 1f))
            {
                this.progressTotalEstimate += 5;
            }
            if (this.args.cliffSmoothing)
            {
                this.progressTotalEstimate += 2;
            }
            this.progressTotalEstimate += 2;
            if ((this.args.maxHeightVariation > 0) || (this.args.maxDepthVariation > 0))
            {
                this.progressTotalEstimate += 5;
            }
            this.progressTotalEstimate += 15;
            if (this.args.addCaves)
            {
                this.progressTotalEstimate += 5;
            }
            if (this.args.addOre)
            {
                this.progressTotalEstimate += 3;
            }
            if (this.args.addBeaches)
            {
                this.progressTotalEstimate += 10;
            }
            if (this.args.addTrees)
            {
                this.progressTotalEstimate += 5;
            }
        }

        private void ReportProgress(int relativeIncrease, string message)
        {
            if (this.ProgressCallback != null)
            {
                this.ProgressCallback(this, new ProgressChangedEventArgs((100 * this.progressRunningTotal) / this.progressTotalEstimate, message));
            }
            this.progressRunningTotal += relativeIncrease;
        }

        #endregion

        #region Heightmap Processing

        private void GenerateHeightmap()
        {
            this.ReportProgress(10, "Heightmap: Priming");
            this.heightmap = new float[this.args.dimX, this.args.dimY];

            this.noise.PerlinNoiseMap(this.heightmap, this.args.featureScale, this.args.detailScale, this.args.roughness, 0, 0);
            
            if (this.args.useBias && !this.args.delayBias)
            {
                this.ReportProgress(2, "Heightmap: Biasing");
                Noise.Normalize(this.heightmap);
                this.ApplyBias();
            }

            Noise.Normalize(this.heightmap);
            
            if (this.args.layeredHeightmap)
            {
                this.ReportProgress(10, "Heightmap: Layering");

                // needs a new Noise object to randomize second map
                float[,] heightmap2 = new float[this.args.dimX, this.args.dimY];
                new Noise(this.rand.Next(), NoiseInterpolationMode.Bicubic).PerlinNoiseMap(heightmap2, 0, this.args.detailScale, this.args.roughness, 0, 0);
                Noise.Normalize(heightmap2);

                // make a blendmap
                this.blendmap = new float[this.args.dimX, this.args.dimY];
                int blendmapDetailSize = ((int)Math.Log((double)Math.Max(this.args.dimX, this.args.dimY), 2.0)) - 2;
                new Noise(this.rand.Next(), NoiseInterpolationMode.Cosine).PerlinNoiseMap(this.blendmap, 3, blendmapDetailSize, 0.5f, 0, 0);
                Noise.Normalize(this.blendmap);
                float cliffSteepness = ((float)Math.Max(this.args.dimX, this.args.dimY)) / 6f;
                Noise.ScaleAndClip(this.blendmap, cliffSteepness);

                Noise.Blend(this.heightmap, heightmap2, this.blendmap);
            }

            if (this.args.marbledHeightmap)
            {
                this.ReportProgress(1, "Heightmap: Marbling");
                Noise.Marble(this.heightmap);
            }

            if (this.args.invertHeightmap)
            {
                this.ReportProgress(1, "Heightmap: Inverting");
                Noise.Invert(this.heightmap);
            }

            if (this.args.useBias && this.args.delayBias)
            {
                this.ReportProgress(2, "Heightmap: Biasing");
                Noise.Normalize(this.heightmap);
                this.ApplyBias();
            }

            Noise.Normalize(this.heightmap);
        }

        private void ApplyBias()
        {
            // set corners and midpoint
            float[] corners = new float[4];
            int c = 0;
            for (int i = 0; i < this.args.raisedCorners; i++)
            {
                corners[c++] = this.args.bias;
            }
            for (int i = 0; i < this.args.loweredCorners; i++)
            {
                corners[c++] = -this.args.bias;
            }
            float midpoint = this.args.midPoint * this.args.bias;

            // shuffle corners
            corners = corners.OrderBy(r => rand.Next()).ToArray();

            // overlay the bias
            Noise.ApplyBias(this.heightmap, corners[0], corners[1], corners[2], corners[3], midpoint);
        }

        // assumes normalzied heightmap
        public static float MatchWaterCoverage(float[,] heightmap, float desiredWaterCoverage)
        {
            if (desiredWaterCoverage == 0)
            {
                return 0;
            }
            if (desiredWaterCoverage == 1)
            {
                return 1;
            }

            float waterLevel = 0.5f;
            for (int i = 0; i < WaterCoveragePasses; i++)
            {
                if (CalculateWaterCoverage(heightmap, waterLevel) > desiredWaterCoverage)
                {
                    waterLevel = waterLevel - 1 / (float)(4 << i);
                }
                else
                {
                    waterLevel = waterLevel + 1 / (float)(4 << i);
                }
            }
            return waterLevel;
        }

        public static float CalculateWaterCoverage(float[,] heightmap, float waterLevel)
        {
            int underwaterBlocks = 0;
            for (int x = heightmap.GetLength(0) - 1; x >= 0; x--)
            {
                for (int y = heightmap.GetLength(1) - 1; y >= 0; y--)
                {
                    if (heightmap[x, y] < waterLevel)
                    {
                        underwaterBlocks++;
                    }
                }
            }
            return underwaterBlocks / (float)heightmap.Length;
        }

        #endregion

        #region Map Processing

        public Level GenerateMap()
        {
            Level map = new Level("newmap", (ushort)args.dimX, (ushort)args.dimY, (ushort)args.dimH, String.Empty);
            return GenerateMap(map);
        }

        public Level GenerateMap(Level map)
        {
            try
            {
                float desiredWaterLevel = 0.5f;
                if (this.args.matchWaterCoverage)
                {
                    this.ReportProgress(2, "Heightmap Processing: Matching water coverage");
                    desiredWaterLevel = MatchWaterCoverage(this.heightmap, this.args.waterCoverage);
                }

                // Calculate above/below water multipliers
                float aboveWaterMultiplier = 0f;
                if (desiredWaterLevel != 1)
                {
                    aboveWaterMultiplier = (float)(this.args.maxDepth / (1 - desiredWaterLevel));
                }

                // Apply power functions to above/below water parts of the heightmap
                if ((this.args.belowFuncExponent != 1) || (this.args.aboveFuncExponent != 1))
                {
                    this.ReportProgress(5, "Heightmap Processing: Adjusting slope");
                    for (int x = this.heightmap.GetLength(0) - 1; x >= 0; x--)
                    {
                        for (int y = this.heightmap.GetLength(1) - 1; y >= 0; y--)
                        {
                            if (this.heightmap[x, y] < desiredWaterLevel)
                            {
                                float normalizedDepth = 1 - (this.heightmap[x, y] / desiredWaterLevel);
                                this.heightmap[x, y] = desiredWaterLevel - (float)Math.Pow(normalizedDepth, args.belowFuncExponent) * desiredWaterLevel;
                            }
                            else
                            {
                                float normalizedHeight = (this.heightmap[x, y] - desiredWaterLevel) / (1 - desiredWaterLevel);
                                this.heightmap[x, y] = desiredWaterLevel + (float)Math.Pow(normalizedHeight, args.aboveFuncExponent) * (1 - desiredWaterLevel);
                            }
                        }
                    }
                }

                // Calculate the slope
                if (this.args.cliffSmoothing)
                {
                    this.ReportProgress(2, "Heightmap Processing: Smoothing");
                    this.slopemap = Noise.CalculateSlope(Noise.GaussianBlur5x5(this.heightmap));
                }
                else
                {
                    this.slopemap = Noise.CalculateSlope(this.heightmap);
                }

                int level;
                float slope;

                /* draw heightmap visually (DEBUG)

float underWaterMultiplier = 0;
if( desiredWaterLevel != 0 ) {
underWaterMultiplier = (float)(args.maxDepth / desiredWaterLevel);
}
for( int x = heightmap.GetLength( 0 ) - 1; x >= 0; x-- ) {
for( int y = heightmap.GetLength( 1 ) - 1; y >= 0; y-- ) {
if( heightmap[x, y] < desiredWaterLevel ) {
slope = slopemap[x, y] * args.maxDepth;
level = args.waterLevel - (int)Math.Round( (desiredWaterLevel - heightmap[x, y]) * underWaterMultiplier );
} else {
slope = slopemap[x, y] * args.maxHeight;
level = args.waterLevel + (int)Math.Round( (heightmap[x, y] - desiredWaterLevel) * aboveWaterMultiplier );
}
Block block;
if( slope < .12 ) {
block = Block.Green;
} else if( slope < .24 ) {
block = Block.Lime;
} else if( slope < .36 ) {
block = Block.Yellow;
} else if( slope < .48 ) {
block = Block.Orange;
} else if( slope < .6 ) {
block = Block.Red;
} else {
block = Block.Black;
}
for( int i = level; i >= 0; i-- ) {
map.SetTile( x, y, i, block );
}
}
}*/

                float[,] altmap = null;
                if ((this.args.maxHeightVariation != 0) || (this.args.maxDepthVariation != 0))
                {
                    this.ReportProgress(5, "Heightmap Processing: Randomizing");
                    altmap = new float[map.width, map.depth];
                    int blendmapDetailSize = (int)Math.Log((double)Math.Max(args.dimX, args.dimY), 2) - 2;
                    new Noise(this.rand.Next(), NoiseInterpolationMode.Cosine).PerlinNoiseMap(altmap, 3, blendmapDetailSize, 0.5f, 0, 0);
                    Noise.Normalize(altmap, -1, 1);
                }

                int snowStartThreshold = this.args.snowAltitude - this.args.snowTransition;
                int snowThreshold = this.args.snowAltitude;

                this.ReportProgress(10, "Filling");
                for (int x = this.heightmap.GetLength(0) - 1; x >= 0; x--)
                {
                    for (int y = this.heightmap.GetLength(1) - 1; y >= 0; y--)
                    {
                        if (this.heightmap[x, y] < desiredWaterLevel)
                        {
                            float depth = (args.maxDepthVariation != 0 ? (args.maxDepth + altmap[x, y] * args.maxDepthVariation) : args.maxDepth);
                            slope = this.slopemap[x, y] * depth;
                            level = args.waterLevel - (int)Math.Round(Math.Pow(1 - heightmap[x, y] / desiredWaterLevel, args.belowFuncExponent) * depth);
                            if (this.args.addWater)
                            {
                                if ((this.args.waterLevel - level) > 3)
                                {
                                    map.SetTile(x, y, this.args.waterLevel, this.bDeepWaterSurface);
                                }
                                else
                                {
                                    map.SetTile(x, y, this.args.waterLevel, this.bWaterSurface);
                                }
                                for (int i = this.args.waterLevel; i > level; i--)
                                {
                                    map.SetTile(x, y, i, this.bWater);
                                }
                                for (int i = level; i >= 0; i--)
                                {
                                    if (level - i < this.seaFloorThickness)
                                    {
                                        map.SetTile(x, y, i, this.bSeaFloor);
                                    }
                                    else
                                    {
                                        map.SetTile(x, y, i, this.bBedrock);
                                    }
                                }
                            }
                            else
                            {
                                if (blendmap != null && blendmap[x, y] > .25 && blendmap[x, y] < .75)
                                {
                                    map.SetTile(x, y, level, bCliff);
                                }
                                else
                                {
                                    if (slope < args.cliffThreshold)
                                    {
                                        map.SetTile(x, y, level, bGroundSurface);
                                    }
                                    else
                                    {
                                        map.SetTile(x, y, level, bCliff);
                                    }
                                }

                                for (int i = level - 1; i >= 0; i--)
                                {
                                    if (level - i < groundThickness)
                                    {
                                        if (blendmap != null && blendmap[x, y] > CliffsideBlockThreshold && blendmap[x, y] < (1 - CliffsideBlockThreshold))
                                        {
                                            map.SetTile(x, y, i, bCliff);
                                        }
                                        else
                                        {
                                            if (slope < args.cliffThreshold)
                                            {
                                                map.SetTile(x, y, i, bGround);
                                            }
                                            else
                                            {
                                                map.SetTile(x, y, i, bCliff);
                                            }
                                        }
                                    }
                                    else
                                    {
                                        map.SetTile(x, y, i, bBedrock);
                                    }
                                }
                            }
                        }
                        else
                        {
                            float height = (args.maxHeightVariation != 0 ? (args.maxHeight + altmap[x, y] * args.maxHeightVariation) : args.maxHeight);
                            slope = this.slopemap[x, y] * height;
                            if (height != 0)
                            {
                                level = args.waterLevel + (int)Math.Round(Math.Pow(heightmap[x, y] - desiredWaterLevel, args.aboveFuncExponent) * aboveWaterMultiplier / args.maxHeight * height);
                            }
                            else
                            {
                                level = this.args.waterLevel;
                            }

                            bool snow = args.addSnow &&
                                    (level > snowThreshold ||
                                    (level > snowStartThreshold && rand.NextDouble() < (level - snowStartThreshold) / (double)(snowThreshold - snowStartThreshold)));

                            if (blendmap != null && blendmap[x, y] > .25 && blendmap[x, y] < .75)
                            {
                                map.SetTile(x, y, level, bCliff);
                            }
                            else
                            {
                                if (slope < args.cliffThreshold)
                                {
                                    if (snow)
                                    {
                                        map.SetTile(x, y, level, Block.white);
                                    }
                                    else
                                    {
                                        map.SetTile(x, y, level, bGroundSurface);
                                    }
                                }
                                else
                                {
                                    map.SetTile(x, y, level, bCliff);
                                }
                            }

                            for (int i = level - 1; i >= 0; i--)
                            {
                                if (level - i < this.groundThickness)
                                {
                                    if (blendmap != null && blendmap[x, y] > CliffsideBlockThreshold && blendmap[x, y] < (1 - CliffsideBlockThreshold))
                                    {
                                        map.SetTile(x, y, i, this.bCliff);
                                    }
                                    else if (slope < this.args.cliffThreshold)
                                    {
                                        if (snow)
                                        {
                                            map.SetTile(x, y, i, Block.white);
                                        }
                                        else
                                        {
                                            map.SetTile(x, y, i, this.bGround);
                                        }
                                    }
                                    else
                                    {
                                        map.SetTile(x, y, i, this.bCliff);
                                    }
                                }
                                else
                                {
                                    map.SetTile(x, y, i, this.bBedrock);
                                }
                            }
                        }
                    }
                }

                if (this.args.addCaves || this.args.addOre)
                {
                    this.AddCaves(map);
                }

                if (this.args.addBeaches)
                {
                    this.ReportProgress(10, "Processing: Adding beaches");
                    this.AddBeaches(map);
                }

                if (args.addTrees)
                {
                    ReportProgress(5, "Processing: Planting trees");
                    Level outMap = new Level(map.name, map.width, map.depth, map.height, String.Empty);
                    outMap.blocks = (byte[])map.blocks.Clone();
                    //outMap.EnableOwnershipTracking(ReservedPlayerID.None);

                    Forester treeGen = new Forester(new Forester.ForesterArgs
                    {
                        inMap = map,
                        outMap = outMap,
                        rand = rand,
                        TREECOUNT = (int)(map.width * map.depth * 4 / (1024f * (args.treeSpacingMax + args.treeSpacingMin) / 2)),
                        OPERATION = Forester.Operation.Add,
                        bGroundSurface = bGroundSurface
                    });
                    treeGen.Generate();
                    map = outMap;

                    GenerateTrees(map);
                }

                this.ReportProgress(0, "Generation complete");
                map.ResetSpawn();

                /*
map.SetMeta("_Origin", "GeneratorName", "fCraft");
map.SetMeta("_Origin", "GeneratorVersion", Updater.GetVersionString());
map.SetMeta("_Origin", "GeneratorParams", args.Serialize().ToString(System.Xml.Linq.SaveOptions.DisableFormatting));
*/

                return map;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }



        #region Caves

        // Cave generation method from Omen 0.70, used with osici's permission
        static void AddSingleCave(Random rand, Level map, byte bedrockType, byte fillingType, int length, double maxDiameter)
        {

            int startX = rand.Next(0, map.width);
            int startY = rand.Next(0, map.depth);
            int startH = rand.Next(0, map.height);

            int k1;
            for (k1 = 0; map.blocks[startX + map.width * map.depth * (map.height - 1 - startH) + map.width * startY] != bedrockType && k1 < 10000; k1++)
            {
                startX = rand.Next(0, map.width);
                startY = rand.Next(0, map.depth);
                startH = rand.Next(0, map.height);
            }

            if (k1 >= 10000)
                return;

            int x = startX;
            int y = startY;
            int h = startH;

            for (int k2 = 0; k2 < length; k2++)
            {
                int diameter = (int)(maxDiameter * rand.NextDouble() * map.width);
                if (diameter < 1) diameter = 2;
                int radius = diameter / 2;
                if (radius == 0) radius = 1;
                x += (int)(0.7 * (rand.NextDouble() - 0.5D) * diameter);
                y += (int)(0.7 * (rand.NextDouble() - 0.5D) * diameter);
                h += (int)(0.7 * (rand.NextDouble() - 0.5D) * diameter);

                for (int j3 = 0; j3 < diameter; j3++)
                {
                    for (int k3 = 0; k3 < diameter; k3++)
                    {
                        for (int l3 = 0; l3 < diameter; l3++)
                        {
                            if ((j3 - radius) * (j3 - radius) + (k3 - radius) * (k3 - radius) + (l3 - radius) * (l3 - radius) >= radius * radius ||
                                x + j3 >= map.width || h + k3 >= map.height || y + l3 >= map.depth ||
                                x + j3 < 0 || h + k3 < 0 || y + l3 < 0)
                            {
                                continue;
                            }

                            int index = x + j3 + map.width * map.depth * (map.height - 1 - (h + k3)) + map.width * (y + l3);

                            if (map.blocks[index] == bedrockType)
                            {
                                map.blocks[index] = (byte)fillingType;
                            }
                            if ((fillingType == 10 || fillingType == 11 || fillingType == 8 || fillingType == 9) &&
                                h + k3 < startH)
                            {
                                map.blocks[index] = 0;
                            }
                        }
                    }
                }
            }
        }


        static void AddSingleVein(Random rand, Level map, byte bedrockType, byte fillingType, int k, double maxDiameter, int l)
        {
            AddSingleVein(rand, map, bedrockType, fillingType, k, maxDiameter, l, 10);
        }

        static void AddSingleVein(Random rand, Level map, byte bedrockType, byte fillingType, int k, double maxDiameter, int l, int i1)
        {

            int j1 = rand.Next(0, map.width);
            int k1 = rand.Next(0, map.height);
            int l1 = rand.Next(0, map.depth);

            double thirteenOverK = 1 / (double)k;

            for (int i2 = 0; i2 < i1; i2++)
            {
                int j2 = j1 + (int)(.5 * (rand.NextDouble() - .5) * (double)map.width);
                int k2 = k1 + (int)(.5 * (rand.NextDouble() - .5) * (double)map.height);
                int l2 = l1 + (int)(.5 * (rand.NextDouble() - .5) * (double)map.depth);
                for (int l3 = 0; l3 < k; l3++)
                {
                    int diameter = (int)(maxDiameter * rand.NextDouble() * map.width);
                    if (diameter < 1) diameter = 2;
                    int radius = diameter / 2;
                    if (radius == 0) radius = 1;
                    int i3 = (int)((1 - thirteenOverK) * (double)j1 + thirteenOverK * (double)j2 + (double)(l * radius) * (rand.NextDouble() - .5));
                    int j3 = (int)((1 - thirteenOverK) * (double)k1 + thirteenOverK * (double)k2 + (double)(l * radius) * (rand.NextDouble() - .5));
                    int k3 = (int)((1 - thirteenOverK) * (double)l1 + thirteenOverK * (double)l2 + (double)(l * radius) * (rand.NextDouble() - .5));
                    for (int k4 = 0; k4 < diameter; k4++)
                    {
                        for (int l4 = 0; l4 < diameter; l4++)
                        {
                            for (int i5 = 0; i5 < diameter; i5++)
                            {
                                if ((k4 - radius) * (k4 - radius) + (l4 - radius) * (l4 - radius) + (i5 - radius) * (i5 - radius) < radius * radius &&
                                    i3 + k4 < map.width && j3 + l4 < map.height && k3 + i5 < map.depth &&
                                    i3 + k4 >= 0 && j3 + l4 >= 0 && k3 + i5 >= 0)
                                {

                                    int index = i3 + k4 + map.width * map.depth * (map.height - 1 - (j3 + l4)) + map.width * (k3 + i5);

                                    if (map.blocks[index] == bedrockType)
                                    {
                                        map.blocks[index] = fillingType;
                                    }
                                }
                            }
                        }
                    }
                }
                j1 = j2;
                k1 = k2;
                l1 = l2;
            }
        }

        static void SealLiquids(Level map, byte sealantType)
        {
            for (int x = 1; x < map.width - 1; x++)
            {
                for (int h = 1; h < map.height; h++)
                {
                    for (int y = 1; y < map.depth - 1; y++)
                    {
                        int index = map.FCPosToInt(x, y, h);
                        if ((map.blocks[index] == 10 || map.blocks[index] == 11 || map.blocks[index] == 8 || map.blocks[index] == 9) &&
                            (map.GetTile(x - 1, y, h) == 0 || map.GetTile(x + 1, y, h) == 0 ||
                            map.GetTile(x, y - 1, h) == 0 || map.GetTile(x, y + 1, h) == 0 ||
                            map.GetTile(x, y, h - 1) == 0))
                        {
                            map.blocks[index] = sealantType;
                        }
                    }
                }
            }
        }

        public void AddCaves(Level map)
        {
            Random rand = new Random();

            if (args.addCaves)
            {
                ReportProgress(5, "Processing: Adding caves");
                for (int i1 = 0; i1 < 36 * args.caveDensity; i1++)
                    AddSingleCave(rand, map, (byte)bBedrock, (byte)Block.air, 30, 0.05 * args.caveSize);

                for (int j1 = 0; j1 < 9 * args.caveDensity; j1++)
                    AddSingleVein(rand, map, (byte)bBedrock, (byte)Block.air, 500, 0.015 * args.caveSize, 1);

                for (int k1 = 0; k1 < 30 * args.caveDensity; k1++)
                    AddSingleVein(rand, map, (byte)bBedrock, (byte)Block.air, 300, 0.03 * args.caveSize, 1, 20);


                if (args.addCaveLava)
                {
                    for (int i = 0; i < 8 * args.caveDensity; i++)
                    {
                        AddSingleCave(rand, map, (byte)bBedrock, (byte)Block.lava, 30, 0.05 * args.caveSize);
                    }
                    for (int j = 0; j < 3 * args.caveDensity; j++)
                    {
                        AddSingleVein(rand, map, (byte)bBedrock, (byte)Block.lava, 1000, 0.015 * args.caveSize, 1);
                    }
                }


                if (args.addCaveWater)
                {
                    for (int k = 0; k < 8 * args.caveDensity; k++)
                    {
                        AddSingleCave(rand, map, (byte)bBedrock, (byte)Block.water, 30, 0.05 * args.caveSize);
                    }
                    for (int l = 0; l < 3 * args.caveDensity; l++)
                    {
                        AddSingleVein(rand, map, (byte)bBedrock, (byte)Block.water, 1000, 0.015 * args.caveSize, 1);
                    }
                }

                SealLiquids(map, (byte)bBedrock);
            }


            if (args.addOre)
            {
                ReportProgress(3, "Processing: Adding ore");
                for (int l1 = 0; l1 < 12 * args.caveDensity; l1++)
                {
                    AddSingleCave(rand, map, (byte)bBedrock, (byte)Block.coal, 500, 0.03);
                }

                for (int i2 = 0; i2 < 32 * args.caveDensity; i2++)
                {
                    AddSingleVein(rand, map, (byte)bBedrock, (byte)Block.coal, 200, 0.015, 1);
                    AddSingleCave(rand, map, (byte)bBedrock, (byte)Block.ironrock, 500, 0.02);
                }

                for (int k2 = 0; k2 < 8 * args.caveDensity; k2++)
                {
                    AddSingleVein(rand, map, (byte)bBedrock, (byte)Block.ironrock, 200, 0.015, 1);
                    AddSingleVein(rand, map, (byte)bBedrock, (byte)Block.goldrock, 200, 0.0145, 1);
                }

                for (int l2 = 0; l2 < 20 * args.caveDensity; l2++)
                {
                    AddSingleCave(rand, map, (byte)bBedrock, (byte)Block.goldrock, 400, 0.0175);
                }
            }
        }

        #endregion

        void AddBeaches(Level map)
        {
            int beachExtentSqr = (args.beachExtent + 1) * (args.beachExtent + 1);
            for (int x = 0; x < map.width; x++)
            {
                for (int y = 0; y < map.depth; y++)
                {
                    for (int h = args.waterLevel; h <= args.waterLevel + args.beachHeight; h++)
                    {
                        if (map.GetTile(x, y, h) != (byte)bGroundSurface) continue;
                        bool found = false;
                        for (int dx = -args.beachExtent; !found && dx <= args.beachExtent; dx++)
                        {
                            for (int dy = -args.beachExtent; !found && dy <= args.beachExtent; dy++)
                            {
                                for (int dh = -args.beachHeight; !found && dh <= 0; dh++)
                                {
                                    if (dx * dx + dy * dy + dh * dh > beachExtentSqr) continue;
                                    int xx = x + dx;
                                    int yy = y + dy;
                                    int hh = h + dh;
                                    if (xx < 0 || xx >= map.width || yy < 0 || yy >= map.depth || hh < 0 || hh >= map.height) continue;
                                    byte block = map.GetTile(xx, yy, hh);
                                    if (block == (byte)bWater || block == (byte)bWaterSurface)
                                    {
                                        found = true;
                                        break;
                                    }
                                }
                            }
                        }
                        if (found)
                        {
                            map.SetTile(x, y, h, bSeaFloor);
                            if (h > 0 && map.GetTile(x, y, h - 1) == (byte)bGround) map.SetTile(x, y, h - 1, bSeaFloor);
                        }
                    }
                }
            }
        }

        public void GenerateTrees(Level map)
        {
            int MinHeight = args.treeHeightMin;
            int MaxHeight = args.treeHeightMax;
            int MinTrunkPadding = args.treeSpacingMin;
            int MaxTrunkPadding = args.treeSpacingMax;
            int TopLayers = 2;
            double Odds = 0.618;
            bool OnlyAir = true;

            Random rn = new Random();
            int nx, ny, nz, nh;
            int radius;

            map.CalculateShadows();

            for (int x = 0; x < map.width; x += rn.Next(MinTrunkPadding, MaxTrunkPadding + 1))
            {
                for (int y = 0; y < map.depth; y += rn.Next(MinTrunkPadding, MaxTrunkPadding + 1))
                {
                    nx = x + rn.Next(-(MinTrunkPadding / 2), (MaxTrunkPadding / 2) + 1);
                    ny = y + rn.Next(-(MinTrunkPadding / 2), (MaxTrunkPadding / 2) + 1);
                    if (nx < 0 || nx >= map.width || ny < 0 || ny >= map.depth) continue;
                    nz = map.shadows[nx, ny];

                    if ((map.GetTile(nx, ny, nz) == (byte)bGroundSurface) && slopemap[nx, ny] < .5)
                    {
                        // Pick a random height for the tree between Min and Max,
                        // discarding this tree if it would breach the top of the map
                        if ((nh = rn.Next(MinHeight, MaxHeight + 1)) + nz + nh / 2 > map.height)
                            continue;

                        // Generate the trunk of the tree
                        for (int z = 1; z <= nh; z++)
                            map.SetTile(nx, ny, nz + z, Block.trunk);

                        for (int i = -1; i < nh / 2; i++)
                        {
                            // Should we draw thin (2x2) or thicker (4x4) foliage
                            radius = (i >= (nh / 2) - TopLayers) ? 1 : 2;
                            // Draw the foliage
                            for (int xoff = -radius; xoff < radius + 1; xoff++)
                            {
                                for (int yoff = -radius; yoff < radius + 1; yoff++)
                                {
                                    // Drop random leaves from the edges
                                    if (rn.NextDouble() > Odds && Math.Abs(xoff) == Math.Abs(yoff) && Math.Abs(xoff) == radius)
                                        continue;
                                    // By default only replace an existing block if its air
                                    if (OnlyAir != true || map.GetTile(nx + xoff, ny + yoff, nz + nh + i) == (byte)Block.air)
                                        map.SetTile(nx + xoff, ny + yoff, nz + nh + i, Block.leaf);
                                }
                            }
                        }
                    }
                }
            }
        }

        #endregion

        #region Themes / Templates

        public void ApplyTheme(MapGenTheme theme)
        {
            args.theme = theme;
            switch (theme)
            {
                case MapGenTheme.Arctic:
                    bWaterSurface = Block.glass;
                    bDeepWaterSurface = Block.water;
                    bGroundSurface = Block.white;
                    bWater = Block.water;
                    bGround = Block.white;
                    bSeaFloor = Block.white;
                    bBedrock = Block.rock;
                    bCliff = Block.rock;
                    groundThickness = 1;
                    break;
                case MapGenTheme.Desert:
                    bWaterSurface = Block.water;
                    bDeepWaterSurface = Block.water;
                    bGroundSurface = Block.sand;
                    bWater = Block.water;
                    bGround = Block.sand;
                    bSeaFloor = Block.sand;
                    bBedrock = Block.rock;
                    bCliff = Block.gravel;
                    break;
                case MapGenTheme.Hell:
                    bWaterSurface = Block.lava;
                    bDeepWaterSurface = Block.lava;
                    bGroundSurface = Block.obsidian;
                    bWater = Block.lava;
                    bGround = Block.rock;
                    bSeaFloor = Block.obsidian;
                    bBedrock = Block.rock;
                    bCliff = Block.stone;
                    break;
                case MapGenTheme.Forest:
                    bWaterSurface = Block.water;
                    bDeepWaterSurface = Block.water;
                    bGroundSurface = Block.grass;
                    bWater = Block.water;
                    bGround = Block.dirt;
                    bSeaFloor = Block.sand;
                    bBedrock = Block.rock;
                    bCliff = Block.stone;
                    break;
                case MapGenTheme.Swamp:
                    bWaterSurface = Block.water;
                    bDeepWaterSurface = Block.water;
                    bGroundSurface = Block.dirt;
                    bWater = Block.water;
                    bGround = Block.dirt;
                    bSeaFloor = Block.leaf;
                    bBedrock = Block.rock;
                    bCliff = Block.rock;
                    break;
            }
        }

        public static MapGeneratorArgs MakeTemplate(MapGenTemplate template)
        {
            switch (template)
            {
                case MapGenTemplate.Archipelago:
                    return new MapGeneratorArgs
                    {
                        maxHeight = 8,
                        maxDepth = 20,
                        featureScale = 3,
                        roughness = .46f,
                        matchWaterCoverage = true,
                        waterCoverage = .85f
                    };

                case MapGenTemplate.Atoll:
                    return new MapGeneratorArgs
                    {
                        theme = MapGenTheme.Desert,
                        maxHeight = 2,
                        maxDepth = 39,
                        useBias = true,
                        bias = .9f,
                        midPoint = 1,
                        loweredCorners = 4,
                        featureScale = 2,
                        detailScale = 5,
                        marbledHeightmap = true,
                        invertHeightmap = true,
                        matchWaterCoverage = true,
                        waterCoverage = .95f
                    };

                case MapGenTemplate.Bay:
                    return new MapGeneratorArgs
                    {
                        maxHeight = 22,
                        maxDepth = 12,
                        useBias = true,
                        bias = 1,
                        midPoint = -1,
                        raisedCorners = 3,
                        loweredCorners = 1,
                        treeSpacingMax = 12,
                        treeSpacingMin = 6,
                        marbledHeightmap = true,
                        delayBias = true
                    };

                case MapGenTemplate.Default:
                    return new MapGeneratorArgs();

                case MapGenTemplate.Dunes:
                    return new MapGeneratorArgs
                    {
                        addTrees = false,
                        addWater = false,
                        theme = MapGenTheme.Desert,
                        maxHeight = 12,
                        maxDepth = 7,
                        featureScale = 2,
                        detailScale = 3,
                        roughness = .44f,
                        marbledHeightmap = true,
                        invertHeightmap = true
                    };

                case MapGenTemplate.Hills:
                    return new MapGeneratorArgs
                    {
                        addWater = false,
                        maxHeight = 8,
                        maxDepth = 8,
                        featureScale = 2,
                        treeSpacingMin = 7,
                        treeSpacingMax = 13
                    };

                case MapGenTemplate.Ice:
                    return new MapGeneratorArgs
                    {
                        addTrees = false,
                        theme = MapGenTheme.Arctic,
                        maxHeight = 2,
                        maxDepth = 2032,
                        featureScale = 2,
                        detailScale = 7,
                        roughness = .64f,
                        marbledHeightmap = true,
                        matchWaterCoverage = true,
                        waterCoverage = .3f,
                        maxHeightVariation = 0
                    };

                case MapGenTemplate.Island:
                    return new MapGeneratorArgs
                    {
                        maxHeight = 16,
                        maxDepth = 39,
                        useBias = true,
                        bias = .7f,
                        midPoint = 1,
                        loweredCorners = 4,
                        featureScale = 3,
                        detailScale = 7,
                        marbledHeightmap = true,
                        delayBias = true
                    };

                case MapGenTemplate.Lake:
                    return new MapGeneratorArgs
                    {
                        maxHeight = 14,
                        maxDepth = 20,
                        useBias = true,
                        bias = .65f,
                        midPoint = -1,
                        raisedCorners = 4,
                        featureScale = 2,
                        roughness = .56f,
                        matchWaterCoverage = true,
                        waterCoverage = .3f
                    };

                case MapGenTemplate.Mountains:
                    return new MapGeneratorArgs
                    {
                        addWater = false,
                        maxHeight = 40,
                        maxDepth = 10,
                        featureScale = 1,
                        detailScale = 7,
                        marbledHeightmap = true
                    };

                case MapGenTemplate.River:
                    return new MapGeneratorArgs
                    {
                        maxHeight = 22,
                        maxDepth = 8,
                        featureScale = 0,
                        detailScale = 6,
                        marbledHeightmap = true,
                        matchWaterCoverage = true,
                        waterCoverage = .31f
                    };

                case MapGenTemplate.Streams:
                    return new MapGeneratorArgs
                    {
                        maxHeight = 5,
                        maxDepth = 4,
                        featureScale = 2,
                        detailScale = 7,
                        roughness = .55f,
                        marbledHeightmap = true,
                        matchWaterCoverage = true,
                        waterCoverage = .25f,
                        treeSpacingMin = 8,
                        treeSpacingMax = 14
                    };

                case MapGenTemplate.Peninsula:
                    return new MapGeneratorArgs
                    {
                        maxHeight = 22,
                        maxDepth = 12,
                        useBias = true,
                        bias = .5f,
                        midPoint = -1,
                        raisedCorners = 3,
                        loweredCorners = 1,
                        treeSpacingMax = 12,
                        treeSpacingMin = 6,
                        invertHeightmap = true,
                        waterCoverage = .5f
                    };

                case MapGenTemplate.Flat:
                    return new MapGeneratorArgs
                    {
                        maxHeight = 0,
                        maxDepth = 0,
                        maxHeightVariation = 0,
                        addWater = false,
                        detailScale = 0,
                        featureScale = 0,
                        addCliffs = false
                    };
            }
            return null; // can never happen
        }

        #endregion
    }
}