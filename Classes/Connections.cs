using Microsoft.Exchange.WebServices.Data;
using System;

namespace deadMail
{
    class Connections
    {
        public static string sqlCon = "";//your connection
        public static string queryProc = "";//your proc
        public static string ConnectToExchangeServer()
        {
            try
            {
                Vars.exchange = new ExchangeService(ExchangeVersion.Exchange2007_SP1);
                Vars.exchange.Credentials = new WebCredentials("","","");//login_name(not mail), password, server
                Vars.exchange.Url = new Uri("");//your web url
            }
            catch (Exception ex)
            {
                Log.WriteToLogError("Class: Connections; Func: ConnectToExchangeServer; Exception: " + ex.ToString());
                Vars.output = "Exception in connecting to Exchange Server!";
            }
            return Vars.output;
        }
    }
}
