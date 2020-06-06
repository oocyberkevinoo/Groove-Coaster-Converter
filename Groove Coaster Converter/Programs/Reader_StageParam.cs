using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Groove_Coaster_Converter.Class;
using System.Windows.Forms;

namespace Groove_Coaster_Converter.Programs
{
    class Reader_StageParam
    {
        private long cursor = 0;
        //private uint total_entries;
        //private String result;
        private Form_GCC form_GCC = Application.OpenForms["Form_GCC"] as Form_GCC;

        public List<Song> songs;


        public List<Song> readBytes(String file, int Platform)
        {
            form_GCC.liste.Clear();
            BinaryReader binReader = new BinaryReader(File.Open(file, FileMode.Open), Encoding.UTF8);

            // Number of ID
            form_GCC.total_entries = ReverseBytes(binReader.ReadUInt16());
            songs = new List<Song>();
            //result += "StageParam contain " + ReverseBytes(binReader.ReadUInt16()) + " ID(s)\r\n";

            for (int i = 1; i > 0; i++)
            {

                try
                {
                    // Start of the song!
                    Song song = new Song();
                    cursor = binReader.BaseStream.Position;
                    song.rangeOffsets[0] = cursor;
                    song.platform = Platform;

                    // Song ID
                    cursor = binReader.BaseStream.Position;
                    song.offsets[0] = cursor;
                    song.id = ReverseBytes(binReader.ReadUInt32());
                    song.unique_id = i;
                    form_GCC.liste_id.Add(song.id);
                    //result += "Song " + ReverseBytes(binReader.ReadUInt32()) + (Position(cursor)) + "\r\n";

                    // Song Name
                    cursor = binReader.BaseStream.Position;
                    song.offsets[1] = cursor;
                    song.names[0] = binReader.ReadString();
                    form_GCC.liste.Add(song.names[0]);
                    //result += "Song Name 1: " + song.names[0] + Position(cursor) + "\r\n";
                    cursor = binReader.BaseStream.Position;
                    if(Platform == 2)
                    {
                        song.offsets[2] = cursor;
                        song.names[1] = binReader.ReadString();
                        //result += "Song Name 2: " + binReader.ReadString() + Position(cursor) + "\r\n";
                        cursor = binReader.BaseStream.Position;
                    }
                    song.offsets[3] = cursor;
                    song.names[2] = binReader.ReadString();
                    //result += "Song Name short: " + binReader.ReadString() + Position(cursor) + "\r\n";
                    cursor = binReader.BaseStream.Position;
                    song.offsets[4] = cursor;
                    try
                    {
                        
                        song.names[3] = binReader.ReadString();
                        //result += "Song Author: " + binReader.ReadString() + Position(cursor) + "\r\n";

                    }
                    catch (Exception)
                    {
               
                        //result += "Song Author: ERROR- Can't decrypt Author name, try to edit this song manually...";
                        binReader.BaseStream.Position = cursor;
                        binReader.ReadBytes(binReader.ReadByte());
                    }
                    cursor = binReader.BaseStream.Position;
                    song.offsets[5] = cursor;
                    song.names[4] = binReader.ReadString();
                    //result += "Song Name 3: " + binReader.ReadString() + Position(cursor) + "\r\n";
                    cursor = binReader.BaseStream.Position;

                    if (Platform == 2)
                    {
                        song.offsets[6] = cursor;
                        song.extras[0] = binReader.ReadString();
                        //result += "Song Ext: " + binReader.ReadString() + Position(cursor) + "\r\n";
                        cursor = binReader.BaseStream.Position;
                        song.offsets[7] = cursor;
                        song.extras[1] = binReader.ReadString();
                        //result += "Song Ext: " + binReader.ReadString() + Position(cursor) + "\r\n";
                        cursor = binReader.BaseStream.Position;
                        song.offsets[8] = cursor;
                        song.extras[2] = binReader.ReadString();
                        //result += "Song Ext: " + binReader.ReadString() + Position(cursor) + "\r\n";
                        cursor = binReader.BaseStream.Position;
                        song.offsets[9] = cursor;
                        song.extras[3] = binReader.ReadString();
                        //result += "Song Ext: " + binReader.ReadString() + Position(cursor) + "\r\n";
                        cursor = binReader.BaseStream.Position;
                        song.offsets[10] = cursor;
                        song.extras[4] = binReader.ReadString();
                        //result += "Song Ext: " + binReader.ReadString() + Position(cursor) + "\r\n";
                        cursor = binReader.BaseStream.Position;
                    }

                    // Song data
                    cursor = binReader.BaseStream.Position;
                    song.offsets[11] = cursor;
                    song.data = binReader.ReadString();
                    //result += "Song data: " + binReader.ReadString() + Position(cursor) + "\r\n";
                    

                    // Song Genre
                    cursor = binReader.BaseStream.Position;
                    song.offsets[12] = cursor;
                    song.genre = binReader.ReadByte();
                    
                    //result += "Song Genre: " + ReadGenre(binReader.ReadByte()) + Position(cursor) + "\r\n";

                    // Song Timer
                    cursor = binReader.BaseStream.Position;
                    song.offsets[13] = cursor;
                    song.timer = binReader.ReadString();
                    //result += "Song timer: " + binReader.ReadString() + Position(cursor) + "\r\n";

                    // Song Difficulies
                    cursor = binReader.BaseStream.Position;
                    song.offsets[14] = cursor;
                    int dif = 4;
                    if(Platform == 2)
                    {
                        dif = 8;
                    }

                    int[] difficulties = new int[dif];
                    for (int i2 = 0; i2 < dif; i2++)
                    {
                        difficulties[i2] = binReader.ReadByte();
                    }

                    song.difficulties.AddRange(difficulties);

                    // Song BPM
                    cursor = binReader.BaseStream.Position;
                    song.offsets[15] = cursor;
                    song.BPM = binReader.ReadString();
                    //result += "Song BPM: " + binReader.ReadString() + Position(cursor) + "\r\n";
                    
                    // WHAT IS THIS ???
                    if(Platform == 2)
                    {
                        song.unknown.AddRange(binReader.ReadBytes(23));
                    }
                    else
                    {
                        song.unknown.AddRange(binReader.ReadBytes(22));
                    }

                    // Song BGM
                    cursor = binReader.BaseStream.Position;
                    song.offsets[16] = cursor;
                    song.BGM = binReader.ReadString();
                    //result += "Song Audio File: " + binReader.ReadString() + Position(cursor) + "\r\n";
                        if(Platform == 2)
                    {
                        dif = 1;
                    }
                    else
                    {
                        dif = 8;
                    }
                    for (int i2 = 0; i2 < dif; i2++)
                    {
                        song.BGM_ext[i2] = binReader.ReadString();
                    }



                    // Song GameData
                    //result += "\r\nSong Game Data:\r\n";
                    bool noDifficulties = false;
                    if(difficulties[0] < 1 && difficulties[1] < 1 && difficulties[2] < 1)
                    {
                        noDifficulties = true;
                    }

                    if (difficulties[0] > 0 || noDifficulties)
                    {
                        cursor = binReader.BaseStream.Position;
                        song.offsets[17] = cursor;
                        song.gameData[0] = binReader.ReadString();
                        //result += "Easy - " + binReader.ReadString() + Position(cursor) + "\r\n";
                    }
                    else
                    {
                        binReader.ReadByte();
                    }
                    if (difficulties[1] > 0 || noDifficulties)
                    {
                        cursor = binReader.BaseStream.Position;
                        song.offsets[18] = cursor;
                        song.gameData[1] = binReader.ReadString();
                        //result += "Normal - " + binReader.ReadString() + Position(cursor) + "\r\n";
                    }
                    else
                    {
                        binReader.ReadByte();
                    }
                    if (difficulties[2] > 0 || noDifficulties)
                    {
                        cursor = binReader.BaseStream.Position;
                        song.offsets[19] = cursor;
                        song.gameData[2] = binReader.ReadString();
                        //result += "Hard - " + binReader.ReadString() + Position(cursor) + "\r\n";
                    }
                    else
                    {
                        binReader.ReadByte();
                    }
                    if (difficulties[3] > 0)
                    {
                        cursor = binReader.BaseStream.Position;
                        song.offsets[20] = cursor;
                        song.gameData[3] = binReader.ReadString();
                        //result += "Extra/Master - " + binReader.ReadString() + Position(cursor) + "\r\n";
                    }
                    else
                    {
                        binReader.ReadByte();
                    }
                    song.additional_string = binReader.ReadString();

                    if(Platform == 2)
                    {
                        cursor = binReader.BaseStream.Position;
                        song.offsets[21] = cursor;
                        song.ver = binReader.ReadString();
                        //result += "Ver? " + binReader.ReadString() + Position(cursor) + "\r\n";

                        dif = 2;
                    }
                    else if(Platform == 1)
                    {
                        dif = 7;

                    }
                    else
                    {
                        dif = 8;
                    }
                    song.additional_data.AddRange(binReader.ReadBytes(dif));  // WHAT IS THIS ???
                    cursor = binReader.BaseStream.Position;
                    song.rangeOffsets[1] = cursor;


                    /*
                     * 
                     * TEMP OPERATION
                     * 
                     */
                     
                       /* string currentContent = String.Empty;
                        if (File.Exists(@".\liste.txt"))
                        {
                            currentContent = File.ReadAllText(@".\liste.txt");
                        }
                        File.WriteAllText(@".\liste.txt", song.id+" - "+song.gameData[0]+"\r\n" + currentContent);

                    /*
                     *  TEMP OPERATION END
                     */
                    songs.Add(song);

                }
                catch (Exception e)
                {
                    form_GCC.result += "Error: "+i+" - " + e.Message+"\r\n";
                    
                }


               
                //result += "----\r\n\r\n";

                if (binReader.PeekChar() == -1)
                {
                    i = -1;
                }
            }
            form_GCC.result += form_GCC.total_entries+" entries loaded.\r\n\r\n";
            form_GCC.label_songsLoaded.Text = "Stages: "+form_GCC.total_entries;
            form_GCC.listBox_StageParam.DataSource = null;
            form_GCC.listBox_StageParam.DataSource = form_GCC.liste;
            form_GCC.textBox_StageParamBytes.Text = form_GCC.result;
            binReader.Close();
            return songs;
        }

