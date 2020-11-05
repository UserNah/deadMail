using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace deadMail.Classes
{
    class getMailLine
    {
        public static void getMailLineParse(string mailBody)
        {
            try
            {
                string[] BodyDividedLines = mailBody.Split('\n');// divide body to divided lines
                //string[] asaa = asd(message.Body.ToString());
                for (int line = 0; BodyDividedLines.Length - 1 >= line; line++)
                {
                    if (BodyDividedLines[line].Contains("Введенный адрес электронной почты не удалось найти"))
                    {
                        Vars.BodyWithDeadMails.Add(BodyDividedLines[line - 1]);
                    }
                }
            }
            catch (Exception ex)
            {
                Log.WriteToLogError("Class: getMailLine; Func: getMailLineParse; Exception: " + ex.ToString());
                Vars.output = "Exception in connecting to Exchange Server!";
            }
        }
    }
}
