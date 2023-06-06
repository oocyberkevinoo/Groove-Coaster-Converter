using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Groove_Coaster_Converter;
using Groove_Coaster_Converter.Programs;

namespace Groove_Coaster_Converter.Class
{
    class Song
    {


        // Song structure
        public uint id;
        public int unique_id;
        public int platform; // 2 = Switch

        public String[] names = new string[10];
        public String[] extras = new string[10];
        public String author;
        public String data;
        public int genre; // Related to SFX/Visual???
        public String timer;
        public List<int> difficulties = new List<int>();
        public String BPM;
        public String BGM;
        public String[] BGM_ext = new string[10];
        public String[] gameData = new String[4];
        public String inputOffset;
        public int previewStartMs;
        public int previewEndMs;

        public String additional_string;
        public List<Byte> additional_informations = new List<Byte>();
        public List<Byte> additional_data = new List<Byte>();




        public long[] offsets = new long[25];
        public long[] rangeOffsets = new long[2];

        public Byte[] switch_flagLockedBeginner = { 0x01, 0x00 };
        public Byte[] GC2_flagLockedBeginner = { 0x00, 0x00, 0x00, 0x00, 0x00, 0x01, 0x00 };
        public Byte[] GC4EX_flagLockedBeginner = { 0x00, 0x00, 0x00, 0x00, 0x00, 0x01, 0x00, 0x00 };
        public Byte[] switch_flagUnknown = { 0x64, 0x64, 0x64, 0x64, 0x64, 0x64, 0x64, 
            0x64, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0xE6, 0xDC, 0x00, 0x01, 
            0x70, 0xC0, 0x01, 0x02, 0x00 };
        public Byte[] GC2_flagUnknown = { 0x64, 0x64, 0x64, 0x64, 0x64, 0x64, 0x64, 0x64, 
            0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0xAF, 0xC8, 0x01, 0x00 };

        public bool dlc;

        private Form_GCC form_GCC = Application.OpenForms["Form_GCC"] as Form_GCC;

        public Song()
        {

        }

        public void setId(uint id)
        {
            form_GCC.liste_id[form_GCC.listBox_StageParam.SelectedIndex] = id;
            this.id = id;
        }

