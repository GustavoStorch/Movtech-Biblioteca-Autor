using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroAutor
{
    public class DaoConnection
    {
        public static SqlConnection GetConexao()
        {
            SqlConnection connection = new SqlConnection(@"Data Source=localhost\sqlexpress;Initial Catalog=Treinamento;Integrated Security=True;MultipleActiveResultSets=true;");
            connection.Open();
            return connection;
        }
    }
}
