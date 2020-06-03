using Groove_Coaster_Converter.Class;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Groove_Coaster_Converter
{
    public static class Program
    {

        public static string title = "Groove Coaster Converter";
        private static string author = "by CyberKevin";
        static readonly string version = "0.2.1";
        public static readonly string songFolder = @"songs";
        public static readonly string conversionFolder = @"songs\Converted";
        public static bool debug = false;
        private static bool program = true;

        public static string songFile;
        public static List<string> songDatas = new List<string>();
        public static string typeSong;
        public static Form_GCC GCC;


        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        [STAThread]
        static public void Main()
        {
            Application.ThreadException += new ThreadExceptionEventHandler(Application_ThreadException);
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            GCC = new Form_GCC();
            Application.Run(GCC);
            
        }

        static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            // Log the exception, display it, etc
            MessageHandler.Show("Unknown Error, please report the error:\n"+ e.Exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            GCC.result += $"\r\n\r\nERROR: from {sender.ToString()}.\r\nError Message: {e.Exception.Message}";
            GCC.textBox_StageParamBytes.Text = GCC.result;
            Debug.WriteLine(e.Exception.Message);
        }

        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            // Log the exception, display it, etc
            MessageHandler.Show("Unknown Error, please report the error:\n" + (e.ExceptionObject as Exception).Message, "Unhandled Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            GCC.result += $"\r\n\r\nERROR: from {sender.ToString()}.\r\nError Message: {(e.ExceptionObject as Exception).Message}";
            GCC.textBox_StageParamBytes.Text = GCC.result;
            Debug.WriteLine((e.ExceptionObject as Exception).Message);
        }
    }
}