        public bool UpdateSong(int mode = 0)
        {
            try
            {
                uint temp_id = id;
                // Song ID
                setId((uint)form_GCC.numericUpDown_songID.Value);

                // Song Name
                names[0] = form_GCC.textBox_songName1.Text;
                names[1] = form_GCC.textBox_songName2.Text;
                names[2] = form_GCC.textBox_songName3.Text;
                names[3] = form_GCC.textBox_songName4.Text;
                names[4] = form_GCC.textBox_songName5.Text;

                // Song Ext
                if(platform == 2)
                {
                    extras[0] = form_GCC.textBox_songExt1.Text;
                    extras[1] = form_GCC.textBox_songExt2.Text;
                    extras[2] = form_GCC.textBox_songExt3.Text;
                    extras[3] = form_GCC.textBox_songExt4.Text;
                    extras[4] = form_GCC.textBox_songExt5.Text;
                }

                // Song Data
                data = form_GCC.textBox_songData.Text;

                // Song Genre
                genre = form_GCC.comboBox_songGenre.SelectedIndex;

                // Song Timer
                timer = form_GCC.textBox_songTimer.Text;

                // Song Difficulties
                difficulties[0] = (int)form_GCC.numericUpDown_songDifficulty1.Value;
                difficulties[1] = (int)form_GCC.numericUpDown_songDifficulty2.Value;
                difficulties[2] = (int)form_GCC.numericUpDown_songDifficulty3.Value;
                difficulties[3] = (int)form_GCC.numericUpDown_songDifficulty4.Value;
                if (platform == 2)
                {
                    difficulties[4] = (int)form_GCC.numericUpDown_songDifficulty5.Value;
                    difficulties[5] = (int)form_GCC.numericUpDown_songDifficulty6.Value;
                    difficulties[6] = (int)form_GCC.numericUpDown_songDifficulty7.Value;
                }
                // Song BPM
                BPM = form_GCC.textBox_songBPM.Text;

                // Song BGM
                BGM = form_GCC.textBox_songBGM.Text;
                BGM_ext[0] = form_GCC.textBox_songBGM_ext1.Text;
                BGM_ext[1] = form_GCC.textBox_songBGM_ext2.Text;
                BGM_ext[2] = form_GCC.textBox_songBGM_ext3.Text;
                BGM_ext[3] = form_GCC.textBox_songBGM_ext4.Text;
                BGM_ext[4] = form_GCC.textBox_songBGM_ext5.Text;
                BGM_ext[5] = form_GCC.textBox_songBGM_ext6.Text;
                BGM_ext[6] = form_GCC.textBox_songBGM_ext7.Text;
                BGM_ext[7] = form_GCC.textBox_songBGM_ext8.Text;


                // Song GameData
                gameData[0] = form_GCC.textBox_songDifficulty1.Text;
                gameData[1] = form_GCC.textBox_songDifficulty2.Text;
                gameData[2] = form_GCC.textBox_songDifficulty3.Text;
                gameData[3] = form_GCC.textBox_songDifficulty4.Text;

                // Song Ver
                inputOffset = form_GCC.textBox_songVer.Text;

                // Preview
                previewStartMs = int.Parse(form_GCC.textBox_previewStart.Text);
                previewEndMs = int.Parse(form_GCC.textBox_previewEnd.Text);
                byte[] temp = BitConverter.GetBytes(previewStartMs);
                additional_informations[15] = temp[0];
                additional_informations[14] = temp[1];
                additional_informations[13] = temp[2];
                additional_informations[12] = temp[3];
                temp = BitConverter.GetBytes(previewEndMs);
                additional_informations[19] = temp[0];
                additional_informations[18] = temp[1];
                additional_informations[17] = temp[2];
                additional_informations[16] = temp[3];

                // Flags
                if (platform == 2)
                {
                    if (form_GCC.checkBox_unlocked.Checked)
                    {
                        additional_data[0] = 0x01;
                    }
                    else
                    {
                        additional_data[0] = 0x00;
                    }
                    if (form_GCC.checkBox_beginner.Checked)
                    {
                        additional_data[1] = 0x01;
                    }
                    else
                    {
                        additional_data[1] = 0x00;
                    }
                }
                else
                {
                    if (form_GCC.checkBox_unlocked.Checked)
                    {
                        additional_data[4] = 0x01;
                    }
                    else
                    {
                        additional_data[4] = 0x00;
                    }
                    if (form_GCC.checkBox_beginner.Checked)
                    {
                        additional_data[5] = 0x01;
                    }
                    else
                    {
                        additional_data[5] = 0x00;
                    }
                }

                dlc = form_GCC.checkBox_DLC_Switch.Checked;

                // Database Update
                UpdateDatabase(0);


                form_GCC.toolStrip_status3.Text = "Song " + temp_id + " (" + names[0] + ") updated";
                if (temp_id != id)
                {
                    form_GCC.toolStrip_status3.Text += " - Id " + temp_id + " to " + id;
                }
                form_GCC.result += "Song Updated\r\n";

                return true;
            }
            catch (Exception)
            {
                throw;

            }
        }

