using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Groove_Coaster_Converter.Class;
using Groove_Coaster_Converter.Functions;
using Groove_Coaster_Converter;
using System.Windows.Forms;


namespace Groove_Coaster_Converter.Programs
{
    class MOBILE_to_SWITCH
    {
        Form_GCC form_GCC = Application.OpenForms["Form_GCC"] as Form_GCC;

        public void Conversion(bool stageParam, bool convert, bool onlyDatabase = false)
        {
            Program.songDatas.Clear();
            Program.songFile = "";
            Program.typeSong = "";

            form_GCC.toolStripProgressBar_Status.Value = 0;
            if (stageParam && convert)
            {
                form_GCC.toolStrip_status2.Text = "Converting Stage files + updating StageParam | ";
            }
            else if (convert)
            {
                form_GCC.toolStrip_status2.Text = "Converting Stage files | ";
            }
            else if (stageParam)
            {
                form_GCC.toolStrip_status2.Text = "updating StageParam | ";
            }

            String stageParamFile = form_GCC.textBox_StageParamInput.Text;
            String songFile = form_GCC.textBox_FileBGM.Text;
            String shotFile = form_GCC.textBox_FileSHOT.Text;
            String songFolder = form_GCC.textBox_Data.Text;
            String destinationFolder = form_GCC.textBox_output.Text;

            if (!onlyDatabase)
            {
                if (songFile.Length > 0 && convert)
                {
                    
                    // Convert OGG to WAV
                    new Converter_OGG_to_WAV().SingleFileConversion(songFile, @"switch\temp\ogg");
                    form_GCC.toolStripProgressBar_Status.Value = 10;

                    // Merge BGM & SHOT WAV files
                    /*if (form_GCC.checkBox_SHOT.Checked)
                    {
                        songFile = (new Merging_WAV().SingleFileConversion(songFile, shotFile));
                    }*/

                    // Convert WAV file to 48khz
                    new Converter_WAV_48khz().Main(@"switch\temp\ogg", @"switch\temp", 1);
                    form_GCC.toolStripProgressBar_Status.Value = 25;

                    // Convert to OPUS
                    new Converter_WAV_to_OPUS().Main(@"switch\temp", destinationFolder + @"\stage\sound");
                    form_GCC.toolStripProgressBar_Status.Value = 50;
                }
            }




            if (songFolder.Length > 0 && convert)
            {
                if (!onlyDatabase)
                {
                    form_GCC.toolStrip_status3.Text = "Converting Song data files...";
                    // Compress to GZIP all the datas files
                    new Compressor_GZIP().Main(0, songFolder, destinationFolder + @"\stage\data_gz");

                    form_GCC.toolStripProgressBar_Status.Value = 75;

                }


                if (stageParam)
                {
                    form_GCC.toolStrip_status3.Text = "Updating StageParam...";

                    // Add the song to the playlist stage_param file
                    //new Generator_StageParam().Main(0, stageParamFile, form_GCC.comboBox_Genres.Text);
                    Song song_temp = new Song();
                    //songs = new List<Song>();
                    form_GCC.total_entries++;
                    song_temp.NewSong(2, form_GCC.total_entries);
                    form_GCC.ReloadSongList();

                    /*Reader_StageParam writer = new Reader_StageParam();
                        writer.writeBytes(form_GCC.textBox_StageParamInput.Text, 0, 1);*/
                }
            }



            form_GCC.toolStrip_status3.Text = "DONE";
            form_GCC.toolStripProgressBar_Status.Value = 100;

        }




