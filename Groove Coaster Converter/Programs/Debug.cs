using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Diagnostics;
using Groove_Coaster_Converter.Functions;

namespace Groove_Coaster_Converter.Programs
{
    class Debug
    {

        public void Main()
        {
            Program.debug = true;
            Console.WriteLine("DEBUG ENABLED!");
            /*if (Directory.Exists(Program.songFolder))
            {
                Console.WriteLine(File.ReadAllText(Program.songFolder+@"\steam\test.txt"));
            }*/

            //new Compressor_GZIP().Main(0);
            //convert48khz();

            //new Generator_StageParam().Main(0);
        }

        private void convert48khz()
        {
            DirectoryInfo directorySelected = new DirectoryInfo(@".\test");
            foreach (FileInfo file in directorySelected.GetFiles("*.wav"))
            {
                try
                {
                    using (Process myProcess = new Process())
                    {
                        Console.WriteLine("CONVERTING");
                        myProcess.StartInfo.UseShellExecute = false;
                        // You can start any process, HelloWorld is a do-nothing example.
                        myProcess.StartInfo.FileName = @".\sr-convert.exe";
                        myProcess.StartInfo.Arguments = $"\"{file.FullName}\" - \"testconv\\{file.Name}\" 48000";
                        myProcess.StartInfo.CreateNoWindow = true;
                        myProcess.Start();
                        myProcess.WaitForExit();
                        // This code assumes the process you are starting will terminate itself. 
                        // Given that is is started without a window so you cannot terminate it 
                        // on the desktop, it must terminate itself or you can do it programmatically
                        // from this application using the Kill method.
                        Console.WriteLine("DONE");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            
        }

    }
}
