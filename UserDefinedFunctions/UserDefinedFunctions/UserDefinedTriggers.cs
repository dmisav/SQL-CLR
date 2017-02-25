using Microsoft.SqlServer.Server;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace UserDefinedFunctions
{
    public class UserDefinedTriggers
    {
        [SqlTrigger(Name = "UserNameAudit", Target = "Users", Event = "FOR INSERT")]
        public static void UserNameAudit()
        {
            SqlTriggerContext triggContext = SqlContext.TriggerContext;
            SqlParameter userNameParam = new SqlParameter("@username", System.Data.SqlDbType.NVarChar);

            if (triggContext.TriggerAction == TriggerAction.Insert)
            {
                using (SqlConnection conn = new SqlConnection("context connection=true"))
                {
                    conn.Open();
                    SqlCommand sqlComm = new SqlCommand();
                    SqlPipe sqlP = SqlContext.Pipe;

                    sqlComm.Connection = conn;
                    sqlComm.CommandText = "SELECT UserName from INSERTED";

                    userNameParam.Value = sqlComm.ExecuteScalar().ToString();

                    if (IsEMailAddress(userNameParam.Value.ToString()))
                    {
                        sqlComm.CommandText = "INSERT UsersAudit (UserName) VALUES(@username)";
                        sqlComm.Parameters.Add(userNameParam);
                        sqlP.Send(sqlComm.CommandText);
                        sqlP.ExecuteAndSend(sqlComm);
                    }
                }
            }
        }

        public static bool IsEMailAddress(string s)
        {
            return Regex.IsMatch(s, "^([\\w-]+\\.)*?[\\w-]+@[\\w-]+\\.([\\w-]+\\.)*?[\\w]+$");
        }
    }
}