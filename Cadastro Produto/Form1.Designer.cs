namespace Cadastro_Produto
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            lblTitulo = new System.Windows.Forms.Label();
            lblCodigoInterno = new System.Windows.Forms.Label();
            txtCodigoInterno = new System.Windows.Forms.TextBox();
            lblCodigoBarra = new System.Windows.Forms.Label();
            txtCodigoBarra = new System.Windows.Forms.TextBox();
            lblQuantidade = new System.Windows.Forms.Label();
            txtQuantidade = new System.Windows.Forms.TextBox();
            lblDescricao = new System.Windows.Forms.Label();
            txtDescricao = new System.Windows.Forms.TextBox();
            lblPrecoCusto = new System.Windows.Forms.Label();
            txtPrecoCusto = new System.Windows.Forms.TextBox();
            lblPrecoVenda = new System.Windows.Forms.Label();
            txtPrecoVenda = new System.Windows.Forms.TextBox();
            lblPrecoTotal = new System.Windows.Forms.Label();
            txtPrecoTotal = new System.Windows.Forms.TextBox();
            lblFoto = new System.Windows.Forms.Label();
            picFotoProduto = new System.Windows.Forms.PictureBox();
            lblProdutosCadastrados = new System.Windows.Forms.Label();
            dgvProdutos = new System.Windows.Forms.DataGridView();
            btnProcurar = new System.Windows.Forms.Button();
            btnInserir = new System.Windows.Forms.Button();
            btnAtualizar = new System.Windows.Forms.Button();
            btnDeletar = new System.Windows.Forms.Button();
            openFileDialogFoto = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)picFotoProduto).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvProdutos).BeginInit();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.BackColor = System.Drawing.Color.White;
            lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold);
            lblTitulo.Location = new System.Drawing.Point(444, 25);
            lblTitulo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new System.Drawing.Size(367, 39);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Cadastro de Produtos";
            lblTitulo.Click += lblTitulo_Click;
            // 
            // lblCodigoInterno
            // 
            lblCodigoInterno.AutoSize = true;
            lblCodigoInterno.Location = new System.Drawing.Point(170, 129);
            lblCodigoInterno.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblCodigoInterno.Name = "lblCodigoInterno";
            lblCodigoInterno.Size = new System.Drawing.Size(109, 20);
            lblCodigoInterno.TabIndex = 1;
            lblCodigoInterno.Text = "Codigo interno";
            // 
            // txtCodigoInterno
            // 
            txtCodigoInterno.Location = new System.Drawing.Point(67, 154);
            txtCodigoInterno.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            txtCodigoInterno.Name = "txtCodigoInterno";
            txtCodigoInterno.Size = new System.Drawing.Size(332, 27);
            txtCodigoInterno.TabIndex = 2;
            // 
            // lblCodigoBarra
            // 
            lblCodigoBarra.AutoSize = true;
            lblCodigoBarra.Location = new System.Drawing.Point(610, 129);
            lblCodigoBarra.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblCodigoBarra.Name = "lblCodigoBarra";
            lblCodigoBarra.Size = new System.Drawing.Size(118, 20);
            lblCodigoBarra.TabIndex = 3;
            lblCodigoBarra.Text = "Codigo de barra";
            // 
            // txtCodigoBarra
            // 
            txtCodigoBarra.Location = new System.Drawing.Point(507, 154);
            txtCodigoBarra.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            txtCodigoBarra.Name = "txtCodigoBarra";
            txtCodigoBarra.Size = new System.Drawing.Size(332, 27);
            txtCodigoBarra.TabIndex = 4;
            // 
            // lblQuantidade
            // 
            lblQuantidade.AutoSize = true;
            lblQuantidade.Location = new System.Drawing.Point(989, 129);
            lblQuantidade.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblQuantidade.Name = "lblQuantidade";
            lblQuantidade.Size = new System.Drawing.Size(87, 20);
            lblQuantidade.TabIndex = 5;
            lblQuantidade.Text = "Quantidade";
            // 
            // txtQuantidade
            // 
            txtQuantidade.Location = new System.Drawing.Point(933, 154);
            txtQuantidade.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            txtQuantidade.Name = "txtQuantidade";
            txtQuantidade.Size = new System.Drawing.Size(199, 27);
            txtQuantidade.TabIndex = 6;
            // 
            // lblDescricao
            // 
            lblDescricao.AutoSize = true;
            lblDescricao.Location = new System.Drawing.Point(373, 215);
            lblDescricao.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblDescricao.Name = "lblDescricao";
            lblDescricao.Size = new System.Drawing.Size(153, 20);
            lblDescricao.TabIndex = 7;
            lblDescricao.Text = "Descricao do Produto";
            // 
            // txtDescricao
            // 
            txtDescricao.Location = new System.Drawing.Point(67, 246);
            txtDescricao.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            txtDescricao.Name = "txtDescricao";
            txtDescricao.Size = new System.Drawing.Size(772, 27);
            txtDescricao.TabIndex = 8;
            // 
            // lblPrecoCusto
            // 
            lblPrecoCusto.AutoSize = true;
            lblPrecoCusto.Location = new System.Drawing.Point(138, 308);
            lblPrecoCusto.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblPrecoCusto.Name = "lblPrecoCusto";
            lblPrecoCusto.Size = new System.Drawing.Size(108, 20);
            lblPrecoCusto.TabIndex = 9;
            lblPrecoCusto.Text = "Preco de Custo";
            // 
            // txtPrecoCusto
            // 
            txtPrecoCusto.Location = new System.Drawing.Point(67, 338);
            txtPrecoCusto.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            txtPrecoCusto.Name = "txtPrecoCusto";
            txtPrecoCusto.Size = new System.Drawing.Size(239, 27);
            txtPrecoCusto.TabIndex = 10;
            // 
            // lblPrecoVenda
            // 
            lblPrecoVenda.AutoSize = true;
            lblPrecoVenda.Location = new System.Drawing.Point(426, 308);
            lblPrecoVenda.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblPrecoVenda.Name = "lblPrecoVenda";
            lblPrecoVenda.Size = new System.Drawing.Size(112, 20);
            lblPrecoVenda.TabIndex = 11;
            lblPrecoVenda.Text = "Preco de Venda";
            lblPrecoVenda.Click += lblPrecoVenda_Click;
            // 
            // txtPrecoVenda
            // 
            txtPrecoVenda.Location = new System.Drawing.Point(373, 338);
            txtPrecoVenda.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            txtPrecoVenda.Name = "txtPrecoVenda";
            txtPrecoVenda.Size = new System.Drawing.Size(239, 27);
            txtPrecoVenda.TabIndex = 12;
            // 
            // lblPrecoTotal
            // 
            lblPrecoTotal.AutoSize = true;
            lblPrecoTotal.Location = new System.Drawing.Point(707, 308);
            lblPrecoTotal.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblPrecoTotal.Name = "lblPrecoTotal";
            lblPrecoTotal.Size = new System.Drawing.Size(104, 20);
            lblPrecoTotal.TabIndex = 13;
            lblPrecoTotal.Text = "Preco de Total";
            // 
            // txtPrecoTotal
            // 
            txtPrecoTotal.Location = new System.Drawing.Point(680, 338);
            txtPrecoTotal.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            txtPrecoTotal.Name = "txtPrecoTotal";
            txtPrecoTotal.Size = new System.Drawing.Size(159, 27);
            txtPrecoTotal.TabIndex = 14;
            // 
            // lblFoto
            // 
            lblFoto.AutoSize = true;
            lblFoto.Location = new System.Drawing.Point(989, 215);
            lblFoto.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblFoto.Name = "lblFoto";
            lblFoto.Size = new System.Drawing.Size(119, 20);
            lblFoto.TabIndex = 15;
            lblFoto.Text = "Foto do produto";
            lblFoto.Click += lblFoto_Click;
            // 
            // picFotoProduto
            // 
            picFotoProduto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            picFotoProduto.Location = new System.Drawing.Point(933, 246);
            picFotoProduto.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            picFotoProduto.Name = "picFotoProduto";
            picFotoProduto.Size = new System.Drawing.Size(239, 230);
            picFotoProduto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            picFotoProduto.TabIndex = 16;
            picFotoProduto.TabStop = false;
            picFotoProduto.DoubleClick += picFotoProduto_DoubleClick;
            // 
            // lblProdutosCadastrados
            // 
            lblProdutosCadastrados.AutoSize = true;
            lblProdutosCadastrados.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);
            lblProdutosCadastrados.Location = new System.Drawing.Point(400, 492);
            lblProdutosCadastrados.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblProdutosCadastrados.Name = "lblProdutosCadastrados";
            lblProdutosCadastrados.Size = new System.Drawing.Size(267, 29);
            lblProdutosCadastrados.TabIndex = 17;
            lblProdutosCadastrados.Text = "Produtos cadastrados";
            // 
            // dgvProdutos
            // 
            dgvProdutos.AllowUserToAddRows = false;
            dgvProdutos.AllowUserToDeleteRows = false;
            dgvProdutos.AllowUserToResizeRows = false;
            dgvProdutos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dgvProdutos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProdutos.Location = new System.Drawing.Point(2, 538);
            dgvProdutos.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            dgvProdutos.MultiSelect = false;
            dgvProdutos.Name = "dgvProdutos";
            dgvProdutos.ReadOnly = true;
            dgvProdutos.RowHeadersVisible = false;
            dgvProdutos.RowHeadersWidth = 51;
            dgvProdutos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            dgvProdutos.Size = new System.Drawing.Size(1002, 431);
            dgvProdutos.TabIndex = 18;
            dgvProdutos.CellClick += dgvProdutos_CellClick;
            // 
            // btnProcurar
            // 
            btnProcurar.BackColor = System.Drawing.Color.Blue;
            btnProcurar.ForeColor = System.Drawing.Color.White;
            btnProcurar.Location = new System.Drawing.Point(1012, 538);
            btnProcurar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            btnProcurar.Name = "btnProcurar";
            btnProcurar.Size = new System.Drawing.Size(160, 62);
            btnProcurar.TabIndex = 19;
            btnProcurar.Text = "PROCURAR";
            btnProcurar.UseVisualStyleBackColor = false;
            btnProcurar.Click += btnProcurar_Click;
            // 
            // btnInserir
            // 
            btnInserir.BackColor = System.Drawing.Color.FromArgb(0, 192, 0);
            btnInserir.ForeColor = System.Drawing.Color.White;
            btnInserir.Location = new System.Drawing.Point(1012, 629);
            btnInserir.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            btnInserir.Name = "btnInserir";
            btnInserir.Size = new System.Drawing.Size(160, 62);
            btnInserir.TabIndex = 20;
            btnInserir.Text = "INSERIR";
            btnInserir.UseVisualStyleBackColor = false;
            btnInserir.Click += btnInserir_Click;
            // 
            // btnAtualizar
            // 
            btnAtualizar.BackColor = System.Drawing.Color.Gray;
            btnAtualizar.ForeColor = System.Drawing.Color.White;
            btnAtualizar.Location = new System.Drawing.Point(1012, 723);
            btnAtualizar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            btnAtualizar.Name = "btnAtualizar";
            btnAtualizar.Size = new System.Drawing.Size(160, 62);
            btnAtualizar.TabIndex = 21;
            btnAtualizar.Text = "ATUALIZAR";
            btnAtualizar.UseVisualStyleBackColor = false;
            btnAtualizar.Click += btnAtualizar_Click;
            // 
            // btnDeletar
            // 
            btnDeletar.BackColor = System.Drawing.Color.FromArgb(192, 0, 0);
            btnDeletar.ForeColor = System.Drawing.Color.White;
            btnDeletar.Location = new System.Drawing.Point(1012, 821);
            btnDeletar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            btnDeletar.Name = "btnDeletar";
            btnDeletar.Size = new System.Drawing.Size(160, 62);
            btnDeletar.TabIndex = 22;
            btnDeletar.Text = "DELETAR";
            btnDeletar.UseVisualStyleBackColor = false;
            btnDeletar.Click += btnDeletar_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1227, 969);
            Controls.Add(btnDeletar);
            Controls.Add(btnAtualizar);
            Controls.Add(btnInserir);
            Controls.Add(btnProcurar);
            Controls.Add(dgvProdutos);
            Controls.Add(lblProdutosCadastrados);
            Controls.Add(picFotoProduto);
            Controls.Add(lblFoto);
            Controls.Add(txtPrecoTotal);
            Controls.Add(lblPrecoTotal);
            Controls.Add(txtPrecoVenda);
            Controls.Add(lblPrecoVenda);
            Controls.Add(txtPrecoCusto);
            Controls.Add(lblPrecoCusto);
            Controls.Add(txtDescricao);
            Controls.Add(lblDescricao);
            Controls.Add(txtQuantidade);
            Controls.Add(lblQuantidade);
            Controls.Add(txtCodigoBarra);
            Controls.Add(lblCodigoBarra);
            Controls.Add(txtCodigoInterno);
            Controls.Add(lblCodigoInterno);
            Controls.Add(lblTitulo);
            Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            Name = "Form1";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Cadastro de Produtos";
            FormClosing += Form1_FormClosing;
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)picFotoProduto).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvProdutos).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblCodigoInterno;
        private System.Windows.Forms.TextBox txtCodigoInterno;
        private System.Windows.Forms.Label lblCodigoBarra;
        private System.Windows.Forms.TextBox txtCodigoBarra;
        private System.Windows.Forms.Label lblQuantidade;
        private System.Windows.Forms.TextBox txtQuantidade;
        private System.Windows.Forms.Label lblDescricao;
        private System.Windows.Forms.TextBox txtDescricao;
        private System.Windows.Forms.Label lblPrecoCusto;
        private System.Windows.Forms.TextBox txtPrecoCusto;
        private System.Windows.Forms.Label lblPrecoVenda;
        private System.Windows.Forms.TextBox txtPrecoVenda;
        private System.Windows.Forms.Label lblPrecoTotal;
        private System.Windows.Forms.TextBox txtPrecoTotal;
        private System.Windows.Forms.Label lblFoto;
        private System.Windows.Forms.PictureBox picFotoProduto;
        private System.Windows.Forms.Label lblProdutosCadastrados;
        private System.Windows.Forms.DataGridView dgvProdutos;
        private System.Windows.Forms.Button btnProcurar;
        private System.Windows.Forms.Button btnInserir;
        private System.Windows.Forms.Button btnAtualizar;
        private System.Windows.Forms.Button btnDeletar;
        private System.Windows.Forms.OpenFileDialog openFileDialogFoto;
    }
}
