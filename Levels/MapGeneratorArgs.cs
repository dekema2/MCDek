using System;
using System.Xml;
using System.Xml.Linq;

namespace MCDek
{
    public sealed class MapGeneratorArgs
    {
        // Fields
        public float aboveFuncExponent;
        public bool addBeaches;
        public bool addCaveLava;
        public bool addCaves;
        public bool addCaveWater;
        public bool addCliffs;
        public bool addOre;
        public bool addSnow;
        public bool addTrees;
        public bool addWater;
        public int beachExtent;
        public int beachHeight;
        public float belowFuncExponent;
        public float bias;
        public float caveDensity;
        public float caveSize;
        public bool cliffSmoothing;
        public float cliffThreshold;
        public bool customWaterLevel;
        public bool delayBias;
        public int detailScale;
        public int dimH;
        public int dimX;
        public int dimY;
        public int featureScale;
        private const int FormatVersion = 2;
        public bool invertHeightmap;
        public bool layeredHeightmap;
        public int loweredCorners;
        public bool marbledHeightmap;
        public bool matchWaterCoverage;
        public int maxDepth;
        public int maxDepthVariation;
        public int maxHeight;
        public int maxHeightVariation;
        public int midPoint;
        public int raisedCorners;
        private const string RootTagName = "MCDekMapGeneratorArgs";
        public float roughness;
        public int seed;
        public int snowAltitude;
        public int snowTransition;
        public MapGenTheme theme;
        public int treeHeightMax;
        public int treeHeightMin;
        public int treeSpacingMax;
        public int treeSpacingMin;
        public bool useBias;
        public float waterCoverage;
        public int waterLevel;

        // Methods
        public MapGeneratorArgs()
        {
            this.theme = MapGenTheme.Forest;
            this.dimX = 0x100;
            this.dimY = 0x100;
            this.dimH = 0x60;
            this.maxHeight = 20;
            this.maxDepth = 12;
            this.maxHeightVariation = 4;
            this.addWater = true;
            this.waterLevel = 0x30;
            this.waterCoverage = 0.5f;
            this.detailScale = 7;
            this.featureScale = 1;
            this.roughness = 0.5f;
            this.aboveFuncExponent = 1f;
            this.belowFuncExponent = 1f;
            this.addTrees = true;
            this.treeSpacingMin = 7;
            this.treeSpacingMax = 11;
            this.treeHeightMin = 5;
            this.treeHeightMax = 7;
            this.caveDensity = 2f;
            this.caveSize = 1f;
            this.snowAltitude = 70;
            this.snowTransition = 7;
            this.addCliffs = true;
            this.cliffSmoothing = true;
            this.cliffThreshold = 1f;
            this.beachExtent = 6;
            this.beachHeight = 2;
            this.seed = new Random().Next();
        }