        public void Conversion_Old(bool stageParam, bool convert)
        {

            form_GCC.toolStripProgressBar_Status.Value = 0;
            if (stageParam && convert)
            {
                form_GCC.toolStrip_status2.Text = "Converting Stage files + updating StageParam | ";
            }
            else if (convert)
            {
                form_GCC.toolStrip_status2.Text = "Converting Stage files | ";
            }
            else if (stageParam)
            {
                form_GCC.toolStrip_status2.Text = "updating StageParam | ";
            }

            String stageParamFile = form_GCC.textBox_StageParamInput.Text;
            String songFile = form_GCC.textBox_FileBGM.Text;
            String shotFile = form_GCC.textBox_FileSHOT.Text;
            String songFolder = form_GCC.textBox_Data.Text;
            String destinationFolder = form_GCC.textBox_output.Text;

            if (songFile.Length > 0 && convert)
            {
                // Convert OGG to WAV
                new Converter_OGG_to_WAV().SingleFileConversion(songFile, @"switch\temp\ogg");
                form_GCC.toolStripProgressBar_Status.Value = 10;

                // Convert WAV file to 48khz
                new Converter_WAV_48khz().Main(@"switch\temp\ogg", @"switch\temp", 1);
                form_GCC.toolStripProgressBar_Status.Value = 25;

                // Convert to OPUS
                new Converter_WAV_to_OPUS().Main(@"switch\temp", destinationFolder + @"\stage\sound");
                form_GCC.toolStripProgressBar_Status.Value = 50;
            }

            if (form_GCC.checkBox_SHOT.Checked && shotFile.Length > 0 && convert)
            {
                // Convert OGG to WAV
                new Converter_OGG_to_WAV().SingleFileConversion(songFile, @"switch\temp\ogg");
                form_GCC.toolStripProgressBar_Status.Value = 10;

                // Convert WAV file to 48khz
                new Converter_WAV_48khz().Main(@"switch\temp\ogg\", @"switch\temp", 1);
                form_GCC.toolStripProgressBar_Status.Value = 25;

                // Convert to OPUS
                new Converter_WAV_to_OPUS().Main(@"switch\temp", destinationFolder + @"\stage\sound");
                form_GCC.toolStripProgressBar_Status.Value = 50;
            }



            if (songFolder.Length > 0 && convert)
            {
                form_GCC.toolStrip_status3.Text = "Converting Song data files...";
                // Compress to GZIP all the datas files
                new Compressor_GZIP().Main(0, songFolder, destinationFolder + @"\stage\data_gz");
                form_GCC.toolStripProgressBar_Status.Value = 75;
                if (stageParam)
                {
                    form_GCC.toolStrip_status3.Text = "Updating StageParam...";
                    // Add the song to the playlist stage_param file
                    new Generator_StageParam().Main(0, stageParamFile, form_GCC.comboBox_Genres.Text);
                }
            }



            form_GCC.toolStrip_status3.Text = "DONE";
            form_GCC.toolStripProgressBar_Status.Value = 100;

        }

        public void Main()
        {

            bool again = true;
            while (again)
            {
                Program.songDatas.Clear();
                Program.songFile = "";
                Program.typeSong = "";

                Console.WriteLine("Mobile TO SWITCH");
                Console.WriteLine("---------------");
                // select folder
                Console.WriteLine("Enter the name of the song's folder:");
                string songName = Console.ReadLine();
                string songFolder = Program.songFolder + @"\mobile\" + songName;
                string destinationFolder = @"switch\atmosphere\contents\0100EB500D92E000\romfs";

                if (Directory.Exists(songFolder))
                {
                    Console.WriteLine("Song found !");

                    Console.WriteLine("Folder for your song (vocaloid, original, misc, pop, touhou, game):");
                    Program.typeSong = Console.ReadLine();

                    if (!Directory.Exists(destinationFolder+@"\stage"))
                    {
                        Directory.CreateDirectory(destinationFolder+@"\stage\data_gz");
                        Directory.CreateDirectory(destinationFolder+@"\stage\sound");
                    }

                    // Convert OGG to WAV
                    new Converter_OGG_to_WAV().Main(songFolder + "\\sound", @"switch\temp\ogg");

                    // Convert WAV file to 48khz
                    new Converter_WAV_48khz().Main(@"switch\temp\ogg", @"switch\temp", 1);

                    // Convert to OPUS
                    new Converter_WAV_to_OPUS().Main(@"switch\temp", destinationFolder + @"\stage\sound");

                    // Compress to GZIP all the datas files
                    new Compressor_GZIP().Main(0, songFolder, destinationFolder + @"\stage\data_gz", 1);

                    // Add the song to the playlist stage_param file
                    //new Generator_StageParam().Main(0, destinationFolder+@"\boot", 1);



                }
                else
                {
                    Console.WriteLine("No song found.");
                }
                
            }
        }

    }
}
