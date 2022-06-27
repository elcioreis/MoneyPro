using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Modelos;
using BLL;
using System.Text.RegularExpressions;
using System.Globalization;

namespace MoneyPro
{
    public partial class fmPlanejamentoManutencao : MoneyPro.Base.fmBaseTopoRodape
    {

        Planejamento modelo = null;

        private int UsuarioID;
        private int ContaID;
        private int LancamentoID;
        private int CategoriaID;
        private int GrupoID;
        private decimal Valor;
        private string CrdDeb;
        private DateTime Data;
        private bool Efetivar = false;

        private int _planejamentoID;
        private int PlanejamentoID
        {
            get
            {
                return _planejamentoID;
            }

            set
            {
                _planejamentoID = value;

                if (_planejamentoID < 0)
                {
                    labelTopo.Text = "Inclusão no Planejamento";
                }
                else
                {
                    labelTopo.Text = "Alteração no Planejamento";
                }
            }
        }

        DataTable table = new DataTable();
        DataRow row = null;

        public fmPlanejamentoManutencao(int usuarioID, int planejamentoID, int contaID = -1, int lancamentoID = -1,
                                        int categoriaID = -1, int grupoID = -1, decimal valor = 0, string crddeb = "D",
                                        DateTime? dia = null)
        {
            InitializeComponent();

            this.UsuarioID = usuarioID;
            this.PlanejamentoID = planejamentoID;

            // As variáveis abaixo são exclusivamente utilizadas para inclusão de item no planejamento,
            // elas recebem valores padrão, a não ser que este formulário seja carregado a partir do
            // movimento de contas, que utiliza um lançamento já realizado para lançar outras repetições.
            this.ContaID = contaID;
            this.LancamentoID = lancamentoID;
            this.CategoriaID = categoriaID;
            this.GrupoID = grupoID;
            this.Valor = valor;
            this.CrdDeb = crddeb;
            if (dia == null)
                this.Data = DateTime.Today.Date;
            else
                this.Data = ((DateTime)dia).Date;

        }

