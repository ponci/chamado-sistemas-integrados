using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Base
{
    public static class Conexao
    {
        public static IDbConnection Connection
        {
            get
            {
                return new MySqlConnection(@"Server=localhost;database=tcc;uid=root;pwd=;SslMode=none");
            }
        }

    }
}