        public MapGeneratorArgs(string fileName)
        {
            this.theme = MapGenTheme.Forest;
            this.dimX = 0x100;
            this.dimY = 0x100;
            this.dimH = 0x60;
            this.maxHeight = 20;
            this.maxDepth = 12;
            this.maxHeightVariation = 4;
            this.addWater = true;
            this.waterLevel = 0x30;
            this.waterCoverage = 0.5f;
            this.detailScale = 7;
            this.featureScale = 1;
            this.roughness = 0.5f;
            this.aboveFuncExponent = 1f;
            this.belowFuncExponent = 1f;
            this.addTrees = true;
            this.treeSpacingMin = 7;
            this.treeSpacingMax = 11;
            this.treeHeightMin = 5;
            this.treeHeightMax = 7;
            this.caveDensity = 2f;
            this.caveSize = 1f;
            this.snowAltitude = 70;
            this.snowTransition = 7;
            this.addCliffs = true;
            this.cliffSmoothing = true;
            this.cliffThreshold = 1f;
            this.beachExtent = 6;
            this.beachHeight = 2;
            XElement root = XDocument.Load(fileName).Root;
            XAttribute attribute = root.Attribute("version");
            int num = 0;
            if (((attribute != null) && (attribute.Value != null)) && (attribute.Value.Length > 0))
            {
                num = int.Parse(attribute.Value);
            }
            this.theme = (MapGenTheme)Enum.Parse(typeof(MapGenTheme), root.Element("theme").Value, true);
            this.seed = int.Parse(root.Element("seed").Value);
            this.maxHeight = int.Parse(root.Element("maxHeight").Value);
            this.maxDepth = int.Parse(root.Element("maxDepth").Value);
            this.addWater = bool.Parse(root.Element("addWater").Value);
            if (root.Element("customWaterLevel") != null)
            {
                this.customWaterLevel = bool.Parse(root.Element("customWaterLevel").Value);
            }
            this.matchWaterCoverage = bool.Parse(root.Element("matchWaterCoverage").Value);
            this.waterLevel = int.Parse(root.Element("waterLevel").Value);
            this.waterCoverage = float.Parse(root.Element("waterCoverage").Value);
            this.useBias = bool.Parse(root.Element("useBias").Value);
            if (root.Element("delayBias") != null)
            {
                this.delayBias = bool.Parse(root.Element("delayBias").Value);
            }
            this.bias = float.Parse(root.Element("bias").Value);
            this.raisedCorners = int.Parse(root.Element("raisedCorners").Value);
            this.loweredCorners = int.Parse(root.Element("loweredCorners").Value);
            this.midPoint = int.Parse(root.Element("midPoint").Value);
            if (num == 0)
            {
                this.detailScale = int.Parse(root.Element("minDetailSize").Value);
                this.featureScale = int.Parse(root.Element("maxDetailSize").Value);
            }
            else
            {
                this.detailScale = int.Parse(root.Element("detailScale").Value);
                this.featureScale = int.Parse(root.Element("featureScale").Value);
            }
            this.roughness = float.Parse(root.Element("roughness").Value);
            this.layeredHeightmap = bool.Parse(root.Element("layeredHeightmap").Value);
            this.marbledHeightmap = bool.Parse(root.Element("marbledHeightmap").Value);
            this.invertHeightmap = bool.Parse(root.Element("invertHeightmap").Value);
            if (root.Element("aboveFuncExponent") != null)
            {
                this.aboveFuncExponent = float.Parse(root.Element("aboveFuncExponent").Value);
            }
            if (root.Element("belowFuncExponent") != null)
            {
                this.belowFuncExponent = float.Parse(root.Element("belowFuncExponent").Value);
            }
            this.addTrees = bool.Parse(root.Element("addTrees").Value);
            this.treeSpacingMin = int.Parse(root.Element("treeSpacingMin").Value);
            this.treeSpacingMax = int.Parse(root.Element("treeSpacingMax").Value);
            this.treeHeightMin = int.Parse(root.Element("treeHeightMin").Value);
            this.treeHeightMax = int.Parse(root.Element("treeHeightMax").Value);
            if (root.Element("addCaves") != null)
            {
                this.addCaves = bool.Parse(root.Element("addCaves").Value);
                this.addCaveLava = bool.Parse(root.Element("addCaveLava").Value);
                this.addCaveWater = bool.Parse(root.Element("addCaveWater").Value);
                this.addOre = bool.Parse(root.Element("addOre").Value);
                this.caveDensity = float.Parse(root.Element("caveDensity").Value);
                this.caveSize = float.Parse(root.Element("caveSize").Value);
            }
            if (root.Element("addSnow") != null)
            {
                this.addSnow = bool.Parse(root.Element("addSnow").Value);
            }
            if (root.Element("snowAltitude") != null)
            {
                this.snowAltitude = int.Parse(root.Element("snowAltitude").Value);
            }
            if (root.Element("snowTransition") != null)
            {
                this.snowTransition = int.Parse(root.Element("snowTransition").Value);
            }
            if (root.Element("addCliffs") != null)
            {
                this.addCliffs = bool.Parse(root.Element("addCliffs").Value);
            }
            if (root.Element("cliffSmoothing") != null)
            {
                this.cliffSmoothing = bool.Parse(root.Element("cliffSmoothing").Value);
            }
            if (root.Element("cliffThreshold") != null)
            {
                this.cliffThreshold = float.Parse(root.Element("cliffThreshold").Value);
            }
            if (root.Element("addBeaches") != null)
            {
                this.addBeaches = bool.Parse(root.Element("addBeaches").Value);
            }
            if (root.Element("beachExtent") != null)
            {
                this.beachExtent = int.Parse(root.Element("beachExtent").Value);
            }
            if (root.Element("beachHeight") != null)
            {
                this.beachHeight = int.Parse(root.Element("beachHeight").Value);
            }
            if (root.Element("maxHeightVariation") != null)
            {
                this.maxHeightVariation = int.Parse(root.Element("maxHeightVariation").Value);
            }
            if (root.Element("maxDepthVariation") != null)
            {
                this.maxDepthVariation = int.Parse(root.Element("maxDepthVariation").Value);
            }
            this.Validate();
        }

