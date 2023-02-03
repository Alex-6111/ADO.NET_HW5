using System.Data.SqlTypes;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks; 
using System.Data.SqlClient;

namespace ADO.NET_HW5
{
    internal class Program
    {
        static void Main(string[] args)
        {

        }

        public async Task ReadDataFromTSQLAsync(string connectionString)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();

                using (SqlCommand command = new SqlCommand("SELECT * FROM TableName", connection))
                {
                    using (SqlDataReader reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            // Обробка даних з reader
                        }
                    }
                }
            }
        }



        public async Task UpdateDataAsync(int id, string newValue)
        {
            using (SqlConnection connection = new SqlConnection("your_connection_string"))
            {
                await connection.OpenAsync();
                using (SqlCommand command = new SqlCommand("UPDATE your_table SET column_name = @newValue WHERE id = @id", connection))
                {
                    command.Parameters.AddWithValue("@id", id);
                    command.Parameters.AddWithValue("@newValue", newValue);
                    await command.ExecuteNonQueryAsync();
                }
            }
        }



    }
}