﻿using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using MCLawl;


namespace MCDek
{

    /// <summary>
    /// Drawing/clipping mode of IsoCat map renderer.
    /// </summary>
    public enum IsoCatMode
    {
        Normal,
        Peeled,
        Cut,
        Chunk
    }

    /// <summary>
    /// Isometric map renderer, tightly integrated with BackgroundWorker.
    /// Creates a bitmap of the map. Every IsoCat instance is single-use.
    /// </summary>
    unsafe public sealed class IsoCat
    {
        static byte[] tiles, stiles;
        static int tileX, tileY;
        static int maxTileDim;
        static int tileStride;

        static IsoCat()
        {

            using (Bitmap tilesBmp = MCDek.Resources.Resources.Tileset)
            {
                tileX = tilesBmp.Width / 50;
                tileY = tilesBmp.Height;
                tileStride = tileX * tileY * 4;
                tiles = new byte[50 * tileStride];

                maxTileDim = Math.Max(tileX, tileY);

                for (int i = 0; i < 50; i++)
                {
                    for (int y = 0; y < tileY; y++)
                    {
                        for (int x = 0; x < tileX; x++)
                        {
                            int p = i * tileStride + (y * tileX + x) * 4;
                            System.Drawing.Color c = tilesBmp.GetPixel(x + i * tileX, y);
                            tiles[p] = c.B;
                            tiles[p + 1] = c.G;
                            tiles[p + 2] = c.R;
                            tiles[p + 3] = c.A;
                        }
                    }
                }
            }

            using (Bitmap stilesBmp = MCDek.Resources.Resources.TilesetShadowed)
            {

                stiles = new byte[50 * tileStride];

                for (int i = 0; i < 50; i++)
                {
                    for (int y = 0; y < tileY; y++)
                    {
                        for (int x = 0; x < tileX; x++)
                        {
                            int p = i * tileStride + (y * tileX + x) * 4;
                            System.Drawing.Color c = stilesBmp.GetPixel(x + i * tileX, y);
                            stiles[p] = c.B;
                            stiles[p + 1] = c.G;
                            stiles[p + 2] = c.R;
                            stiles[p + 3] = c.A;
                        }
                    }
                }
            }
        }


        byte* image;
        int imageWidth, imageHeight;
        int x, y, h;
        byte block;
        IsoCatMode mode;
        int[] chunkCoords = new int[6];
        Level map;
        Bitmap imageBmp;
        BitmapData imageData;

        int dimX, dimY, dimX1, dimY1, dimX2, dimY2;
        int offsetX, offsetY, rot;
        int isoOffset, isoX, isoY, isoH;

        int imageStride;

        public IsoCat(Level _map, IsoCatMode _mode, int _rot)
        {
            rot = _rot;
            mode = _mode;
            map = _map;

            dimX = map.width;
            dimY = map.depth;
            offsetY = Math.Max(0, map.width - map.depth);
            offsetX = Math.Max(0, map.depth - map.width);
            dimX2 = dimX / 2 - 1;
            dimY2 = dimY / 2 - 1;
            dimX1 = dimX - 1;
            dimY1 = dimY - 1;

            blendDivisor = 255 * map.height;

            imageWidth = tileX * Math.Max(dimX, dimY) + tileY / 2 * map.height + tileX * 2;
            imageHeight = tileY / 2 * map.height + maxTileDim / 2 * Math.Max(Math.Max(dimX, dimY), map.height) + tileY * 2;

            imageBmp = new Bitmap(imageWidth, imageHeight, PixelFormat.Format32bppArgb);
            imageData = imageBmp.LockBits(new Rectangle(0, 0, imageBmp.Width, imageBmp.Height),
                                           ImageLockMode.ReadWrite,
                                           PixelFormat.Format32bppArgb);

            image = (byte*)imageData.Scan0;
            imageStride = imageData.Stride;

            isoOffset = (map.height * tileY / 2 * imageStride + imageStride / 2 + tileX * 2);
            isoX = (tileX / 4 * imageStride + tileX * 2);
            isoY = (tileY / 4 * imageStride - tileY * 2);
            isoH = (-tileY / 2 * imageStride);

            mh34 = map.height * 3 / 4;
        }

        public void SetChunk(int x1, int y1, int z1, int x2, int y2, int z2)
        {
            chunkCoords[0] = x1;
            chunkCoords[1] = y1;
            chunkCoords[2] = z1;
            chunkCoords[3] = x2;
            chunkCoords[4] = y2;
            chunkCoords[5] = z2;
        }

