using MoneyPro.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using Modelos;
using BLL;

namespace MoneyPro
{
    public partial class fmContas : MoneyPro.Base.fmBaseTopoRodape
    {
        private int IDUsuario { get; set; }
        private FmPrincipal Origem { get; set; }

        #region Singleton

        private static fmContas _singleton;

        private fmContas(FmPrincipal origem, int idusuario)
        {
            InitializeComponent();
            this.IDUsuario = idusuario;
            this.Origem = origem;
        }

        public static fmContas CreateInstance(FmPrincipal origem, int idusuario)
        {
            if (_singleton == null)
            {
                _singleton = new fmContas(origem, idusuario);
            }
            return _singleton;
        }

        protected override void OnClosed(EventArgs e)
        {
            _singleton = null;
            base.OnClosed(e);
        }

        #endregion Singleton

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            //IDUsuario = Geral.UserID;
            CarregaDados(IDUsuario);
        }

        private void CarregaDados(int _usuarioID)
        {
            // Se está exibindo apenas as contas ativas, exibe o botão Exibe Todas as Contas para poder
            // mudar o status.
            btnExibeTodasContas.Visible = !(this.Origem as FmPrincipal).Configuracoes.Contas_ExibeAtivas;
            btnExibeSomenteContasAtivas.Visible = !btnExibeTodasContas.Visible;

            contaDataGridView.Columns["Ativo"].Visible = (this.Origem as FmPrincipal).Configuracoes.Contas_ExibeAtivas;

            CriaColunaInstituicao(_usuarioID);
            CriaColunaTipoConta(_usuarioID);
            CriaColunaMoeda();
            CarregarContas(_usuarioID, (this.Origem as FmPrincipal).Configuracoes.Contas_ExibeAtivas);
        }

        private void CriaColunaMoeda()
        {
            string nomeColuna = "Moeda";
            MoedaBLL moeda = new MoedaBLL();

            // Cria uma nova colluna do tipo ComboBox
            DataGridViewComboBoxColumn combo = new DataGridViewComboBoxColumn();
            combo.Name = nomeColuna;
            combo.DataSource = moeda.ListarMoedas();
            combo.DataPropertyName = "MoedaID";
            combo.DisplayMember = "Simbolo";
            combo.ValueMember = "MoedaID";
            combo.HeaderText = "Moeda";
            combo.SortMode = DataGridViewColumnSortMode.Automatic;
            // Atributos de formato
            combo.FlatStyle = FlatStyle.Flat;
            combo.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing; // DropDownButton;
            combo.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            combo.AutoComplete = true;
            combo.Width = 50;
            combo.FillWeight = 50;
            combo.MinimumWidth = 50;

            if (!contaDataGridView.Columns.Contains(nomeColuna))
            {
                // Acha a posição da coluna numérica e coloca o combobox junto, deixando a coluna numérica invisível.
                int index = contaDataGridView.Columns["MoedaID"].Index;
                contaDataGridView.Columns[index].Visible = false;
                contaDataGridView.Columns.Insert(index, combo);
            }
            else
            {
                int index = contaDataGridView.Columns[nomeColuna].Index;
                contaDataGridView.Columns.RemoveAt(index);
                contaDataGridView.Columns.Insert(index, combo);
            }
        }

        private void RecarregarMoeda()
        {
            DataGridViewComboBoxColumn combo = (DataGridViewComboBoxColumn)contaDataGridView.Columns["Moeda"];

            MoedaBLL bll = new MoedaBLL();
            combo.DataSource = bll.ListarMoedas();
        }

