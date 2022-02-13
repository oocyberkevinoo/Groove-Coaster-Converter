using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Groove_Coaster_Converter.Programs;
using Groove_Coaster_Converter.Class;
using Microsoft.WindowsAPICodePack.Dialogs;
using Groove_Coaster_Converter.Functions;

namespace Groove_Coaster_Converter
{
    public partial class Form_GCC : Form
    {
        public bool dlcConvert = false;
        public bool all = false;
        public bool dark = false;
        private Form_About form_about = new Form_About();
        public ushort total_entries;
        private List<Song> songs = new List<Song>();
        private int song_id;
        public String result;
        public List<String> liste = new List<String>();
        public List<uint> liste_id = new List<uint>();
        public String[] genres = new string[] {"Unknown",
            "Anime/Pop", "VOCALOID", "Music Games",
            "Game Music", "Misc.", "Original", "Touhou"  };
        List<TextBox> liste_TextBox_SHOT = new List<TextBox>();
        List<Button> liste_Button_SHOT = new List<Button>();
        public Form_GCC()
        {
            InitializeComponent();
            liste_TextBox_SHOT.Add(textBox_FileSHOT);
            liste_Button_SHOT.Add(button_FileSHOT);
            comboBox_Genres.Items.AddRange(genres);
            comboBox_songGenre.Items.AddRange(genres);
            
            EnableDisable_UI_SHOT(false);
            tabControl_Main.TabPages.Remove(tab_StageParamConverter);
        }

        private void Form_GCC_Load(object sender, EventArgs e)
        {
            

            //listBox_StageParam.DataSource = liste;
            comboBox_Mode.SelectedIndex = 0;
            comboBox_Genres.SelectedIndex = 0;
            comboBox_SystemStageParam.SelectedIndex = 0;
            textBox_StageParamBytes.Text = result;

            
        }


        private void buttonStageParam_Click(object sender, EventArgs e)
        {
        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }
        private void listBox_StageParam_Click(object sender, EventArgs e)
        {

            try
            {
                //SelectSong();
            }
            catch (Exception)
            {


            }

        }
        private String ReadGenre(int genre)
        {

            if (genre > 0 && genre < 8)
            {
                return genres[genre];
            }
            else
            {
                return genres[0];
            }
        }


        private void listBox_StageParam_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                SelectSong();
            }
            catch (Exception)
            {

            }

