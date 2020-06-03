using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Windows.Forms;
using Groove_Coaster_Converter.Programs;

namespace Groove_Coaster_Converter.Functions
{
    class Converter_OGG_to_WAV
    {
        public void Main(string directoryPath = @".\temp\test", string destinationPath = @".\temp\conv")
        {

            DirectoryInfo directorySelected = new DirectoryInfo(directoryPath);
            foreach (FileInfo file in directorySelected.GetFiles("*.ogg"))
            {
                try
                {
                    using (Process myProcess = new Process())
                    {
                        Console.WriteLine($"{file.Name} Converting to WAV ...");
                        myProcess.StartInfo.UseShellExecute = false;

                        Program.songFile = Path.GetFileNameWithoutExtension(file.Name);
                        myProcess.StartInfo.FileName = @"tools\ffmpeg.exe";
                        myProcess.StartInfo.Arguments = $"-i \"{file.FullName}\" \"{destinationPath}\\{Program.songFile}.wav\"";
                        myProcess.StartInfo.CreateNoWindow = true;
                        myProcess.Start();
                        myProcess.WaitForExit();

                        
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
            form_GCC.toolStrip_status3.Text = $"{file.Name} Converting OGG to WAV...";
            try
            {
                using (Process myProcess = new Process())
                {
                    Console.WriteLine($"{file.Name} Converting to WAV ...");
                    myProcess.StartInfo.UseShellExecute = false;

                    Program.songFile = Path.GetFileNameWithoutExtension(file.Name);
                    myProcess.StartInfo.FileName = @"tools\ffmpeg.exe";
                    myProcess.StartInfo.Arguments = $"-i \"{file.FullName}\" \"{destinationPath}\\{Program.songFile}.wav\"";
                    myProcess.StartInfo.CreateNoWindow = false;
                    myProcess.Start();
                    myProcess.WaitForExit();


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
