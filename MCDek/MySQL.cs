using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

using MySql.Data.MySqlClient;
using MySql.Data.Types;

namespace MCLawl
{
    static class MySQL
    {
        private static string connString = "Data Source=" + Server.MySQLHost + ";Port=" + Server.MySQLPort + ";User ID=" + Server.MySQLUsername + ";Password=" + Server.MySQLPassword + ";Pooling=" + Server.MySQLPooling;

        public static void executeQuery(string queryString, bool createDB = false)
        {
            if (!Server.useMySQL) return;

            int totalCount = 0;
    retry:  try
            {
                using (var conn = new MySqlConnection(connString))
                {
                    conn.Open();
                    if (!createDB)
                    {
                        conn.ChangeDatabase(Server.MySQLDatabaseName);
                    }
                    MySqlCommand cmd = new MySqlCommand(queryString, conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
            catch (Exception e)
            {
                if (!createDB)
                {
                    totalCount++;
                    if (totalCount > 10)
                    {
                        File.WriteAllText("MySQL_error.log", queryString);
                        Server.ErrorLog(e);
                    }
                    else
                    {
                        goto retry;
                    }
                }
                else
                {
                    throw e;
                }
            }
        }

        public static DataTable fillData(string queryString, bool skipError = false)
        {
            DataTable toReturn = new DataTable("toReturn");
            if (!Server.useMySQL) return toReturn;

            int totalCount = 0;
    retry:  try
            {
                using (var conn = new MySqlConnection(connString))
                {
                    conn.Open();
                    conn.ChangeDatabase(Server.MySQLDatabaseName);
                    using (MySqlDataAdapter da = new MySqlDataAdapter(queryString, conn))
                    {
                        da.Fill(toReturn);
                    }
                    conn.Close();
                }
            }
            catch (Exception e)
            {
                totalCount++;
                if (totalCount > 10)
                {
                    if (!skipError)
                    {
                        File.WriteAllText("MySQL_error.log", queryString);
                        Server.ErrorLog(e);
                    }
                }
                else
                    goto retry;
            }

            return toReturn;
        }
    }
}