            //toolStrip_status.Text = listBox_StageParam.SelectedItem.ToString();

        }
        private void listBox_StageParam_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                //SelectSong();
            }
            catch (Exception)
            {


            }
        }

        private void listBox_StageParam_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                //SelectSong();
            }
            catch (Exception)
            {


            }

        }

        private void SelectSong()
        {
            song_id = listBox_StageParam.SelectedIndex;
            String name = songs[song_id].names[0];
            numericUpDown_songID.Value = songs[song_id].id;
            textBox_songName1.Text = name;
            textBox_songName2.Text = songs[song_id].names[1];
            textBox_songName3.Text = songs[song_id].names[2];
            textBox_songName4.Text = songs[song_id].names[3];
            textBox_songName5.Text = songs[song_id].names[4];
            textBox_songBGM.Text = songs[song_id].BGM;
            textBox_songBGM_ext1.Text = songs[song_id].BGM_ext[0];
            textBox_songBGM_ext2.Text = songs[song_id].BGM_ext[1];
            textBox_songBGM_ext3.Text = songs[song_id].BGM_ext[2];
            textBox_songBGM_ext4.Text = songs[song_id].BGM_ext[3];
            textBox_songBGM_ext5.Text = songs[song_id].BGM_ext[4];
            textBox_songBGM_ext6.Text = songs[song_id].BGM_ext[5];
            textBox_songBGM_ext7.Text = songs[song_id].BGM_ext[6];
            textBox_songBGM_ext8.Text = songs[song_id].BGM_ext[7];
            textBox_songBPM.Text = songs[song_id].BPM;
            textBox_songTimer.Text = songs[song_id].timer;
            textBox_songVer.Text = songs[song_id].ver;
            comboBox_songGenre.SelectedIndex = songs[song_id].genre;
            numericUpDown_songDifficulty1.Value = songs[song_id].difficulties[0];
            numericUpDown_songDifficulty2.Value = songs[song_id].difficulties[1];
            numericUpDown_songDifficulty3.Value = songs[song_id].difficulties[2];
            numericUpDown_songDifficulty4.Value = songs[song_id].difficulties[3];
            try
            {
                numericUpDown_songDifficulty5.Value = songs[song_id].difficulties[4];
                numericUpDown_songDifficulty6.Value = songs[song_id].difficulties[5];
                numericUpDown_songDifficulty7.Value = songs[song_id].difficulties[6];
            }
            catch (Exception)
            {


            }
            textBox_songDifficulty1.Text = songs[song_id].gameData[0];
            textBox_songDifficulty2.Text = songs[song_id].gameData[1];
            textBox_songDifficulty3.Text = songs[song_id].gameData[2];
            textBox_songDifficulty4.Text = songs[song_id].gameData[3];
            textBox_songData.Text = songs[song_id].data;
            textBox_songExt1.Text = songs[song_id].extras[0];
            textBox_songExt2.Text = songs[song_id].extras[1];
            textBox_songExt3.Text = songs[song_id].extras[2];
            textBox_songExt4.Text = songs[song_id].extras[3];
            textBox_songExt5.Text = songs[song_id].extras[4];

            if(songs[song_id].platform == 2)
            {
                if (songs[song_id].additional_data[0] == 0x01)
                {
                    checkBox_unlocked.Checked = true;
                }
                else
                {
                    checkBox_unlocked.Checked = false;
                }
                if (songs[song_id].additional_data[1] == 0x01)
                {
                    checkBox_beginner.Checked = true;
                }
                else
                {
                    checkBox_beginner.Checked = false;
                }

                if (songs[song_id].dlc)
                    checkBox_DLC_Switch.Checked = true;
                else
                    checkBox_DLC_Switch.Checked = false;
            }
            else
            {
                if (songs[song_id].additional_data[4] == 0x01)
                {
                    checkBox_unlocked.Checked = true;
                }
                else
                {
                    checkBox_unlocked.Checked = false;
                }
                if (songs[song_id].additional_data[5] == 0x01)
                {
                    checkBox_beginner.Checked = true;
                }
                else
                {
                    checkBox_beginner.Checked = false;
                }
            }


            result += "Song N°" + song_id + ", " + songs[song_id].names[0] + " has been selected.\r\n";
            textBox_StageParamBytes.Text = result;
        }

        private void label_ID_Click(object sender, EventArgs e)
        {

        }

        private void textBox_ID_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox_Genres_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void checkBox_SHOT_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_SHOT.Checked)
            {
                EnableDisable_UI_SHOT(true);
            }
            else
            {
                EnableDisable_UI_SHOT(false);
            }
        }


        private void EnableDisable_UI_SHOT(bool mode)
        {
            if (mode)
            {
                foreach (var component in liste_TextBox_SHOT)
                {
                    component.Enabled = true;
                }
                foreach (var component in liste_Button_SHOT)
                {
                    component.Enabled = true;
                }

            }
            else
            {
                foreach (var component in liste_TextBox_SHOT)
                {
                    component.Enabled = false;
                }
                foreach (var component in liste_Button_SHOT)
                {
                    component.Enabled = false;
                }
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void checkBox_DarkUI_CheckedChanged(object sender, EventArgs e)
        {
            
            Program.darkUI = checkBox_DarkUI.Checked;
            DarkUI.Dark(this);
        }
        

        public bool StageParamLoaded()
        {
            if (!File.Exists(textBox_StageParamInput.Text))
            {
                MessageHandler.ShowError(0);
                return false;
            }
            else
                return true;
        }


        public void button_ConvertUpdate_Click(object sender, EventArgs e)
        {
            
            bool mode = true;
            bool functionStart = false;
            if (StageParamLoaded())
            {
                if (OutputCheck())
                {
                    if (sender == button_ConvertUpdate || sender == button_ConvertALL)
                    {
                        mode = true;
                        if(sender == button_ConvertALL)
                        {
                            all = true;
                        }
                    }
                    else if (sender == button_Convert)
                    {
                        mode = false;
                    }

                    if (all)
                    {

                    }




                    if (comboBox_Mode.SelectedIndex == 0)
                    {
                        
                        if (Directory.Exists(textBox_Data.Text) ||
                            File.Exists(textBox_FileBGM.Text) ||
                            File.Exists(textBox_FileSHOT.Text))
                        {

                            if (comboBox_SystemStageParam.SelectedIndex == 2)
                            {
                                functionStart = true;
                                AC_to_SWITCH converter = new AC_to_SWITCH();
                                converter.Conversion(mode, true, comboBox_SystemStageParam.SelectedIndex);

                            }
                            else if (comboBox_SystemStageParam.SelectedIndex == 0 ||
                                comboBox_SystemStageParam.SelectedIndex == 1)
                            {
                                functionStart = true;
                                AC_to_AC converter = new AC_to_AC();
                                converter.Conversion(mode, true, comboBox_SystemStageParam.SelectedIndex);

                            }
                            else if (!functionStart)
                            {
                                MessageHandler.ShowWarning(7);
                            }


                        }
                        else
                        {
                            MessageHandler.ShowError(1);
                            functionStart = true;
                        }


                    }
                    if (comboBox_Mode.SelectedIndex == 1 && comboBox_SystemStageParam.SelectedIndex == 2)
                    {
                        
                        if (Directory.Exists(textBox_Data.Text) ||
                            File.Exists(textBox_FileBGM.Text) ||
                            File.Exists(textBox_FileSHOT.Text))
                        {
                            functionStart = true;
                            MOBILE_to_SWITCH converter = new MOBILE_to_SWITCH();
                            if (sender.Equals(button_onlyStageParam))
                            {
                                converter.Conversion(mode, true, true);
                            }
                            else
                            {
                                converter.Conversion(mode, true);
                            }

                        }
                        else
                        {
                            MessageHandler.ShowError(1);
                            functionStart = true;
                        }


                    }
                    else if (!functionStart)
                    {
                        MessageHandler.ShowWarning(7);
                    }

                    
                }
            }


            if (Args.convert)
            {
                Application.Exit();
            }

        }

        private void button_Convert_Click(object sender, EventArgs e)
        {
            if (StageParamLoaded())
                if (OutputCheck())



            if (Directory.Exists(textBox_Data.Text) ||
                File.Exists(textBox_FileBGM.Text) ||
                File.Exists(textBox_FileSHOT.Text))
            {
                    if (comboBox_Mode.SelectedIndex == 0)
                    {
                            if (comboBox_SystemStageParam.SelectedIndex == 2)
                            {
                                AC_to_SWITCH converter = new AC_to_SWITCH();
                                converter.Conversion(false, true);
                            }
                            else
                            {
                                AC_to_AC converter = new AC_to_AC();
                                converter.Conversion(false, true);
                            }
                            
                    }else if(comboBox_Mode.SelectedIndex == 1)
                    {
                        MOBILE_to_SWITCH mobiletoswitch = new MOBILE_to_SWITCH();
                        mobiletoswitch.Conversion(false, true);
                    }
            }
            else
            {
                    MessageHandler.ShowError(1);
            }

        }
        private void button_songDelete_Click(object sender, EventArgs e)
        {
            if (StageParamLoaded())
            {
                Reader_StageParam reader = new Reader_StageParam();
                int unique_id = songs[song_id].unique_id;
                bool valid = true;
                valid = reader.EraseBytes(textBox_StageParamInput.Text, songs[song_id].rangeOffsets[0], songs[song_id].rangeOffsets[1]);

                if (valid)
                {
                    if (StageParamLoaded())
                    {

                        songs = reader.readBytes(textBox_StageParamInput.Text, comboBox_SystemStageParam.SelectedIndex);
                        SelectSong();
                    }
                }
            }
            
        }

        private void button_Update_Click(object sender = null, EventArgs e = null)
        {
            if (StageParamLoaded())
            {
                int unique_id = songs[song_id].unique_id;
                bool valid = true;
                foreach (Song song in songs)
                {

                    if (valid && song.id == (uint)numericUpDown_songID.Value && unique_id != song.unique_id)
                    {
                        MessageHandler.ShowError(2);
                        valid = false;
                    }
                }

                if (valid)
                {
                    if (songs[song_id].UpdateSong())
                    {

                        liste[listBox_StageParam.SelectedIndex] = songs[song_id].names[0];
                        listBox_StageParam.DataSource = null;
                        listBox_StageParam.DataSource = liste;
                    }
                    ReloadSongList();
                }
            }
            
        }

        public void ReloadSongList()
        {
            if (StageParamLoaded())
            {

                Reader_StageParam reader = new Reader_StageParam();
                songs = reader.readBytes(textBox_StageParamInput.Text, comboBox_SystemStageParam.SelectedIndex);
                tabControl_Main.Enabled = true;
            }
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private string FileSelect(string fileName, string filter, string dir, bool mode, string result)
        {

            if (!mode)
            {
                openFileDialog1.FileName = fileName;
                openFileDialog1.Filter = filter;
                openFileDialog1.InitialDirectory = dir;
                openFileDialog1.RestoreDirectory = true;

                if(openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    if (File.Exists(openFileDialog1.FileName))
                    {
                        result = openFileDialog1.FileName;
                    }
                }
               
                
            }
            else
            {
                CommonOpenFileDialog dialog = new CommonOpenFileDialog();
                dialog.InitialDirectory = dir;
                dialog.IsFolderPicker = true;
                
                if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
                {
                    if (Directory.Exists(dialog.FileName))
                    {
                        result = dialog.FileName;
                    }
                }
                
                
            }
            
   
            
            return result;
        }

        private void button_StageParamInput_Click(object sender, EventArgs e)
        {
            String dir = Application.StartupPath;
            if (File.Exists(textBox_StageParamInput.Text))
            {
                dir = textBox_StageParamInput.Text;
            }
            textBox_StageParamInput.Text = FileSelect("Stage_Param",
                "Stage_Param File|stage_param.dat|" +
                "Dat File(*.dat)|*.dat|" +
                "All files (*.*)|*.*",
                dir, false, textBox_StageParamInput.Text);
        }

        private void button_FileBGM_Click(object sender, EventArgs e)
        {
            textBox_FileBGM.Text = FileSelect("Audio File",
                "Audio file (wav, OGG)|*.wav;*.ogg|All files (*.*)|*.*", 
                Application.StartupPath, false, textBox_FileBGM.Text);
            

        }
        private void button_FileSHOT_Click(object sender, EventArgs e)
        {
            textBox_FileSHOT.Text = FileSelect("Audio File",
               "Audio file (wav, OGG)|*.wav;*.ogg|All files (*.*)|*.*",
               Application.StartupPath, false, textBox_FileSHOT.Text);

        }

        private void button_FileOutput_Click(object sender, EventArgs e)
        {
            textBox_output.Text = FileSelect("",
                "",
                Application.StartupPath, true, textBox_output.Text);
            // folderBrowserDialog1.ShowDialog();
            // textBox_output.Text = folderBrowserDialog1.SelectedPath;
        }

        private void button_Data_Click(object sender, EventArgs e)
        {
            textBox_Data.Text = FileSelect("",
                "",
                Application.StartupPath, true, textBox_Data.Text);
        }

        private void comboBox_Mode_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox_ALL_Destination.SelectedIndex = comboBox_Mode.SelectedIndex;
            toolStrip_status.Text = comboBox_Mode.Text;
        }

        private bool OutputCheck()
        {
            bool result = false;
            if (textBox_output.TextLength <= 0)
            {
                MessageHandler.ShowError(3);

            }
            else if(!Directory.Exists(textBox_output.Text)){
                Directory.CreateDirectory(textBox_output.Text);
            }
            else
            {
                result = true;
            }

            return result;
        }
       

        public void button_LoadStageParam_Click(object sender, EventArgs e)
        {
            if (StageParamLoaded())
            {

                Reader_StageParam reader = new Reader_StageParam();
                songs = reader.readBytes(textBox_StageParamInput.Text, comboBox_SystemStageParam.SelectedIndex);
                tabControl_Main.Enabled = true;
            }
        }

        private void tab_SongEditor_Click(object sender, EventArgs e)
        {

        }

        private void comboBox_SystemStageParam_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox_SystemStageParam.SelectedIndex == 0 || comboBox_SystemStageParam.SelectedIndex == 1)
            {
                numericUpDown_songDifficulty5.Enabled = false;
                numericUpDown_songDifficulty6.Enabled = false;
                numericUpDown_songDifficulty7.Enabled = false;

                textBox_songVer.Enabled = false;
                textBox_songExt1.Enabled = false;
                textBox_songExt2.Enabled = false;
                textBox_songExt3.Enabled = false;
                textBox_songExt4.Enabled = false;
                textBox_songExt5.Enabled = false;

                textBox_songBGM_ext2.Enabled = true;
                textBox_songBGM_ext3.Enabled = true;
                textBox_songBGM_ext4.Enabled = true;
                textBox_songBGM_ext5.Enabled = true;
                textBox_songBGM_ext6.Enabled = true;
                textBox_songBGM_ext7.Enabled = true;
                textBox_songBGM_ext8.Enabled = true;

            }
            else
            {
                numericUpDown_songDifficulty5.Enabled = true;
                numericUpDown_songDifficulty6.Enabled = true;
                numericUpDown_songDifficulty7.Enabled = true;

                textBox_songVer.Enabled = true;
                textBox_songExt1.Enabled = true;
                textBox_songExt2.Enabled = true;
                textBox_songExt3.Enabled = true;
                textBox_songExt4.Enabled = true;
                textBox_songExt5.Enabled = true;

                textBox_songBGM_ext2.Enabled = false;
                textBox_songBGM_ext3.Enabled = false;
                textBox_songBGM_ext4.Enabled = false;
                textBox_songBGM_ext5.Enabled = false;
                textBox_songBGM_ext6.Enabled = false;
                textBox_songBGM_ext7.Enabled = false;
                textBox_songBGM_ext8.Enabled = false;
            }
        }

        private void button_about_Click(object sender, EventArgs e)
        {
            form_about.ShowDialog();
        }

        private void Form_GCC_Shown(object sender, EventArgs e)
        {
            Args.args(this);
        }

        private void comboBox_ALL_Source_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox_Mode.SelectedIndex = comboBox_ALL_Destination.SelectedIndex;
        }

        private void textBox_output_TextChanged(object sender, EventArgs e)
        {
            textBox_ALL_Output.Text = textBox_output.Text;
        }

        private void textBox_ALL_output_TextChanged(object sender, EventArgs e)
        {
            textBox_output.Text = textBox_ALL_Output.Text;
        }

        private void button_ConvertALL_Click(object sender, EventArgs e)
        {
            if(sender == button_ALL_convertSP || (Directory.Exists(textBox_ALL_BGM.Text) && Directory.Exists(textBox_ALL_Data.Text) &&
               Directory.Exists(textBox_ALL_Output.Text) && File.Exists(textBox_ALL_StageParam.Text)))
            {
                try
                {
                    
                    List<Song> newSongs = new List<Song>(songs);
                    //Reader_StageParam reader = new Reader_StageParam();
                    //newSongs.AddRange(reader.readBytes(textBox_ALL_StageParam.Text, comboBox_ALL_Destination.SelectedIndex));
                    int i = 0;
                    toolStrip_status2.Text = "Convert... " + i + "/" + songs.Count;
                    if (!File.Exists(textBox_ALL_Output.Text + @"\stage_param.dat"))
                    {
                        File.Create(textBox_ALL_Output.Text + @"\stage_param.dat");

                    }
                    bool done = false;
                    foreach (var song in newSongs)
                    {
                        i++;
                        if(i == songs.Count)
                        {
                            done = true;
                        }

                        song.ConvertSong(comboBox_ALL_Destination.SelectedIndex, textBox_ALL_Output.Text+@"\stage_param.dat", done);

                        toolStrip_status2.Text = "Convert... " + i + "/" + songs.Count;

                    }



                }
                catch (Exception)
                {

                    throw;
                }
            }
            else if (sender == button_ConvertALL)
            {
                DirectoryInfo dir = new DirectoryInfo(textBox_ALL_BGM.Text);
                foreach (FileInfo songFile in dir.GetFiles())
                {
                    // Convert WAV file to 48khz
                    new Converter_WAV_48khz().SingleFileConversion(songFile.FullName, @"switch\temp");

                    // Convert to OPUS
                    new Converter_WAV_to_OPUS().Main(@"switch\temp", textBox_ALL_Output.Text + @"\stage\sound");

                }


                // Compress to GZIP all the datas files
                //new Compressor_GZIP().Main(0, textBox_ALL_Data.Text, textBox_ALL_Output.Text + @"\stage\data_gz");
            }
            else
            {
                MessageHandler.ShowError(8);
            }
        }

        private void button_ALL_Data_Click(object sender, EventArgs e)
        {
            textBox_ALL_Data.Text = FileSelect("",
                "",
                Application.StartupPath, true, textBox_ALL_Data.Text);
        }

        private void button_ALL_BGM_Click(object sender, EventArgs e)
        {
            textBox_ALL_BGM.Text = FileSelect("",
                "",
                Application.StartupPath, true, textBox_ALL_BGM.Text);
        }

        private void button_ALL_Output_Click(object sender, EventArgs e)
        {
            textBox_ALL_Output.Text = FileSelect("",
                "",
                Application.StartupPath, true, textBox_ALL_Output.Text);
        }

        private void button_ALL_StageParam_Click(object sender, EventArgs e)
        {
            String dir = Application.StartupPath;
            if (File.Exists(textBox_ALL_StageParam.Text))
            {
                dir = textBox_ALL_StageParam.Text;
            }
            textBox_ALL_StageParam.Text = FileSelect("Stage_Param",
                "Stage_Param File|stage_param.dat|" +
                "Dat File(*.dat)|*.dat|" +
                "All files (*.*)|*.*",
                dir, false, textBox_ALL_StageParam.Text);
        }

        private void comboBox_songGenre_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label22_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (StageParamLoaded())
            {

                for (int i = 0; i < listBox_StageParam.Items.Count; i++)
                {
                    listBox_StageParam.SelectedIndex = i;
                    SelectSong();
                    checkBox_DLC_Switch.Checked = false;
                    button_Update_Click();
                }
                dlcConvert = false;
            }
            dlcConvert = false;
        }

        private void checkBox_unlocked_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