        public fmPlanejamentoManutencao(bool efetivar, int usuarioID, int planejamentoID)
        {
            // método usado para efetivar o item do planejamento
            InitializeComponent();

            this.UsuarioID = usuarioID;
            this.PlanejamentoID = planejamentoID;

            this.Efetivar = efetivar;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            // Combobox baseados em tabelas
            CarregarContas();
            CarregarLancamentos();
            CarregarCategorias();
            CarregarGrupoCategorias();
            // Combobox com opções fixas (BIT)
            CarregaCrdDeb();
            CarregarTotal();
            CarregarTipoDia();
            CarregarDiferencaNaPrimeira();
            CarregarSeNaoForDiaUtil();

            // Campos texto
            apelidoTextBox.DataBindings.Clear();
            apelidoTextBox.DataBindings.Add("Text", planejamentoBindingSource, "Apelido", false, DataSourceUpdateMode.OnPropertyChanged);
            diaTextBox.DataBindings.Clear();
            diaTextBox.DataBindings.Add("Text", planejamentoBindingSource, "Dia", false, DataSourceUpdateMode.OnPropertyChanged);
            repeticoesTextBox.DataBindings.Clear();
            repeticoesTextBox.DataBindings.Add("Text", planejamentoBindingSource, "Repeticoes", false, DataSourceUpdateMode.OnPropertyChanged);
            observacaoTextBox.DataBindings.Clear();
            observacaoTextBox.DataBindings.Add("Text", planejamentoBindingSource, "Observacao", false, DataSourceUpdateMode.OnPropertyChanged);

            if (!Efetivar)
            {
                this.Height -= valorParcelaPanel.Height;
                valorParcelaPanel.Visible = false;

                if (PlanejamentoID < 0)
                {
                    IncluirPlanejamento();
                }
                else
                {
                    AlterarPlanejamento(PlanejamentoID);
                }
            }
            else
            {
                labelTopo.Text = "Efetivação do Planejamento";
                // Somente os seguintes campos podem ser editados:
                // Descrição, Conta, Valor e Data;
                contaIDComboBox.Enabled = true;
                lancamentoIDComboBox.Enabled = false;
                categoriaIDComboBox.Enabled = false;
                grupoCategoriaIDComboBox.Enabled = false;
                crdDebComboBox.Enabled = false;
                totalComboBox.Enabled = false;
                diferencaNaPrimeiraComboBox.Enabled = false;
                diaTextBox.Enabled = false;
                diaFixoComboBox.Enabled = false;
                adiaSeNaoUtilComboBox.Enabled = false;
                repeticoesTextBox.Enabled = false;
                dtInicialLabel.Text = "Efetivar em:";
                ativoCheckBox.Enabled = false;

                AlterarPlanejamento(PlanejamentoID);

                // Se houver número da parcela no apelido, preenche com a parcela atual. 
                if (((string)row["Apelido"]).Contains("(X/")) // (procura parcela com 1 dígito)
                {
                    int num = ((int)row["Processados"]) + 1;
                    string substituto = num.ToString("0") + "/";
                    row["Apelido"] = ((string)row["Apelido"]).Replace("X/", substituto);
                }
                else if (((string)row["Apelido"]).Contains("(XX/")) // (procura parcela com 2 dígitos)
                {
                    int num = ((int)row["Processados"]) + 1;
                    string substituto = num.ToString("00") + "/";
                    row["Apelido"] = ((string)row["Apelido"]).Replace("XX/", substituto);
                }

                if (row["Observacao"] != DBNull.Value)
                {
                    // Se houver número da parcela na observacao, preenche com a parcela atual. 
                    if (((string)row["Observacao"]).Contains("(X/")) // (procura parcela com 1 dígito)
                    {
                        int num = ((int)row["Processados"]) + 1;
                        string substituto = num.ToString("0") + "/";
                        row["Observacao"] = ((string)row["Observacao"]).Replace("X/", substituto);
                    }
                    else if (((string)row["Observacao"]).Contains("(XX/")) // (procura parcela com 2 dígitos)
                    {
                        int num = ((int)row["Processados"]) + 1;
                        string substituto = num.ToString("00") + "/";
                        row["Observacao"] = ((string)row["Observacao"]).Replace("XX/", substituto);
                    }
                }

                decimal valorParcela;
                decimal diferenca = 0;
                decimal valorTotal = (decimal?)row["Valor"] ?? 0;
                int repeticoes = (int?)row["Repeticoes"] ?? 0;
                Boolean diferencaNaPrimeira = (Boolean?)row["DiferencaNaPrimeira"] ?? true;
                int processados = (int?)row["Processados"] ?? 0;

                if (repeticoes > 0)
                {
                    // Para truncar com duas casas decimais
                    valorParcela = Math.Truncate(valorTotal / repeticoes * 100) / 100;
                }
                else
                {
                    valorParcela = valorTotal;
                }

                if (diferencaNaPrimeira)   // Diferença na primeira
                {
                    if (processados == 0)
                    {
                        // Se for a primeira parcela, calcula a diferença
                        diferenca = valorTotal - (valorParcela * repeticoes);
                    }
                }
                else // Diferença na última
                {
                    if (processados == repeticoes - 1)
                    {
                        // Se for a última parcela, calcula a diferença
                        diferenca = valorTotal - (valorParcela * repeticoes);
                    }
                }
                valorParcela += diferenca;

                row["ValorParcela"] = valorParcela;


                /////////////////////////////////////////////////////
                /////////////////////////////////////////////////////
            }
        }

