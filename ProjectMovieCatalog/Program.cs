using ProjectMovieCatalog.Common;
using ProjectMovieCatalog.Data;
using ProjectMovieCatalog.Presentation;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMovieCatalog
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var connection = Database.GetConnection())
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("DELETE FROM [movies] DBCC CHECKIDENT ('[movies]', RESEED, 0) ", connection))
                {
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }

            Display d = new Display();
        }
    }
}
