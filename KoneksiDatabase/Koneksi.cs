using System;
using System.Collections.Generic;
// Jika Anda menggunakan .NET Core/.NET 5+, disarankan menggunakan Microsoft.Data.SqlClient
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoneksiDatabase
{
    internal class Koneksi
    {
        // Connection string yang sudah diperbaiki
        static string connString = "Data Source=BILGAS\\SQLEXPRESS;Initial Catalog=TokoDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;";

        public static SqlConnection GetConnection()
        {
            return new SqlConnection(connString);
        }
    }
}