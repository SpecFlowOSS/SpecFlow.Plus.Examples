using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace TestCalculator
{
    public class DatabaseCalculator : ICalculator
    {
        private const string ConnectionString = "FullUri=file::memory:?cache=shared";

        public int Result { get; private set; }

        public void EnterNumber(int number)
        {
            using (var con = new SQLiteConnection(ConnectionString).OpenAndReturn())
            {
                var command = con.CreateCommand();
                command.CommandText = "INSERT INTO calc VALUES (?)";
                var param = command.CreateParameter();
                param.Value = number;
                command.Parameters.Add(param);
                command.ExecuteNonQuery();
            }
        }

        public void Add()
        {
            using (var con = new SQLiteConnection(ConnectionString).OpenAndReturn())
            {
                var command = con.CreateCommand();
                command.CommandText = "Select SUM(numbers) FROM calc";
                Result = Convert.ToInt32(command.ExecuteScalar());
            }
        }

        public void Clear()
        {
            using (var con = new SQLiteConnection(ConnectionString).OpenAndReturn())
            {
                var command1 = con.CreateCommand();
                command1.CommandText = "DROP TABLE IF EXISTS calc";
                command1.ExecuteNonQuery();

                var command2 = con.CreateCommand();
                command2.CommandText = "CREATE TABLE calc ( numbers INTEGER);";
                command2.ExecuteNonQuery();
            }
        }
    }
}
