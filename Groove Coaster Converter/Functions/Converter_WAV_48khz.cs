using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using Groove_Coaster_Converter.Programs;
using Groove_Coaster_Converter;

namespace Groove_Coaster_Converter.Functions
{
    class Converter_WAV_48khz
    {

        public void Main(string directoryPath = @".\temp\test", string destinationPath = @".\temp\conv", int mode = 0)
        {

            DirectoryInfo directorySelected = new DirectoryInfo(directoryPath);
            foreach (FileInfo file in directorySelected.GetFiles("*.wav"))
            {
                try
                {
                    using (Process myProcess = new Process())
                    {
                        Console.WriteLine($"{file.Name} Converting to WAV 48Khz ...");
                        myProcess.StartInfo.UseShellExecute = false;

                        myProcess.StartInfo.FileName = @"tools\sr-convert.exe";
                        myProcess.StartInfo.Arguments = $"\"{file.FullName}\" - \"{destinationPath}\\{file.Name}\" 48000";
                        myProcess.StartInfo.CreateNoWindow = true;
                        myProcess.Start();
                        myProcess.WaitForExit();

                        Program.songFile = Path.GetFileNameWithoutExtension(file.Name);
                        if(mode == 1)
                        {
                            File.Delete(file.FullName);
                        }
                        Console.WriteLine("conversion done.");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

        }

        public void SingleFileConversion(string directoryPath = @".\temp\test", string destinationPath = @".\temp\conv", int mode = 0)
        {
            FileInfo file = new FileInfo(directoryPath);
            Form_GCC form_GCC = Application.OpenForms["Form_GCC"] as Form_GCC;
            form_GCC.toolStrip_status3.Text = $"{file.Name} Converting to WAV 48Khz...";
            


            try
            {
                using (Process myProcess = new Process())
                {
                    Console.WriteLine($"{file.Name} Converting to WAV 48Khz ...");
                    
                    myProcess.StartInfo.UseShellExecute = false;

                    myProcess.StartInfo.FileName = @"tools\sr-convert.exe";
                    myProcess.StartInfo.Arguments = $"\"{file.FullName}\" - \"{destinationPath}\\{file.Name}\" 48000";
                    myProcess.StartInfo.CreateNoWindow = true;
                    myProcess.Start();
                    myProcess.WaitForExit();

                    Program.songFile = Path.GetFileNameWithoutExtension(file.Name);
                    if (mode == 1)
                    {
                        File.Delete(file.FullName);
                    }
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
