using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BLL;
using Modelos;
using static Modelos.Tipo;

namespace MoneyPro
{
    public partial class fmPesquisa : MoneyPro.Base.fmBaseTopoRodape
    {
        private Form Origem { get; set; }
        private int UsuarioID { get; set; }

        #region Singleton

        private static fmPesquisa _singleton;

        private fmPesquisa(Form origem, int usuarioID)
        {
            InitializeComponent();
            this.UsuarioID = usuarioID;
            this.Origem = origem;
        }

        public static fmPesquisa CreateInstance(Form origem, int usuarioID)
        {
            if (_singleton == null)
            {
                _singleton = new fmPesquisa(origem, usuarioID);
            }
            return _singleton;
        }

        protected override void OnClosed(EventArgs e)
        {
            _singleton = null;
            base.OnClosed(e);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            CarregaDados(UsuarioID);
        }

        #endregion Singleton

        private void CarregaDados(int usuarioID)
        {
            CarregarParceiros(usuarioID);
            CarregarCategoria(usuarioID);
            CarregarGrupo(usuarioID);
            CarregarGrupoContas(usuarioID, checkBoxGruposContasAtivos.Checked);
            CarregarTiposConta(usuarioID, checkBoxTiposContasAtivos.Checked);
            CarregarContas(usuarioID, checkBoxContasAtivas.Checked);

            dateTimePickerDe.Value = Geral.PrimeiroDiaMovimento(usuarioID);
            dateTimePickerAte.Value = Geral.UltimoDiaMovimento(usuarioID);

            Pesquisa pesquisa = new Pesquisa();
            pesquisaBindingSource.DataSource = pesquisa;
        }

        private void CarregarParceiros(int usuarioID)
        {
            PesquisaBLL bll = new PesquisaBLL();
            comboBoxParceiro.DataSource = bll.ListarParceiros(usuarioID);
            comboBoxParceiro.SelectedIndex = -1;
        }

        private void CarregarCategoria(int usuarioID)
        {
            PesquisaBLL bll = new PesquisaBLL();
            comboBoxCategoria.DataSource = bll.ListarCategorias(usuarioID);
            comboBoxCategoria.SelectedIndex = -1;
        }

        private void CarregarGrupo(int usuarioID)
        {
            PesquisaBLL bll = new PesquisaBLL();
            comboBoxGrupo.DataSource = bll.ListarGrupos(usuarioID);
            comboBoxGrupo.SelectedIndex = -1;
        }

        private void CarregarGrupoContas(int usuarioID, bool SomenteAtivos)
        {
            comboBoxGruposContas.SelectedIndexChanged -= ComboBoxGrupos_SelectedIndexChanged;

            PesquisaBLL bll = new PesquisaBLL();
            comboBoxGruposContas.DataSource = bll.ListarGruposContas(usuarioID, SomenteAtivos);
            comboBoxGruposContas.SelectedIndex = -1;

            comboBoxGruposContas.SelectedIndexChanged += ComboBoxGrupos_SelectedIndexChanged;
        }

        private void CarregarTiposConta(int usuarioID, bool SomenteAtivos, int grupoID = -1)
        {
            comboBoxTiposContas.SelectedIndexChanged -= ComboBoxTipoConta_SelectedIndexChanged;

            PesquisaBLL bll = new PesquisaBLL();
            comboBoxTiposContas.DataSource = bll.ListarTiposContas(usuarioID, SomenteAtivos, grupoID);
            comboBoxTiposContas.SelectedIndex = -1;

            comboBoxTiposContas.SelectedIndexChanged += ComboBoxTipoConta_SelectedIndexChanged;
        }

        private void CarregarContas(int usuarioID, bool SomenteAtivos, int grupoID = -1, int tipoID = -1)
        {
            // Carrega as fontes de dados
            PesquisaBLL bll = new PesquisaBLL();
            comboBoxContas.DataSource = bll.ListarContas(usuarioID, SomenteAtivos, grupoID, tipoID);
            comboBoxContas.SelectedIndex = -1;
        }

        private void CheckBoxGruposContasAtivos_Click(object sender, EventArgs e)
        {
            CarregarGrupoContas(UsuarioID, checkBoxGruposContasAtivos.Checked);
        }