        private void CarregaCrdDeb()
        {
            Dictionary<string, string> items = new Dictionary<string, string>();
            items.Add("C", "Crédito");
            items.Add("D", "Débito");

            crdDebComboBox.DataBindings.Clear();
            try
            {
                crdDebComboBox.DataBindings.Add("SelectedValue", planejamentoBindingSource, "CrdDeb");
                crdDebComboBox.DataSource = new BindingSource(items, null);
                crdDebComboBox.DisplayMember = "Value";
                crdDebComboBox.ValueMember = "Key";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
        }

        private void CarregarDiferencaNaPrimeira()
        {
            Dictionary<bool, string> items = new Dictionary<bool, string>();
            items.Add(false, "Diferença na última prestação");
            items.Add(true, "Diferença na primeira prestação");

            diferencaNaPrimeiraComboBox.DataBindings.Clear();
            try
            {
                diferencaNaPrimeiraComboBox.DataBindings.Add("SelectedValue", planejamentoBindingSource, "DiferencaNaPrimeira");
                diferencaNaPrimeiraComboBox.DataSource = new BindingSource(items, null);
                diferencaNaPrimeiraComboBox.DisplayMember = "Value";
                diferencaNaPrimeiraComboBox.ValueMember = "Key";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
        }

        private void CarregarSeNaoForDiaUtil()
        {
            Dictionary<int, string> items = new Dictionary<int, string>();
            items.Add(0, "Adianta se não for dia útil");
            items.Add(1, "Adia se não for dia útil");
            items.Add(2, "Dia fixo");

            adiaSeNaoUtilComboBox.DataBindings.Clear();
            try
            {
                adiaSeNaoUtilComboBox.DataBindings.Add("SelectedValue", planejamentoBindingSource, "AdiaSeNaoUtil");
                adiaSeNaoUtilComboBox.DataSource = new BindingSource(items, null);
                adiaSeNaoUtilComboBox.DisplayMember = "Value";
                adiaSeNaoUtilComboBox.ValueMember = "Key";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
        }

        private void CarregarTipoDia()
        {
            Dictionary<bool, string> items = new Dictionary<bool, string>();
            items.Add(false, "Dia Útil");
            items.Add(true, "Dia Fixo");

            diaFixoComboBox.DataBindings.Clear();
            try
            {
                diaFixoComboBox.DataBindings.Add("SelectedValue", planejamentoBindingSource, "DiaFixo");
                diaFixoComboBox.DataSource = new BindingSource(items, null);
                diaFixoComboBox.DisplayMember = "Value";
                diaFixoComboBox.ValueMember = "Key";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
        }

        private void CarregarTotal()
        {
            // Exemplo combobox com itens fixos
            Dictionary<bool, string> items = new Dictionary<bool, string>();
            items.Add(false, "Mensalidade");
            items.Add(true, "Valor Total");

            totalComboBox.DataBindings.Clear();
            try
            {
                totalComboBox.DataBindings.Add("SelectedValue", planejamentoBindingSource, "Total");
                totalComboBox.DataSource = new BindingSource(items, null);
                totalComboBox.DisplayMember = "Value";
                totalComboBox.ValueMember = "Key";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
        }

        private void IncluirPlanejamento()
        {
            PlanejamentoBLL bll = new PlanejamentoBLL();
            planejamentoBindingSource.DataSource = bll.Planejamento(-1);

            table = (DataTable)planejamentoBindingSource.DataSource;
            row = table.NewRow();

            row["PlanejamentoID"] = PlanejamentoBLL.ProximoID;
            row["UsuarioID"] = UsuarioID;
            row["Valor"] = this.Valor;
            row["Total"] = false;
            row["DiaFixo"] = true;
            row["ValorFixo"] = true;
            row["AdiaSeNaoUtil"] = true;
            row["DiferencaNaPrimeira"] = true;
            row["DtInicial"] = this.Data; // DateTime.Today;
            row["Dia"] = this.Data.Day;   // DateTime.Today.Day;
            row["CrdDeb"] = this.CrdDeb;
            row["Repeticoes"] = 0;
            row["Processados"] = 0;

            if (this.ContaID > 0)
                row["ContaID"] = this.ContaID;
            else
                row["ContaID"] = DBNull.Value;

            if (this.LancamentoID > 0)
                row["LancamentoID"] = this.LancamentoID;
            else
                row["LancamentoID"] = DBNull.Value;

            if (this.CategoriaID > 0)
                row["CategoriaID"] = this.CategoriaID;
            else
                row["CategoriaID"] = DBNull.Value;

            if (this.GrupoID > 0)
                row["GrupoCategoriaID"] = this.GrupoID;
            else
                row["GrupoCategoriaID"] = DBNull.Value;

            row["Descricao"] = DBNull.Value;
            row["Apelido"] = DBNull.Value;
            row["Ativo"] = true;
            row["UltimoDiaMes"] = false;
            row["Observacao"] = DBNull.Value;

            table.Rows.Add(row);
        }

        private void AlterarPlanejamento(int PlanejamentoID)
        {
            PlanejamentoBLL bll = new PlanejamentoBLL();
            planejamentoBindingSource.DataSource = bll.Planejamento(PlanejamentoID);

            table = (DataTable)planejamentoBindingSource.DataSource;
            row = table.Rows[0];
        }

        private void CarregarGrupoCategorias()
        {
            GrupoCategoriaBLL bll = new GrupoCategoriaBLL();
            grupoCategoriaBindingSource.DataSource = bll.Listar(UsuarioID);
            grupoCategoriaIDComboBox.DataBindings.Clear();
            try
            {
                grupoCategoriaIDComboBox.DataBindings.Add("SelectedValue", planejamentoBindingSource, "GrupoCategoriaID");
                grupoCategoriaIDComboBox.DataSource = grupoCategoriaBindingSource;
                grupoCategoriaIDComboBox.DisplayMember = "Apelido";
                grupoCategoriaIDComboBox.ValueMember = "GrupoCategoriaID";

                grupoCategoriaIDComboBox.AutoCompleteSource = AutoCompleteSource.ListItems;
                grupoCategoriaIDComboBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
        }

        private void CarregarCategorias()
        {
            CategoriaBLL bll = new CategoriaBLL();
            categoriaBindingSource.DataSource = bll.ListarSelecionaveis(UsuarioID);
            categoriaIDComboBox.DataBindings.Clear();
            try
            {
                categoriaIDComboBox.DataBindings.Add("SelectedValue", planejamentoBindingSource, "CategoriaID");
                categoriaIDComboBox.DataSource = categoriaBindingSource;
                categoriaIDComboBox.DisplayMember = "vFiltro";
                categoriaIDComboBox.ValueMember = "CategoriaID";

                categoriaIDComboBox.AutoCompleteSource = AutoCompleteSource.ListItems;
                categoriaIDComboBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
        }

        private void CarregarLancamentos()
        {
            LancamentoBLL bll = new LancamentoBLL();
            lancamentoBindingSource.DataSource = bll.Listar(UsuarioID);
            lancamentoIDComboBox.DataBindings.Clear();
            try
            {
                lancamentoIDComboBox.DataBindings.Add("SelectedValue", planejamentoBindingSource, "LancamentoID");
                lancamentoIDComboBox.DataSource = lancamentoBindingSource;
                lancamentoIDComboBox.DisplayMember = "Apelido";
                lancamentoIDComboBox.ValueMember = "LancamentoID";

                lancamentoIDComboBox.AutoCompleteSource = AutoCompleteSource.ListItems;
                lancamentoIDComboBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
        }

        private void CarregarContas()
        {
            ContaBLL bll = new ContaBLL();
            contaBindingSource.DataSource = bll.ListarContas(UsuarioID, false);
            contaIDComboBox.DataBindings.Clear();
            try
            {
                // Exemplo databinding manual
                contaIDComboBox.DataBindings.Add("SelectedValue",
                                                 planejamentoBindingSource,
                                                 "ContaID",
                                                 false,
                                                 DataSourceUpdateMode.OnPropertyChanged);

                contaIDComboBox.AutoCompleteSource = AutoCompleteSource.ListItems;
                contaIDComboBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
        }

        private void fmPlanejamentoManutencao_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                // Se teclado escape, percorre todos os controles do form
                foreach (Control item in this.Controls)
                {
                    // Se encontrado um combobox
                    if (item is ComboBox)
                    {
                        // Se ele possuir o foco
                        if ((item as ComboBox).Focused)
                        {
                            // Remove o conteúdo do combobox
                            (item as ComboBox).SelectedValue = DBNull.Value;
                            e.SuppressKeyPress = true;
                        }
                    }
                }
            }
        }

        private void valorTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar))
            {
                // Se usar o PONTO, troca por VIRGULA, assim permite usar o teclado numérico.
                if (e.KeyChar == '.')
                {
                    e.KeyChar = ',';
                }

                TextBox textBox = (TextBox)sender;

                if (textBox.SelectionLength == textBox.Text.Length)
                    textBox.Text = "";

                if (!Regex.IsMatch(textBox.Text + e.KeyChar, "^[+]?[0-9]{0,12}((,[0-9]{0,2})|())$"))
                    e.Handled = true;
            }
        }

        private void apelidoTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar))
            {
                // Recebe o sender como TextBox
                TextBox textbox = (TextBox)sender;
                // Aceita qualquer texto de 0 a 100 caracters
                if (Regex.IsMatch(textbox.Text + e.KeyChar, "^.{0,100}$"))
                {
                    Geral.Capitaliza(textbox);                             // Capitaliza o conteúdo do textbox
                }
                else
                {
                    e.Handled = true;                                      // não passou pela regex
                }
            }
        }

        private void totalComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            diferencaNaPrimeiraComboBox.Enabled = (totalComboBox.SelectedIndex != 0);
        }

