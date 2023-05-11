using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CadastroAutor
{
    public class AutorDAO
    {

        private SqlConnection Connection { get; }

        public AutorDAO(SqlConnection connection)
        {
            Connection = connection;
        }

        public void Salvar(AutorModel autor)
        {
            using (SqlCommand command = Connection.CreateCommand()) {
                SqlTransaction t = Connection.BeginTransaction();
                try
                {
                    StringBuilder sql = new StringBuilder();
                    sql.AppendLine($"INSERT INTO mvtBibAutor(nomeAutor, descricao) VALUES(@nomeAutor, @descricao)");
                    command.CommandText = sql.ToString();
                    command.Parameters.Add(new SqlParameter("@nomeAutor", autor.NomeAutor));
                    command.Parameters.Add(new SqlParameter("@descricao", autor.Descricao));
                    command.Transaction = t;
                    command.ExecuteNonQuery();
                    t.Commit();
                } catch (Exception ex)
                {
                    t.Rollback();
                    throw ex;
                }
            }
        }

        public void Editar(AutorModel autor)
        {
            using (SqlCommand command = Connection.CreateCommand())
            {
                SqlTransaction t = Connection.BeginTransaction();
                try
                {
                    StringBuilder sql = new StringBuilder();
                    sql.AppendLine($"UPDATE mvtBibAutor SET nomeAutor = @nomeAutor, descricao = @descricao WHERE codAutor = @codAutor");
                    command.CommandText = sql.ToString();
                    command.Parameters.AddWithValue("@codAutor", autor.CodAutor);
                    command.Parameters.Add(new SqlParameter("@nomeAutor", autor.NomeAutor));
                    command.Parameters.Add(new SqlParameter("@descricao", autor.Descricao));
                    command.Transaction = t;
                    command.ExecuteNonQuery();
                    t.Commit();
                }
                catch (Exception ex)
                {
                    t.Rollback();
                    throw ex;
                }
            }
        }

        public void Excluir(AutorModel autor, SqlTransaction t = null)
        {
            using (SqlCommand command = Connection.CreateCommand())
            {
                if (t != null)
                {
                    command.Transaction = t;
                }
                StringBuilder sql = new StringBuilder();
                sql.AppendLine($"DELETE FROM mvtBibAutor WHERE codAutor = @codAutor");
                command.CommandText = sql.ToString();
                command.Parameters.Add(new SqlParameter("@codAutor", autor.CodAutor));
                command.ExecuteNonQuery();
            }
        }

        public int VerificaRegistros(AutorModel autor)
        {
            using (SqlCommand command = Connection.CreateCommand())
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine($"SELECT COUNT(*) FROM mvtBibAutor WHERE codAutor = @codAutor");
                command.CommandText = sql.ToString();
                command.Parameters.AddWithValue("@codAutor", autor.CodAutor);
                int count = Convert.ToInt32(command.ExecuteScalar());
                return count;
            }
        }

        public List<AutorModel> GetAutores()
        {
            List<AutorModel> autores = new List<AutorModel>();
            using(SqlCommand command = Connection.CreateCommand()) { 
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT AUT.codAutor, AUT.nomeAutor, AUT.descricao FROM mvtBibAutor AUT ORDER BY AUT.codAutor");
                command.CommandText = sql.ToString();   
                using(SqlDataReader dr = command.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        autores.Add(PopulateDr(dr));
                    }
                }
            }
            return autores;
        }

        private AutorModel PopulateDr(SqlDataReader dr)
        {
            string codAutor = "";
            string nomeAutor = "";
            string descricao = "";

            if(DBNull.Value != dr["codAutor"])
            {
                codAutor = dr["codAutor"] + "";
            }
            if (DBNull.Value != dr["nomeAutor"])
            {
                nomeAutor = dr["nomeAutor"] + "";
            }
            if (DBNull.Value != dr["descricao"])
            {
                descricao = dr["descricao"] + "";
            }
            return new AutorModel()
            {
                CodAutor = codAutor,
                NomeAutor = nomeAutor,
                Descricao = descricao
            };
        }
    }
}
