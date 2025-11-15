using BLL;
using Modelos;
using System;
using System.Data;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace MoneyPro
{
    public partial class fmMovimentosCambio : MoneyPro.Base.fmBaseTopoRodape
    {
        readonly TransacaoCambioBLL transacoes = new TransacaoCambioBLL();

        private FmPrincipal Principal { get; set; }
        private Form FormOrigem { get; set; }
        private int IDUsuario { get; set; }
        private int IDConta { get; set; }
        private int IDMovimentoConta { get; set; }
        private MovimentoCambio MovtoCambio { get; set; }
        private int _decimais = 10;

        public int Decimais
        {
            get
            {
                return _decimais;
            }

            set
            {
                _decimais = value;
            }
        }

        //private object origem;

        public fmMovimentosCambio(FmPrincipal principal, Form origem, int usuarioID, int contaID, int movimentoContaID)
        {
            InitializeComponent();
            this.MovtoCambio = new MovimentoCambio();
            this.Principal = principal;
            this.FormOrigem = origem;
            this.IDUsuario = usuarioID;
            this.IDConta = contaID;
            this.IDMovimentoConta = movimentoContaID;

            this.MovtoCambio.DecimaisOrigem = Geral.CasasDecimais(contaID);
            this.MovtoCambio.UsuarioID = usuarioID;
            this.MovtoCambio.MovimentoContaID = movimentoContaID;
            this.MovtoCambio.ContaOrigemID = contaID;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            contaDestinoBindingSource.DataSource = transacoes.ListarContaDestino(MovtoCambio.UsuarioID, IDConta);
            CarregaBindings();

            if (IDMovimentoConta < 0)
            {
                labelTopo.Text = "Incluir Câmbio";
            }
            else
            {
                labelTopo.Text = "Alterar Câmbio";
            }
        }

        private void CarregaBindings()
        {
            string formatoDecimal = String.Format("N{0}", Decimais);

            // Monta o binding do valor de origem
            valorOrigemTextBox.DataBindings.Clear();
            valorOrigemTextBox.DataBindings.Add("Text",
                                                MovtoCambio,
                                                "ValorOrigem",
                                                true,
                                                DataSourceUpdateMode.OnValidation,
                                                null,
                                                formatoDecimal);

            // Monta o binding do valor de destino
            valorDestinoTextBox.DataBindings.Clear();
            valorDestinoTextBox.DataBindings.Add("Text",
                                                 MovtoCambio,
                                                 "ValorDestino",
                                                 true,
                                                 DataSourceUpdateMode.OnValidation,
                                                 null,
                                                 formatoDecimal);

            // Monta o binding da taxa
            taxaTextBox.DataBindings.Clear();
            taxaTextBox.DataBindings.Add("Text",
                                         MovtoCambio,
                                         "Taxa",
                                         true,
                                         DataSourceUpdateMode.OnValidation,
                                         null,
                                         formatoDecimal);

            // Monta o binding da descrição
            descricaoTextBox.DataBindings.Clear();
            descricaoTextBox.DataBindings.Add("Text",
                                              MovtoCambio,
                                              "Descricao",
                                              false,
                                              DataSourceUpdateMode.OnPropertyChanged);

            // Monta o bindind da cotação
            cotacaoTextBox.DataBindings.Clear();
            cotacaoTextBox.DataBindings.Add("Text",
                                            MovtoCambio,
                                            "Cotacao",
                                            true,
                                            DataSourceUpdateMode.OnPropertyChanged,
                                            null,
                                            formatoDecimal);

        }

        private void transacaoComboBox_Leave(object sender, EventArgs e)
        {
            if (transacaoComboBox.SelectedValue != null)
            {
                MovtoCambio.Compra = (bool)((DataRowView)transacaoCambioBindingSource.Current).Row["Compra"];

                MovtoCambio.SimboloOrigem = ((DataRowView)transacaoCambioBindingSource.Current).Row["SimboloOrigem"].ToString();
                MovtoCambio.SimboloDestino = ((DataRowView)transacaoCambioBindingSource.Current).Row["SimboloDestino"].ToString();

                simboloOrigemLabel.Text = String.Format("Valor em {0}:", MovtoCambio.SimboloOrigem);
                simboloDestinoLabel.Text = String.Format("Valor em {0}:", MovtoCambio.SimboloDestino);

                // Normalmente as taxas são recolhidas na conta destino
                destinoRadioButton.Checked = true;
            }
        }

        private void buttonCancelarCategoria_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonGravarCategoria_Click(object sender, EventArgs e)
        {
            if (ValidaInformacoes(MovtoCambio))
            {
                if (GravarMovimentoCambio())
                {
                    // Recarrega as categorias no form de origem pois o investimento pode ter gerado uma nova categoria
                    (FormOrigem as fmMovimentosConta).CarregaLancamentos(IDUsuario);
                    // Recarrega o grid de lançamentos
                    (FormOrigem as fmMovimentosConta).CarregarMovimentosContas(IDConta);

                    Principal.CarregarRolContasAsync();

                    this.Close();
                }
            }
        }

        private bool ValidaInformacoes(MovimentoCambio modelo)
        {
            if (transacaoComboBox.SelectedValue == null)
            {
                MessageBox.Show("A transação não foi selecionada.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                transacaoComboBox.Focus();
                return false;
            }

            if (contaDestinoComboBox.SelectedValue == null)
            {
                if (modelo.Compra)
                    MessageBox.Show("A conta de destino não foi selecionada.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                else
                    MessageBox.Show("A conta de origem não foi selecionada.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                contaDestinoComboBox.Focus();
                return false;
            }

            return true;
        }

        private bool GravarMovimentoCambio()
        {
            MovtoCambio.ContaOrigemID = IDConta;
            MovtoCambio.ContaDestinoID = (int)(contaDestinoComboBox.SelectedValue);
            MovtoCambio.DataHora = dataDateTimePicker.Value;
            MovtoCambio.Lancamento = transacaoComboBox.Text;

            // Manter esta propriedade por último pois ela executa cálculos que necessitam de outras propriedades preenchidas
            MovtoCambio.RespTaxa = destinoRadioButton.Checked ? Tipo.ResponsavelTaxa.Destino : Tipo.ResponsavelTaxa.Origem;

            MovimentoCambioBLL bll = new MovimentoCambioBLL();

            return bll.ManterCambio(MovtoCambio);
        }

        private void valorOrigemTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            TrataDigitacaoNumerica(sender, e, (MovtoCambio.Compra || !MovtoCambio.Padrao) ? MovtoCambio.DecimaisOrigem : MovtoCambio.DecimaisDestino);
        }

        private void valorDestinoTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            TrataDigitacaoNumerica(sender, e, (MovtoCambio.Compra || !MovtoCambio.Padrao) ? MovtoCambio.DecimaisDestino : MovtoCambio.DecimaisOrigem);
        }

        private void taxaTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (destinoRadioButton.Checked)
            {
                //TrataDigitacaoNumerica(sender, e, MovtoCambio.DecimaisDestino);
                TrataDigitacaoNumerica(sender, e, (MovtoCambio.Compra || !MovtoCambio.Padrao) ? MovtoCambio.DecimaisDestino : MovtoCambio.DecimaisOrigem);
            }
            else
            {
                //TrataDigitacaoNumerica(sender, e, MovtoCambio.DecimaisOrigem);
                TrataDigitacaoNumerica(sender, e, (MovtoCambio.Compra || !MovtoCambio.Padrao) ? MovtoCambio.DecimaisOrigem : MovtoCambio.DecimaisDestino);
            }
        }

        private static void TrataDigitacaoNumerica(object sender, KeyPressEventArgs e, int decimais)
        {
            if (!char.IsControl(e.KeyChar))
            {
                TextBox textBox = (TextBox)sender;

                if (textBox.SelectionLength == textBox.Text.Length)
                    textBox.Text = "";

                if (e.KeyChar == '.')
                {
                    // Para que o ponto do teclado numérico seja aceito como vírgula decimal
                    e.KeyChar = ',';
                }

                String formato = "^[+]?[0-9]{0,12}((,[0-9]{0,X})|())$".Replace("X", decimais.ToString());

                if (!Regex.IsMatch(textBox.Text + e.KeyChar, formato))
                    e.Handled = true;
            }
        }

        private void contaDestinoComboBox_Leave(object sender, EventArgs e)
        {
            if (contaDestinoComboBox.SelectedValue != null)
            {
                MovtoCambio.ContaDestinoID = (int)contaDestinoComboBox.SelectedValue;
                MovtoCambio.DecimaisDestino = Geral.CasasDecimais((int)contaDestinoComboBox.SelectedValue);

                if (MovtoCambio.DecimaisOrigem >= 0 && MovtoCambio.DecimaisDestino >= 0)
                {
                    Decimais = Math.Max(MovtoCambio.DecimaisOrigem, MovtoCambio.DecimaisDestino);
                }
                CarregaBindings();

                transacaoCambioBindingSource.DataSource = transacoes.ListarTransacoes(MovtoCambio.ContaOrigemID, MovtoCambio.ContaDestinoID);
            }
        }
    }
}