        private void CriaColunaTipoConta(int _usuarioID)
        {
            string nomeColuna = "TipoConta";
            TipoContaBLL tipoConta = new TipoContaBLL();

            // Cria uma nova colluna do tipo ComboBox
            DataGridViewComboBoxColumn combo = new DataGridViewComboBoxColumn();
            combo.Name = nomeColuna;
            combo.DataSource = tipoConta.Listar(_usuarioID);
            combo.DataPropertyName = "TipoContaID";
            combo.DisplayMember = "Apelido";
            combo.ValueMember = "TipoContaID";
            combo.HeaderText = "Tipo Conta";
            combo.SortMode = DataGridViewColumnSortMode.Automatic;
            // Atributos de formato
            combo.FlatStyle = FlatStyle.Flat;
            combo.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing; // DropDownButton;
            combo.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            combo.AutoComplete = true;
            combo.Width = 180;
            combo.FillWeight = 180;
            combo.MinimumWidth = 120;

            // Acha a posição da coluna numérica e coloca o combobox junto, deixando a coluna numérica invisível.
            int index = contaDataGridView.Columns["TipoContaID"].Index;
            contaDataGridView.Columns[index].Visible = false;
            contaDataGridView.Columns.Insert(index, combo);
        }

        private void RecarregarTipoConta(int usuarioID)
        {
            DataGridViewComboBoxColumn combo = (DataGridViewComboBoxColumn)contaDataGridView.Columns["TipoConta"];

            TipoContaBLL bll = new TipoContaBLL();
            combo.DataSource = bll.Listar(usuarioID);
        }

        private void CriaColunaInstituicao(int _usuarioID)
        {
            string nomeColuna = "Instituicao";
            InstituicaoBLL instituicao = new InstituicaoBLL();

            // Cria uma nova colluna do tipo ComboBox
            DataGridViewComboBoxColumn combo = new DataGridViewComboBoxColumn();
            combo.Name = nomeColuna;
            combo.DataSource = instituicao.Listar(_usuarioID);
            combo.DataPropertyName = "InstituicaoID";
            combo.DisplayMember = "Apelido";
            combo.ValueMember = "InstituicaoID";
            combo.HeaderText = "Instituição";
            combo.SortMode = DataGridViewColumnSortMode.Automatic;
            // Atributos de formato
            combo.FlatStyle = FlatStyle.Flat;
            combo.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;  // DropDownButton;
            combo.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            combo.AutoComplete = true;
            combo.Width = 180;
            combo.FillWeight = 180;
            combo.MinimumWidth = 120;

            // Acha a posição da coluna numérica e coloca o combobox junto, deixando a coluna numérica invisível.
            int index = contaDataGridView.Columns["InstituicaoID"].Index;
            contaDataGridView.Columns[index].Visible = false;
            contaDataGridView.Columns.Insert(index, combo);
        }

        private void RecarregarInstituicao(int usuarioID)
        {
            DataGridViewComboBoxColumn combo = (DataGridViewComboBoxColumn)contaDataGridView.Columns["Instituicao"];

            InstituicaoBLL bll = new InstituicaoBLL();
            combo.DataSource = bll.Listar(usuarioID);
        }

        private void CarregarContas(int UsuarioID, Boolean TodasContas)
        {
            contaDataGridView.RowValidating -= contaDataGridView_RowValidating;

            ContaBLL bll = new ContaBLL();
            contaBindingSource.DataSource = bll.ListarContas(UsuarioID, TodasContas);

            contaDataGridView.Columns["Ativo"].Visible = TodasContas;

            // Troca todos os espaços dos cabeçalhos das colunas visíveis por espaços inseparáveis
            foreach (DataGridViewColumn col in contaDataGridView.Columns)
            {
                if (col.Visible)
                {
                    col.MinimumWidth = 10;
                    col.SortMode = DataGridViewColumnSortMode.NotSortable;
                    col.HeaderText = col.HeaderText.Trim().Replace(' ', '\u00A0');
                }
            }

            // Faz com que a altura da linha do cabeçalho seja igual ao das linhas do grid
            contaDataGridView.ColumnHeadersHeight = contaDataGridView.RowTemplate.Height;

            contaDataGridView.RowValidating += contaDataGridView_RowValidating;
        }

        private void toolTip_Draw(object sender, DrawToolTipEventArgs e)
        {
            e.DrawBackground();
            e.DrawBorder();
            e.DrawText();
        }

        private void btnMoedas_Click(object sender, EventArgs e)
        {
            CarregarFormMoedas();
        }

        private void CarregarFormMoedas()
        {
            fmMoedas moedas = new fmMoedas();
            moedas.ShowDialog();
            RecarregarMoeda();
        }

