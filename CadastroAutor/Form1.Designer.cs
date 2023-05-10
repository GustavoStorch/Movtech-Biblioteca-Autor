namespace CadastroAutor
{
    partial class FormCadAutor
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblNome = new System.Windows.Forms.Label();
            this.lblInfoAutor = new System.Windows.Forms.Label();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.txtInfoAutor = new System.Windows.Forms.TextBox();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.btnExcluir = new System.Windows.Forms.Button();
            this.lblCodigo = new System.Windows.Forms.Label();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.imgAutor = new System.Windows.Forms.PictureBox();
            this.btnImgAutor = new System.Windows.Forms.Button();
            this.gridInfoAutor = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.imgAutor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridInfoAutor)).BeginInit();
            this.SuspendLayout();
            // 
            // lblNome
            // 
            this.lblNome.AccessibleName = "";
            this.lblNome.AutoSize = true;
            this.lblNome.Location = new System.Drawing.Point(9, 68);
            this.lblNome.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNome.Name = "lblNome";
            this.lblNome.Size = new System.Drawing.Size(55, 20);
            this.lblNome.TabIndex = 1;
            this.lblNome.Text = "Nome:";
            // 
            // lblInfoAutor
            // 
            this.lblInfoAutor.AccessibleName = "";
            this.lblInfoAutor.AutoSize = true;
            this.lblInfoAutor.Location = new System.Drawing.Point(9, 104);
            this.lblInfoAutor.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblInfoAutor.Name = "lblInfoAutor";
            this.lblInfoAutor.Size = new System.Drawing.Size(167, 20);
            this.lblInfoAutor.TabIndex = 2;
            this.lblInfoAutor.Text = "Informações do Autor:";
            // 
            // txtNome
            // 
            this.txtNome.Location = new System.Drawing.Point(200, 65);
            this.txtNome.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtNome.MaxLength = 50;
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(644, 26);
            this.txtNome.TabIndex = 3;
            // 
            // txtInfoAutor
            // 
            this.txtInfoAutor.Location = new System.Drawing.Point(200, 101);
            this.txtInfoAutor.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtInfoAutor.MaxLength = 1000;
            this.txtInfoAutor.Name = "txtInfoAutor";
            this.txtInfoAutor.Size = new System.Drawing.Size(644, 26);
            this.txtInfoAutor.TabIndex = 4;
            // 
            // btnSalvar
            // 
            this.btnSalvar.Location = new System.Drawing.Point(604, 150);
            this.btnSalvar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(116, 34);
            this.btnSalvar.TabIndex = 5;
            this.btnSalvar.Text = "Salvar";
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // btnExcluir
            // 
            this.btnExcluir.Location = new System.Drawing.Point(728, 150);
            this.btnExcluir.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(116, 34);
            this.btnExcluir.TabIndex = 6;
            this.btnExcluir.Text = "Excluir";
            this.btnExcluir.UseVisualStyleBackColor = true;
            this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click);
            // 
            // lblCodigo
            // 
            this.lblCodigo.AccessibleName = "";
            this.lblCodigo.AutoSize = true;
            this.lblCodigo.Location = new System.Drawing.Point(9, 31);
            this.lblCodigo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Size = new System.Drawing.Size(63, 20);
            this.lblCodigo.TabIndex = 7;
            this.lblCodigo.Text = "Código:";
            // 
            // txtCodigo
            // 
            this.txtCodigo.Enabled = false;
            this.txtCodigo.Location = new System.Drawing.Point(200, 28);
            this.txtCodigo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtCodigo.MaxLength = 3;
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(212, 26);
            this.txtCodigo.TabIndex = 8;
            this.txtCodigo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCodigo_KeyPress);
            // 
            // imgAutor
            // 
            this.imgAutor.BackColor = System.Drawing.SystemColors.Control;
            this.imgAutor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.imgAutor.Location = new System.Drawing.Point(852, 11);
            this.imgAutor.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.imgAutor.Name = "imgAutor";
            this.imgAutor.Size = new System.Drawing.Size(102, 113);
            this.imgAutor.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.imgAutor.TabIndex = 9;
            this.imgAutor.TabStop = false;
            // 
            // btnImgAutor
            // 
            this.btnImgAutor.Location = new System.Drawing.Point(852, 150);
            this.btnImgAutor.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnImgAutor.Name = "btnImgAutor";
            this.btnImgAutor.Size = new System.Drawing.Size(116, 34);
            this.btnImgAutor.TabIndex = 10;
            this.btnImgAutor.Text = "Carregar";
            this.btnImgAutor.UseVisualStyleBackColor = false;
            this.btnImgAutor.Click += new System.EventHandler(this.btnImgAutor_click);
            // 
            // gridInfoAutor
            // 
            this.gridInfoAutor.AllowUserToDeleteRows = false;
            this.gridInfoAutor.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridInfoAutor.BackgroundColor = System.Drawing.SystemColors.Control;
            this.gridInfoAutor.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gridInfoAutor.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridInfoAutor.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.gridInfoAutor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridInfoAutor.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.gridInfoAutor.GridColor = System.Drawing.SystemColors.Control;
            this.gridInfoAutor.Location = new System.Drawing.Point(13, 194);
            this.gridInfoAutor.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gridInfoAutor.MultiSelect = false;
            this.gridInfoAutor.Name = "gridInfoAutor";
            this.gridInfoAutor.RowHeadersWidth = 62;
            this.gridInfoAutor.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridInfoAutor.Size = new System.Drawing.Size(955, 227);
            this.gridInfoAutor.TabIndex = 11;
            this.gridInfoAutor.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.gridInfoAutor_MouseDoubleClick);
            // 
            // FormCadAutor
            // 
            this.AcceptButton = this.btnSalvar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(3340, 1506);
            this.Controls.Add(this.gridInfoAutor);
            this.Controls.Add(this.btnImgAutor);
            this.Controls.Add(this.imgAutor);
            this.Controls.Add(this.txtCodigo);
            this.Controls.Add(this.lblCodigo);
            this.Controls.Add(this.btnExcluir);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.txtInfoAutor);
            this.Controls.Add(this.txtNome);
            this.Controls.Add(this.lblInfoAutor);
            this.Controls.Add(this.lblNome);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.Name = "FormCadAutor";
            this.Text = "Novo Usuário";
            this.Load += new System.EventHandler(this.FormCadAutor_Load);
            ((System.ComponentModel.ISupportInitialize)(this.imgAutor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridInfoAutor)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblNome;
        private System.Windows.Forms.Label lblInfoAutor;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.TextBox txtInfoAutor;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.Button btnExcluir;
        private System.Windows.Forms.Label lblCodigo;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.PictureBox imgAutor;
        private System.Windows.Forms.Button btnImgAutor;
        private System.Windows.Forms.DataGridView gridInfoAutor;
    }
}

