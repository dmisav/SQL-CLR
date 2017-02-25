using Microsoft.SqlServer.Server;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace UserDefinedFunctions
{
    public class UserDefinedFunctions

    {
        [SqlFunction(FillRowMethodName = "SplitStringFillRow", TableDefinition = "part NVARCHAR(MAX), ID_ORDER INT")]
        static public IEnumerator SplitString(SqlString text, char[] delimiter)
        {
            if (text.IsNull) yield break;

            int valueIndex = 1;
            foreach (string s in text.Value.Split(delimiter, StringSplitOptions.RemoveEmptyEntries))
            {
                yield return new KeyValuePair<int, string>(valueIndex++, s.Trim());
            }
        }
        static public void SplitStringFillRow(object oKeyValuePair, out SqlString value, out SqlInt32 valueIndex)
        {
            KeyValuePair<int, string> keyValuePair = (KeyValuePair<int, string>)oKeyValuePair;

            valueIndex = keyValuePair.Key;
            value = keyValuePair.Value;
        }


        [SqlFunction(DataAccess = DataAccessKind.Read)]
        public static SqlBoolean UniqueValidation(SqlString username)
        {
            SqlBoolean returnValue = false;           

            using (SqlConnection conn = new SqlConnection("context connection=true"))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM [AdventureWorks2012].[HumanResources].[Employee] " +
                                                       "WHERE [LoginID] = @param", conn))
                {
                    cmd.Parameters.AddWithValue("@param", username);
                    var  rowCount = (int)cmd.ExecuteScalar();

                    if (rowCount == 0)
                        returnValue = true;

                    conn.Close();
                }
            }
            return returnValue;
        }
    }
}