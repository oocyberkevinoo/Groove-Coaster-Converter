using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Windows.Forms;
using Groove_Coaster_Converter;

namespace Groove_Coaster_Converter.Functions
{
    class Converter_WAV_to_OPUS
    {
        public void Main(string directoryPath = @".\temp\test", string destinationPath = @".\temp\conv")
        {

            DirectoryInfo directorySelected = new DirectoryInfo(directoryPath);
            Form_GCC form_GCC = Application.OpenForms["Form_GCC"] as Form_GCC;
            
            foreach (FileInfo file in directorySelected.GetFiles("*.wav"))
            {
                form_GCC.toolStrip_status3.Text = $"{file.Name} Converting to OPUS SWITCH...";
                try
                {
                    using (Process myProcess = new Process())
                    {
                        Console.WriteLine($"{file.Name} Converting to OPUS SWITCH ...");
                        myProcess.StartInfo.UseShellExecute = false;

                        myProcess.StartInfo.FileName = @"tools\VGAudioCli.exe";
                        myProcess.StartInfo.Arguments = $"--bitrate 128000 --cbr \"{file.FullName}\" \"{destinationPath}\\{Path.GetFileNameWithoutExtension(file.Name)}.lopus\"";
                        //myProcess.StartInfo.Arguments = $"\"{file.FullName}\" - \"{destinationPath}\\{file.Name}\" 48000";
                        myProcess.StartInfo.CreateNoWindow = true;
                        myProcess.Start();
                        myProcess.WaitForExit();
                        string fileOut = destinationPath + "\\" + Path.GetFileNameWithoutExtension(file.Name).ToLower() + ".wav.opus";
                        if (File.Exists(fileOut))
                        {
                            File.Delete(fileOut);
                        }
                        File.Move(destinationPath+"\\"+Path.GetFileNameWithoutExtension(file.Name)+".lopus", fileOut);
                        File.Delete(file.FullName);

                        Console.WriteLine("conversion done.");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

        }

        public void SingleFileConversion(string directoryPath = @".\temp\test", string destinationPath = @".\temp\conv")
        {
            FileInfo file = new FileInfo(directoryPath);
            Form_GCC form_GCC = Application.OpenForms["Form_GCC"] as Form_GCC;
            form_GCC.toolStrip_status3.Text = $"{file.Name} Converting to OPUS SWITCH...";

            try
                {
                    using (Process myProcess = new Process())
                    {
                        Console.WriteLine($"{file.Name} Converting to OPUS SWITCH ...");

                        myProcess.StartInfo.UseShellExecute = false;

                        myProcess.StartInfo.FileName = @"tools\VGAudioCli.exe";
                        myProcess.StartInfo.Arguments = $"--bitrate 128000 --cbr \"{file.FullName}\" \"{destinationPath}\\{Path.GetFileNameWithoutExtension(file.Name)}.lopus\"";
                        //myProcess.StartInfo.Arguments = $"\"{file.FullName}\" - \"{destinationPath}\\{file.Name}\" 48000";
                        myProcess.StartInfo.CreateNoWindow = true;
                        myProcess.Start();
                        myProcess.WaitForExit();
                        string fileOut = destinationPath + "\\" + Path.GetFileNameWithoutExtension(file.Name).ToLower() + ".wav.opus";
                        if (File.Exists(fileOut))
                        {
                            File.Delete(fileOut);
                        }
                        File.Move(destinationPath + "\\" + Path.GetFileNameWithoutExtension(file.Name) + ".lopus", fileOut);
                        File.Delete(file.FullName);

                        Console.WriteLine("conversion done.");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            

        }

    }
}