        private void CheckBoxTiposContasAtivos_Click(object sender, EventArgs e)
        {
            CarregarTiposConta(UsuarioID, checkBoxTiposContasAtivos.Checked, (int?)comboBoxGruposContas.SelectedValue ?? -1);
        }

        private void CheckBoxContasAtivas_Click(object sender, EventArgs e)
        {
            CarregarContas(UsuarioID, checkBoxContasAtivas.Checked, (int?)comboBoxGruposContas.SelectedValue ?? -1, (int?)comboBoxTiposContas.SelectedValue ?? -1);
        }

        private void ComboBoxGrupos_SelectedIndexChanged(object sender, EventArgs e)
        {
            CarregarTiposConta(UsuarioID, checkBoxTiposContasAtivos.Checked, (int?)comboBoxGruposContas.SelectedValue ?? -1);
            CarregarContas(UsuarioID, checkBoxTiposContasAtivos.Checked, (int?)comboBoxGruposContas.SelectedValue ?? -1, (int?)comboBoxTiposContas.SelectedValue ?? -1);
        }

        private void ComboBoxTipoConta_SelectedIndexChanged(object sender, EventArgs e)
        {
            CarregarContas(UsuarioID, checkBoxTiposContasAtivos.Checked, (int?)comboBoxGruposContas.SelectedValue ?? -1, (int?)comboBoxTiposContas.SelectedValue ?? -1);
        }

        private void ButtonPesquisar_Click(object sender, EventArgs e)
        {
            // Coloca o foco no botão pesquisar.
            buttonPesquisar.Focus();

            if (!((Pesquisa)pesquisaBindingSource.DataSource).Vazia())
            {

                try
                {
                    // Muda o cursor para ampulheta
                    Cursor.Current = Cursors.WaitCursor;

                    if (radioButtonTodas.Checked)
                    {
                        ((Pesquisa)pesquisaBindingSource.DataSource).Transferencia = Tipo.FiltroTransferencia.Todas;
                    }
                    else if (radioButtonOrigem.Checked)
                    {
                        ((Pesquisa)pesquisaBindingSource.DataSource).Transferencia = Tipo.FiltroTransferencia.Origem;
                    }
                    else if (radioButtonDestino.Checked)
                    {
                        ((Pesquisa)pesquisaBindingSource.DataSource).Transferencia = Tipo.FiltroTransferencia.Destino;
                    }
                    else if (radioButtonNenhuma.Checked)
                    {
                        ((Pesquisa)pesquisaBindingSource.DataSource).Transferencia = Tipo.FiltroTransferencia.Nenhuma;
                    }

                    PesquisaBLL bll = new PesquisaBLL();
                    detalhesMovimentacaoBindingSource.DataSource = bll.ListarMovimentos(UsuarioID, (Pesquisa)pesquisaBindingSource.DataSource);

                    // O total de linhas inclui o rodapé
                    int linhas = detalhesMovimentacaoBindingSource.Count - 1;

                    switch (linhas)
                    {
                        case 0:
                            labelRegistros.Text = "Nenhum lançamento encontrado";
                            break;
                        case 1:
                            labelRegistros.Text = "Um lançamento encontrado";
                            break;
                        default:
                            labelRegistros.Text = linhas.ToString("#,##0") + " lançamentos encontrados";
                            break;
                    }
                                        
                }
                finally
                {
                    // Restaura o cursor padrão
                    Cursor.Current = Cursors.Default;
                }
            }
            else
            {
                MessageBox.Show("Selecione ao menos um dos filtros disponíveis.",
                                "Atenção",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
            }
        }

        private void TextBoxGenerico_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '.')
            {
                e.KeyChar = ',';
            }
        }

        private void toolTip_Draw(object sender, DrawToolTipEventArgs e)
        {
            e.DrawBackground();
            e.DrawBorder();
            e.DrawText();
        }

