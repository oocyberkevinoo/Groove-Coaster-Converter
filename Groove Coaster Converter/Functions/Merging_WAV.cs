using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using Groove_Coaster_Converter.Programs;
using Groove_Coaster_Converter;
using Groove_Coaster_Converter.Class;

namespace Groove_Coaster_Converter.Functions
{
    class Merging_WAV
    {

        public String SingleFileConversion(string directoryPath = @".\temp\test", string directoryPath2 = @".\temp\test", int mode = 0)
        {
            FileInfo file = new FileInfo(directoryPath);
            FileInfo file2 = new FileInfo(directoryPath2);
            String file_out = file.DirectoryName + "\\m_" + file.Name;
            Form_GCC form_GCC = Application.OpenForms["Form_GCC"] as Form_GCC;
            form_GCC.toolStrip_status3.Text = $"{file.Name} and {file2.Name} Merging...";

            try
            {
                if (File.Exists(file_out))
                {
                    File.Delete(file_out);
                }
                using (Process myProcess = new Process())
                {

                    myProcess.StartInfo.UseShellExecute = false;

                    Program.songFile = Path.GetFileNameWithoutExtension(file.Name);
                    myProcess.StartInfo.FileName = @"tools\ffmpeg.exe";
                    myProcess.StartInfo.Arguments = $"-i \"{file.FullName}\" -i \"{file2.FullName}\" -filter_complex \"[0:a][1:a]amerge=inputs=2,pan=stereo|c0=c0+c2|c1=c1+c3[a]\" -map \"[a]\" \"{file_out}\"";
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
                MessageHandler.ShowError(4);
                Console.WriteLine(e.Message);
            }

            return file_out;
        }
    }
}