        private void diaTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar))
            {
                TextBox textBox = (TextBox)sender;

                if (textBox.SelectionLength == textBox.Text.Length)
                    textBox.Text = "";

                if (!Regex.IsMatch(textBox.Text + e.KeyChar, "^[+]?[0-9]{0,2}$"))
                    e.Handled = true;
            }
        }

        private void dtInicialDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            if (row != null)
            {
                if (dtInicialDateTimePicker.Value != null)
                {
                    row["DtInicial"] = dtInicialDateTimePicker.Value;
                    row["Dia"] = dtInicialDateTimePicker.Value.Day;

                    diaTextBox.Text = dtInicialDateTimePicker.Value.Day.ToString();
                }
            }
        }

        private void repeticoesTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar))
            {
                TextBox textBox = (TextBox)sender;

                if (textBox.SelectionLength == textBox.Text.Length)
                    textBox.Text = "";

                if (!Regex.IsMatch(textBox.Text + e.KeyChar, "^[+]?[0-9]{0,4}$"))
                    e.Handled = true;
            }
        }

        private void toolTip_Draw(object sender, DrawToolTipEventArgs e)
        {
            e.DrawBackground();
            e.DrawBorder();
            e.DrawText();
        }

        private void buttonGravarPlanejamento_Click(object sender, EventArgs e)
        {
            string msg = ValidaDados();

            if (msg == string.Empty)
            {
                if (modelo.DtInicial.DayOfWeek == DayOfWeek.Saturday || modelo.DtInicial.DayOfWeek == DayOfWeek.Sunday)
                {
                    msg = "O dia " + modelo.DtInicial.ToString("dd/MM/yyyy é dddd") + ", mantém o dia?";
                }
                else if (Geral.Feriado(modelo.DtInicial))
                {
                    msg = Geral.Capitaliza(modelo.DtInicial.ToString("dddd, dd/MM/yyyy")) + " é feriado, mantém o dia?";

                }

                if (msg != string.Empty)
                {
                    if (MessageBox.Show(msg, "MoneyPro", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    {
                        return;
                    }
                }

                PlanejamentoBLL bll = new PlanejamentoBLL();

                if (!Efetivar)
                {
                    if (bll.GravarPlanejamento(modelo))
                    {
                        this.DialogResult = DialogResult.OK;
                        Close();
                    }
                }
                else
                {
                    if (bll.EfetivarPlanejamento(modelo))
                    {
                        this.DialogResult = DialogResult.OK;
                        Close();
                    }
                }
            }
            else
            {
                MessageBox.Show(msg, "MoneyPro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private string ValidaDados()
        {
            // Finaliza edição
            row.EndEdit();

            modelo = new Planejamento();

            modelo.PlanejamentoID = (int)row["PlanejamentoID"];
            modelo.UsuarioID = (int)row["UsuarioID"];

            if (row["Apelido"] != DBNull.Value)
            {
                modelo.Apelido = (string)row["Apelido"];
                modelo.Descricao = modelo.Apelido;
            }
            else
            {
                apelidoTextBox.Focus();
                return "A descrição é obrigatória.";
            }

            //modelo.Descricao { get; set; }

            if (row["ContaID"] != DBNull.Value)
            {
                modelo.ContaID = (int)row["ContaID"];
            }
            else
            {
                contaIDComboBox.Focus();
                return "A conta deve ser informada.";
            }
            //modelo.Conta { get; set; }

            if (row["LancamentoID"] != DBNull.Value)
            {
                modelo.LancamentoID = (int)row["LancamentoID"];
            }
            else
            {
                lancamentoIDComboBox.Focus();
                return "O lançammento deve ser informado.";
            }
            //modelo.Lancamento { get; set; }

            if (row["CategoriaID"] != DBNull.Value)
            {
                modelo.CategoriaID = (int)row["CategoriaID"];
            }
            else
            {
                categoriaIDComboBox.Focus();
                return "A categoria deve ser informada.";
            }
            //modelo.Categoria { get; set; }

            if (row["GrupoCategoriaID"] != DBNull.Value)
            {
                modelo.GrupoCategoriaID = (int)row["GrupoCategoriaID"];
            }
            else
            {
                modelo.GrupoCategoriaID = null;
            }
            //modelo.GrupoCategoria { get; set; }        

            if (row["Valor"] != DBNull.Value)
            {
                modelo.Valor = (decimal)row["Valor"];
            }
            else
            {
                valorTextBox.Focus();
                return "O valor deve ser informado.";
            }

            if (row["CrdDeb"] != DBNull.Value)
            {
                modelo.CrdDeb = (string)row["CrdDeb"];
            }
            else
            {
                crdDebComboBox.Focus();
                return "Informe se o valor é um crédito ou débito.";
            }

            if (row["Total"] != DBNull.Value)
            {
                modelo.Total = (bool)row["Total"];
            }
            else
            {
                totalComboBox.Focus();
                return "Informe se o pagamento é total ou uma parcela.";
            }

            if (row["DiferencaNaPrimeira"] != DBNull.Value)
            {
                modelo.DiferencaNaPrimeira = (bool)row["DiferencaNaPrimeira"];
            }
            else
            {
                diferencaNaPrimeiraComboBox.Focus();
                return "Informe se a diferença do arredondamento deve ser incluída na primeira ou na última parcela.";
            }

            if (row["DtInicial"] != DBNull.Value)
            {
                modelo.DtInicial = (DateTime)row["DtInicial"];
            }
            else
            {
                dtInicialDateTimePicker.Focus();
                return "A data inicial deve ser informada.";
            }

            if (row["Dia"] != DBNull.Value)
            {
                modelo.Dia = (int)row["Dia"];
            }
            else
            {
                diaTextBox.Focus();
                return "Informe o dia do pagamento.";
            }

            if (row["DiaFixo"] != DBNull.Value)
            {
                modelo.DiaFixo = (bool)row["DiaFixo"];
            }
            else
            {
                diaFixoComboBox.Focus();
                return "Informe se é dia fixo ou dia útil.";
            }

            if (row["AdiaSeNaoUtil"] != DBNull.Value)
            {
                modelo.AdiaSeNaoUtil = (int)row["AdiaSeNaoUtil"];
            }
            else
            {
                adiaSeNaoUtilComboBox.Focus();
                return "Informe se o dia de pagamento deve ser adiado ou adiantado caso caia em dia não útil.";
            }

            if (row["Repeticoes"] != DBNull.Value)
            {
                if (((int)row["Repeticoes"] > 0) ||
                    ((int)row["Repeticoes"] == 0 && !(bool)row["Total"]))
                {
                    modelo.Repeticoes = (int)row["Repeticoes"];
                }
                else
                {
                    repeticoesTextBox.Focus();
                    return "Se o valor é total, informe o número de parcelas.";
                }
            }
            else
            {
                repeticoesTextBox.Focus();
                return "Informe a quantidade de parcelas do pagamento, deixe zero se for indefinida.";
            }

            if (row["Observacao"] != DBNull.Value)
            {
                if (!string.IsNullOrWhiteSpace((string)row["Observacao"]))
                {
                    modelo.Observacao = row["Observacao"].ToString().Trim();
                }
                else
                {
                    modelo.Observacao = null;
                }
            }


            if (Efetivar)
            {
                if (row["ValorParcela"] != DBNull.Value)
                {
                    modelo.ValorParcela = (decimal)row["ValorParcela"];
                }
                else
                {
                    valorParcelaTextBox.Focus();
                    return "O valor da parcela deve ser informado.";
                }
            }

            modelo.Processados = (int)row["Processados"];

            modelo.ValorFixo = (bool)row["ValorFixo"];

            modelo.Ativo = (bool)row["Ativo"];

            return string.Empty;
        }

        private void buttonCancelarCategoria_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            Close();
        }

        private void repeticoesTextBox_Leave(object sender, EventArgs e)
        {
            // Se tiver prestações, remove
            RemovePrestacoes();

            int vezes = (int)row["Repeticoes"];
            if (vezes > 1)
            {
                // Se tiver prestações coloca no final da descrição no formato (X/Y) ou (XX/YY) ou (XXX/YYY)
                if (!((string)row["Apelido"]).Contains("(X/") &&
                    !((string)row["Apelido"]).Contains("(XX/") &&
                    !((string)row["Apelido"]).Contains("(XXX/")) // (procura parcela com 1, 2 ou 3 dígitos)
                {
                    if (vezes < 10)
                    {
                        row["Apelido"] = (string)row["Apelido"] + " (X/" + vezes.ToString() + ")";
                    }
                    else if (vezes < 100)
                    {
                        row["Apelido"] = (string)row["Apelido"] + " (XX/" + vezes.ToString() + ")";
                    }
                    else
                    {
                        row["Apelido"] = (string)row["Apelido"] + " (XXX/" + vezes.ToString() + ")";
                    }
                    row.EndEdit();
                }

                // Se tiver observação, coloca a repetição no final.
                if (row["Observacao"] != DBNull.Value)
                {
                    if (!((string)row["Observacao"]).Contains("(X/") &&
                        !((string)row["Observacao"]).Contains("(XX/") &&
                        !((string)row["Observacao"]).Contains("(XXX/")) // (procura parcela com 1, 2 ou 3 dígitos)
                    {
                        if (vezes < 10)
                        {
                            row["Observacao"] = (string)row["Observacao"] + " (X/" + vezes.ToString() + ")";
                        }
                        else if (vezes < 100)
                        {
                            row["Observacao"] = (string)row["Observacao"] + " (XX/" + vezes.ToString() + ")";
                        }
                        else
                        {
                            row["Observacaos"] = (string)row["Observacao"] + " (XXX/" + vezes.ToString() + ")";
                        }
                        row.EndEdit();
                    }
                }
            }
        }

        private void RemovePrestacoes()
        {
            // Procura prestações com menos de 10 parcelas
            int pos = ((string)row["Apelido"]).IndexOf("(X/");

            if (pos < 0)
            {
                // Se não encontrou, procura prestações com menos de 100 parcelas
                pos = ((string)row["Apelido"]).IndexOf("(XX/");

            }

            if (pos < 0)
            {
                // Se não encontrou, procura prestações com até 999 parcelas
                pos = ((string)row["Apelido"]).IndexOf("(XXX/");
            }

            // Se encontrou, remove
            if (pos >= 0)
            {
                row["Apelido"] = ((string)row["Apelido"]).Substring(0, pos).Trim();
                row.EndEdit();
            }
        }

        private void ValorParcelaTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar))
            {
                // Se usar o PONTO, troca por VIRGULA, assim permite usar o teclado numérico.
                if (e.KeyChar == '.')
                {
                    e.KeyChar = ',';
                }

                TextBox textBox = (TextBox)sender;

                if (textBox.SelectionLength == textBox.Text.Length)
                    textBox.Text = "";

                if (!Regex.IsMatch(textBox.Text + e.KeyChar, "^[+]?[0-9]{0,12}((,[0-9]{0,2})|())$"))
                    e.Handled = true;
            }
        }
    }
}
