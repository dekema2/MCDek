// 

using System;
using System.IO;
using System.IO.Compression;
using System.Net;
using MCDek;


namespace MCLawl
{
    public static class ConvertDat
    {
        public static Level Load(Stream lvlStream, string fileName)
        {
            byte[] temp = new byte[8];
            Level lvl = new Level(fileName, 0, 0, 0, "empty");
            byte[] data;
            int length;
            try
            {
                lvlStream.Seek(-4, SeekOrigin.End);
                lvlStream.Read(temp, 0, sizeof(int));
                lvlStream.Seek(0, SeekOrigin.Begin);
                length = BitConverter.ToInt32(temp, 0);
                data = new byte[length];
                using (GZipStream reader = new GZipStream(lvlStream, CompressionMode.Decompress, true))
                {
                    reader.Read(data, 0, length);
                }

                for (int i = 0; i < length - 1; i++)
                {
                    if (data[i] == 0xAC && data[i + 1] == 0xED)
                    {

                        // bypassing the header crap
                        int pointer = i + 6;
                        Array.Copy(data, pointer, temp, 0, sizeof(short));
                        pointer += IPAddress.HostToNetworkOrder(BitConverter.ToInt16(temp, 0));
                        pointer += 13;

                        int headerEnd = 0;
                        // find the end of serialization listing
                        for (headerEnd = pointer; headerEnd < data.Length - 1; headerEnd++)
                        {
                            if (data[headerEnd] == 0x78 && data[headerEnd + 1] == 0x70)
                            {
                                headerEnd += 2;
                                break;
                            }
                        }

                        // start parsing serialization listing
                        int offset = 0;
                        while (pointer < headerEnd)
                        {
                            if (data[pointer] == 'Z') offset++;
                            else if (data[pointer] == 'I' || data[pointer] == 'F') offset += 4;
                            else if (data[pointer] == 'J') offset += 8;

                            pointer += 1;
                            Array.Copy(data, pointer, temp, 0, sizeof(short));
                            short skip = IPAddress.HostToNetworkOrder(BitConverter.ToInt16(temp, 0));
                            pointer += 2;

                            // look for relevant variables
                            Array.Copy(data, headerEnd + offset - 4, temp, 0, sizeof(int));
                            if (MemCmp(data, pointer, "width"))
                            {
                                lvl.width = (ushort)IPAddress.HostToNetworkOrder(BitConverter.ToInt32(temp, 0));
                            }
                            else if (MemCmp(data, pointer, "depth"))
                            {
                                lvl.depth = (ushort)IPAddress.HostToNetworkOrder(BitConverter.ToInt32(temp, 0));
                            }
                            else if (MemCmp(data, pointer, "height"))
                            {
                                lvl.height = (ushort)IPAddress.HostToNetworkOrder(BitConverter.ToInt32(temp, 0));
                            }

                            pointer += skip;
                        }

                        lvl.spawnx = (ushort)(lvl.width / 1.3);
                        lvl.spawny = (ushort)(lvl.depth / 1.3);
                        lvl.spawnz = (ushort)(lvl.height / 1.3);

                        // find the start of the block array
                        bool foundBlockArray = false;
                        offset = Array.IndexOf<byte>(data, 0x00, headerEnd);
                        while (offset != -1 && offset < data.Length - 2)
                        {
                            if (data[offset] == 0x00 && data[offset + 1] == 0x78 && data[offset + 2] == 0x70)
                            {
                                foundBlockArray = true;
                                pointer = offset + 7;
                            }
                            offset = Array.IndexOf<byte>(data, 0x00, offset + 1);
                        }

                        // copy the block array... or fail
                        if (foundBlockArray)
                        {
                            lvl.CopyBlocks(data, pointer);
                            lvl.Save(true);
                        }
                        else
                        {
                            throw new Exception("Could not locate block array.");
                        }
                        break;
                    }
                }

            }
            catch (Exception ex)
            {
                Server.s.Log("Conversion failed");
                Server.ErrorLog(ex);
                return null;
            }

            return lvl;
        }

        static bool MemCmp(byte[] data, int offset, string value)
        {
            for (int i = 0; i < value.Length; i++)
            {
                if (offset + i >= data.Length || data[offset + i] != value[i]) return false;
            }
            return true;
        }
    }
}