using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Modelos;
using BLL;
using MoneyPro.Base;
using System.Text.RegularExpressions;

namespace MoneyPro
{
    public partial class fmCategorias : MoneyPro.Base.fmBaseSoTopo
    {
        private int _usuarioID;
        private int _posicao;

        private BindingList<GrupoCategoria> grupoCategorias = new BindingList<GrupoCategoria>();

        #region Singleton

        private static fmCategorias _singleton;

        private fmCategorias()
        {
            InitializeComponent();
        }

        public static fmCategorias CreateInstance()
        {
            if (_singleton == null)
            {
                _singleton = new fmCategorias();
            }
            return _singleton;
        }

        protected override void OnClosed(EventArgs e)
        {
            _singleton = null;
            base.OnClosed(e);
        }

        #endregion Singleton

        #region Eventos

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            _usuarioID = Geral.UserID;
            pnlDireita.Size = new Size(400, 100);
            // Esconde os campos de edição de categoria
            AcessoCampos(false);
            CarregaDados();
            // Coloca o foco na árvore hierárquica
            treeViewCategorias.Focus();
        }

        private void buttonIncluirGrupos_Click(object sender, EventArgs e)
        {
            IncluirGrupoCategoria();
        }

        private void buttonExcluirGrupos_Click(object sender, EventArgs e)
        {
            ExcluirGrupoCategoria();
        }

        private void buttonEditarCategoria_Click(object sender, EventArgs e)
        {
            EditarCategoria();
        }

        private void EditarCategoria()
        {
            AcessoCampos(true);
            CarregarRegistroCategoria();
        }

        private void buttonIncluirCategoria_Click(object sender, EventArgs e)
        {
            IncluirCategoria();
        }

        private void IncluirCategoria()
        {
            AcessoCampos(true);
            IncluirRegistroCategoria();
        }

        private void toolTip_Draw(object sender, DrawToolTipEventArgs e)
        {
            e.DrawBackground();
            e.DrawBorder();
            e.DrawText();
        }

        private void fmCategorias_KeyDown(object sender, KeyEventArgs e)
        {
            // Verifica se o foco está no gridGrupoCategoria
            if (gridGrupoCategoria.Focused)
            {
                if (!gridGrupoCategoria.IsCurrentCellInEditMode)
                {
                    // Se teclado Insert sem modificadores
                    if (e.Modifiers == Keys.None && e.KeyCode == Keys.Insert)
                    {
                        IncluirGrupoCategoria();
                    }
                    // Se teclado Ctrl + Delete
                    else if (e.Modifiers == Keys.Control && e.KeyCode == Keys.Delete)
                    {
                        ExcluirGrupoCategoria();
                    }
                    // Se teclado Escape sem modificadores
                    else if (e.Modifiers == Keys.None && e.KeyCode == Keys.Escape)
                    {
                        CancelarLinhaNova();
                    }

                }
            }
            else if (treeViewCategorias.Focused)
            {
                // Se teclado Insert (sem modificadores (Alt ou Ctrl ou Shif))
                if (e.Modifiers == Keys.None && e.KeyCode == Keys.Insert)
                {
                    IncluirCategoria();
                }
                // Se teclado Delete (sem modificadores (Alt ou Ctrl ou Shift))
                else if (e.Modifiers == Keys.None && e.KeyCode == Keys.F2)
                {
                    EditarCategoria();
                }
                // Se teclado Ctrl + Delete
                else if (e.Modifiers == Keys.Control && e.KeyCode == Keys.Delete)
                {
                    ExcluirCategoria();
                }
            }
        }

