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

        private SqlConnection conn;
        private bool btnAtivo;

        public FormCadAutor()
        {
            InitializeComponent();
        }

        private void FormCadAutor_Load(object sender, EventArgs e)
        {
            table_load();
            CarregaID();
            btnAtivo = false;
            botaoAtivado();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        //Cria a conexão com o banco de dados.
        private SqlConnection Conexao()
        {
            conn = new SqlConnection(@"Data Source=localhost\sqlexpress;Initial Catalog=Treinamento;Integrated Security=True");
            return conn;
        }

        //Método para ativar ou desativar o botão de excluir do usuário.
        private void botaoAtivado()
        {
            if (btnAtivo)
            {
                btnExcluir.Enabled = true;
            }
            else
            {
                btnExcluir.Enabled = false;
            }
        }

        private void btnImgAutor_click(object sender, EventArgs e)
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
            
        }

        //Botão com a funcionalidade de salvar/persistir os dados inseridos no banco de dados.
        private void btnSalvar_Click(object sender, EventArgs e)
        {
            conn = Conexao();
            String sql;
            byte[] foto = GetFoto(caminhoFoto);

            try
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
                    table_load();
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
                        table_load();
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
                        table_load();
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
            }
        }

        //Botão que realiza o Delete de um registro no banco de dados.
        private void btnExcluir_Click(object sender, EventArgs e)
        {
            conn = Conexao();
            String sql = "DELETE mvtBibAutor WHERE codAutor = @codAutor";

            try
            {
                SqlCommand c = new SqlCommand(sql, conn);

                c.Parameters.AddWithValue("@codAutor", txtCodigo.Text);

                conn.Open();
                c.ExecuteNonQuery();
                conn.Close();

                limparForm();
                table_load();
                CarregaID();
                btnAtivo = false;
                botaoAtivado();

                MessageBox.Show("Excluído com sucesso!");
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Ocorreu o erro: " + ex);
            }
            finally
            {
                conn.Close();
            }
        }

        //Método que limpa o formulário toda vez que é salvo ou deletado um registro.
        public void limparForm()
        {
            txtCodigo.Text = String.Empty;
            txtInfoAutor.Text = String.Empty;
            txtNome.Text = String.Empty;
            imgAutor.Image = null;

        }

        private void lblInfoAutor_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void gridInfoAutor_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        //Carrega todos os registros contidos no banco de dados para a DataGridView.
        private void table_load()
        {
            conn = Conexao();
            String sql = "SELECT codAutor AS Código, nomeAutor AS Nome, descricao AS InfoAutor FROM mvtBibAutor ORDER BY Nome";

            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(sql, conn);

                conn.Open();
                da.Fill(ds);
                gridInfoAutor.DataSource = ds.Tables[0];
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Ocorreu o erro: " + ex);
            }
            finally
            {
                conn.Close();
            }
        }

        //Método que faz com que apenas seja digitado números no campo do código.
        public static void IntNumber(KeyPressEventArgs e)
        {
            if(!char.IsDigit(e.KeyChar) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        private void txtCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            IntNumber(e);
        }

        //Método que realiza o double click em uma linha da grid e joga todos os seus dados para as textBox.
        private void gridInfoAutor_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if(gridInfoAutor.SelectedRows.Count > 0) {
                txtCodigo.Text = gridInfoAutor.SelectedRows[0].Cells[0].Value.ToString();
                txtNome.Text = gridInfoAutor.SelectedRows[0].Cells[1].Value.ToString();
                txtInfoAutor.Text = gridInfoAutor.SelectedRows[0].Cells[2].Value.ToString();

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

        //Recupera o próximo id a ser cadastrado e joga ele para o textBox.
        private void CarregaID()
        {
            conn = Conexao();
            conn.Open();

            SqlCommand cm = new SqlCommand("SELECT IDENT_CURRENT('mvtBibAutor') + 1", conn);
            int nextCod = Convert.ToInt32(cm.ExecuteScalar());

            txtCodigo.Text = nextCod.ToString();

            conn.Close();
        }
    }
}