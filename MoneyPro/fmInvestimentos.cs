using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Modelos;
using BLL;
using System.Text.RegularExpressions;
using static Modelos.Tipo;
using System.Collections.Generic;

namespace MoneyPro
{
    public partial class fmInvestimentos : MoneyPro.Base.fmBaseTopoRodape
    {
        private fmCarteiraGraficoComparativo grafico = null;
        private int IDUsuario { get; set; }

        #region Singleton

        private static fmInvestimentos _singleton;

        private fmInvestimentos()
        {
            InitializeComponent();
        }

        public static fmInvestimentos CreateInstance()
        {
            if (_singleton == null)
            {
                _singleton = new fmInvestimentos();
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
            this.IDUsuario = Geral.UserID;
            CarregarDados(this.IDUsuario);
        }

        private void CarregarDados(int usuarioID)
        {
            CriarColunaTipoInvestimento(usuarioID);
            CriarColunaInstituicao(usuarioID);
            CriarColunaMoeda();
            CriarColunaRisco();
            CarregarInvestimentos(usuarioID);
            AjustarTamanhoMaximo();
        }

        private void AjustarTamanhoMaximo()
        {
            foreach (var item in investimentoDataGridView.Columns)
            {
                if (item is DataGridViewTextBoxColumn)
                {
                    DataGridViewTextBoxColumn col = (DataGridViewTextBoxColumn)item;

                    if (col.ValueType == typeof(string))
                    {
                        if (col.Name == "Apelido")
                            col.MaxInputLength = 40;
                        else if (col.Name == "Descricao")
                            col.MaxInputLength = 100;
                        else if (col.Name == "Consulta")
                            col.MaxInputLength = 25;
                        else if (col.Name == "Aplicacao")
                            col.MaxInputLength = 5;
                        else if (col.Name == "Resgate")
                            col.MaxInputLength = 5;
                        else if (col.Name == "Liquidacao")
                            col.MaxInputLength = 5;
                    }
                }
            }

        }

        private void CriarColunaTipoInvestimento(int usuarioID)
        {
            // Cria uma nova colluna do tipo ComboBox
            DataGridViewComboBoxColumn combo = new DataGridViewComboBoxColumn();
            combo.Name = "TipoInvestimento";
            combo.DataPropertyName = "TipoInvestimentoID";
            combo.DisplayMember = "Apelido";
            combo.ValueMember = "TipoInvestimentoID";
            combo.HeaderText = "Tipo de Investimento";
            combo.SortMode = DataGridViewColumnSortMode.Automatic;
            // Atributos de formato
            combo.FlatStyle = FlatStyle.Flat;
            combo.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;
            combo.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            combo.AutoComplete = true;
            combo.Width = 100;
            combo.FillWeight = 100;
            combo.MinimumWidth = 80;

            // Acha a posição da coluna numérica e coloca o combobox junto, deixando a coluna numérica invisível.
            int index = investimentoDataGridView.Columns["TipoInvestimentoID"].Index;
            investimentoDataGridView.Columns[index].Visible = false;
            investimentoDataGridView.Columns.Insert(index, combo);

            RecarregarColunaTipoInvestimento(usuarioID);
        }

        private void RecarregarColunaTipoInvestimento(int usuarioID)
        {
            DataGridViewComboBoxColumn combo = (DataGridViewComboBoxColumn)investimentoDataGridView.Columns["TipoInvestimento"];

            TipoInvestimentoBLL bll = new TipoInvestimentoBLL();
            combo.DataSource = bll.Listar(usuarioID);
        }

        private void CriarColunaInstituicao(int usuarioID)
        {
            // Cria uma nova colluna do tipo ComboBox
            DataGridViewComboBoxColumn combo = new DataGridViewComboBoxColumn();
            combo.Name = "Instituicao";
            combo.DataPropertyName = "InstituicaoID";
            combo.DisplayMember = "Apelido";
            combo.ValueMember = "InstituicaoID";
            combo.HeaderText = "Instituição";
            combo.SortMode = DataGridViewColumnSortMode.Automatic;
            // Atributos de formato
            combo.FlatStyle = FlatStyle.Flat;
            combo.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;
            combo.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            combo.AutoComplete = true;
            combo.Width = 100;
            combo.FillWeight = 80;
            combo.MinimumWidth = 50;

            // Acha a posição da coluna numérica e coloca o combobox junto, deixando a coluna numérica invisível.
            int index = investimentoDataGridView.Columns["InstituicaoID"].Index;
            investimentoDataGridView.Columns[index].Visible = false;
            investimentoDataGridView.Columns.Insert(index, combo);

            RecarregarColunaInstituicao(usuarioID);
        }

        private void RecarregarColunaInstituicao(int usuarioID)
        {
            DataGridViewComboBoxColumn combo = (DataGridViewComboBoxColumn)investimentoDataGridView.Columns["Instituicao"];

            InstituicaoBLL bll = new InstituicaoBLL();
            combo.DataSource = bll.Listar(usuarioID);
        }

        private void CriarColunaMoeda()
        {
            // Cria uma nova colluna do tipo ComboBox
            DataGridViewComboBoxColumn combo = new DataGridViewComboBoxColumn();
            combo.Name = "Moeda";
            combo.DataPropertyName = "MoedaID";
            combo.DisplayMember = "Simbolo";
            combo.ValueMember = "MoedaID";
            combo.HeaderText = "Moeda";
            combo.SortMode = DataGridViewColumnSortMode.Automatic;
            // Atributos de formato
            combo.FlatStyle = FlatStyle.Flat;
            combo.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;
            combo.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            combo.AutoComplete = true;
            combo.Width = 35;
            combo.FillWeight = 35;
            combo.MinimumWidth = 35;

            // Acha a posição da coluna numérica e coloca o combobox junto, deixando a coluna numérica invisível.
            int index = investimentoDataGridView.Columns["MoedaID"].Index;
            investimentoDataGridView.Columns[index].Visible = false;
            investimentoDataGridView.Columns.Insert(index, combo);

            RecarregarColunaMoeda();
        }

        private void RecarregarColunaMoeda()
        {
            DataGridViewComboBoxColumn combo = (DataGridViewComboBoxColumn)investimentoDataGridView.Columns["Moeda"];

            MoedaBLL bll = new MoedaBLL();
            combo.DataSource = bll.ListarMoedas();
        }

        private void CriarColunaRisco()
        {
            // Cria uma nova colluna do tipo ComboBox
            DataGridViewComboBoxColumn combo = new DataGridViewComboBoxColumn();
            combo.Name = "Risco";
            combo.DataPropertyName = "RiscoID";
            combo.DisplayMember = "Apelido";
            combo.ValueMember = "RiscoID";
            combo.HeaderText = "Risco";
            combo.SortMode = DataGridViewColumnSortMode.Automatic;
            // Atributos de formato
            combo.FlatStyle = FlatStyle.Flat;
            combo.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;
            combo.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            combo.AutoComplete = true;
            combo.Width = 100;
            combo.FillWeight = 80;
            combo.MinimumWidth = 80;

            // Acha a posição da coluna numérica e coloca o combobox junto, deixando a coluna numérica invisível.
            int index = investimentoDataGridView.Columns["MoedaID"].Index;
            investimentoDataGridView.Columns[index].Visible = false;
            investimentoDataGridView.Columns.Insert(index, combo);

            RiscoBLL bll = new RiscoBLL();
            combo.DataSource = bll.Listar();
        }

        private void CarregarInvestimentos(int usuarioID)
        {
            investimentoDataGridView.RowValidating -= investimentoDataGridView_RowValidating;

            InvestimentoBLL bll = new InvestimentoBLL();
            investimentoBindingSource.DataSource = bll.Listar(usuarioID);

            investimentoDataGridView.RowValidating += investimentoDataGridView_RowValidating;
        }

        private void toolTip_Draw(object sender, DrawToolTipEventArgs e)
        {
            e.DrawBackground();
            e.DrawBorder();
            e.DrawText();
        }

        private void btnTiposInvestimentos_Click(object sender, EventArgs e)
        {
            CarregarFormTipoInvestimentos();
        }

        private void CarregarFormTipoInvestimentos()
        {
            fmTiposInvestimentos form = new fmTiposInvestimentos();
            form.ShowDialog();
            RecarregarColunaTipoInvestimento(IDUsuario);
        }

        private void btnInstituicao_Click(object sender, EventArgs e)
        {
            CarregarFormInstituicoes();
        }

        private void CarregarFormInstituicoes()
        {
            fmInstituicoes form = new fmInstituicoes();
            form.ShowDialog();
            RecarregarColunaInstituicao(IDUsuario);
        }

        private void btnMoedas_Click(object sender, EventArgs e)
        {
            CarregarFormMoedas();
        }

        private void CarregarFormMoedas()
        {
            fmMoedas form = new fmMoedas();
            form.ShowDialog();
            RecarregarColunaMoeda();
        }

        private void buttonIncluir_Click(object sender, EventArgs e)
        {
            IncluirInvestimento();
        }

        private void IncluirInvestimento()
        {
            if (investimentoDataGridView.CurrentRow != null)
            {
                // Se a linha atual tiver índice menor que zero, o que indica que já há uma inclusão em curso.
                if ((int)investimentoDataGridView.CurrentRow.Cells["InvestimentoID"].Value < 0)
                {
                    // Cancela a inclusão, pois índices menores que zero estão em inclusão
                    return;
                }
            }

            DataTable table = (DataTable)investimentoBindingSource.DataSource;
            DataRow row = table.NewRow();

            row["InvestimentoID"] = InvestimentoBLL.ProximoID;
            row["UsuarioID"] = IDUsuario;
            row["Apelido"] = String.Empty;
            row["Descricao"] = String.Empty;
            row["Consulta"] = String.Empty;
            row["Ativo"] = true;
            row["Aplicacao"] = "D+0";
            row["Resgate"] = "D+0";
            row["Liquidacao"] = "D+0";
            row["TaxaAdministracao"] = 0;
            row["TaxaPerformance"] = 0;
            row["InicialMinimo"] = 0;
            row["MovimentoMinimo"] = 0;
            row["MovimentoMinimo"] = 0;

            table.Rows.Add(row);

            investimentoDataGridView.Focus();

            int lin = investimentoDataGridView.Rows.Count - 1;
            int col = Geral.PrimeiraColunaVisivel(investimentoDataGridView);
            investimentoDataGridView.CurrentCell = investimentoDataGridView.Rows[lin].Cells[col];
        }

        private void buttonExcluir_Click(object sender, EventArgs e)
        {
            ExcluirInvestimento();
        }

        private void ExcluirInvestimento()
        {
            if (investimentoDataGridView.CurrentRow != null)
            {
                InvestimentoBLL bll = new InvestimentoBLL();

                if (!bll.HaInvestimentos((int)investimentoDataGridView.CurrentRow.Cells["InvestimentoID"].Value))
                {

                    string msg = string.Format("Confirma a exclusão do investimento {0}?", (string)investimentoDataGridView.CurrentRow.Cells["Apelido"].Value);

                    DialogResult dr = MessageBox.Show(msg, "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

                    if (dr == DialogResult.Yes)
                    {
                        bll.Excluir((int)investimentoDataGridView.CurrentRow.Cells["InvestimentoID"].Value);
                        CarregarInvestimentos(IDUsuario);
                    }
                }
                else
                {
                    string msg = string.Format("O investimento {0} possui lançamentos e não pode ser excluído.", (string)investimentoDataGridView.CurrentRow.Cells["Apelido"].Value);

                    MessageBox.Show(msg, "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void fmInvestimentos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Modifiers == Keys.None && e.KeyCode == Keys.Insert)
            {
                // Se teclado insert chama rotina de inclusão.
                IncluirInvestimento();
            }
            else if (e.Modifiers == Keys.Control && e.KeyCode == Keys.Delete)
            {
                // Se teclado ctrl + delete chama rotina de exclusão.
                ExcluirInvestimento();
            }
            else if (e.Modifiers == Keys.None && e.KeyCode == Keys.Escape)
            {
                // Se teclado Escape (sem modificadores (Alt ou Ctrl ou Shift))
                CancelarLinhaNova();
            }
            else if (e.Modifiers == Keys.Alt && e.KeyCode == Keys.T)
            {
                // Se teclado Alt + T
                CarregarFormTipoInvestimentos();
            }
            else if (e.Modifiers == Keys.Alt && e.KeyCode == Keys.I)
            {
                // Se teclado Alt + I
                CarregarFormInstituicoes();
            }
            else if (e.Modifiers == Keys.Alt && e.KeyCode == Keys.M)
            {
                // Se teclado Alt + M
                CarregarFormMoedas();
            }
        }

        private void CancelarLinhaNova()
        {
            if (investimentoDataGridView.CurrentRow != null)
            {
                if ((int)investimentoDataGridView.CurrentRow.Cells["InvestimentoID"].Value < 0)
                {
                    investimentoDataGridView.Rows.Remove(investimentoDataGridView.CurrentRow);
                }
            }
        }

        private void investimentoDataGridView_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar))
            {
                // pega o número da coluna corrente
                int cell = investimentoDataGridView.CurrentCell.ColumnIndex;

                // pega o campo de dados associado a coluna
                string coluna = investimentoDataGridView.Columns[cell].DataPropertyName;

                if (coluna == "Apelido")
                {
                    // Recebe o sender como TextBox
                    TextBox textbox = (TextBox)sender;
                    // Aceita qualquer texto de 0 a 100 caracters
                    if (Regex.IsMatch(textbox.Text + e.KeyChar, "^.{0,25}$"))
                    {
                        Geral.Capitaliza(textbox);                     // Capitaliza o conteúdo do textbox
                    }
                    else
                    {
                        e.Handled = true;                              // não passou pela regex
                    }
                }
                else if (coluna == "Descricao")
                {
                    // Recebe o sender como TextBox
                    TextBox textbox = (TextBox)sender;
                    // Aceita qualquer texto de 0 a 100 caracters
                    if (Regex.IsMatch(textbox.Text + e.KeyChar, "^.{0,100}$"))
                    {
                        Geral.Capitaliza(textbox);                     // Capitaliza o conteúdo do textbox
                    }
                    else
                    {
                        e.Handled = true;                              // não passou pela regex
                    }
                }
                else if (coluna == "Consulta")
                {
                    // Recebe o sender como TextBox
                    TextBox textbox = (TextBox)sender;
                    // Aceita qualquer texto de 0 a 100 caracters
                    if (Regex.IsMatch(textbox.Text + e.KeyChar, "^.{0,25}$"))
                    {
                        Geral.Capitaliza(textbox);                     // Capitaliza o conteúdo do textbox
                    }
                    else
                    {
                        e.Handled = true;                              // não passou pela regex
                    }
                }
            }
        }

        private void investimentoDataGridView_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (investimentoDataGridView.RowCount > 0 && investimentoDataGridView.CurrentRow != null)
            {
                if (investimentoDataGridView.CurrentRow.Cells["InvestimentoID"].Value != null)
                {
                    if (investimentoDataGridView.IsCurrentRowDirty || (int)investimentoDataGridView.CurrentRow.Cells["InvestimentoID"].Value < 0)
                    {
                        DataGridViewRow linha = investimentoDataGridView.CurrentRow;

                        Investimento modelo = new Investimento();

                        modelo.InvestimentoID = (int)linha.Cells["InvestimentoID"].Value;
                        modelo.UsuarioID = (int)linha.Cells["UsuarioID"].Value;

                        if (linha.Cells["Apelido"].Value != DBNull.Value)
                            modelo.Apelido = (string)linha.Cells["Apelido"].Value;
                        else
                            modelo.Apelido = null;

                        if (linha.Cells["Descricao"].Value != DBNull.Value)
                            modelo.Descricao = (string)linha.Cells["Descricao"].Value;
                        else
                            modelo.Descricao = null;

                        if (linha.Cells["TipoInvestimentoID"].Value != DBNull.Value)
                            modelo.TipoInvestimentoID = (int)linha.Cells["TipoInvestimentoID"].Value;
                        else
                            modelo.TipoInvestimentoID = null;

                        if (linha.Cells["InstituicaoID"].Value != DBNull.Value)
                            modelo.InstituicaoID = (int)linha.Cells["InstituicaoID"].Value;
                        else
                            modelo.InstituicaoID = null;

                        if (linha.Cells["MoedaID"].Value != DBNull.Value)
                            modelo.MoedaID = (int)linha.Cells["MoedaID"].Value;
                        else
                            modelo.MoedaID = null;

                        if (linha.Cells["RiscoID"].Value != DBNull.Value)
                            modelo.RiscoID = (int)linha.Cells["RiscoID"].Value;
                        else
                            modelo.RiscoID = null;

                        if (linha.Cells["Consulta"].Value != DBNull.Value)
                            modelo.Consulta = (string)linha.Cells["Consulta"].Value;
                        else
                            modelo.Consulta = null;

                        if (linha.Cells["DataInicio"].Value != DBNull.Value)
                            modelo.DataInicio = (DateTime)linha.Cells["DataInicio"].Value;
                        else
                            modelo.DataInicio = null;

                        if (linha.Cells["CodigoAnbima"].Value != DBNull.Value)
                            modelo.CodigoAnbima = (string)linha.Cells["CodigoAnbima"].Value;
                        else
                            modelo.CodigoAnbima = null;

                        if (linha.Cells["Aplicacao"].Value != DBNull.Value)
                            modelo.Aplicacao = (string)linha.Cells["Aplicacao"].Value;
                        else
                            modelo.Aplicacao = "D+0";

                        if (linha.Cells["Resgate"].Value != DBNull.Value)
                            modelo.Resgate = (string)linha.Cells["Resgate"].Value;
                        else
                            modelo.Resgate = "D+0";

                        if (linha.Cells["Liquidacao"].Value != DBNull.Value)
                            modelo.Liquidacao = (string)linha.Cells["Liquidacao"].Value;
                        else
                            modelo.Liquidacao = "D+0";

                        if (linha.Cells["TaxaAdministracao"].Value != DBNull.Value)
                            modelo.TaxaAdministracao = (decimal)linha.Cells["TaxaAdministracao"].Value;
                        else
                            modelo.TaxaAdministracao = 0;

                        if (linha.Cells["TaxaPerformance"].Value != DBNull.Value)
                            modelo.TaxaPerformance = (decimal)linha.Cells["TaxaPerformance"].Value;
                        else
                            modelo.TaxaPerformance = 0;

                        if (linha.Cells["InicialMinimo"].Value != DBNull.Value)
                            modelo.InicialMinimo = (decimal)linha.Cells["InicialMinimo"].Value;
                        else
                            modelo.InicialMinimo = 0;

                        if (linha.Cells["MovimentoMinimo"].Value != DBNull.Value)
                            modelo.MovimentoMinimo = (decimal)linha.Cells["MovimentoMinimo"].Value;
                        else
                            modelo.MovimentoMinimo = 0;

                        if (linha.Cells["SaldoMinimo"].Value != DBNull.Value)
                            modelo.SaldoMinimo = (decimal)linha.Cells["SaldoMinimo"].Value;
                        else
                            modelo.SaldoMinimo = 0;

                        modelo.Ativo = (bool)linha.Cells["Ativo"].Value;

                        InvestimentoBLL bll = new InvestimentoBLL();

                        if (bll.Validar(modelo))
                        {
                            try
                            {
                                int registro = bll.Gravar(modelo);
                                CarregarInvestimentos(IDUsuario);
                            }
                            catch (ArgumentException ex)
                            {
                                MessageBox.Show(ex.ParamName, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                e.Cancel = true;
                            }
                        }
                        else
                        {
                            // Não passou pela validação.
                            e.Cancel = true;
                        }
                    }
                }
            }
        }

        private void investimentoDataGridView_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            investimentoDataGridView.EditingControl.KeyPress += investimentoDataGridView_KeyPress;
        }

        private void buttonTaxas_Click(object sender, EventArgs e)
        {
            CarregarFormTaxas();
        }

        private void CarregarFormTaxas()
        {
            if (investimentoDataGridView.CurrentRow != null)
            {
                if (investimentoDataGridView.CurrentRow.Cells["InvestimentoID"].Value != DBNull.Value)
                {
                    int investimentoID = (int)investimentoDataGridView.CurrentRow.Cells["InvestimentoID"].Value;
                    fmInvestimentoDespesas form = new fmInvestimentoDespesas(investimentoID);
                    form.ShowDialog();
                }
            }
        }

        private void btnTributacao_Click(object sender, EventArgs e)
        {
            fmImposto form = new fmImposto();
            form.ShowDialog();
        }

        private void investimentoDataGridView_Paint(object sender, PaintEventArgs e)
        {

        }

        private void investimentoDataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (investimentoDataGridView.CurrentRow != null)
            {
                if (e.Value != null)
                {
                    if (investimentoDataGridView.Columns[e.ColumnIndex].Name == "Risco")
                    {
                        if (investimentoDataGridView.Rows[e.RowIndex].Cells["RiscoID"].Value != DBNull.Value)
                        {

                            ClassificacaoRisco risco = (ClassificacaoRisco)investimentoDataGridView.Rows[e.RowIndex].Cells["RiscoID"].Value;

                            switch (risco)
                            {
                                case ClassificacaoRisco.Baixo:
                                    e.CellStyle.BackColor = Color.FromArgb(255, Color.FromArgb((Int32)CorRisco.Baixo));
                                    break;
                                case ClassificacaoRisco.MedioBaixo:
                                    e.CellStyle.BackColor = Color.FromArgb(255, Color.FromArgb((Int32)CorRisco.MedioBaixo));
                                    break;
                                case ClassificacaoRisco.Medio:
                                    e.CellStyle.BackColor = Color.FromArgb(255, Color.FromArgb((Int32)CorRisco.Medio));
                                    break;
                                case ClassificacaoRisco.MedioAlto:
                                    e.CellStyle.BackColor = Color.FromArgb(255, Color.FromArgb((Int32)CorRisco.MedioAlto));
                                    break;
                                case ClassificacaoRisco.Alto:
                                    e.CellStyle.BackColor = Color.FromArgb(255, Color.FromArgb((Int32)CorRisco.Alto));
                                    break;
                                default:
                                    break;
                            }
                        }
                    }
                }
            }
        }

