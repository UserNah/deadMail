using Microsoft.Exchange.WebServices.Data;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace deadMail
{
    class Vars
    {
        public static TimeSpan ts = new TimeSpan(0, -10, 0, 0);//messages reseived last 10 hours
        public static DateTime date = DateTime.Now.Add(ts);
        public static SearchFilter.IsGreaterThanOrEqualTo filter = new SearchFilter.IsGreaterThanOrEqualTo(ItemSchema.DateTimeSent, date);
        public static string output = "";//any errors var
        public static string path = System.IO.Path.GetDirectoryName(Application.ExecutablePath);
        public static ExchangeService exchange = null;
        public static List<string> BodyWithDeadMails = new List<string>();
    }
}
