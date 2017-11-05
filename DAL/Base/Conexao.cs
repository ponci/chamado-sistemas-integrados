using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
                return new SqlConnection(@"");
            }
        }

    }
}
