using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace deadMail
{
    class CheckIsDubled
    {
        public static DataTable isMailExists(string mail)
        {
            string commandText = @"SELECT * 
                                    FROM [dbo].[dead_mails] 
                                    WHERE [mail] like N'%" + mail + "%'";
            using (SqlConnection conn = new SqlConnection(Connections.sqlCon))
            using (SqlCommand cmd = new SqlCommand(commandText, conn))
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                using (SqlDataAdapter sda = new SqlDataAdapter())
                {
                    sda.SelectCommand = cmd;
                    cmd.CommandTimeout = 60;
                    using (DataTable dt = new DataTable())
                    {
                        sda.Fill(dt);
                        return dt;
                    }
                }
            }
        }
    }
}
