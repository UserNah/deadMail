using System;
using System.Data;
using System.Data.SqlClient;

namespace deadMail.Classes
{
    class InsertMail
    {
        public static string saveMailToTable(string mail)
        {
            try
            {
                if (mail.Contains("@"))
                {
                    using (System.Data.SqlClient.SqlConnection conn = new SqlConnection(Connections.sqlCon))
                    {
                        using (SqlCommand com = new SqlCommand(Connections.queryProc, conn))
                        {
                            com.CommandType = CommandType.StoredProcedure;
                            com.Parameters.Add("@id", SqlDbType.Int).Direction = ParameterDirection.Output;
                            com.Parameters.AddWithValue("@mail", mail);
                            conn.Open();
                            com.ExecuteNonQuery();
                            conn.Close();
                            Console.WriteLine(Convert.ToString(com.Parameters["@id"].Value));
                            
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Log.WriteToLogError("Class: Connections; Func: ConnectToExchangeServer; Exception: " + ex.ToString());
                Vars.output = "Exception in creating save Mail To Data Table!";
            }
            return Vars.output;
        }
    }
}
