using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;
using System.IO;
using System.Threading;
using System.Security.Cryptography.X509Certificates;
using static System.Windows.Forms.LinkLabel;
using System.Runtime.CompilerServices;

namespace CadastroAutor
{
    public partial class FormCadAutor : Form
    {
        public String caminhoFoto { get; set; }

        public byte[] foto { get; set; }

        public FormCadAutor()
        {
            InitializeComponent();
        }

        private void FormCadAutor_Load(object sender, EventArgs e)
        {
            InitializeTable();
            CarregaID();
            btnExcluir.Enabled = false;
        }

        /*private void btnImgAutor_click(object sender, EventArgs e)
        {
            carregarFoto();
        }

        private void carregarFoto()
        {
            var openFile = new OpenFileDialog();
            openFile.Filter = "Arquivos de imagens jpg e png| *.jpg; *.png";
            openFile.Multiselect = false;

            if (openFile.ShowDialog() == DialogResult.OK)
            {
                caminhoFoto = openFile.FileName;
            }

            if (caminhoFoto != "")
            {
                imgAutor.Load(caminhoFoto);
            }
        }

        private byte[] GetFoto(String caminhoFoto)
        {
            try
            {
                byte[] foto;
                using (var stream = new FileStream(caminhoFoto, FileMode.Open, FileAccess.Read))
                {
                    using (var reader = new BinaryReader(stream))
                    {
                        foto = reader.ReadBytes((int)stream.Length);
                    }
                }
                return foto;
            } catch(Exception ex) { }
            {
                return null;
            }
            
        }*/

        //Botão com a funcionalidade de salvar/persistir os dados inseridos no banco de dados.
        private void btnSalvar_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(txtCodigo.Text) || string.IsNullOrWhiteSpace(txtCodigo.Text))
            {
                MessageBox.Show("Informe o campo do Código do Autor");
                return;
            } else if (string.IsNullOrEmpty(txtNome.Text) || string.IsNullOrWhiteSpace(txtNome.Text))
            {
                MessageBox.Show("Informe o campo do Nome do Autor");
                return;
            }


            try
            {
                using(SqlConnection connection = DaoConnection.GetConexao())
                {
                    AutorDAO dao = new AutorDAO(connection);

                    string sql2 = "SELECT COUNT(*) FROM mvtBibAutor WHERE codAutor = @codAutor";
                    SqlCommand cmdSelect = new SqlCommand(sql2, connection);
                    cmdSelect.Parameters.AddWithValue("@codAutor", txtCodigo.Text);
                    int count = Convert.ToInt32(cmdSelect.ExecuteScalar());

                    if(count > 0)
                    {
                        dao.Editar(new AutorModel()
                        {
                            CodAutor = txtCodigo.Text,
                            NomeAutor = txtNome.Text,
                            Descricao = txtInfoAutor.Text
                        });

                    } else
                    {
                        dao.Salvar(new AutorModel()
                        {
                            CodAutor = txtCodigo.Text,
                            NomeAutor = txtNome.Text,
                            Descricao = txtInfoAutor.Text
                        });
                    }
                    MessageBox.Show("Autor salvo com sucesso!");
                }

                    
                InitializeTable();
                limparForm();
                CarregaID();
                btnExcluir.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Houve um problema ao salvar o usuário!\n{ex.Message}");
            }