        public bool EraseBytes(String file, long offsetStart, long offsetEnd, int mode=1 )
        {
            //BinaryReader binReader = new BinaryReader(File.Open(file, FileMode.Open), Encoding.UTF8);
            //BinaryWriter binWriter = new BinaryWriter(File.Open(file, FileMode.Open), Encoding.UTF8);

            try
            {

                List<Byte> bytes = new List<Byte>(File.ReadAllBytes(file));
                bytes.RemoveRange((int)offsetStart-1, (int)(offsetEnd - offsetStart));
                File.WriteAllBytes(file, bytes.ToArray());

                BinaryWriter binWriter = new BinaryWriter(File.Open(file, FileMode.Open), Encoding.UTF8);
               if(mode == 1)
                {
                    form_GCC.total_entries--;
                }
                binWriter.Write((short) ReverseBytes(form_GCC.total_entries));
                binWriter.Dispose();
                binWriter.Close();
                bytes.Clear();




            }
            catch (Exception)
            {
  
                return false;
            }
            return true;
        }
        public void writeBytes(String file, int Platform, int mode = 0, Song song = null, bool done=false)
        {
            /*if(mode == 1)
            {
                Song song_temp = new Song();
                //songs = new List<Song>();
                song_temp.NewSong(Platform, form_GCC.total_entries++);
                song = song_temp;
            }*/
            file = AppDomain.CurrentDomain.BaseDirectory+"temp.dat";
            File.Create(file).Close();
            BinaryWriter binWriter = new BinaryWriter(File.Open(file, FileMode.Open), Encoding.UTF8);

            if(mode == 1 || (mode == 2 && done))
            {
                binWriter.Write((short)ReverseBytes(form_GCC.total_entries));

            }


            try
            {

                // Song ID
                binWriter.Write((UInt32)ReverseBytes(song.id));

                // Song Name
                binWriter.Write(song.names[0]);
                if (Platform == 2)
                {
                    binWriter.Write(song.names[1]);
                }
                binWriter.Write(song.names[2]);
                try
                {
                    binWriter.Write(song.names[3]);
                }
                catch (Exception)
                {
                    //binReader.ReadBytes(binReader.ReadByte());
                }
                binWriter.Write(song.names[4]);

                if (Platform == 2)
                {
                    binWriter.Write(song.extras[0]);
                    binWriter.Write(song.extras[1]); 
                    binWriter.Write(song.extras[2]);
                    binWriter.Write(song.extras[3]);
                    binWriter.Write(song.extras[4]);
                }

                // Song data
                binWriter.Write(song.data);

                // Song Genre
                binWriter.Write((Byte)song.genre);

                // Song Timer
                binWriter.Write(song.timer);

                // Song Difficulies
                int dif = 4;
                if (Platform == 2)
                {
                    dif = 8;
                }

                for (int i2 = 0; i2 < dif; i2++)
                {
                    binWriter.Write((Byte)song.difficulties[i2]);
                }

                // Song BPM
                binWriter.Write(song.BPM);

                // UNKNOWN !
                /*for (int i = 22; i > 0; i--)
                {
                    binWriter.Write((Byte)0x00);
                }
                
                if (Platform == 2)
                {
                    binWriter.Write((Byte)0x00);
                }*/
                binWriter.Write(song.unknown.ToArray());

                // Song BGM
                binWriter.Write(song.BGM);

                if (Platform == 2)
                {
                    dif = 1;
                }
                else
                {
                    dif = 8;
                }
                for (int i2 = 0; i2 < dif ; i2++)
                {
    
                    binWriter.Write(song.BGM_ext[i2]);
                    
                }



                // Song GameData
                if (song.difficulties[0] > 0)
                {
                    binWriter.Write(song.gameData[0]);
                }
                else
                {
                    binWriter.Write((Byte) 0x00);
                }
                if (song.difficulties[1] > 0)
                {
                    binWriter.Write(song.gameData[1]);
                }
                else
                {
                    binWriter.Write((Byte)0x00);
                }
                if (song.difficulties[2] > 0)
                {
                    binWriter.Write(song.gameData[2]);
                }
                else
                {
                    binWriter.Write((Byte)0x00);
                }
                if (song.difficulties[3] > 0)
                {
                    binWriter.Write(song.gameData[3]);
                }
                else
                {
                    binWriter.Write((Byte)0x00);
                }
                binWriter.Write(song.additional_string);
                if (Platform == 2)
                {
                    binWriter.Write(song.ver);
                    dif = 2;
                }
                else if(Platform == 1)
                {
                    dif = 7;

                }
                else
                {
                    dif = 8;
                }
                //binReader.ReadBytes(dif);  // WHAT IS THIS ???
                /*while(dif > 0)
                {
                    binWriter.Write((Byte)0x00);
                    dif--;
                }*/
                binWriter.Write(song.additional_data.ToArray());


                // Save song
                binWriter.Dispose();
                binWriter.Close();

                /*if(mode == 1)
                {
                    song.UpdateDatabase(mode);
                }*/
                
                
                //bytes.Clear();

            }
            catch (Exception e)
            {
                MessageHandler.ShowError(5);
                form_GCC.result += "Error: " + e.Message + "\r\n";
                //return song;
            }

        }

        // reverse byte order (16-bit)
        public static UInt16 ReverseBytes(UInt16 value)
        {
            return (UInt16)((value & 0xFFU) << 8 | (value & 0xFF00U) >> 8);
        }
        // reverse byte order (32-bit)
        public static UInt32 ReverseBytes(UInt32 value)
        {
            return (value & 0x000000FFU) << 24 | (value & 0x0000FF00U) << 8 |
                   (value & 0x00FF0000U) >> 8 | (value & 0xFF000000U) >> 24;
        }
        // reverse byte order (64-bit)
        public static UInt64 ReverseBytes(UInt64 value)
        {
            return (value & 0x00000000000000FFUL) << 56 | (value & 0x000000000000FF00UL) << 40 |
                   (value & 0x0000000000FF0000UL) << 24 | (value & 0x00000000FF000000UL) << 8 |
                   (value & 0x000000FF00000000UL) >> 8 | (value & 0x0000FF0000000000UL) >> 24 |
                   (value & 0x00FF000000000000UL) >> 40 | (value & 0xFF00000000000000UL) >> 56;
        }

        private static String Position(long position)
        {
            return " | at Offset " + (0x00 + (position));
        }

        

    }
}
