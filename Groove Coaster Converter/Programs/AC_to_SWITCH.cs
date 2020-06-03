using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Windows.Forms;
using Groove_Coaster_Converter.Functions;
using Groove_Coaster_Converter;
using Groove_Coaster_Converter.Class;

namespace Groove_Coaster_Converter.Programs
    
{
    class AC_to_SWITCH
    {

        Form_GCC form_GCC = Application.OpenForms["Form_GCC"] as Form_GCC;

        public void Conversion(bool stageParam, bool convert, int platform = 0, bool onlyDatabase=false)
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
            bool merged = false;

            if (!onlyDatabase)
            {
                if (songFile.Length > 0 && convert)
                {
                    try
                    {
                        // Merge BGM & SHOT WAV files
                        if (form_GCC.checkBox_SHOT.Checked)
                        {
                            songFile = (new Merging_WAV().SingleFileConversion(songFile, shotFile));
                            merged = true;
                        }
                    }
                    catch (Exception)
                    {

                        MessageHandler.ShowError(4);
                    }
                    
                    // Convert WAV file to 48khz
                    new Converter_WAV_48khz().SingleFileConversion(songFile, @"switch\temp");
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
                    try
                    {
                        form_GCC.toolStrip_status3.Text = "Converting Song data files...";
                        // Compress to GZIP all the datas files
                        new Compressor_GZIP().Main(0, songFolder, destinationFolder + @"\stage\data_gz");

                        form_GCC.toolStripProgressBar_Status.Value = 75;
                    }
                    catch (Exception)
                    {
                        MessageHandler.ShowError(6);
                    }
                   

                }
                
                
                if (stageParam)
                {
                    try
                    {
                        form_GCC.toolStrip_status3.Text = "Updating StageParam...";

                        // Add the song to the playlist stage_param file
                        //new Generator_StageParam().Main(0, stageParamFile, form_GCC.comboBox_Genres.Text);
                        Song song_temp = new Song();
                        //songs = new List<Song>();
                        form_GCC.total_entries++;
                        song_temp.NewSong(form_GCC.comboBox_SystemStageParam.SelectedIndex, form_GCC.total_entries, merged);
                        form_GCC.ReloadSongList();

                        /*Reader_StageParam writer = new Reader_StageParam();
                            writer.writeBytes(form_GCC.textBox_StageParamInput.Text, 0, 1);*/
                    }
                    catch (Exception)
                    {

                        MessageHandler.ShowError(5);
                    }
                    
                }
            }

            

            form_GCC.toolStrip_status3.Text = "DONE";
            form_GCC.toolStripProgressBar_Status.Value = 100;

        }

        

    }
}