        private void FmPesquisa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                if (ActiveControl is TextBox || ActiveControl is DateTimePicker)
                {
                    ButtonPesquisar_Click(sender, null);
                }
                else if (ActiveControl is ComboBox)
                {
                    if (!((ComboBox)ActiveControl).DroppedDown)
                    {
                        ButtonPesquisar_Click(sender, null);
                    }
                }
            }
            else if (e.KeyCode == Keys.Escape)
            {
                if (ActiveControl is TextBox)
                {
                    ((TextBox)ActiveControl).Clear();
                }
                else if (ActiveControl is ComboBox)
                {
                    ((ComboBox)ActiveControl).SelectedIndex = -1;
                }
            }
        }

        private void DetalhesMovimentacaoDataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (detalhesMovimentacaoDataGridView.CurrentRow != null)
            {
                if ((int)detalhesMovimentacaoDataGridView.Rows[e.RowIndex].Cells["Detalhe"].Value == 1)
                {
                    // Itens da movimentação

                    if (e.Value != null)
                    {
                        // Se é movimento futuro (leva em consideração data e hora)
                        bool futuro = (DateTime)detalhesMovimentacaoDataGridView.Rows[e.RowIndex].Cells["Data"].Value > DateTime.Now;
                        // Ou se foi marcado como lançamentos agendado ou futuros
                        futuro = futuro || (string)detalhesMovimentacaoDataGridView.Rows[e.RowIndex].Cells["Conciliacao"].Value == "A"     // Agendado
                                        || (string)detalhesMovimentacaoDataGridView.Rows[e.RowIndex].Cells["Conciliacao"].Value == "F";    // Futuro

                        if (futuro)
                        {
                            // Pinta de verde claro alternado de verde escuro
                            if ((e.RowIndex % 2) == 0)
                            {
                                e.CellStyle.BackColor = Color.PaleGreen;
                            }
                            else
                            {
                                e.CellStyle.BackColor = Color.DarkSeaGreen;
                            }
                        }

                        if (detalhesMovimentacaoDataGridView.Columns[e.ColumnIndex].Name == "Conciliacao")
                        {
                            try
                            {
                                // Pega o primeiro caracter da string "Conciliacao" e transforma em char
                                char atual = ((string)e.Value)[0];
                                // Status conterá o tipo reference à conciliação
                                TipoConciliacao status = ((TipoConciliacao)atual);

                                if (status == TipoConciliacao.Conciliado)
                                    e.CellStyle.ForeColor = Color.Blue;
                                else if (status == TipoConciliacao.Reconciliado)
                                    e.CellStyle.ForeColor = Color.Green;
                                else if (status == TipoConciliacao.Agendado)
                                    e.CellStyle.ForeColor = Color.Magenta;
                                else if (status == TipoConciliacao.Futuro)
                                    e.CellStyle.ForeColor = Color.Black;

                                if (status != TipoConciliacao.NaoConciliado)
                                    e.CellStyle.Font = new Font(e.CellStyle.Font, FontStyle.Bold);
                            }
                            catch
                            {
                                // não faz nada.
                            }
                        }
                        else if (detalhesMovimentacaoDataGridView.Columns[e.ColumnIndex].Name == "Debito")
                        {
                            e.CellStyle.ForeColor = Color.Red;
                            e.CellStyle.SelectionForeColor = Color.Gold;
                        }
                        else if (detalhesMovimentacaoDataGridView.Columns[e.ColumnIndex].Name == "Credito")
                        {
                            e.CellStyle.ForeColor = Color.DarkGreen;
                            e.CellStyle.SelectionForeColor = Color.DarkGreen;
                        }
                        else
                        {
                            e.CellStyle.ForeColor = Color.Black;
                            e.CellStyle.SelectionForeColor = SystemColors.HighlightText;
                        }
                    }
                }
                else
                {
                    // Rodapé

                    e.CellStyle.BackColor = Color.Black;

                    if (e.Value != null)
                    {
                        if (detalhesMovimentacaoDataGridView.Columns[e.ColumnIndex].Name == "Descricao")
                        {
                            e.CellStyle.ForeColor = Color.White;
                            e.CellStyle.SelectionForeColor = SystemColors.HighlightText;
                            e.CellStyle.Font = new Font(e.CellStyle.Font, FontStyle.Bold);
                        }
                        else if (detalhesMovimentacaoDataGridView.Columns[e.ColumnIndex].Name == "Debito")
                        {
                            e.CellStyle.ForeColor = Color.Tomato;
                            e.CellStyle.SelectionForeColor = Color.Gold;
                        }
                        else if (detalhesMovimentacaoDataGridView.Columns[e.ColumnIndex].Name == "Credito")
                        {
                            e.CellStyle.ForeColor = Color.LightGreen;
                            e.CellStyle.SelectionForeColor = Color.DarkGreen;
                        }
                    }
                }
            }
        }
    }
}