            /*try
            {
                //Verifica se o campo do código está vazio e realiza o insert.
                if (string.IsNullOrEmpty(this.txtCodigo.Text))
                {
                    sql = "INSERT INTO mvtBibAutor(nomeAutor, descricao, fotoAutor) VALUES(@nomeAutor, @descricao, @fotoAutor)";
                    SqlCommand c = new SqlCommand(sql, conn);

                    if (String.IsNullOrWhiteSpace(txtNome.Text))
                    {
                        MessageBox.Show("Erro: Preencha o nome do Autor!");
                    } else
                    {
                        c.Parameters.Add(new SqlParameter("@nomeAutor", this.txtNome.Text));
                    }
                    
                    c.Parameters.Add(new SqlParameter("@descricao", this.txtInfoAutor.Text));
                    c.Parameters.Add("@fotoAutor", System.Data.SqlDbType.Image, foto.Length).Value = foto;

                    conn.Open();
                    c.ExecuteNonQuery();
                    conn.Close();

                    MessageBox.Show("Enviado com sucesso!");

                    limparForm();
                    InitializeTable();
                    CarregaID();
                } else
                {
                    //Verifica se o código presente no textbox já está registrado dentro do banco de dados.
                    conn.Open();
                    string sql2 = "SELECT COUNT(*) FROM mvtBibAutor WHERE codAutor = @codAutor";
                    SqlCommand cmdSelect = new SqlCommand(sql2, conn);
                    cmdSelect.Parameters.AddWithValue("@codAutor", txtCodigo.Text);
                    int count = Convert.ToInt32(cmdSelect.ExecuteScalar());
                    conn.Close();

                    //Se o código estiver registrado no banco de dados realiza apenas o update.
                    if (count > 0)
                    {
                        sql = "UPDATE mvtBibAutor SET nomeAutor = @nomeAutor, descricao = @descricao, fotoAutor = @fotoAutor WHERE codAutor = @codAutor";
                        SqlCommand c = new SqlCommand(sql, conn);

                        c.Parameters.AddWithValue("@codAutor", txtCodigo.Text);

                        if (String.IsNullOrWhiteSpace(txtNome.Text))
                        {
                            MessageBox.Show("Erro: Preencha o nome do Autor!");
                        }
                        else
                        {
                            c.Parameters.Add(new SqlParameter("@nomeAutor", this.txtNome.Text));
                        }

                        c.Parameters.Add(new SqlParameter("@descricao", this.txtInfoAutor.Text));
                        c.Parameters.Add("@fotoAutor", System.Data.SqlDbType.Image, foto.Length).Value = foto;

                        conn.Open();
                        c.ExecuteNonQuery();
                        conn.Close();

                        MessageBox.Show("Atualizado com sucesso!");

                        limparForm();
                        InitializeTable();
                        CarregaID();
                        btnAtivo = false;
                        botaoAtivado();
                    } else
                    {
                        //Se não estiver registrado no banco de dados realiza o insert.
                        sql = "INSERT INTO mvtBibAutor(nomeAutor, descricao, fotoAutor) VALUES(@nomeAutor, @descricao, @fotoAutor)";
                        SqlCommand c = new SqlCommand(sql, conn);

                        if (String.IsNullOrWhiteSpace(txtNome.Text))
                        {
                            MessageBox.Show("Erro: Preencha o nome do Autor!");
                        }
                        else
                        {
                            c.Parameters.Add(new SqlParameter("@nomeAutor", this.txtNome.Text));
                        }

                        c.Parameters.Add(new SqlParameter("@descricao", this.txtInfoAutor.Text));
                        c.Parameters.Add("@fotoAutor", System.Data.SqlDbType.Image, foto.Length).Value = foto;

                        conn.Open();
                        c.ExecuteNonQuery();
                        conn.Close();

                        MessageBox.Show("Enviado com sucesso!");

                        limparForm();
                        InitializeTable();
                        CarregaID();
                    }
                }             
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Ocorreu o erro: " + ex);
            }
            finally
            {
                conn.Close();
            }*/
        }

        //Botão que realiza o Delete de um registro no banco de dados.
        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNome.Text))
            {
                MessageBox.Show("Informe o Autor!");
                return;
            }

            DialogResult conf = MessageBox.Show("Tem certeza que deseja excluir o Autor?", "Ops, tem certeza?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            try
            {
                if (conf == DialogResult.Yes)
                {
                    using (SqlConnection connection = DaoConnection.GetConexao())
                    {
                        AutorDAO dao = new AutorDAO(connection);

                        dao.Excluir(new AutorModel()
                        {
                            CodAutor = txtCodigo.Text
                        });
                    }
                    MessageBox.Show("Autor excluído com sucesso!");
                    InitializeTable();
                    limparForm();
                    CarregaID();
                    btnExcluir.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Houve um problema ao excluir o Autor!\n{ex.Message}");
            }
        }

        //Método que limpa o formulário toda vez que é salvo ou deletado um registro.
        public void limparForm()
        {
            txtCodigo.Text = String.Empty;
            txtInfoAutor.Text = String.Empty;
            txtNome.Text = String.Empty;

        }

        //Carrega todos os registros contidos no banco de dados para a DataGridView.
        private void InitializeTable()
        {
            dtgDadosAutor.Rows.Clear();
            using(SqlConnection connection = DaoConnection.GetConexao())
            {
                AutorDAO dao = new AutorDAO(connection);
                List<AutorModel> autores = dao.GetAutores();
                foreach(AutorModel autor in autores) {
                    DataGridViewRow row = dtgDadosAutor.Rows[dtgDadosAutor.Rows.Add()];
                    row.Cells[colCodAutor.Index].Value = autor.CodAutor;
                    row.Cells[colNomeAutor.Index].Value = autor.NomeAutor;
                    row.Cells[colDescAutor.Index].Value = autor.Descricao;
                }
            }
        }

        //Recupera o próximo id a ser cadastrado e joga ele para o textBox.
        private void CarregaID()
        {
            using (SqlConnection connection = DaoConnection.GetConexao())
            {

                SqlCommand cm = new SqlCommand("SELECT IDENT_CURRENT('mvtBibAutor') + 1", connection);
                int nextCod = Convert.ToInt32(cm.ExecuteScalar());

                txtCodigo.Text = nextCod.ToString();
            }
        }

        //Método que realiza o double click em uma linha da grid e joga todos os seus dados para as textBox.
        private void dtgDadosAutor_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex > -1 && e.ColumnIndex > -1)
            {
                txtCodigo.Text = dtgDadosAutor.Rows[e.RowIndex].Cells[colCodAutor.Index].Value + "";
                txtNome.Text = dtgDadosAutor.Rows[e.RowIndex].Cells[colNomeAutor.Index].Value + "";
                txtInfoAutor.Text = dtgDadosAutor.Rows[e.RowIndex].Cells[colDescAutor.Index].Value + "";

                if (string.IsNullOrEmpty(this.txtNome.Text))
                {
                    btnExcluir.Enabled = false;
                    CarregaID();
                }
                else
                {
                    btnExcluir.Enabled = true;
                }
            }
        }
    }
}