        public void Save(string fileName)
        {
            XDocument document = new XDocument();
            XElement content = new XElement("MCDekMapGeneratorArgs");
            content.Add(new XAttribute("version", 2));
            content.Add(new XElement("theme", this.theme));
            content.Add(new XElement("seed", this.seed));
            content.Add(new XElement("dimX", this.dimX));
            content.Add(new XElement("dimY", this.dimY));
            content.Add(new XElement("dimH", this.dimH));
            content.Add(new XElement("maxHeight", this.maxHeight));
            content.Add(new XElement("maxDepth", this.maxDepth));
            content.Add(new XElement("addWater", this.addWater));
            content.Add(new XElement("customWaterLevel", this.customWaterLevel));
            content.Add(new XElement("matchWaterCoverage", this.matchWaterCoverage));
            content.Add(new XElement("waterLevel", this.waterLevel));
            content.Add(new XElement("waterCoverage", this.waterCoverage));
            content.Add(new XElement("useBias", this.useBias));
            content.Add(new XElement("delayBias", this.delayBias));
            content.Add(new XElement("raisedCorners", this.raisedCorners));
            content.Add(new XElement("loweredCorners", this.loweredCorners));
            content.Add(new XElement("midPoint", this.midPoint));
            content.Add(new XElement("bias", this.bias));
            content.Add(new XElement("detailScale", this.detailScale));
            content.Add(new XElement("featureScale", this.featureScale));
            content.Add(new XElement("roughness", this.roughness));
            content.Add(new XElement("layeredHeightmap", this.layeredHeightmap));
            content.Add(new XElement("marbledHeightmap", this.marbledHeightmap));
            content.Add(new XElement("invertHeightmap", this.invertHeightmap));
            content.Add(new XElement("aboveFuncExponent", this.aboveFuncExponent));
            content.Add(new XElement("belowFuncExponent", this.belowFuncExponent));
            content.Add(new XElement("addTrees", this.addTrees));
            content.Add(new XElement("treeSpacingMin", this.treeSpacingMin));
            content.Add(new XElement("treeSpacingMax", this.treeSpacingMax));
            content.Add(new XElement("treeHeightMin", this.treeHeightMin));
            content.Add(new XElement("treeHeightMax", this.treeHeightMax));
            content.Add(new XElement("addCaves", this.addCaves));
            content.Add(new XElement("addCaveLava", this.addCaveLava));
            content.Add(new XElement("addCaveWater", this.addCaveWater));
            content.Add(new XElement("addOre", this.addOre));
            content.Add(new XElement("caveDensity", this.caveDensity));
            content.Add(new XElement("caveSize", this.caveSize));
            content.Add(new XElement("addSnow", this.addSnow));
            content.Add(new XElement("snowAltitude", this.snowAltitude));
            content.Add(new XElement("snowTransition", this.snowTransition));
            content.Add(new XElement("addCliffs", this.addCliffs));
            content.Add(new XElement("cliffSmoothing", this.cliffSmoothing));
            content.Add(new XElement("cliffThreshold", this.cliffThreshold));
            content.Add(new XElement("addBeaches", this.addBeaches));
            content.Add(new XElement("beachExtent", this.beachExtent));
            content.Add(new XElement("beachHeight", this.beachHeight));
            content.Add(new XElement("maxHeightVariation", this.maxHeightVariation));
            content.Add(new XElement("maxDepthVariation", this.maxDepthVariation));
            document.Add(content);
            document.Save(fileName);
        }

        public void Validate()
        {
            if (((this.raisedCorners < 0) || (this.raisedCorners > 4)) || (((this.loweredCorners < 0) || (this.raisedCorners > 4)) || ((this.raisedCorners + this.loweredCorners) > 4)))
            {
                throw new ArgumentOutOfRangeException("raisedCorners and loweredCorners must be between 0 and 4.");
            }
            if ((this.caveDensity <= 0f) || (this.caveSize <= 0f))
            {
                throw new ArgumentOutOfRangeException("caveDensity and caveSize must be > 0");
            }
        }
    }
}
