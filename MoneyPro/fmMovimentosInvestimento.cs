using BLL;
using Modelos;
using System;
using System.Data;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace MoneyPro
{
    public partial class fmMovimentosInvestimento : MoneyPro.Base.fmBaseTopoRodape
    {
        private Form FormOrigem { get; set; }
        private int IDUsuario { get; set; }
        private int IDConta { get; set; }
        private int IDMovimentoConta { get; set; }
        private object Origem { get; set; }
        private bool Venda { get; set; }
        private bool Acao { get; set; }

        DataTable table = new DataTable();
        DataRow row = null;

        public fmMovimentosInvestimento(Form origem, int usuarioID, int contaID, int movimentoContaID)
        {
            InitializeComponent();
            this.FormOrigem = origem;
            this.IDUsuario = usuarioID;
            this.IDConta = contaID;
            this.IDMovimentoConta = movimentoContaID;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            CarregaBindings();

            CarregarMovimentoConta(IDMovimentoConta);

            if (IDMovimentoConta < 0)
            {
                labelTopo.Text = "Incluir Lançamento";
                IncluirMovimentoInvestimento();
            }
            else
            {
                labelTopo.Text = "Alterar Lançamento";
                AlterarMovimentoInvestimento();
                TransacaoCarregarInvestimentos();
            }

            AcessoAosComponentes(false);
        }

        private void CarregarMovimentoConta(int movimentoContaID)
        {
            MovimentoContaBLL bll = new MovimentoContaBLL();

            table = bll.Movimento(movimentoContaID);

            investimentoIDComboBox.SelectedIndexChanged -= investimentoIDComboBox_SelectedIndexChanged;

            movimentoContaBindingSource.DataSource = table;

            if (IDMovimentoConta > 0)
            {
                investimentoIDComboBox.Enabled = false;
                dataDateTimePicker.Leave -= dataDateTimePicker_Leave;

                // TODO Desabilitar botão salvar se conciliado = C ou R
            }
            else
            {
                investimentoIDComboBox.SelectedIndexChanged += investimentoIDComboBox_SelectedIndexChanged;
                //investimentoIDComboBox.SelectedIndexChanged -= investimentoIDComboBox_SelectedIndexChanged;
            }

            if (table.Rows.Count != 0)
                AtualizaCotacao();
        }

        private void IncluirMovimentoInvestimento()
        {
            row = ((DataTable)movimentoContaBindingSource.DataSource).NewRow();

            row["MovimentoContaID"] = MovimentoContaBLL.ProximoID;
            row["MovimentoInvestimentoID"] = MovimentoInvestimentoBLL.ProximoID;
            row["UsuarioID"] = IDUsuario;
            row["ContaID"] = IDConta;
            row["Data"] = Geral.UltimoDiaUtil(DateTime.Today.AddDays(-1));
            row["TransacaoID"] = DBNull.Value;
            row["InvestimentoID"] = DBNull.Value;
            row["CategoriaID"] = DBNull.Value;
            row["CrdDeb"] = " ";       // Será mudado conforme for preenchido os valores de débito ou crédito.
            row["Conciliacao"] = " ";  // Não conciliado
            row["Sistema"] = false;
            row["Legenda"] = 0;
            row["QtCotas"] = 0.0;
            row["VrCotacao"] = 0.0;
            row["VrBruto"] = 0.0;
            row["VrLiquido"] = 0.0;
            row["SldCotas"] = 0.0;
            row["VrDespesa"] = 0.0;

            try
            {
                table.Rows.Add(row);
            }
            catch (Exception e)
            {
                MessageBox.Show("Problemas ao criar a transação.\n" + e.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }

        private void AlterarMovimentoInvestimento()
        {
            row = ((DataTable)movimentoContaBindingSource.DataSource).Rows[0];
            //CarregaListaDespesas();
        }

        private void CarregaBindings()
        {
            transacaoIDComboBox.DataBindings.Clear();

            TransacaoBLL bll = new TransacaoBLL();
            transacaoBindingSource.DataSource = bll.Listar();

            // Binding para transacaos
            transacaoIDComboBox.DataBindings.Add("SelectedValue",
                                                 movimentoContaBindingSource,
                                                 "TransacaoID",
                                                 false,
                                                 DataSourceUpdateMode.OnPropertyChanged);

            // Binding para quantidade de cotas
            qtCotasTextBox.DataBindings.Clear();
            qtCotasTextBox.DataBindings.Add("Text",
                                            movimentoContaBindingSource,
                                            "QtCotas",
                                            true,
                                            DataSourceUpdateMode.OnValidation,
                                            null,
                                            "N9");

            // Binding para cotação
            vrCotaTextBox.DataBindings.Clear();
            vrCotaTextBox.DataBindings.Add("Text",
                                           movimentoContaBindingSource,
                                           "VrCotacao",
                                           true,
                                           DataSourceUpdateMode.OnValidation,
                                           null,
                                           "N9");

            // Binding para valor bruto (quantidade de cotas * cotação)
            vrBrutoTextBox.DataBindings.Clear();
            vrBrutoTextBox.DataBindings.Add("Text",
                                            movimentoContaBindingSource,
                                            "VrBruto",
                                            true,
                                            DataSourceUpdateMode.OnValidation,
                                            null,
                                            "N2");
        }

        private void CarregaInvestimentos(bool venda, bool fundo, bool acao)
        {
            InvestimentoBLL bll = new InvestimentoBLL();
            investimentoBindingSource.DataSource = bll.Listar(IDUsuario, venda, fundo, acao);
        }

        private void qtCotasTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Back)
            {
                TextBox textBox = (TextBox)sender;
                if (!textBox.ReadOnly)
                    if (textBox.SelectionLength == textBox.Text.Length)
                        textBox.Text = "";
            }
        }

        private void qtCotasTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            Origem = sender;
            if (!char.IsControl(e.KeyChar))
            {
                TextBox textBox = (TextBox)sender;

                if (textBox.SelectionLength == textBox.Text.Length)
                    textBox.Text = "";

                if (!Regex.IsMatch(textBox.Text + e.KeyChar, "^[+]?[0-9]{0,12}((,[0-9]{0,9})|())$"))
                    e.Handled = true;
            }
        }

        private void vrCotaTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (!vrCotaTextBox.ReadOnly)
            {
                if (e.KeyCode == Keys.Back)
                {
                    TextBox textBox = (TextBox)sender;
                    if (!textBox.ReadOnly)
                        if (textBox.SelectionLength == textBox.Text.Length)
                            textBox.Text = "";
                }
            }
        }

        private void vrCotaTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!vrCotaTextBox.ReadOnly)
            {
                Origem = sender;
                if (!char.IsControl(e.KeyChar))
                {
                    TextBox textBox = (TextBox)sender;

                    if (textBox.SelectionLength == textBox.Text.Length)
                        textBox.Text = "";

                    if (!Regex.IsMatch(textBox.Text + e.KeyChar, "^[+]?[0-9]{0,12}((,[0-9]{0,9})|())$"))
                        e.Handled = true;
                }
            }
        }

        private void investimentoIDComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (investimentoIDComboBox.SelectedValue != null)
            {
                row["InvestimentoID"] = investimentoIDComboBox.SelectedValue;

                if (Venda)
                {
                    // Carrega o saldo total disponível no text box qtCotasTextBox
                    DataTable investimentoTable = (DataTable)investimentoBindingSource.DataSource;
                    row["QtCotas"] = (Decimal)investimentoTable.Rows[investimentoIDComboBox.SelectedIndex]["QtCotas"];
                }
                else
                {
                    // No caso de compra sempre deixa zerado
                    row["QtCotas"] = 0;
                }

                AtualizaCotacao();
            }
            CarregaListaDespesas();
        }

        private void AtualizaCotacao()
        {
            // Pesquisa a cotação do investimento no dia.
            if (investimentoIDComboBox.SelectedValue != null && dataDateTimePicker.Value != null)
            {
                int investimento = (int)investimentoIDComboBox.SelectedValue;
                DateTime data = dataDateTimePicker.Value;
                decimal vrCotacao = -1;

                // CotacaoDia retorna true se a cotação for definitiva
                // O valor da cotação vem em vrCotacao
                InvestimentoBLL bll = new InvestimentoBLL();
                CVMcheckBox.Checked = bll.CotacaoDia(investimento, data, ref vrCotacao);

                if (vrCotacao >= 0)
                {
                    row["VrCotacao"] = Math.Round(vrCotacao, 9);
                }
            }
            else
            {
                CVMcheckBox.Checked = false;
            }
        }

        private void CarregaListaDespesas()
        {
            if (transacaoIDComboBox.SelectedValue != null && investimentoIDComboBox.SelectedValue != null)
            {
                DataTable transacaoTable = (DataTable)transacaoBindingSource.DataSource;
                DataRow transacaoRow = transacaoTable.Rows[transacaoIDComboBox.SelectedIndex];

                bool saida = (int)transacaoRow["Tipo"] == 2;

                DataTable investimentoTable = (DataTable)investimentoBindingSource.DataSource;
                DataRow investimentoRow = investimentoTable.Rows[investimentoIDComboBox.SelectedIndex];

                int investimento = (int)investimentoRow["InvestimentoID"];

                if (IDMovimentoConta < 0)
                {
                    // Para inclusão de investimento, carrega uma lista de despesas vazia.
                    MovimentoInvestimentoDespesaBLL bll = new MovimentoInvestimentoDespesaBLL();
                    movimentoInvestimentoDespesaBindingSource.DataSource = bll.CriarListaDespesas(investimento, saida);
                }
                else
                {
                    // Para alteração de investimento, carrega uma lista de despesas já preenchidas.
                    MovimentoInvestimentoDespesaBLL bll = new MovimentoInvestimentoDespesaBLL();
                    movimentoInvestimentoDespesaBindingSource.DataSource = bll.CarregarListaDespesas(IDMovimentoConta);
                }

                SomaDespesas();
            }
        }

        private void movimentoInvestimentoDespesaDataGridView_RowValidated(object sender, DataGridViewCellEventArgs e)
        {
            SomaDespesas();
        }

        private void vrBrutoTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Back)
            {
                TextBox textBox = (TextBox)sender;
                if (!textBox.ReadOnly)
                    if (textBox.SelectionLength == textBox.Text.Length)
                        textBox.Text = "";
            }
        }

        private void vrLiquidoTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Back)
            {
                TextBox textBox = (TextBox)sender;
                if (!textBox.ReadOnly)
                    if (textBox.SelectionLength == textBox.Text.Length)
                        textBox.Text = "";
            }
        }

        private void vrBrutoTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            Origem = sender;
            if (!char.IsControl(e.KeyChar))
            {
                TextBox textBox = (TextBox)sender;

                if (textBox.SelectionLength == textBox.Text.Length)
                    textBox.Text = "";

                if (!Regex.IsMatch(textBox.Text + e.KeyChar, "^[+]?[0-9]{0,12}((,[0-9]{0,2})|())$"))
                    e.Handled = true;
            }
        }

        private void vrLiquidoTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            Origem = sender;
            if (!char.IsControl(e.KeyChar))
            {
                TextBox textBox = (TextBox)sender;

                if (textBox.SelectionLength == textBox.Text.Length)
                    textBox.Text = "";

                if (!Regex.IsMatch(textBox.Text + e.KeyChar, "^[+]?[0-9]{0,12}((,[0-9]{0,2})|())$"))
                    e.Handled = true;
            }
        }

        #region Calculos

        private void qtCotasTextBox_Leave(object sender, EventArgs e)
        {
            if (sender == Origem)
            {
                row.EndEdit();

                Decimal valor;

                if (!Decimal.TryParse(qtCotasTextBox.Text, out valor))
                {
                    valor = 0;
                }

                row["QtCotas"] = valor;

                decimal qtCotas = (decimal?)row["QtCotas"] ?? 0;
                decimal vrCotacao = (decimal?)row["VrCotacao"] ?? 0;
                // Trunca valor na segunda casa decimal 
                // 1,938 fica 1,93 (arredondamento matemático ficaria 1,94).
                decimal vrBruto = Math.Floor(qtCotas * vrCotacao * 100) / 100;

                row["VrBruto"] = vrBruto;

                SomaDespesas();
            }
        }

        private void vrCotaTextBox_Leave(object sender, EventArgs e)
        {
            if (sender == Origem)
            {
                row.EndEdit();

                Decimal valor;

                if (!Decimal.TryParse(vrCotaTextBox.Text, out valor))
                {
                    valor = 0;
                }

                row["VrCotacao"] = valor;

                decimal qtCotas = (decimal?)row["QtCotas"] ?? 0;
                decimal vrCotacao = (decimal?)row["VrCotacao"] ?? 0;
                // Trunca valor na segunda casa decimal 
                // 1,938 fica 1,93 (arredondamento matemático ficaria 1,94).
                decimal vrBruto = Math.Floor(qtCotas * vrCotacao * 100) / 100;

                row["VrBruto"] = vrBruto;

                SomaDespesas();
            }
        }

        private void vrBrutoTextBox_Leave(object sender, EventArgs e)
        {
            if (sender == Origem)
            {
                row.EndEdit();

                Decimal valor;

                if (!Decimal.TryParse(vrBrutoTextBox.Text, out valor))
                {
                    valor = 0;
                }

                row["VrBruto"] = valor;

                // Tenta primeiro atualizar o valor da cotação (somente se o valor da cotação não for ReadOnly)
                // Se a cotação foi buscada em tabela e a tabela estiver marcada como CotacaoDaCVM vrCotaTextBox será ReadOnly.
                if (row["QtCotas"] != DBNull.Value && (decimal)row["QtCotas"] != 0 && !vrCotaTextBox.ReadOnly)
                {
                    row["VrCotacao"] = Math.Round((decimal)row["VrBruto"] / (decimal)row["QtCotas"], 9);
                }
                else if (row["VrCotacao"] != DBNull.Value && (decimal)row["VrCotacao"] != 0)
                {
                    row["QtCotas"] = Math.Round((decimal)row["VrBruto"] / (decimal)row["VrCotacao"], 9);
                }

                SomaDespesas();
            }
        }

        private void vrLiquidoTextBox_Leave(object sender, EventArgs e)
        {
            if (sender == Origem)
            {
                row.EndEdit();

                Decimal valor;

                if (!Decimal.TryParse(vrLiquidoTextBox.Text, out valor))
                {
                    valor = 0;
                }

                row["VrLiquido"] = valor;

                row["VrBruto"] = (decimal)row["VrLiquido"] +
                                 (decimal)row["VrDespesa"];

                if (row["VrCotacao"] != DBNull.Value && (decimal)row["VrCotacao"] != 0)
                {
                    row["QtCotas"] = (decimal)row["VrBruto"] /
                                     (decimal)row["VrCotacao"];
                }
                else
                {
                    row["QtCotas"] = 0;
                }

                SomaDespesas();
            }
        }

        private void SomaDespesas()
        {
            decimal vrTotalDespesas = 0;
            foreach (DataGridViewRow item in movimentoInvestimentoDespesaDataGridView.Rows)
            {
                if (item.Cells["Valor"].Value != null)
                {
                    vrTotalDespesas += (decimal)item.Cells["Valor"].Value;
                }
            }

            row["VrDespesa"] = vrTotalDespesas;

            if (row["VrBruto"] != null)
            {
                if (Venda)
                    row["VrLiquido"] = (decimal)row["VrBruto"] - (decimal)row["VrDespesa"];
                else
                    row["VrLiquido"] = (decimal)row["VrBruto"] + (decimal)row["VrDespesa"];
            }
        }

        #endregion Calculos

        private void toolTip_Draw(object sender, DrawToolTipEventArgs e)
        {
            e.DrawBackground();
            e.DrawBorder();
            e.DrawText();
        }

        private void buttonCancelarCategoria_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonGravarCategoria_Click(object sender, EventArgs e)
        {
            if (GravarMovimentoInvestimento())
            {
                // Recarrega as categorias no form de origem pois o investimento pode ter gerado uma nova categoria
                (FormOrigem as fmMovimentosConta).CarregaLancamentos(IDUsuario);
                // Recarrega o grid de lançamentos
                (FormOrigem as fmMovimentosConta).CarregarMovimentosContas(IDConta);
                this.Close();
            }
        }

        private bool GravarMovimentoInvestimento()
        {
            MovimentoInvestimento modelo = new MovimentoInvestimento();

            modelo.MovimentoContaID = (int)row["MovimentoContaID"];
            modelo.MovimentoInvestimentoID = (int)row["MovimentoInvestimentoID"];
            modelo.UsuarioID = (int)row["UsuarioID"];
            modelo.ContaID = (int)row["ContaID"];
            modelo.InvestimentoID = (int?)investimentoIDComboBox.SelectedValue;
            modelo.GrupoCategoriaID = ((DataRowView)investimentoIDComboBox.SelectedItem).Row.Field<int?>("GrupoCategoriaID");

            //
            // Propriedades necessárias ao cadastro da cotação
            //
            if (transacaoIDComboBox.SelectedIndex >= 0)
            {
                DataTable tableTransacao = (DataTable)transacaoBindingSource.DataSource;
                DataRow rowTransacao = tableTransacao.Rows[transacaoIDComboBox.SelectedIndex];

                // Informações provenientes da tabela de transações, através do combobox transação
                modelo.CrdDeb = (string)rowTransacao["CrdDeb"];
                modelo.TransacaoID = (int?)rowTransacao["TransacaoID"];
                modelo.CategoriaID = (int?)rowTransacao["CategoriaID"];
            }
            else
            {
                modelo.CrdDeb = null;
                modelo.TransacaoID = null;
                modelo.CategoriaID = null;
            }

            //
            // Incluir aqui uma geração de Parceiro/Lançamento para tratar o nome do investimento.
            //            

            if (row["Data"] != DBNull.Value)
                modelo.Data = row.Field<DateTime>("Data");//  (DateTime)row["Data"];
            else
                modelo.Data = null;

            if (row["VrCotacao"] != DBNull.Value)
                modelo.VrCotacao = row.Field<decimal>("VrCotacao");
            else
                modelo.VrCotacao = null;

            // Se o checkbox da CMV estiver desmarcado, força a atualização
            modelo.ForcaAtualizacao = !CVMcheckBox.Checked;

            //
            // Propriedades necessárias ao cadastro do movimento em conta
            //
            row.EndEdit();

            if (row["Numero"] != DBNull.Value)
                modelo.Numero = row.Field<string>("Numero");
            else
                modelo.Numero = null;

            // Encontra o número do lançamento/parceiro 
            modelo.LancamentoID = Math.Abs(IDdoLancamento(IDUsuario, (string)investimentoIDComboBox.Text, false));

            if (Acao)
            {
                if (modelo.CrdDeb == "C")
                {
                    modelo.Credito = row.Field<decimal>("VrBruto");
                    modelo.Debito = null;
                }
                else
                {
                    modelo.Credito = null;
                    modelo.Debito = row.Field<decimal>("VrBruto");
                }
            }
            else
            {
                if (modelo.CrdDeb == "C")
                {
                    modelo.Credito = row.Field<decimal>("VrBruto");
                    modelo.Debito = null;
                }
                else
                {
                    modelo.Credito = null;
                    modelo.Debito = row.Field<decimal>("VrBruto");
                }
            }

            if (row["Conciliacao"] != DBNull.Value)
                modelo.Conciliacao = row.Field<string>("Conciliacao");
            else
                modelo.Conciliacao = null;

            if (row["InvestimentoCotacaoID"] != DBNull.Value)
                modelo.InvestimentoCotacaoID = row.Field<Int32>("InvestimentoCotacaoID");
            else
                modelo.InvestimentoCotacaoID = null;

            if (row["QtCotas"] != DBNull.Value)
                modelo.QtCotas = row.Field<decimal>("QtCotas");
            else
                modelo.QtCotas = null;

            if (row["VrBruto"] != DBNull.Value)
                modelo.VrBruto = row.Field<decimal>("VrBruto");
            else
                modelo.VrBruto = null;

            if (row["VrLiquido"] != DBNull.Value)
                modelo.VrLiquido = row.Field<decimal>("VrLiquido");
            else
                modelo.VrLiquido = null;

            //if (row["SldCotas"] != DBNull.Value)
            //    modelo.SldCotas = (decimal)row["SldCotas"];
            //else
            //    modelo.SldCotas = null;

            if (row["Descricao"] == DBNull.Value || row.Field<string>("Descricao") == String.Empty)
            {
                if (modelo.QtCotas != null && modelo.VrCotacao != null)
                    modelo.Descricao = String.Format("{0} Cotas @ R$ {1}",
                                                    ((decimal)modelo.QtCotas).ToString("F6"),
                                                    ((decimal)modelo.VrCotacao).ToString("F6"));
                else
                    modelo.Descricao = null;
            }
            else
            {
                modelo.Descricao = row.Field<string>("Descricao");
            }

            if (row["VrDespesa"] != DBNull.Value)
                modelo.VrDespesa = row.Field<decimal>("VrDespesa");
            else
                modelo.VrDespesa = null;

            // Cria um array com todos os lançamentos de despesas
            int qtde = ((DataTable)movimentoInvestimentoDespesaBindingSource.DataSource).Rows.Count;

            MovimentoInvestimentoDespesa[] despesas = InitializeArray<MovimentoInvestimentoDespesa>(qtde);

            for (int i = 0; i < qtde; i++)
            {
                DataRow linha = ((DataTable)movimentoInvestimentoDespesaBindingSource.DataSource).Rows[i];
                despesas[i].MovimentoInvestimentoDespesaID = (int)linha["MovimentoInvestimentoDespesaID"];
                despesas[i].MovimentoInvestimentoID = (int)linha["MovimentoInvestimentoID"];
                despesas[i].CategoriaID = (int)linha["CategoriaID"];

                if (linha["Parceiro"] != DBNull.Value && (string)linha["Parceiro"] != String.Empty)
                {
                    despesas[i].Parceiro = (string)linha["Parceiro"];
                }
                else
                {
                    if (modelo.CrdDeb == "C")
                        despesas[i].Parceiro = "Despesa de Resgate";
                    else
                        despesas[i].Parceiro = "Despesa de Aplicação";
                }

                despesas[i].Valor = (decimal)linha["Valor"];
                despesas[i].Ordem = i;
            }

            MovimentoInvestimentoBLL bll = new MovimentoInvestimentoBLL();

            if (bll.Validar(modelo))
            {
                return bll.GravarMovimentoInvestimento(modelo, despesas) > 0;
            }
            else
            {
                return false;
            }
        }

        private int IDdoLancamento(int usuarioID, string conteudo, bool apagaNaoUtilizado)
        {
            LancamentoBLL bll = new LancamentoBLL();
            return bll.IDdoLancamento(usuarioID, conteudo, apagaNaoUtilizado);
        }

        private void dataDateTimePicker_Leave(object sender, EventArgs e)
        {
            row.EndEdit();

            DateTime data = dataDateTimePicker.Value;
            row["Data"] = data;
            AtualizaCotacao();
        }

        T[] InitializeArray<T>(int length) where T : new()
        {
            T[] array = new T[length];
            for (int i = 0; i < length; ++i)
            {
                array[i] = new T();
            }

            return array;
        }

        private void transacaoIDComboBox_Leave(object sender, EventArgs e)
        {
            AcessoAosComponentes(transacaoIDComboBox.SelectedValue != null);

            if (transacaoIDComboBox.SelectedValue != null)
            {
                row.EndEdit();
                TransacaoCarregarInvestimentos();

                dataDateTimePicker.Focus();
            }
        }

        private void AcessoAosComponentes(Boolean liberado)
        {
            // Bloqueia os componentes que dependem do preenchimento do combo box transacaoIDComboBox

            foreach (Control container in this.Controls)
            {
                foreach (Control item in container.Controls)
                {
                    // O componente transacaoIDComboBox nunca deverá ser desabilitado
                    if (item != transacaoIDComboBox)
                    {
                        if (item is ComboBox)
                        {
                            ((ComboBox)item).Enabled = liberado;
                        }
                        else if (item is DateTimePicker)
                        {
                            ((DateTimePicker)item).Enabled = liberado;
                        }
                        else if (item is TextBox)
                        {
                            ((TextBox)item).Enabled = liberado;
                        }
                        else if (item is CheckBox)
                        {
                            ((CheckBox)item).Enabled = liberado;
                        }
                        else if (item is DataGridView)
                        {
                            ((DataGridView)item).Enabled = liberado;
                        }
                    }
                }
            }
        }

        private void TransacaoCarregarInvestimentos()
        {
            row["TransacaoID"] = transacaoIDComboBox.SelectedValue;

            // Exemplo resgatando registro associado ao combobox
            DataRowView dr = (DataRowView)transacaoBindingSource.Current;
            // CrdDeb pode ser C para crédito ou D para débito
            // Se C, então venda, pois crédito
            // Se D, então compra, pois débito
            Venda = ((string)dr["CrdDeb"])[0] == 'C';
            bool fundo = (bool)dr["Fundo"];
            bool acao = (bool)dr["Acao"];

            decimal qtCotas = row.Field<decimal?>("QtCotas") ?? 0;
            decimal vrCota = row.Field<decimal?>("VrCotacao") ?? 0;

            CarregaInvestimentos(Venda, fundo, acao);
            CarregaListaDespesas();

            qtCotasTextBox.Text = qtCotas.ToString();
            vrCotaTextBox.Text = vrCota.ToString();
        }

        private void CVMcheckBox_CheckedChanged(object sender, EventArgs e)
        {
            // Se a cotação for proveniente da CVM, bloqueia a edição do 
            // valor da cotação, porém o usuário poderá desbloquear.
            vrCotaTextBox.ReadOnly = CVMcheckBox.Checked;
            vrCotaTextBox.TabStop = !vrCotaTextBox.ReadOnly;
        }

        private void FmMovimentosInvestimento_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Se usar o PONTO, troca por VIRGULA, assim permite usar o teclado numérico.
            if (e.KeyChar == '.')
            {
                e.KeyChar = ',';
            }
        }

        private void transacaoIDComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var combo = (ComboBox)sender;

            if (combo.SelectedValue != null)
            {
                var id = ((ComboBox)sender).SelectedValue;
                // Para saber se a transação é de compra ou venda ((D)ébito ou (C)rédito)
                var CrdDeb = ((DataTable)transacaoBindingSource.DataSource).Rows.Find(id).Field<string>("CrdDeb");
                Acao = ((DataTable)transacaoBindingSource.DataSource).Rows.Find(id).Field<bool>("Acao");

                Venda = CrdDeb == "D";

                if (Venda)
                {
                    lblFormulaTotal.Text = "e = (c + d)";
                    vrSubTotal.Text = "Valor Total Líquido";
                    vrTotal.Text = "Valor Total Bruto";
                }
                else
                {
                    lblFormulaTotal.Text = "e = (c - d)";
                    vrSubTotal.Text = "Valor Total Bruto:";
                    vrTotal.Text = "Valor Total Líquido:";
                }
            }
        }
    }
}
