using System;
using System.IO;
using System.Windows.Forms;

namespace deadMail
{
    class Log
    {
        public static string logFilNeame = Path.GetDirectoryName(Application.ExecutablePath) + "\\Logs\\log_" + DateTime.Now.Date.ToString("dd.MM.yyyy") + ".txt";
        public static void WriteToLogError(string text)
        {
            string FullMessage = text;

            using (StreamWriter w = File.AppendText(logFilNeame))
            {
                Logging(FullMessage, w);
            }
        }
        private static void Logging(string logMessage, TextWriter w)
        {
            w.Write("\r\n\nLog Entry : ");
            w.WriteLine("{0}", DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss"));
            w.WriteLine("  :");
            w.WriteLine("  :{0}", logMessage);
            w.WriteLine("-------------------------------");
        }
    }
}