        public void UpdateDatabase(int mode, bool newSP=false, string newFile="", bool done=false)
        {
            string file = "";
            // Database Update
            if (newSP)
            {
                file = newFile;
            }
            else
            {
                file = form_GCC.textBox_StageParamInput.Text;
            }
            
            Reader_StageParam reader = new Reader_StageParam();
            if(mode == 0)
            {
                reader.EraseBytes(form_GCC.textBox_StageParamInput.Text, this.rangeOffsets[0], this.rangeOffsets[1], 0);

            }
            List<Byte> newStageParam = new List<Byte>();
            newStageParam.AddRange(File.ReadAllBytes(file));

            
            reader.writeBytes(file, platform, mode, this, done);
            switch (mode)
            {
                case 0:
                    newStageParam.InsertRange((int)rangeOffsets[0], File.ReadAllBytes(AppDomain.CurrentDomain.BaseDirectory + "temp.dat"));
                    break;

                case 1:
                    newStageParam.RemoveRange(0, 2);
                    newStageParam.InsertRange(0, File.ReadAllBytes(AppDomain.CurrentDomain.BaseDirectory + "temp.dat"));
                    break;

                case 2:
                    newStageParam.InsertRange(0, File.ReadAllBytes(AppDomain.CurrentDomain.BaseDirectory + "temp.dat"));
                    break;
            }

            File.WriteAllBytes(file, newStageParam.ToArray());
            File.Delete(AppDomain.CurrentDomain.BaseDirectory + "temp.dat");
        }

