using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.IO.Compression;
using Groove_Coaster_Converter.Programs;
using Groove_Coaster_Converter.Class;

namespace Groove_Coaster_Converter.Functions
{
    class Compressor_GZIP
    {
        public static List<string> list;
        public static StringCheck stringCheck = new StringCheck();
        //private string directoryPath = @".\temp\arkanoid";
        public void Main(int method = 0, string directoryPath = @".\temp\test", string destinationPath = @".\temp\conv", int mode = 0)
        {
            
            DirectoryInfo directorySelected = new DirectoryInfo(directoryPath);
            switch (method)
            {
                case 1:
                    foreach (FileInfo fileToDecompress in directorySelected.GetFiles("*.gz"))
                    {
                        if (Args.songNameData.Length == 0 || (Args.songNameData.Length > 0 && fileToDecompress.Name.Contains("sw_" + Args.songNameData + "_")))
                        { 

                        }
                            Decompress(fileToDecompress, directoryPath, destinationPath);
                    }
                    break;
                default:
                    Compress(directorySelected, directoryPath, destinationPath, mode);
                    break;
            }
        }

        public static void Compress(DirectoryInfo directorySelected, string directoryPath, string destinationPath, int mode)
        {
            foreach (FileInfo fileToCompress in directorySelected.GetFiles())
            {
                try
                {
                    if (Args.songNameData.Length == 0 || (Args.songNameData.Length > 0 && fileToCompress.Name.Contains("ac_" + Args.songNameData + "_")))
                    {
                        using (FileStream originalFileStream = fileToCompress.OpenRead())
                        {
                            if ((File.GetAttributes(fileToCompress.FullName) &
                               FileAttributes.Hidden) != FileAttributes.Hidden & fileToCompress.Extension != ".gz")
                            {
                                using (FileStream compressedFileStream = File.Create(fileToCompress.FullName + ".gz"))
                                {
                                    using (GZipStream compressionStream = new GZipStream(compressedFileStream,
                                       CompressionMode.Compress))
                                    {
                                        originalFileStream.CopyTo(compressionStream);
                                    }
                                }
                                FileInfo info = new FileInfo(directoryPath + Path.DirectorySeparatorChar + fileToCompress.Name + ".gz");
                                string fileName = info.Name;
                                if (!fileToCompress.Name.Contains("_clip") && !fileToCompress.Name.Contains("_ext") && fileToCompress.Name.Contains("ac_"))
                                    Program.songDatas.Add(Path.GetFileNameWithoutExtension(fileToCompress.Name));

                                fileName = rename(fileName, "_easy", "_1");
                                fileName = rename(fileName, "_normal", "_1");
                                fileName = rename(fileName, "_hard", "_1");
                                fileName = rename(fileName, "_ex", "_1");

                                //STEAM_to_SWITCH.songDatas[STEAM_to_SWITCH.songDatas.Length] = Path.GetFileNameWithoutExtension(fileName);

                                //list.Add(Path.GetFileNameWithoutExtension(fileName));




                                string fileOut = destinationPath + @"\" + fileName;
                                if (!Directory.Exists(destinationPath))
                                {
                                    Directory.CreateDirectory(destinationPath);
                                }



                                if (!fileName.Contains("ac_") && mode == 1)
                                {
                                    fileOut = destinationPath + @"\ac_" + fileName;
                                }
                                else
                                {
                                    if (File.Exists(fileOut))
                                    {
                                        File.Delete(fileOut);
                                    }
                                    File.Move(info.ToString(), fileOut);
                                }


                                if (File.Exists(fileOut.Replace("_1", "_2")))
                                {
                                    File.Delete(fileOut.Replace("_1", "_2"));
                                }

                                if (!fileName.Contains("ac_") && mode == 1)
                                {
                                    File.Move(info.ToString(), fileOut.Replace("_1", "_2"));
                                }
                                else
                                {
                                    File.Copy(fileOut, fileOut.Replace("_1", "_2"));
                                }



                                Console.WriteLine($"Compressed {fileToCompress.Name}");
                                //Console.WriteLine($"Compressed {fileToCompress.Name} from {fileToCompress.Length.ToString()} to {info.Length.ToString()} bytes.");
                            }
                        }
                    }
                }
                catch (Exception)
                {

                    
                }
                
            }
            Console.WriteLine("Compression done.");
        }

        public static void Decompress(FileInfo fileToDecompress, string directoryPath, string destinationPath)
        {
            using (FileStream originalFileStream = fileToDecompress.OpenRead())
            {
                string currentFileName = fileToDecompress.FullName;
                string newFileName = currentFileName.Remove(currentFileName.Length - fileToDecompress.Extension.Length);

                using (FileStream decompressedFileStream = File.Create(newFileName))
                {
                    using (GZipStream decompressionStream = new GZipStream(originalFileStream, CompressionMode.Decompress))
                    {
                        decompressionStream.CopyTo(decompressedFileStream);
                        Console.WriteLine($"Decompressed: {fileToDecompress.Name}");
                    }
                }
            }
        }


        private static string rename(string text, string check, string place)
        {
            if (text.Contains(check+".") || text.Contains(check + "_"))
            {
                int endtest = stringCheck.EndIndexOf(text, check);
                text = text.Insert(endtest, place);
            }
            return text;
        }


    }
}
