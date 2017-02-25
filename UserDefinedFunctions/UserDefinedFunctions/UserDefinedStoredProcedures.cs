using Microsoft.SqlServer.Server;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace UserDefinedFunctions
{
    //CLR functions are more appropriate than simple Transact-SQL statements for computation-intensive applications.
    public class UserDefinedStoredProcedures
    {
        //The following shows a stored procedure returning information through an OUTPUT parameter:
        [SqlProcedure]
        public static void PriceSum(out SqlInt32 value)
        {
            using (SqlConnection connection = new SqlConnection("context connection=true"))
            {
                value = 0;
                connection.Open();
                SqlCommand command = new SqlCommand("select id from [dbo].[Address]", connection);
                SqlDataReader reader = command.ExecuteReader();

                using (reader)
                {
                    while (reader.Read())
                    {
                        value += reader.GetSqlInt32(0);
                    }
                }
            }
        }
    }
}