        public void CreateSong(int Platform)
        {
            try
            {
                platform = Platform;

                // Song ID
                id = (uint)form_GCC.listBox_StageParam.Items.Count;

                // Song Name
                names[0] = form_GCC.textBox_songName1.Text;
                names[1] = form_GCC.textBox_songName2.Text;
                names[2] = form_GCC.textBox_songName3.Text;
                names[3] = form_GCC.textBox_songName4.Text;
                names[4] = form_GCC.textBox_songName5.Text;

                // Song Ext
                if (platform == 2)
                {
                    extras[0] = form_GCC.textBox_songExt1.Text;
                    extras[1] = form_GCC.textBox_songExt2.Text;
                    extras[2] = form_GCC.textBox_songExt3.Text;
                    extras[3] = form_GCC.textBox_songExt4.Text;
                    extras[4] = form_GCC.textBox_songExt5.Text;
                }

                // Song Data
                data = form_GCC.textBox_songData.Text;

                // Song Genre
                genre = form_GCC.comboBox_songGenre.SelectedIndex;

                // Song Timer
                timer = form_GCC.textBox_songTimer.Text;

                // Preview
                previewStartMs = int.Parse(form_GCC.textBox_previewStart.Text);
                previewEndMs = int.Parse(form_GCC.textBox_previewEnd.Text);

                // Song Difficulties
                difficulties.Add((int)form_GCC.numericUpDown_songDifficulty1.Value);
                difficulties.Add((int)form_GCC.numericUpDown_songDifficulty2.Value);
                difficulties.Add((int)form_GCC.numericUpDown_songDifficulty3.Value);
                difficulties.Add((int)form_GCC.numericUpDown_songDifficulty4.Value);
                if (platform == 2)
                {
                    difficulties.Add((int)form_GCC.numericUpDown_songDifficulty5.Value);
                    difficulties.Add((int)form_GCC.numericUpDown_songDifficulty6.Value);
                    difficulties.Add((int)form_GCC.numericUpDown_songDifficulty7.Value);
                }
                // Song BPM
                BPM = form_GCC.textBox_songBPM.Text;

                // Song BGM
                BGM = form_GCC.textBox_songBGM.Text;
                BGM_ext[0] = form_GCC.textBox_songBGM_ext1.Text;
                BGM_ext[1] = form_GCC.textBox_songBGM_ext2.Text;
                BGM_ext[2] = form_GCC.textBox_songBGM_ext3.Text;
                BGM_ext[3] = form_GCC.textBox_songBGM_ext4.Text;
                BGM_ext[4] = form_GCC.textBox_songBGM_ext5.Text;
                BGM_ext[5] = form_GCC.textBox_songBGM_ext6.Text;
                BGM_ext[6] = form_GCC.textBox_songBGM_ext7.Text;
                BGM_ext[7] = form_GCC.textBox_songBGM_ext8.Text;


                // Song GameData
                gameData[0] = form_GCC.textBox_songDifficulty1.Text;
                gameData[1] = form_GCC.textBox_songDifficulty2.Text;
                gameData[2] = form_GCC.textBox_songDifficulty3.Text;
                gameData[3] = form_GCC.textBox_songDifficulty4.Text;

                // Song Ver
                inputOffset = form_GCC.textBox_songVer.Text;

                // Flags
                if (platform == 2)
                {
                    if (form_GCC.checkBox_unlocked.Checked)
                    {
                        additional_data[0] = 0x01;
                    }
                    else
                    {
                        additional_data[0] = 0x00;
                    }
                    if (form_GCC.checkBox_beginner.Checked)
                    {
                        additional_data[1] = 0x01;
                    }
                    else
                    {
                        additional_data[1] = 0x00;
                    }
                }
                else
                {
                    if (form_GCC.checkBox_unlocked.Checked)
                    {
                        additional_data[4] = 0x01;
                    }
                    else
                    {
                        additional_data[4] = 0x00;
                    }
                    if (form_GCC.checkBox_beginner.Checked)
                    {
                        additional_data[5] = 0x01;
                    }
                    else
                    {
                        additional_data[5] = 0x00;
                    }
                }

                dlc = form_GCC.checkBox_DLC_Switch.Checked;


                UpdateDatabase(1);



            }
            catch (Exception e)
            {
                MessageHandler.Show("Creation of the new song failed:\r\n " + e.Message + "\r\n", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                form_GCC.result += "Creation of the new song failed: " + e.Message + "\r\n";

            }
        }

        public void NewSong(int Platform, ushort total, bool merged=false, bool convert = true)
        {


            try
            {
                platform = Platform;

                // Song ID
                id = total;

                // Song Name
                if (convert)
                {
                    if (Args.songNameData.Length > 0)
                    {
                        names[0] = Path.GetFileName(Args.songNameData);
                    }
                    else
                    {
                        names[0] = Path.GetFileName(form_GCC.textBox_Data.Text);
                    }

                }
                else
                    names[0] = "New Song";

                if (Platform == 2)
                {
                    names[1] = "Name 2";
                }
                names[2] = "Name 3";
                try
                {
                    names[3] = "Name 4";
                }
                catch (Exception)
                {
                    //binReader.ReadBytes(binReader.ReadByte());
                }
                names[4] = "Name 5";

                if (Platform == 2)
                {
                    extras[0] = "Extra 1";
                    extras[1] = "Extra 2";
                    extras[2] = "Extra 3";
                    extras[3] = "Extra 4";
                    extras[4] = "Extra 5";
                }

                // Song data
                data = "Data";

                // Song Genre
                genre = 0;

                // Song Timer
                timer = "0:00";

                // Preview
                previewStartMs = 60000;
                previewEndMs = 90000;

                // Song Difficulies
                int dif = 4;
                if (Platform == 2)
                {
                    dif = 8;
                }

                for (int i2 = 0; i2 < dif; i2++)
                {
                    difficulties.Add(i2 + 1);
                }


                // Song BPM
                BPM = id.ToString();

                //binReader.ReadBytes(22);  // WHAT IS THIS ???
                if (Platform == 2)
                {
                    
                    additional_informations.AddRange(switch_flagUnknown);
                }
                else
                {
                    
                    additional_informations.AddRange(GC2_flagUnknown);

                }
                


                // Song BGM
                
                BGM = "bgm";
                if (merged)
                {
                    BGM = "m_" + BGM;
                }

                if (Platform == 2)
                {
                    dif = 1;
                }
                else
                {
                    dif = 8;
                }
                for (int i2 = 0; i2 < dif; i2++)
                {
                    BGM_ext[i2] = "";
                }



                // Song GameData

                if (difficulties[0] > 0)
                {
                    gameData[0] = "data easy";
                }
                else
                {
                    //binReader.ReadByte();
                }
                if (difficulties[1] > 0)
                {
                    gameData[1] = "data normal";
                }
                else
                {
                    //binReader.ReadByte();
                }
                if (difficulties[2] > 0)
                {
                    gameData[2] = "data hard";
                }
                else
                {
                    //binReader.ReadByte();
                }
                if (difficulties[3] > 0)
                {
                    gameData[3] = "data master";
                }
                else
                {
                    //binReader.ReadByte();
                }
                // What is this ???
                additional_string = "";
                if (Platform == 2)
                {
                    inputOffset = "1.3";
                    additional_data.AddRange(switch_flagLockedBeginner);
                }
                else if (Platform == 1)
                {
                    additional_data.AddRange(GC2_flagLockedBeginner);

                }
                else
                {
                    additional_data.AddRange(GC4EX_flagLockedBeginner);
                }
                dlc = false;

                UpdateDatabase(1);



            }
            catch (Exception e)
            {
                MessageHandler.Show("Creation of the new song failed:\r\n " + e.Message + "\r\n", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                form_GCC.result += "Creation of the new song failed: " + e.Message + "\r\n";

            }
        }


        public void ConvertSong(int Platform, string file, bool done, bool merged = false)
        {

            //songs = new List<Song>();



            try
            {
                platform = Platform;

              

                if (Platform == 2)
                {
                    names[1] = "Name 2";
                }
                else
                {
                    names[1] = "";
                }
                
                if (Platform == 2)
                {
                    extras[0] = "Extra 1";
                    extras[1] = "Extra 2";
                    extras[2] = "Extra 3";
                    extras[3] = "Extra 4";
                    extras[4] = "Extra 5";
                }
                else
                {
                    extras[0] = null;
                    extras[1] = null;
                    extras[2] = null;
                    extras[3] = null;
                    extras[4] = null;

                }

                

                // Song Difficulies
                int dif = 4;
                if (Platform == 2)
                {
                    difficulties.Add(difficulties[0]);
                    difficulties.Add(difficulties[1]);
                    difficulties.Add(difficulties[2]);
                    difficulties.Add(difficulties[3]);
                }
                else
                {
                    difficulties.RemoveRange(3, 4);

                }

                // Song BPM
                BPM = id.ToString();

                // WHAT IS THIS ??? (it's additional information, DUH. Certainly for default values like SFX, VFX)
                //additional_informations.Clear();
                if (Platform == 2)
                {
                    if (additional_informations.Count == 22)
                        additional_informations.Add(0x00);
                    //additional_informations.AddRange(switch_flagUnknown);
                }
                else
                {
                    if (additional_informations.Count == 23)
                        additional_informations.RemoveAt(additional_informations.Count-1);
                    //additional_informations.AddRange(GC2_flagUnknown);
                }



                
                if (merged)
                {
                    BGM = "m_" + BGM;
                }

                BGM_ext = new string[10];
                if (Platform == 2)
                {
                    dif = 1;
                }
                else
                {
                    dif = 8;
                }
                for (int i2 = 0; i2 < dif; i2++)
                {
                    BGM_ext[i2] = "";
                }

                additional_data.Clear();
                if (Platform == 2)
                {
                    inputOffset = "1.3";
                    additional_data.AddRange(switch_flagLockedBeginner);
                }
                else if (Platform == 1)
                {
                    inputOffset = null;
                    additional_data.AddRange(GC2_flagLockedBeginner);

                }
                else
                {
                    inputOffset = null;
                    additional_data.AddRange(GC4EX_flagLockedBeginner);
                }
                dlc = false;

                UpdateDatabase(2, true, file, done);



            }
            catch (Exception e)
            {
                MessageHandler.Show("Creation of the new song failed:\r\n " + e.Message + "\r\n", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                form_GCC.result += "Creation of the new song failed: " + e.Message + "\r\n";

            }
        }



    }
}