        private void buttonGraficoComparativo_Click(object sender, EventArgs e)
        {

            if (investimentoDataGridView.SelectedCells.Count == 0)
            {
                MessageBox.Show("Selecione ao menos uma aplicação.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            //
            // Seleciona todas as linhas aonde há células selecionadas
            //

            // Gerará uma lista de linhas
            List<int> linhas = new List<int>();

            // Percorre todas as células selecionadas
            for (int i = 0; i < investimentoDataGridView.SelectedCells.Count; i++)
            {
                // Pega a linha da célula selecionada
                int indice = investimentoDataGridView.SelectedCells[i].RowIndex;
                // Verifica se não existe a linha na lista.
                if (!linhas.Exists(x => x.Equals(indice)))
                    // Nesse caso, adiciona a linha na lista de linhas
                    linhas.Add(indice);
            }

            // Ordena a lista
            linhas.Sort();

            // Percorre toda a lista de linhas
            foreach (int item in linhas)
            {
                // Marca cada linha como selecionada
                investimentoDataGridView.Rows[item].Selected = true;
            }

            // Deve haver de uma a cinco linhas de fundos selecionadas.
            if (investimentoDataGridView.SelectedRows.Count < 1 || investimentoDataGridView.SelectedRows.Count > 8)
            {
                // Percorre toda a lista de linhas
                foreach (int item in linhas)
                {
                    // Desmarca cada linha como selecionada
                    investimentoDataGridView.Rows[item].Selected = false;
                }

                MessageBox.Show("Selecione de um a oito itens para criar o gráfico.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            //
            // Cria uma janela com o gráfico comparativo dos investimentos
            // Ao fechar a janela criada, a atual é restaurada.
            //

            // Cria uma instância do form de detalhes
            grafico = fmCarteiraGraficoComparativo.CreateInstance(this, investimentoDataGridView);

            // Ajusta a aparência do formulário para que ele se encaixe no lugar do formulário atual 
            AjustaAparenciaSubForm(grafico);

            // Esconde o form atual
            this.WindowState = FormWindowState.Minimized;

            // Exibe o sub form
            grafico.Show();
            grafico.Focus();
        }

        private void AjustaAparenciaSubForm(Form subForm)
        {
            // Ajusta o form de detalhes para que seja semelhante ao da movimentação de contas

            // Atribui o MdiParent ao form atual
            subForm.MdiParent = this.MdiParent;
            // Remove as bordas
            subForm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            // Remove os botões (remover todos os botões faz com que o menu do filho não seja fundido (merged))
            subForm.ControlBox = false;
            subForm.MaximizeBox = false;
            subForm.MinimizeBox = false;
            // Desabilita exibição do ícone
            subForm.ShowIcon = false;
            // Maximiza
            subForm.WindowState = FormWindowState.Maximized;
            // Remove o título da janela
            subForm.Text = string.Empty;
            // Preenche o dock
            subForm.Dock = DockStyle.Fill;
            // Atribui o padding 3;3;3;3 (todos lados iguais)
            subForm.Padding = new Padding(3);
            // Procura groupbox no formulário
            foreach (Control C1 in subForm.Controls)
            {
                if (C1 is GroupBox)
                {
                    C1.Font = new Font("Microsoft Sans Serif", 10, FontStyle.Bold);
                    foreach (Control C2 in C1.Controls)
                    {
                        C2.Font = new Font("Microsoft Sans Serif", 8, FontStyle.Regular);
                    }
                }
                else
                {
                    C1.Font = new Font("Microsoft Sans Serif", 8, FontStyle.Regular);
                }
            }
        }

        private void fmInvestimentos_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (grafico != null)
            {
                grafico.Close();
            }
        }
    }
}
