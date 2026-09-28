using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.IO;

namespace Cadastro_Produto
{
    public partial class Form1 : Form
    {
       
        private readonly string stringConexao =
    "server=localhost;database=cadastro_produtos;uid=root;pwd=minha_senha_segura;allowPublicKeyRetrieval=true;SslMode=None;";

        
        private string caminhoFotoSelecionada = string.Empty;

  
        private System.Windows.Forms.Timer timerAtualizacao;

        public Form1()
        {
            InitializeComponent();

           
            txtPrecoTotal.ReadOnly = true;
            txtPrecoTotal.BackColor = System.Drawing.SystemColors.Control;

            
            txtQuantidade.TextChanged += CalcularPrecoTotal;
            txtPrecoVenda.TextChanged += CalcularPrecoTotal;

           
            AtualizarDataGridView();

       
            ConfigurarTimerAtualizacao();
        }

        private void ConfigurarTimerAtualizacao()
        {
            timerAtualizacao = new System.Windows.Forms.Timer();
            timerAtualizacao.Interval = 30000;
            timerAtualizacao.Tick += (sender, e) => AtualizarDataGridView();
            timerAtualizacao.Start();
        }

       
        private void CalcularPrecoTotal(object sender, EventArgs e)
        {
            try
            {
               
                if (!string.IsNullOrWhiteSpace(txtQuantidade.Text) && !string.IsNullOrWhiteSpace(txtPrecoVenda.Text))
                {
                    int quantidade = int.Parse(txtQuantidade.Text);
                    decimal precoVenda = decimal.Parse(txtPrecoVenda.Text);

                 
                    decimal precoTotal = quantidade * precoVenda;

               
                    txtPrecoTotal.Text = precoTotal.ToString("F2");
                }
                else
                {
                    
                    txtPrecoTotal.Clear();
                }
            }
            catch (FormatException)
            {
                
                txtPrecoTotal.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao calcular preco total: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

       
        public void AtualizarDataGridView()
        {
            MySqlConnection conexao = new MySqlConnection(stringConexao); ;
            try
            {
               
               
                conexao.Open();

              
                string sql = @"SELECT 
                                codigo_interno AS 'Codigo interno',
                                codigo_barra AS 'Codigo de barra',
                                descricao AS 'Descricao do Produto',
                                quantidade AS 'Quantidade',
                                preco_custo AS 'Preco de Custo',
                                preco_venda AS 'Preco de Venda',
                                (quantidade * preco_venda) AS 'Preco Total',
                                caminho_foto AS 'Caminho_Foto'
                               FROM produtos
                               ORDER BY codigo_interno";

               
                MySqlDataAdapter adaptador = new MySqlDataAdapter(sql, conexao);
                DataTable tabelaProdutos = new DataTable();
                adaptador.Fill(tabelaProdutos);

                
                dgvProdutos.DataSource = tabelaProdutos;

              
                if (dgvProdutos.Columns.Contains("Caminho_Foto"))
                {
                    dgvProdutos.Columns["Caminho_Foto"].Visible = false;
                }

               
                dgvProdutos.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            }
            catch (MySqlException ex)
            {
               
                MessageBox.Show("Erro no banco de dados ao atualizar lista: " + ex.Message, "Erro MySQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                
                MessageBox.Show("Erro ao atualizar lista de produtos: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
               
                if (conexao != null && conexao.State == ConnectionState.Open)
                {
                    conexao.Close();
                    conexao.Dispose();
                }
            }
        }

        private void btnProcurar_Click(object sender, EventArgs e)
        {
            MySqlConnection conexao = null;
            MySqlDataReader leitor = null;

            try
            {
               
                if (string.IsNullOrWhiteSpace(txtCodigoInterno.Text))
                {
                    MessageBox.Show("Informe o Codigo interno para procurar!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtCodigoInterno.Focus();
                    return;
                }

                string codigoBusca = txtCodigoInterno.Text.Trim();

                conexao = new MySqlConnection(stringConexao);
                conexao.Open();

                
                string sql = @"SELECT codigo_interno, codigo_barra, descricao, quantidade,
                                      preco_custo, preco_venda, caminho_foto
                               FROM produtos
                               WHERE codigo_interno = @codigoInterno";

                MySqlCommand comando = new MySqlCommand(sql, conexao);
                comando.Parameters.AddWithValue("@codigoInterno", codigoBusca);

                leitor = comando.ExecuteReader();

                if (leitor.Read())
                {
                   
                    txtCodigoInterno.Text = leitor["codigo_interno"].ToString();
                    txtCodigoBarra.Text = leitor["codigo_barra"].ToString();
                    txtDescricao.Text = leitor["descricao"].ToString();
                    txtQuantidade.Text = leitor["quantidade"].ToString();
                    txtPrecoCusto.Text = leitor["preco_custo"].ToString();
                    txtPrecoVenda.Text = leitor["preco_venda"].ToString();

                   
                    caminhoFotoSelecionada = leitor["caminho_foto"] != DBNull.Value ? leitor["caminho_foto"].ToString() : string.Empty;
                    if (!string.IsNullOrEmpty(caminhoFotoSelecionada) && File.Exists(caminhoFotoSelecionada))
                    {
                        picFotoProduto.ImageLocation = caminhoFotoSelecionada;
                    }
                    else
                    {
                        picFotoProduto.Image = null;
                    }

                    
                    MessageBox.Show("Produto encontrado!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Produto nao encontrado!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimparCampos();
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Erro no banco de dados ao procurar: " + ex.Message, "Erro MySQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao procurar produto: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
               
                if (leitor != null && !leitor.IsClosed)
                {
                    leitor.Close();
                    leitor.Dispose();
                }
                if (conexao != null && conexao.State == ConnectionState.Open)
                {
                    conexao.Close();
                    conexao.Dispose();
                }
            }
        }

       
        private void btnInserir_Click(object sender, EventArgs e)
        {
            MySqlConnection conexao = null;

            try
            {
                MessageBox.Show(
           "Caminho da foto:\n" + caminhoFotoSelecionada,
           "Teste da foto"
                         );
                
                if (string.IsNullOrWhiteSpace(txtCodigoInterno.Text) ||
                    string.IsNullOrWhiteSpace(txtDescricao.Text) ||
                    string.IsNullOrWhiteSpace(txtQuantidade.Text) ||
                    string.IsNullOrWhiteSpace(txtPrecoCusto.Text) ||
                    string.IsNullOrWhiteSpace(txtPrecoVenda.Text))
                {
                    MessageBox.Show("Preencha todos os campos obrigatorios! (Codigo interno, Descricao, Quantidade, Preco de Custo, Preco de Venda)", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

               
                if (!int.TryParse(txtQuantidade.Text, out int quantidade))
                {
                    MessageBox.Show("Quantidade invalida! Digite apenas numeros inteiros.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtQuantidade.Focus();
                    return;
                }
                if (!decimal.TryParse(txtPrecoCusto.Text, out decimal precoCusto))
                {
                    MessageBox.Show("Preco de Custo invalido! Digite um valor numerico.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtPrecoCusto.Focus();
                    return;
                }
                if (!decimal.TryParse(txtPrecoVenda.Text, out decimal precoVenda))
                {
                    MessageBox.Show("Preco de Venda invalido! Digite um valor numerico.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtPrecoVenda.Focus();
                    return;
                }

                conexao = new MySqlConnection(stringConexao);
                conexao.Open();

               
                string sql = @"INSERT INTO produtos
                                (codigo_interno, codigo_barra, descricao, quantidade, preco_custo, preco_venda, caminho_foto)
                               VALUES
                                (@codigoInterno, @codigoBarra, @descricao, @quantidade, @precoCusto, @precoVenda, @caminhoFoto)";

                MySqlCommand comando = new MySqlCommand(sql, conexao);
                comando.Parameters.AddWithValue("@codigoInterno", txtCodigoInterno.Text.Trim());
                comando.Parameters.AddWithValue("@codigoBarra", txtCodigoBarra.Text.Trim());
                comando.Parameters.AddWithValue("@descricao", txtDescricao.Text.Trim());
                comando.Parameters.AddWithValue("@quantidade", quantidade);
                comando.Parameters.AddWithValue("@precoCusto", precoCusto);
                comando.Parameters.AddWithValue("@precoVenda", precoVenda);
                comando.Parameters.AddWithValue("@caminhoFoto", caminhoFotoSelecionada);

                int linhasAfetadas = comando.ExecuteNonQuery();

                if (linhasAfetadas > 0)
                {
                    MessageBox.Show("Produto inserido com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimparCampos();
                    
                    AtualizarDataGridView();
                }
            }
            catch (MySqlException ex) when (ex.Number == 1062)
            {
               
                MessageBox.Show("Codigo interno ja cadastrado! Use um codigo diferente.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCodigoInterno.Focus();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Erro no banco de dados ao inserir: " + ex.Message, "Erro MySQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao inserir produto: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
               
                if (conexao != null && conexao.State == ConnectionState.Open)
                {
                    conexao.Close();
                    conexao.Dispose();
                }
            }
        }

        
        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            MySqlConnection conexao = null;

            try
            {
               
                if (string.IsNullOrWhiteSpace(txtCodigoInterno.Text) ||
                    string.IsNullOrWhiteSpace(txtDescricao.Text) ||
                    string.IsNullOrWhiteSpace(txtQuantidade.Text) ||
                    string.IsNullOrWhiteSpace(txtPrecoCusto.Text) ||
                    string.IsNullOrWhiteSpace(txtPrecoVenda.Text))
                {
                    MessageBox.Show("Preencha todos os campos obrigatorios!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

               
                if (!int.TryParse(txtQuantidade.Text, out int quantidade))
                {
                    MessageBox.Show("Quantidade invalida!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (!decimal.TryParse(txtPrecoCusto.Text, out decimal precoCusto) || !decimal.TryParse(txtPrecoVenda.Text, out decimal precoVenda))
                {
                    MessageBox.Show("Preco invalido! Digite valores numericos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                conexao = new MySqlConnection(stringConexao);
                conexao.Open();

               
                string sql = @"UPDATE produtos SET
                                codigo_barra = @codigoBarra,
                                descricao = @descricao,
                                quantidade = @quantidade,
                                preco_custo = @precoCusto,
                                preco_venda = @precoVenda,
                                caminho_foto = @caminhoFoto
                               WHERE codigo_interno = @codigoInterno";

                MySqlCommand comando = new MySqlCommand(sql, conexao);
                comando.Parameters.AddWithValue("@codigoInterno", txtCodigoInterno.Text.Trim());
                comando.Parameters.AddWithValue("@codigoBarra", txtCodigoBarra.Text.Trim());
                comando.Parameters.AddWithValue("@descricao", txtDescricao.Text.Trim());
                comando.Parameters.AddWithValue("@quantidade", quantidade);
                comando.Parameters.AddWithValue("@precoCusto", precoCusto);
                comando.Parameters.AddWithValue("@precoVenda", precoVenda);
                comando.Parameters.AddWithValue("@caminhoFoto", caminhoFotoSelecionada);

                int linhasAfetadas = comando.ExecuteNonQuery();

                if (linhasAfetadas > 0)
                {
                    MessageBox.Show("Produto atualizado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimparCampos();
                   
                    AtualizarDataGridView();
                }
                else
                {
                    MessageBox.Show("Produto nao encontrado para atualizacao! Verifique o Codigo interno.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Erro no banco de dados ao atualizar: " + ex.Message, "Erro MySQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao atualizar produto: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (conexao != null && conexao.State == ConnectionState.Open)
                {
                    conexao.Close();
                    conexao.Dispose();
                }
            }
        }

       
        private void btnDeletar_Click(object sender, EventArgs e)
        {
            MySqlConnection conexao = null;

            try
            {
                if (string.IsNullOrWhiteSpace(txtCodigoInterno.Text))
                {
                    MessageBox.Show("Informe o Codigo interno do produto para deletar!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtCodigoInterno.Focus();
                    return;
                }

               
                DialogResult confirmacao = MessageBox.Show("Tem certeza que deseja DELETAR este produto? Esta acao nao pode ser desfeita!", "Confirmacao de Exclusao", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirmacao != DialogResult.Yes)
                    return;

                string codigoDeletar = txtCodigoInterno.Text.Trim();

                conexao = new MySqlConnection(stringConexao);
                conexao.Open();

                string sql = "DELETE FROM produtos WHERE codigo_interno = @codigoInterno";

                MySqlCommand comando = new MySqlCommand(sql, conexao);
                comando.Parameters.AddWithValue("@codigoInterno", codigoDeletar);

                int linhasAfetadas = comando.ExecuteNonQuery();

                if (linhasAfetadas > 0)
                {
                    MessageBox.Show("Produto deletado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimparCampos();
                   
                    AtualizarDataGridView();
                }
                else
                {
                    MessageBox.Show("Produto nao encontrado para exclusao!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Erro no banco de dados ao deletar: " + ex.Message, "Erro MySQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao deletar produto: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (conexao != null && conexao.State == ConnectionState.Open)
                {
                    conexao.Close();
                    conexao.Dispose();
                }
            }
        }

     
        private void picFotoProduto_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                openFileDialogFoto.Filter = "Arquivos de Imagem|*.jpg;*.jpeg;*.png;*.bmp;*.gif|Todos os arquivos|*.*";
                openFileDialogFoto.Title = "Selecionar Foto do Produto";
                openFileDialogFoto.FileName = string.Empty;

                if (openFileDialogFoto.ShowDialog() == DialogResult.OK)
                {
                    caminhoFotoSelecionada = openFileDialogFoto.FileName;
                    picFotoProduto.ImageLocation = caminhoFotoSelecionada;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar foto: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LimparCampos()
        {
            txtCodigoInterno.Clear();
            txtCodigoBarra.Clear();
            txtDescricao.Clear();
            txtQuantidade.Clear();
            txtPrecoCusto.Clear();
            txtPrecoVenda.Clear();
            txtPrecoTotal.Clear();
            picFotoProduto.Image = null;
            caminhoFotoSelecionada = string.Empty;
            txtCodigoInterno.Focus();
        }

        private void dgvProdutos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
               
                if (e.RowIndex >= 0 && e.RowIndex < dgvProdutos.Rows.Count)
                {
                    DataGridViewRow linha = dgvProdutos.Rows[e.RowIndex];

                    
                    txtCodigoInterno.Text = linha.Cells["Codigo interno"].Value?.ToString() ?? string.Empty;
                    txtCodigoBarra.Text = linha.Cells["Codigo de barra"].Value?.ToString() ?? string.Empty;
                    txtDescricao.Text = linha.Cells["Descricao do Produto"].Value?.ToString() ?? string.Empty;
                    txtQuantidade.Text = linha.Cells["Quantidade"].Value?.ToString() ?? string.Empty;
                    txtPrecoCusto.Text = linha.Cells["Preco de Custo"].Value?.ToString() ?? string.Empty;
                    txtPrecoVenda.Text = linha.Cells["Preco de Venda"].Value?.ToString() ?? string.Empty;

                   
                    if (dgvProdutos.Columns.Contains("Caminho_Foto") && linha.Cells["Caminho_Foto"].Value != null && linha.Cells["Caminho_Foto"].Value != DBNull.Value)
                    {
                        caminhoFotoSelecionada = linha.Cells["Caminho_Foto"].Value.ToString();
                        if (File.Exists(caminhoFotoSelecionada))
                        {
                            picFotoProduto.ImageLocation = caminhoFotoSelecionada;
                        }
                        else
                        {
                            picFotoProduto.Image = null;
                        }
                    }
                    else
                    {
                        picFotoProduto.Image = null;
                        caminhoFotoSelecionada = string.Empty;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao selecionar produto: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (timerAtualizacao != null)
            {
                timerAtualizacao.Stop();
                timerAtualizacao.Dispose();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void lblFoto_Click(object sender, EventArgs e)
        {

        }

        private void lblTitulo_Click(object sender, EventArgs e)
        {

        }

        private void lblPrecoVenda_Click(object sender, EventArgs e)
        {

        }
    }
}
