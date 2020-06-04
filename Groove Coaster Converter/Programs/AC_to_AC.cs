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
    class AC_to_AC
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
                    // Just copy the audio file, same format.
                    FileInfo songFileInfo = new FileInfo(songFile);
                    String destFolder = destinationFolder + @"\stage\sound\";
                    String destFile = destFolder + songFileInfo.Name;
                    if (!Directory.Exists(destFolder))
                    {
                        Directory.CreateDirectory(destFolder);
                    }
                    if (File.Exists(destFile))
                    {
                        File.Delete(destFile);
                    }
                    File.Copy(songFile, destFile);
                    // SHOT
                    String fileSHOT = AppDomain.CurrentDomain.BaseDirectory + @"\tools\ACSHOT.wav";
                    destFolder = destinationFolder + @"\stage\sound\";
                    destFile = destFile.Remove(destFile.Length - 7, 7) + "SHOT.wav";
                    if (!Directory.Exists(destFolder))
                    {
                        Directory.CreateDirectory(destFolder);
                    }
                    if (File.Exists(destFile))
                    {
                        File.Delete(destFile);
                    }
                    


                    File.Copy(fileSHOT, destFile);
                    form_GCC.toolStripProgressBar_Status.Value = 50;
                }
            }
            

                

            if (songFolder.Length > 0 && convert)
            {
                
                if (!onlyDatabase)
                {
                    try
                    {
                        // Just copy the gameplay data file, same format.
                        FileInfo songFileInfo = new FileInfo(songFile);
                        DirectoryInfo d = new DirectoryInfo(songFolder);
                        String gameplaydataFolder = destinationFolder + @"\stage\data_gz\";
                        if (!Directory.Exists(gameplaydataFolder))
                        {
                            Directory.CreateDirectory(gameplaydataFolder);
                        }

                        foreach (var file in d.GetFiles("*.dat"))
                        {
                            if(Args.songNameData.Length == 0 || (Args.songNameData.Length > 0 && file.Name.Contains("ac_"+Args.songNameData+"_") ))
                            {
                                if (!file.Name.Contains("_clip") && !file.Name.Contains("_ext") && file.Name.Contains("ac_"))
                                    Program.songDatas.Add(Path.GetFileNameWithoutExtension(file.Name));

                                if (File.Exists(gameplaydataFolder + file.Name))
                                {
                                    File.Delete(gameplaydataFolder + file.Name);
                                }
                                File.Copy(file.FullName, gameplaydataFolder + file.Name);
                            }
                        }

                        

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
