using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acme.DataAccessLayer.DbConnection
{
    public class Connection
    {
        public SqlConnection DbConnect()
        {
            SqlConnection conn = new SqlConnection("Data Source = BURAK; Initial Catalog = AcmeDb; Integrated Security = True");
            conn.Open();
            return conn;
        }

    }
}
