using System.Data.SqlClient;
using System.Collections.Generic;

namespace bin
{
    class Program
    {
        static void Main(string[] args)
        {
            var Con = new SqlConnection("Data Source=localhost;Initial Catalog=UVDB;User Id=Univ;Password=Solomatin11");
            Con.Open();
            var Stmt = Con.CreateCommand();
            //////////////////////////////////////////////////////
            Stmt.CommandText = "SELECT * FROM phones where TECH = 'XIAOMI'";
            var Exq = Stmt.ExecuteReader();
            var A = new List<int>();
            while(Exq.Read())
            {
                A.Add(Exq.GetInt32(1));
            }
            System.Console.WriteLine(A.ToArray().Length);
            //////////////////////////////////////////////////////
            Con.Close();
        }
    }
}