
namespace deadMail
{
    class MailParse
    {
        public static string getMailFromLine(int mailLineID)
        {
            int begining = Vars.BodyWithDeadMails[mailLineID].IndexOf("mailto:") + "mailto:".Length;
            int end = Vars.BodyWithDeadMails[mailLineID].IndexOf("\">", begining);
            return Vars.BodyWithDeadMails[mailLineID].Substring(begining, end - begining);
        }
    }
}