        byte* bp, ctp;
        public unsafe Bitmap Draw(ref Rectangle cropRectangle, BackgroundWorker worker)
        {
            int blockRight, blockLeft, blockUp;
            try
            {
                fixed (byte* bpx = map.blocks)
                {
                    fixed (byte* tp = tiles)
                    {
                        fixed (byte* stp = stiles)
                        {
                            bp = bpx;
                            while (h < map.height)
                            {
                                block = GetBlock(x, y, h);
                                if (block != 0)
                                {

                                    switch (rot)
                                    {
                                        case 0: ctp = (h >= map.shadows[x, y] ? tp : stp); break;
                                        case 1: ctp = (h >= map.shadows[dimX1 - y, x] ? tp : stp); break;
                                        case 2: ctp = (h >= map.shadows[dimX1 - x, dimY1 - y] ? tp : stp); break;
                                        case 3: ctp = (h >= map.shadows[y, dimY1 - x] ? tp : stp); break;
                                    }

                                    if (x != (rot == 1 || rot == 3 ? dimY1 : dimX1)) blockRight = GetBlock(x + 1, y, h);
                                    else blockRight = 0;
                                    if (y != (rot == 1 || rot == 3 ? dimX1 : dimY1)) blockLeft = GetBlock(x, y + 1, h);
                                    else blockLeft = 0;
                                    if (h != map.height - 1) blockUp = GetBlock(x, y, h + 1);
                                    else blockUp = 0;

                                    if (blockUp == 0 || blockLeft == 0 || blockRight == 0 || // air
                                        blockUp == 8 || blockLeft == 8 || blockRight == 8 || // water
                                        blockUp == 9 || blockLeft == 9 || blockRight == 9 || // water
                                        (block != 20 && (blockUp == 20 || blockLeft == 20 || blockRight == 20)) || // glass
                                        blockUp == 18 || blockLeft == 18 || blockRight == 18 || // foliage
                                        blockLeft == 44 || blockRight == 44 || // step

                                        blockUp == 10 || blockLeft == 10 || blockRight == 10 || // lava
                                        blockUp == 11 || blockLeft == 11 || blockRight == 11 || // lava

                                        blockUp == 37 || blockLeft == 37 || blockRight == 37 || // flower
                                        blockUp == 38 || blockLeft == 38 || blockRight == 38 || // flower
                                        blockUp == 6 || blockLeft == 6 || blockRight == 6 || // tree
                                        blockUp == 39 || blockLeft == 39 || blockRight == 39 || // mushroom
                                        blockUp == 40 || blockLeft == 40 || blockRight == 40) // mushroom
                                        BlendTile();
                                }

                                x++;
                                if (x == (rot == 1 || rot == 3 ? dimY : dimX))
                                {
                                    y++;
                                    x = 0;
                                }
                                if (y == (rot == 1 || rot == 3 ? dimX : dimY))
                                {
                                    h++;
                                    y = 0;
                                    if (h % 4 == 0)
                                    {
                                        if (worker.CancellationPending) return null;
                                        worker.ReportProgress((h * 100) / map.height);
                                    }
                                }
                            }
                        }
                    }
                }

                int xMin = 0, xMax = imageWidth - 1, yMin = 0, yMax = imageHeight - 1;
                bool cont = true;
                int offset;

                // find left bound (xMin)
                for (int x = 0; cont && x < imageWidth; x++)
                {
                    offset = x * 4 + 3;
                    for (int y = 0; y < imageHeight; y++)
                    {
                        if (image[offset] > 0)
                        {
                            xMin = x;
                            cont = false;
                            break;
                        }
                        offset += imageStride;
                    }
                }

                if (worker.CancellationPending) return null;

                // find top bound (yMin)
                cont = true;
                for (int y = 0; cont && y < imageHeight; y++)
                {
                    offset = imageStride * y + xMin * 4 + 3;
                    for (int x = xMin; x < imageWidth; x++)
                    {
                        if (image[offset] > 0)
                        {
                            yMin = y;
                            cont = false;
                            break;
                        }
                        offset += 4;
                    }
                }

                if (worker.CancellationPending) return null;

                // find right bound (xMax)
                cont = true;
                for (int x = imageWidth - 1; cont && x >= xMin; x--)
                {
                    offset = x * 4 + 3 + yMin * imageStride;
                    for (int y = yMin; y < imageHeight; y++)
                    {
                        if (image[offset] > 0)
                        {
                            xMax = x + 1;
                            cont = false;
                            break;
                        }
                        offset += imageStride;
                    }
                }

                if (worker.CancellationPending) return null;

                // find bottom bound (yMax)
                cont = true;
                for (int y = imageHeight - 1; cont && y >= yMin; y--)
                {
                    offset = imageStride * y + 3 + xMin * 4;
                    for (int x = xMin; x < xMax; x++)
                    {
                        if (image[offset] > 0)
                        {
                            yMax = y + 1;
                            cont = false;
                            break;
                        }
                        offset += 4;
                    }
                }

                cropRectangle = new Rectangle(Math.Max(0, xMin - 2),
                                               Math.Max(0, yMin - 2),
                                               Math.Min(imageBmp.Width, xMax - xMin + 4),
                                               Math.Min(imageBmp.Height, yMax - yMin + 4));
                return imageBmp;
            }
            finally
            {
                imageBmp.UnlockBits(imageData);
                if (worker.CancellationPending && imageBmp != null)
                {
                    try
                    {
                        imageBmp.Dispose();
                    }
                    catch { }
                }
            }
        }