        private void fmContas_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Modifiers == Keys.Alt && e.KeyCode == Keys.M)
            {
                // Se teclado Alt + M, carrega cadastro de moedas.
                CarregarFormMoedas();
            }
            if (e.Modifiers == Keys.Alt && e.KeyCode == Keys.T)
            {
                // Se teclado Alt + T, carrega cadastro de tipo de contas.
                CarregarFormTiposContas();
            }
            if (e.Modifiers == Keys.Alt && e.KeyCode == Keys.I)
            {
                // Se teclado Alt + I, carrega cadastro de instituições
                CarregarFormInstituicoes();
            }
            if (e.Modifiers == Keys.None && e.KeyCode == Keys.Insert)
            {
                // Se teclado insert chama rotina de inclusão.
                IncluirConta();
            }
            else if (e.Modifiers == Keys.Control && e.KeyCode == Keys.Delete)
            {
                // Se teclado ctrl + delete chama rotina de exclusão.
                ExcluirConta();
            }
            else if (e.Modifiers == Keys.None && e.KeyCode == Keys.Escape)
            {
                // Se teclado Escape (sem modificadores (Alt ou Ctrl ou Shift))
                CancelarLinhaNova();
            }
        }

        private void CancelarLinhaNova()
        {
            if ((int)contaDataGridView.CurrentRow.Cells["ContaID"].Value < 0)
            {
                contaDataGridView.Rows.Remove(contaDataGridView.CurrentRow);
                CarregarContas(IDUsuario, (this.Origem as FmPrincipal).Configuracoes.Contas_ExibeAtivas);
            }
        }

        private void btnTipoConta_Click(object sender, EventArgs e)
        {
            CarregarFormTiposContas();
        }

        private void CarregarFormTiposContas()
        {
            fmTiposContas form = new fmTiposContas();
            form.ShowDialog();
            RecarregarTipoConta(IDUsuario);
        }

        private void btnInstituicao_Click(object sender, EventArgs e)
        {
            CarregarFormInstituicoes();
        }

        private void CarregarFormInstituicoes()
        {
            fmInstituicoes form = new fmInstituicoes();
            form.ShowDialog();
            RecarregarInstituicao(IDUsuario);
        }

        private void buttonIncluir_Click(object sender, EventArgs e)
        {
            IncluirConta();
        }

        private void buttonExcluir_Click(object sender, EventArgs e)
        {
            ExcluirConta();
        }

        private void IncluirConta()
        {
            // Se a linha atual não for nula
            if (contaDataGridView.CurrentRow != null)
            {
                // Se a linha atual tiver índice menor que zero, o que indica que já há uma inclusão em curso.
                if ((int)contaDataGridView.CurrentRow.Cells["ContaID"].Value < 0)
                {
                    // Cancela a inclusão, pois índices menores que zero estão em inclusão
                    return;
                }
            }

            DataTable table = (DataTable)contaBindingSource.DataSource;
            DataRow row = table.NewRow();

            row["ContaID"] = ContaBLL.ProximoID;
            row["UsuarioID"] = IDUsuario;
            row["InstituicaoID"] = DBNull.Value;
            row["TipoContaID"] = DBNull.Value;
            row["MoedaID"] = DBNull.Value;
            row["Apelido"] = String.Empty;
            row["Descricao"] = String.Empty;
            row["DataAbertura"] = DBNull.Value;
            row["SaldoInicial"] = 0.0;
            row["Limite"] = 0.0;
            row["OFX"] = false;
            row["CSV"] = false;
            row["Decimais"] = 2;
            row["UsaHora"] = false;
            row["Ativo"] = true;
            row["ExibirProjecao"] = false;

            table.Rows.Add(row);

            contaDataGridView.Focus();

            int lin = contaDataGridView.Rows.Count - 1;
            int col = Geral.PrimeiraColunaVisivel(contaDataGridView);
            contaDataGridView.CurrentCell = contaDataGridView.Rows[lin].Cells[col];
        }

        private void ExcluirConta()
        {
            if (contaDataGridView.CurrentRow != null)
            {
                string msg = String.Format("Deseja excluir a conta {0}?", (string)contaDataGridView.CurrentRow.Cells["Apelido"].Value);

                DialogResult dr = MessageBox.Show(msg, "Confirma",
                                                  MessageBoxButtons.YesNo,
                                                  MessageBoxIcon.Question,
                                                  MessageBoxDefaultButton.Button2);

                if (dr == DialogResult.Yes)
                {
                    ContaBLL bll = new ContaBLL();
                    bll.Excluir((int)contaDataGridView.CurrentRow.Cells["ContaID"].Value);
                    CarregarContas(IDUsuario, (this.Origem as FmPrincipal).Configuracoes.Contas_ExibeAtivas);
                }
            }
        }

        private void contaDataGridView_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (contaDataGridView.RowCount > 0 && contaDataGridView.CurrentRow != null && contaDataGridView.CurrentRow.Cells["ContaID"].Value != null)
            {
                if (contaDataGridView.IsCurrentRowDirty || (int)(contaDataGridView.CurrentRow.Cells["ContaID"].Value ?? 0) < 0)
                {
                    DataGridViewRow linha = contaDataGridView.CurrentRow;

                    Conta conta = new Conta
                    {
                        ContaID = (int)linha.Cells["ContaID"].Value,
                        UsuarioID = (int)linha.Cells["UsuarioID"].Value
                    };

                    if (linha.Cells["Instituicao"].Value != DBNull.Value)
                    {
                        conta.InstituicaoID = (int?)linha.Cells["Instituicao"].Value;
                    }
                    else
                    {
                        conta.InstituicaoID = null;
                    }

                    if (linha.Cells["TipoConta"].Value != DBNull.Value)
                    {
                        conta.TipoContaID = (int)linha.Cells["TipoConta"].Value;
                    }
                    else
                    {
                        conta.TipoContaID = null;
                    }

                    if (linha.Cells["Moeda"].Value != DBNull.Value)
                    {
                        conta.MoedaID = (int)linha.Cells["Moeda"].Value;
                    }
                    else
                    {
                        conta.MoedaID = null;
                    }

                    if (linha.Cells["DataAbertura"].Value != DBNull.Value)
                    {
                        conta.DataAbertura = (DateTime?)linha.Cells["DataAbertura"].Value;
                    }
                    else
                    {
                        conta.DataAbertura = null;
                    }
                    conta.Apelido = (string)linha.Cells["Apelido"].Value;
                    conta.Descricao = (string)linha.Cells["Descricao"].Value;
                    conta.SaldoInicial = (decimal?)linha.Cells["SaldoInicial"].Value;
                    conta.Limite = (decimal?)linha.Cells["Limite"].Value;
                    conta.OFX = (bool)linha.Cells["OFX"].Value;
                    conta.CSV = (bool)linha.Cells["CSV"].Value;
                    conta.Ativo = (bool)linha.Cells["Ativo"].Value;
                    conta.Decimais = (int)linha.Cells["Decimais"].Value;
                    conta.UsaHora = (bool)linha.Cells["UsaHora"].Value;
                    conta.ExibirProjecao = (bool)linha.Cells["ExibirProjecao"].Value;

                    if (linha.Cells["TipoArquivo"].Value != DBNull.Value)
                    {
                        conta.TipoArquivo = (string)linha.Cells["TipoArquivo"].Value;
                    }
                    else
                    {
                        conta.TipoArquivo = null;
                    }

                    ContaBLL bll = new ContaBLL();

                    if (bll.Validar(conta))
                    {
                        // Passou pela validação, tentará gravar
                        int registro = bll.Gravar(conta);
                        CarregarContas(IDUsuario, (this.Origem as FmPrincipal).Configuracoes.Contas_ExibeAtivas);
                        Origem.CarregarRolContasAsync();
                    }
                    else
                    {
                        e.Cancel = true;
                    }
                }
            }
        }

        private void contaDataGridView_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            contaDataGridView.EditingControl.KeyPress += contaDataGridView_KeyPress;
        }

        private void contaDataGridView_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar))
            {
                // pega o número da coluna corrente
                int cell = contaDataGridView.CurrentCell.ColumnIndex;

                // pega o campo de dados associado a coluna
                string coluna = contaDataGridView.Columns[cell].DataPropertyName;

                if (coluna == "Apelido")
                {
                    // Recebe o sender como TextBox
                    TextBox textbox = (TextBox)sender;
                    // Aceita qualquer texto de 0 a 25 caracters
                    if (!Regex.IsMatch(textbox.Text + e.KeyChar, "^.{0,40}$"))
                    {
                        e.Handled = true;                              // não passou pela regex
                    }
                }
                else if (coluna == "Descricao")
                {
                    // Recebe o sender como TextBox
                    TextBox textbox = (TextBox)sender;
                    // Aceita qualquer texto de 0 a 100 caracters
                    if (!Regex.IsMatch(textbox.Text + e.KeyChar, "^.{0,100}$"))
                    {
                        e.Handled = true;                              // não passou pela regex
                    }
                }
                else if (coluna == "DataAbertura")
                {
                    TextBox editingControl = (TextBox)sender;

                    if ((e.KeyChar == '+') || (e.KeyChar == '='))
                    {
                        // Se + ou = (dois valores da mesma tecla, mudados pelo shift)
                        // tenta avançar um dia na data
                        e.KeyChar = (char)Keys.None;
                        DateTime dt;
                        if (DateTime.TryParse(editingControl.Text, out dt))
                        {
                            dt = dt.AddDays(1);
                            editingControl.Text = dt.ToString().Substring(0, 10);
                            //dataGridViewMovimento.CurrentRow.Cells["Alterado"].Value = 1;
                            //                                dataGridViewMovimento.NotifyCurrentCellDirty(true);
                        }
                    }
                    else if ((e.KeyChar == '_') || (e.KeyChar == '-'))
                    {
                        // Se - ou _ (dois valores da mesma tecla, mudados pelo shift)
                        // tenta retroceder um dia na data
                        e.KeyChar = (char)Keys.None;
                        DateTime dt;
                        if (DateTime.TryParse(editingControl.Text, out dt))
                        {
                            dt = dt.AddDays(-1);
                            editingControl.Text = dt.ToString().Substring(0, 10);
                            //dataGridViewMovimento.CurrentRow.Cells["Alterado"].Value = 1;
                            //                                dataGridViewMovimento.NotifyCurrentCellDirty(true);
                        }
                    }
                    else
                    {
                        if (editingControl.Text == editingControl.SelectedText)
                        {
                            editingControl.Text = string.Empty;
                            editingControl.SelectionStart = editingControl.TextLength;
                            editingControl.SelectionLength = 0;
                        }

                        // Valida a data durante a digitação
                        e.Handled = !Geral.ValidarDataNaDigitacao(editingControl.Text + e.KeyChar);
                    }
                }
            }
        }

        private void contaDataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (contaDataGridView.CurrentRow != null)
            {
                if (e.ColumnIndex == contaDataGridView.Columns["SaldoInicial"].Index)
                {
                    // Está na coluna SaldoInicial
                    if ((decimal)contaDataGridView.Rows[e.RowIndex].Cells["SaldoInicial"].Value >= 0)
                    {
                        e.CellStyle.ForeColor = Color.Black;
                        e.CellStyle.SelectionForeColor = Color.White;
                    }
                    else
                    {
                        e.CellStyle.ForeColor = Color.Red;
                        e.CellStyle.SelectionForeColor = Color.Tomato;
                    }
                }
            }
        }

        private void BtnExibeTodasContas_Click(object sender, EventArgs e)
        {
            // Marca que deve exibir todas as contas
            btnExibeTodasContas.Visible = !btnExibeTodasContas.Visible;
            btnExibeSomenteContasAtivas.Visible = !btnExibeTodasContas.Visible;

            (this.Origem as FmPrincipal).Configuracoes.Contas_ExibeAtivas = btnExibeSomenteContasAtivas.Visible;

            CarregarContas(IDUsuario, (this.Origem as FmPrincipal).Configuracoes.Contas_ExibeAtivas);

            (this.Origem as FmPrincipal).ArmazenarConfiguracao();
        }
    }
}
