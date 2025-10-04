using BLL;
using Modelos;
using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace MoneyPro
{
    public partial class fmMovimentosCDB : MoneyPro.Base.fmBaseTopoRodape
    {
        private readonly string FormatoDecimal;
        private int IDUsuario;
        private int IDConta;
        private int Decimais;

        public fmMovimentosCDB(int idUsuario, int idConta, string numero, int decimais)
        {
            InitializeComponent();

            IDUsuario = idUsuario;
            IDConta = idConta;
            Decimais = decimais;

            FormatoDecimal = String.Format("N{0}", Decimais);

            dataDateTimePicker.Value = DateTime.Today;

            if (!string.IsNullOrEmpty(numero))
            {
                numeroCDB.Text = numero;
                numeroCDB.ReadOnly = true;
            }

            ConsultaSaldo(IDConta, numero);
            ConsultarTexto(IDConta, numero);
            CarregarLancamentoPadraoCDB(IDUsuario);
            CarregarCategoriaPadraoCDB(IDUsuario);
        }

        private void CarregarLancamentoPadraoCDB(int idUsuario)
        {
            LancamentoBLL bllLanc = new LancamentoBLL();
            int idPadrao = bllLanc.IDdoLancamentoPadraoCDB(idUsuario);

            PesquisaBLL bllPesq = new PesquisaBLL();
            lancamentoComboBox.DataSource = bllPesq.ListarParceirosUsadosNaConta(IDConta);
            lancamentoComboBox.DisplayMember = "Apelido";
            lancamentoComboBox.ValueMember = "LancamentoID";
            lancamentoComboBox.SelectedValue = idPadrao;
        }

        private void CarregarCategoriaPadraoCDB(int idUsuario)
        {
            CategoriaBLL bllCateg = new CategoriaBLL();
            int idPadrao = bllCateg.IDdaCategoriaPadraoCDB(idUsuario);

            PesquisaBLL bllPesq = new PesquisaBLL();
            categoriaComboBox.DataSource = bllPesq.ListarCategoriasUsadosNaConta(IDConta);
            categoriaComboBox.DisplayMember = "Apelido";
            categoriaComboBox.ValueMember = "CategoriaID";
            categoriaComboBox.SelectedValue = idPadrao;
        }

        private void ConsultarTexto(int idConta, string numeroCDB)
        {
            MovimentoContaBLL bll = new MovimentoContaBLL();
            descricaoTextBox.Text = bll.ConsultaTextoCDB(idConta, numeroCDB);
        }

        private void ConsultaSaldo(int idConta, string numeroCDB)
        {
            MovimentoContaBLL bll = new MovimentoContaBLL();
            decimal saldoAtual = bll.ConsultaSaldoCDB(idConta, numeroCDB);

            saldoAtualTextBox.Text = saldoAtual.ToString(FormatoDecimal);
            saldoAtualTextBox.Tag = saldoAtual;
        }

        private void novoSaldoTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Back)
            {
                TextBox textBox = (TextBox)sender;
                if (!textBox.ReadOnly)
                    if (textBox.SelectionLength == textBox.Text.Length)
                        textBox.Text = "";
            }
        }

        private void novoSaldoTextBox_KeyPress(object sender, KeyPressEventArgs e)
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

        private void novoSaldoTextBox_Leave(object sender, EventArgs e)
        {
            Decimal NovoValor;

            TextBox NovoSaldo = (TextBox)sender;

            if (!Decimal.TryParse(NovoSaldo.Text, out NovoValor))
            {
                NovoValor = 0;
            }

            NovoSaldo.Text = NovoValor.ToString(FormatoDecimal);
            NovoSaldo.Tag = NovoValor;

            diferencaTextBox.Text = (NovoValor - (decimal)saldoAtualTextBox.Tag).ToString(FormatoDecimal);
            diferencaTextBox.Tag = NovoValor - (decimal)saldoAtualTextBox.Tag;
        }

        private void buttonGravar_Click(object sender, EventArgs e)
        {
            MovimentoConta modelo = new MovimentoConta();

            modelo.MovimentoContaID = -1;
            modelo.UsuarioID = IDUsuario;
            modelo.ContaID = IDConta;

            modelo.Data = dataDateTimePicker.Value;

            modelo.Numero = numeroCDB.Text;
            modelo.LancamentoID = (int)lancamentoComboBox.SelectedValue;
            modelo.CategoriaID = (int)categoriaComboBox.SelectedValue;
            modelo.Descricao = descricaoTextBox.Text;

            modelo.GrupoCategoriaID = null;

            if ((decimal)diferencaTextBox.Tag >= 0)
            {
                modelo.CrdDeb = "C";
                modelo.Credito = (decimal)diferencaTextBox.Tag;
                modelo.Debito = null;
            }
            else
            {
                modelo.CrdDeb = "D";
                modelo.Credito = null;
                modelo.Debito = (decimal)diferencaTextBox.Tag;
            }

            modelo.Conciliacao = " ";
            modelo.PilhaMovimentoContaID = null;
            modelo.DoMovimentoContaID = null;
            modelo.Observacao = null;

            MovimentoContaBLL bll = new MovimentoContaBLL();

            if (bll.Validar(modelo))
            {
                int registro = bll.Gravar(modelo);
            }
        }

        private void fmMovimentosCDB_Shown(object sender, EventArgs e)
        {
            novoSaldoTextBox.Focus();
        }
    }
}
