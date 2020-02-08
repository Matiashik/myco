using System;
using System.Data.SqlClient;

namespace bin
{
    class Program
    {
        static void Main(string[] args)
        {
            var Con = new SqlConnection("Data Source=localhost;Initial Catalog=UVDB;User Id=universai;Password=solomatin11");
            Con.Open();
            var Stmt = Con.CreateCommand();
            Stmt.CommandText = "SELECT * FROM dbo.People";
            var Exq = Stmt.ExecuteReader();
            while(Exq.Read())
            {
                Console.Write(Exq.GetInt32(0) + " ");
                Console.WriteLine(Exq.GetString(1));
            }
            Con.Close();
        }
    }
}