        unsafe void BlendTile()
        {
            int pos = (x + (rot == 1 || rot == 3 ? offsetY : offsetX)) * isoX + (y + (rot == 1 || rot == 3 ? offsetX : offsetY)) * isoY + h * isoH + isoOffset;
            if (block > 49) return;
            int tileOffset = block * tileStride;
            BlendPixel(pos, tileOffset);
            BlendPixel(pos + 4, tileOffset + 4);
            BlendPixel(pos + 8, tileOffset + 8);
            BlendPixel(pos + 12, tileOffset + 12);
            pos += imageStride;
            BlendPixel(pos, tileOffset + 16);
            BlendPixel(pos + 4, tileOffset + 20);
            BlendPixel(pos + 8, tileOffset + 24);
            BlendPixel(pos + 12, tileOffset + 28);
            pos += imageStride;
            BlendPixel(pos, tileOffset + 32);
            BlendPixel(pos + 4, tileOffset + 36);
            BlendPixel(pos + 8, tileOffset + 40);
            BlendPixel(pos + 12, tileOffset + 44);
            pos += imageStride;
            //BlendPixel( pos, tileOffset + 48 ); // bottom left block, always blank in current tileset
            BlendPixel(pos + 4, tileOffset + 52);
            BlendPixel(pos + 8, tileOffset + 56);
            //BlendPixel( pos + 12, tileOffset + 60 ); // bottom right block, always blank in current tileset
        }


        byte tA;
        int FA, SA, DA;
        int blendDivisor, mh34;
        // inspired by http://www.devmaster.net/wiki/Alpha_blending
        unsafe void BlendPixel(int imageOffset, int tileOffset)
        {
            if (ctp[tileOffset + 3] == 0) return;

            tA = ctp[tileOffset + 3];

            // Get final alpha channel.
            FA = tA + ((255 - tA) * image[imageOffset + 3]) / 255;

            // Get percentage (out of 256) of source alpha compared to final alpha
            if (FA == 0) SA = 0;
            else SA = tA * 255 / FA;

            // Destination percentage is just the additive inverse.
            DA = 255 - SA;

            if (h < (map.height >> 1))
            {
                int shadow = (h >> 1) + mh34;
                image[imageOffset] = (byte)((ctp[tileOffset] * SA * shadow + image[imageOffset] * DA * map.height) / blendDivisor);
                image[imageOffset + 1] = (byte)((ctp[tileOffset + 1] * SA * shadow + image[imageOffset + 1] * DA * map.height) / blendDivisor);
                image[imageOffset + 2] = (byte)((ctp[tileOffset + 2] * SA * shadow + image[imageOffset + 2] * DA * map.height) / blendDivisor);
            }
            else
            {
                int shadow = (h - (map.height >> 1)) * 64;
                image[imageOffset] = (byte)Math.Min(255, (ctp[tileOffset] * SA + shadow + image[imageOffset] * DA) / 255);
                image[imageOffset + 1] = (byte)Math.Min(255, (ctp[tileOffset + 1] * SA + shadow + image[imageOffset + 1] * DA) / 255);
                image[imageOffset + 2] = (byte)Math.Min(255, (ctp[tileOffset + 2] * SA + shadow + image[imageOffset + 2] * DA) / 255);
            }

            image[imageOffset + 3] = (byte)FA;
        }

        byte GetBlock(int xx, int yy, int hh)
        {
            int realx;
            int realy;
            switch (rot)
            {
                case 0:
                    realx = xx;
                    realy = yy;
                    break;
                case 1:
                    realx = dimX1 - yy;
                    realy = xx;
                    break;
                case 2:
                    realx = dimX1 - xx;
                    realy = dimY1 - yy;
                    break;
                default:
                    realx = yy;
                    realy = dimY1 - xx;
                    break;
            }
            int pos = (hh * dimY + realy) * dimX + realx;

            if (mode == IsoCatMode.Normal)
            {
                return bp[pos];
            }
            else if (mode == IsoCatMode.Peeled && (xx == (rot == 1 || rot == 3 ? dimY1 : dimX1) || yy == (rot == 1 || rot == 3 ? dimX1 : dimY1) || hh == map.height - 1))
            {
                return 0;
            }
            else if (mode == IsoCatMode.Cut && xx > (rot == 1 || rot == 3 ? dimY2 : dimX2) && yy > (rot == 1 || rot == 3 ? dimX2 : dimY2))
            {
                return 0;
            }
            else if (mode == IsoCatMode.Chunk && (realx < chunkCoords[0] || realy < chunkCoords[1] || hh < chunkCoords[2] || realx > chunkCoords[3] || realy > chunkCoords[4] || hh > chunkCoords[5]))
            {
                return 0;
            }

            return bp[pos];
        }
    }
}
