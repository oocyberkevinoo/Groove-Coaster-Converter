using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Groove_Coaster_Converter.Class
{
    public static class MessageHandler
    {
        private static Form_GCC form_GCC = Application.OpenForms["Form_GCC"] as Form_GCC;
        private static String[] messages = 
            {"Stage_Param file is not loaded.",
            "no file found to convert.",
            "This Song ID is already used.\nPlease use another ID.",
            "Please select an Output folder.",
            "Merging audio files failed.\nPlease check that your files are the correct ones.",
            "Updating Stage_param failed.\nPlease check that your files are the correct ones.",
            "Gameplay data seems wrong.\nplease make sure that the Song Data folder only contain the data files of the song you want to convert.",
            "This conversion is not supported yet."};


        public static void Show(String text, String title, MessageBoxButtons buttons, MessageBoxIcon icon)
        {
            MessageBox.Show(text, title, buttons, icon);
        }

        public static void ShowError(int i)
        {
            MessageBox.Show(messages[i], "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            log(messages[i]);
        }
        public static void ShowWarning(int i)
        {
            MessageBox.Show(messages[i], "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        public static void ShowInfo(int i)
        {
            MessageBox.Show(messages[i], "Groove Coaster Converter", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public static void ShowExclam(int i)
        {
            MessageBox.Show(messages[i], "Groove Coaster Converter", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        public static DialogResult AskQuestion(int i, MessageBoxButtons buttons)
        {
            return MessageBox.Show(messages[i], "Groove Coaster Converter", buttons, MessageBoxIcon.Question);
            
        }

        private static void log(String str)
        {
            form_GCC.result += str+"\r\n";
        }

        


    }
}
