using System;
using System.Data;
using System.Data.SqlClient;

namespace BirthdayFunction.Services
{
    public class DBService
    {
        private static readonly string Connection_String = Environment.GetEnvironmentVariable("Connection_String");
        private static readonly string DB_Table = Environment.GetEnvironmentVariable("DB_Table");

        public DataTable GetBirthdayPersons()
        {
            string today = DateTime.Now.ToString("MMdd");

            SqlConnection sqlCon = new SqlConnection(Connection_String);
            SqlDataAdapter sqlda = new SqlDataAdapter($"SELECT * FROM {DB_Table} WHERE FORMAT(Birthdate, 'MMdd') = {today}", sqlCon);
            DataTable dataTable = new DataTable();
            sqlda.Fill(dataTable);

            return dataTable;
        }
    }
}
