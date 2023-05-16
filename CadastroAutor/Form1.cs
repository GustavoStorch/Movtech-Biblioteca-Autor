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

        //Botão com a funcionalidade de salvar/persistir os dados inseridos no banco de dados.
        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                using(SqlConnection connection = DaoConnection.GetConexao())
                {
                    AutorDAO dao = new AutorDAO(connection);

                    bool verificaCampos = dao.VerificaCampos(new AutorModel()
                    {
                        CodAutor = txtCodigo.Text,
                        NomeAutor = txtNome.Text
                    });

                    if(verificaCampos)
                    {
                        int count = dao.VerificaRegistros(new AutorModel()
                        {
                            CodAutor = txtCodigo.Text

                        });

                        if (count > 0)
                        {
                            dao.Editar(new AutorModel()
                            {
                                CodAutor = txtCodigo.Text,
                                NomeAutor = txtNome.Text,
                                Descricao = txtInfoAutor.Text
                            });
                            MessageBox.Show("Autor atualizado com sucesso!");
                        }
                        else
                        {
                            dao.Salvar(new AutorModel()
                            {
                                CodAutor = txtCodigo.Text,
                                NomeAutor = txtNome.Text,
                                Descricao = txtInfoAutor.Text
                            });
                            MessageBox.Show("Autor salvo com sucesso!");
                        }
                    }
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
        }

        //Botão que realiza o Delete de um registro no banco de dados.
        private void btnExcluir_Click(object sender, EventArgs e)
        {
            DialogResult conf = MessageBox.Show("Tem certeza que deseja excluir o Autor?", "Ops, tem certeza?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            try
            {
                if (conf == DialogResult.Yes)
                {
                    using (SqlConnection connection = DaoConnection.GetConexao())
                    {
                        AutorDAO dao = new AutorDAO(connection);

                        bool verificaCampos = dao.VerificaCampos(new AutorModel()
                        {
                            CodAutor = txtCodigo.Text,
                            NomeAutor = txtNome.Text
                        });

                        if (verificaCampos)
                        {

                            dao.Excluir(new AutorModel()
                            {
                                CodAutor = txtCodigo.Text
                            });
                            MessageBox.Show("Autor excluído com sucesso!");
                        }
                    }
                    
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