        private void gridGrupoCategoria_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar))
            {
                // pega o número da coluna corrente
                int cell = gridGrupoCategoria.CurrentCell.ColumnIndex;

                // pega o campo de dados associado a coluna
                string coluna = gridGrupoCategoria.Columns[cell].DataPropertyName;

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
            }
        }

        private void gridGrupoCategoria_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            gridGrupoCategoria.EditingControl.KeyPress += gridGrupoCategoria_KeyPress;
        }

        private void gridGrupoCategoria_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (gridGrupoCategoria.RowCount > 0 && gridGrupoCategoria.CurrentRow != null)
            {
                if (gridGrupoCategoria.IsCurrentRowDirty || (int)gridGrupoCategoria.CurrentRow.Cells["GrupoCategoriaID"].Value < 0)
                {
                    DataGridViewRow linha = gridGrupoCategoria.CurrentRow;

                    GrupoCategoria atual = new GrupoCategoria();

                    atual.GrupoCategoriaID = (int)linha.Cells["GrupoCategoriaID"].Value;
                    atual.UsuarioID = (int)linha.Cells["UsuarioID"].Value;

                    if (linha.Cells["Apelido"].Value != DBNull.Value)
                        atual.Apelido = (string)linha.Cells["Apelido"].Value;
                    else
                        atual.Apelido = String.Empty;

                    if (linha.Cells["Descricao"].Value != DBNull.Value)
                        atual.Descricao = (string)linha.Cells["Descricao"].Value;
                    else
                        atual.Descricao = String.Empty;

                    if (linha.Cells["Ativo"].Value != DBNull.Value)
                        atual.Ativo = (bool)linha.Cells["Ativo"].Value;
                    else
                        atual.Ativo = true;

                    if (linha.Cells["Proporcao"].Value != DBNull.Value)
                        atual.Proporcao = (decimal)linha.Cells["Proporcao"].Value;
                    else
                        atual.Proporcao = 100;

                    GrupoCategoriaBLL grupoCategoria = new GrupoCategoriaBLL();

                    try
                    {
                        e.Cancel = !grupoCategoria.AtualizaSeValido(atual);

                        if (!e.Cancel)
                        {
                            CarregaGruposCategorias(_usuarioID);
                        }
                    }
                    catch (ArgumentException ex)
                    {
                        MessageBox.Show(ex.ParamName, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        e.Cancel = true;
                    }
                }
            }
        }

        private void treeViewCategorias_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (treeViewCategorias.SelectedNode != null)
            {
                int categoriaID = -1;

                if (int.TryParse(treeViewCategorias.SelectedNode.Name, out categoriaID))
                {
                    int reg = categoriaBindingSource.Find("CategoriaID", categoriaID);

                    categoriaBindingSource.Position = reg;
                }

                AcessoCampos(false);

                // Somente poderá haver três níveis. (zero-based)
                // Se estiver no nível 0 não poderá excluir
                buttonExcluirCategoria.Enabled = (treeViewCategorias.SelectedNode.Level > 0);
                // Se estiver no nível 2 não poderá incluir
                buttonIncluirCategoria.Enabled = (treeViewCategorias.SelectedNode.Level < 2);
            }
        }

        #endregion Eventos

        #region Tratamento de dados

        private void CarregaDados()
        {
            CarregaCategorias(_usuarioID);
            CarregaGruposCategorias(_usuarioID);

            SelecionaPrimeiroNode();
        }

        private void SelecionaPrimeiroNode()
        {
            if (treeViewCategorias.Nodes.Count > 0)
            {
                treeViewCategorias.SelectedNode = treeViewCategorias.Nodes[0];
                treeViewCategorias.Select();
            }
        }

        private void CarregaCategorias(int usuarioID)
        {
            CategoriaBLL obj = new CategoriaBLL();
            categoriaBindingSource.DataSource = obj.Listar(usuarioID);

            ancestralBindingSource.DataSource = obj.Ancestral(usuarioID);

            DataTable categorias = obj.Listar(usuarioID);
            categoriaBindingSource.DataSource = categorias;

            treeViewCategorias.BeginUpdate();

            treeViewCategorias.Nodes.Clear();

            foreach (DataRow item in categorias.Rows)
            {
                int categoriaID = item.Field<int>("CategoriaID");
                int? categoriaPaiID = item.Field<int?>("CategoriaPaiID");
                string apelido = item.Field<string>("Apelido");
                string descricao = item.Field<string>("Descricao");
                bool fixo = item.Field<bool>("Fixo");

                string label = null;

                if (!String.IsNullOrEmpty(descricao))
                    label = apelido + "  (" + descricao + ")";
                else
                    label = apelido;

                if (categoriaPaiID == null)
                {
                    // A categoria não possui pai, então será criado um nó na raiz.
                    treeViewCategorias.Nodes.Add(categoriaID.ToString(), label);
                }
                else
                {
                    // A categoria possui pai, então procurará pela chave (categoriaID) pra incluir um nó abaixo
                    TreeNode[] node = treeViewCategorias.Nodes.Find(categoriaPaiID.ToString(), true);

                    if (node.Length > 0)
                    {
                        TreeNode novo = node[0].Nodes.Add(categoriaID.ToString(), label);

                        if (fixo)
                            novo.NodeFont = new Font(treeViewCategorias.Font, FontStyle.Underline);
                            
                    }
                }
            }

            treeViewCategorias.EndUpdate();
            treeViewCategorias.ExpandAll();
        }

        private void CarregaGruposCategorias(int usuarioID)
        {
            gridGrupoCategoria.RowValidating -= gridGrupoCategoria_RowValidating;

            GrupoCategoriaBLL obj = new GrupoCategoriaBLL();
            grupoCategoriaBindingSource.DataSource = obj.Listar(usuarioID);

            gridGrupoCategoria.RowValidating += gridGrupoCategoria_RowValidating;
        }

        private void IncluirGrupoCategoria()
        {
            // Se a linha atual não for nula
            if (gridGrupoCategoria.CurrentRow != null)
            {
                // Se a linha atual tiver índice menor que zero
                if ((int)gridGrupoCategoria.CurrentRow.Cells["GrupoCategoriaID"].Value < 0)
                {
                    // Cancela a inclusão, pois índices menores que zero estão em inclusão
                    return;
                }
            }

            DataTable table = (DataTable)(grupoCategoriaBindingSource.DataSource);
            DataRow row = table.NewRow();

            row["GrupoCategoriaID"] = GrupoCategoriaBLL.ProximoID;
            row["UsuarioID"] = Geral.UserID;
            row["Apelido"] = String.Empty;
            row["Descricao"] = String.Empty;
            row["Ativo"] = true;

            table.Rows.Add(row);

            gridGrupoCategoria.Focus();

            int lin = gridGrupoCategoria.Rows.Count - 1;
            int col = Geral.PrimeiraColunaVisivel(gridGrupoCategoria);
            gridGrupoCategoria.CurrentCell = gridGrupoCategoria.Rows[lin].Cells[col];

        }

        private void CancelarLinhaNova()
        {
            if ((int)gridGrupoCategoria.CurrentRow.Cells["GrupoCategoriaID"].Value < 0)
            {
                gridGrupoCategoria.Rows.Remove(gridGrupoCategoria.CurrentRow);
                CarregaGruposCategorias(_usuarioID);
            }
        }

        private void ExcluirGrupoCategoria()
        {
            if (gridGrupoCategoria.CurrentRow != null)
            {
                string msg = String.Format("Deseja excluir o grupo de categoria {0}?", gridGrupoCategoria.CurrentRow.Cells["Apelido"].Value);
                DialogResult dr = MessageBox.Show(msg, "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

                if (dr == DialogResult.Yes)
                {
                    try
                    {
                        GrupoCategoriaBLL obj = new GrupoCategoriaBLL();
                        obj.Excluir((int)gridGrupoCategoria.CurrentRow.Cells["GrupoCategoriaID"].Value);

                        CarregaGruposCategorias(_usuarioID);
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }

        private void IncluirRegistroCategoria()
        {
            _posicao = categoriaBindingSource.Position;

            DataTable table = (DataTable)categoriaBindingSource.DataSource;
            DataRow row = table.NewRow();

            table.Rows.Add(row);

            // No caso de inclusão, coloca um número negativo pra sinalizar
            row["CategoriaID"] = CategoriaBLL.ProximoID;
            // Coloca a categoria do registro atual como pai da próxima categoria
            row["CategoriaPaiID"] = table.Rows[_posicao].Field<int>("CategoriaID");
            // Informa que não há grupo selecionado
            row["GrupoCategoriaID"] = DBNull.Value;
            // Informa que a categoria é ativa
            row["Ativo"] = true;
            // Informa que a conta não é fixa
            row["Fixo"] = false;
            // Define que não é informação postada pelo sistema
            row["Sistema"] = false;
            // Define o número do usuário
            row["UsuarioID"] = _usuarioID;
            // Tipifica o registro
            row["CrdDeb"] = table.Rows[_posicao].Field<string>("CrdDeb");

            categoriaBindingSource.MoveLast();
        }

        private void  CarregarRegistroCategoria()
        {
            _posicao = categoriaBindingSource.Position;

            DataTable table = (DataTable)categoriaBindingSource.DataSource;
            DataRow row = table.Rows[_posicao];
        }

        #endregion Tratamento de dados

        #region Tratamento de tela

        private void AcessoCampos(bool libera)
        {
            gpbDetalhes.Visible = libera;

            if (cbxAncestral.SelectedValue == null)
                cbxAncestral.Text = String.Empty;

            if (cbxGrupo.SelectedValue == null)
                cbxGrupo.Text = String.Empty;

            // Botões de gravar e cancelar
            buttonGravarCategoria.Visible = libera;
            buttonCancelarCategoria.Visible = libera;

            if (libera)
                apelidoTextBox.Focus();
            else
                treeViewCategorias.Focus();

        }

        #endregion Tratamento de tela

        private void buttonCancelarCategoria_Click(object sender, EventArgs e)
        {
            categoriaBindingSource.Position = _posicao;
            AcessoCampos(false);
        }

        private void buttonGravarCategoria_Click(object sender, EventArgs e)
        {
            DialogResult dr = DialogResult.None;

            int atual = categoriaBindingSource.Position;

            DataRow row = ((DataTable)categoriaBindingSource.DataSource).Rows[atual];

            Categoria registro = new Categoria();
            registro.CategoriaID = (int)row["CategoriaID"];
            registro.Ativo = (bool)row["Ativo"];
            registro.Sistema = (bool)row["Sistema"];
            registro.Fixo = (bool)row["Fixo"];
            registro.UsuarioID = (int)row["UsuarioID"];
            registro.CrdDeb = (string)row["CrdDeb"];

            if (cbxGrupo.SelectedValue != null)
            {
                if (row["GrupoCategoriaID"] != DBNull.Value)
                    registro.GrupoCategoriaID = (int)row["GrupoCategoriaID"];
                else
                    registro.GrupoCategoriaID = null;
            }
            else
            {
                registro.GrupoCategoriaID = null;
            }

            if (row["ContaID"] != DBNull.Value)
                registro.ContaID = (int)row["ContaID"];
            else
                registro.ContaID = null;

            if (row["Descricao"] != DBNull.Value)
                registro.Descricao = (string)row["Descricao"];
            else
                registro.Descricao = null;

            // Se a categoria for criada pelo sistema, a categoria pai será nula
            if (!(bool)row["Sistema"])
            {
                if (row["CategoriaPaiID"] != DBNull.Value)
                    registro.CategoriaPaiID = (int)row["CategoriaPaiID"];
                else
                    dr = MessageBox.Show("A categoria ancestral deve ser informada", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                row["CategoriaPaiID"] = DBNull.Value;
            }

            if (dr == DialogResult.None)
            {
                if (row["Apelido"] != DBNull.Value)
                    registro.Apelido = (string)row["Apelido"];
                else
                    dr = MessageBox.Show("O apelido deve ser informado", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            if (dr == DialogResult.None)
            {
                // Se chegou aqui, tenta gravar.
                CategoriaBLL obj = new CategoriaBLL();
                int novaCategoriaID = obj.Gravar(registro);

                // Recarrega a árvore de categorias
                CarregaCategorias(_usuarioID);

                // Pesquisa o nó onde está a categoria incluída ou alterada.
                TreeNode[] node = treeViewCategorias.Nodes.Find(novaCategoriaID.ToString(), true);
                // Se encontrou o nó, posiciona nele.
                if (node.Length > 0)
                    treeViewCategorias.SelectedNode = node[0];

                AcessoCampos(false);
            }
        }

        private void buttonExcluirCategoria_Click(object sender, EventArgs e)
        {
            ExcluirCategoria();
        }

        private void ExcluirCategoria()
        {
            if (treeViewCategorias.SelectedNode != null)
            {
                string msg = "Confirma a exclusão da categoria " + treeViewCategorias.SelectedNode.Text + "?";
                DialogResult dr = MessageBox.Show(msg, "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);

                if (dr == DialogResult.Yes)
                {
                    int categoriaID;

                    if (int.TryParse(treeViewCategorias.SelectedNode.Name, out categoriaID))
                    {
                        CategoriaBLL obj = new CategoriaBLL();
                        if (obj.Excluir(categoriaID))
                            CarregaCategorias(_usuarioID);
                        SelecionaPrimeiroNode();
                    }
                }
            }
        }
    }
}
