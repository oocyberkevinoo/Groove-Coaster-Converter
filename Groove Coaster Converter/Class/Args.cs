using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Groove_Coaster_Converter.Class
{
    public static class Args
    {
        private static String[] coms;
        private static int cursor = 0;
        private static string command = "";
        private static string param = "";
        private static int int_convert = 0;

        public static bool convert = false;
        public static string songNameData = "";
        public static bool noAudioConverter = false;
        public static bool noDataConverter = false;

        /*
         *  -h:         Hide software window
         *  -s "":      String StageParam File to edit
         *  -sp_fr x:   Stage_param From...
         *              (0: Arcade; 1: Mobile)
         *  -sp_to x:   Stage_param To...
         *              (0: GC4EX; 1: GC2; 2: Switch)
         *  -i_bgm "":  BGM audio file
         *  -i_shot "": SHOT audio file to merge or not
         *  -i_data "": Folder that contain data files
         *  -n_data "": Name to gameplay data (ex: XXXX is the name in ac_XXXX_easy_ext.dat)
         *  -g x:       Genre of the song 
         *              (1: Anime/pop; 2: VOCALOID; 3: MusicGames; 
         *              4: Game Music; 5: Misc; 6: Original; 7: Touhou)
         *  -o "":      Output folder
         *  -nac:       No Audio Converter  
         *  -ndc:       No Data Converter
         *  -convert x: Convert mode 
         *              (0: files only; 1: Convert & Update stage_param)
         */

        public static void args(Form_GCC form)
        {
            if(Program.@params.Length > 0)
            {
                coms = Program.@params;
                foreach (var com in coms)
                {
                    if(command.Length == 0)
                    {
                        command = com;
                    }
                    else
                    {
                        param = com;
                    }
                    
                    
                    if (command.Equals("-h"))
                    {
                        form.Visible = false;
                        ClearCommands();
                    }
                    else if (command.Equals("-s") && param.Length > 0)
                    {
                        form.textBox_StageParamInput.Text = param;
                    }
                    else if (command.Equals("-sp_fr") && param.Length > 0)
                    {
                        form.comboBox_Mode.SelectedIndex = int.Parse(param);
                    }
                    else if (command.Equals("-sp_to") && param.Length > 0)
                    {
                        form.comboBox_SystemStageParam.SelectedIndex = int.Parse(param);
                    }
                    else if (command.Equals("-i_bgm") && param.Length > 0)
                    {
                        form.textBox_FileBGM.Text = param;
                    }
                    else if (command.Equals("-i_shot") && param.Length > 0)
                    {
                        form.checkBox_SHOT.Checked = true;
                        form.textBox_FileSHOT.Text = param;
                    }
                    else if (command.Equals("-i_data") && param.Length > 0)
                    {
                        form.textBox_Data.Text = param;
                    }
                    else if (command.Equals("-n_data") && param.Length > 0)
                    {
                        songNameData = param;
                    }
                    else if (command.Equals("-g") && param.Length > 0)
                    {
                        form.comboBox_Genres.SelectedIndex = int.Parse(param);
                    }
                    else if (command.Equals("-o") && param.Length > 0)
                    {
                        form.textBox_output.Text = param;
                    }
                    else if (command.Equals("-nac"))
                    {
                        noAudioConverter = false;
                        ClearCommands();
                    }
                    else if (command.Equals("-ndc"))
                    {
                        noDataConverter = false;
                        ClearCommands();
                    }
                    else if (command.Equals("-convert") && param.Length > 0)
                    {
                        int_convert = int.Parse(param);
                        convert = true;
                        
                    }

                    if (command.Length > 0 && param.Length > 0)
                    {
                        ClearCommands();
                    }
                    
                }

                if (convert)
                {
                    form.button_LoadStageParam_Click(form.button_LoadStageParam, EventArgs.Empty);

                    while (!form.tabControl_Main.Enabled)
                    {

                    }
                    
                    if (int_convert == 1)
                    {
                        form.button_ConvertUpdate_Click(form.button_ConvertUpdate, EventArgs.Empty);
                    }
                    else
                    {
                        form.button_ConvertUpdate_Click(form.button_Convert, EventArgs.Empty);
                    }
                }
               
            }
        }

        private static void ClearCommands()
        {
            param = "";
            command = "";
        }
    }
}
