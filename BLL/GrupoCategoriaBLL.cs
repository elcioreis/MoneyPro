using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelos;
using DAL;
using System.Data;
using System.Windows.Forms;

namespace BLL
{
    public class GrupoCategoriaBLL
    {
        static private int proximoID = 0;

        /// <summary>
        /// Retorna o próximo número ID disponível (de zero pra baixo)
        /// </summary>
        static public int ProximoID
        {
            get
            {
                return --proximoID;
            }
        }

        /// <summary>
        /// Lista com todos os registros da tabela de GrupoCategoria
        /// </summary>
        /// <returns>
        /// Retorna um DataTable
        /// </returns>
        public DataTable Listar(int usuarioID)
        {
            GrupoCategoriaDAL obj = new GrupoCategoriaDAL();
            return obj.Listar(usuarioID);
        }

        public bool Excluir(int GrupoCategoriaId)
        {
            GrupoCategoriaDAL obj = new GrupoCategoriaDAL();
            return obj.Excluir(GrupoCategoriaId);
        }

        /// <summary>
        /// Valida os campos e, se estiverem ok, chama atualização do banco de dados.
        /// </summary>
        /// <param name="registro">GrupoCategoria a ser atualizado ou incluído</param>
        /// <returns>
        /// Retorna true se houve sucesso
        /// </returns>
        public bool AtualizaSeValido(GrupoCategoria registro)
        {
            bool resposta = false;

            // Apelido deve ser preenchido
            if (String.IsNullOrEmpty(registro.Apelido))
            {
                throw new System.ArgumentException("", "O Apelido deve ser preenchido.");
            }
            // Verifica se o apelido está disponível (Apelido é unique)
            else if (!ApelidoDisponivel(registro.GrupoCategoriaID, registro.Apelido))
            {
                throw new System.ArgumentException("", String.Format("O Apelido {0} já está sendo utilizado.", registro.Apelido));
            }
            else
            {
                resposta = true;
            }

            if (resposta)
            {
                // Passou nos testes, tentará gravar o registro no banco de dados

                // Se o ID é maior que zero é uma atualização.
                // Se o ID é menor que zero é uma inclusão.

                GrupoCategoriaDAL obj = new GrupoCategoriaDAL();
                try
                {
                    if (registro.GrupoCategoriaID > 0)
                    {
                        // Atualiza o registro existente
                        resposta = obj.Atualizar(registro);
                    }
                    else
                    {
                        // Inclui novo registro
                        resposta = obj.Incluir(registro);
                    }
                }
                catch (Exception e)
                {
                    resposta = false;
                    MessageBox.Show(e.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            return resposta;
        }

        /// <summary>
        /// Chama o método para verficar na base de dados
        /// </summary>
        /// <param name="UsuarioID">id do registro atual</param>
        /// <param name="apelido">apelido do registro atual</param>
        /// <returns>
        /// Retorna verdadeiro se o apelido estiver disponível para uso
        /// </returns>
        private bool ApelidoDisponivel(int UsuarioID, string apelido)
        {
            GrupoCategoriaDAL obj = new GrupoCategoriaDAL();
            return obj.ApelidoDisponivel(UsuarioID, apelido);
        }

        public int IDdoGrupoCategoria(int usuarioID, string conteudo)
        {
            GrupoCategoriaDAL dal = new GrupoCategoriaDAL();
            return dal.IDdoGrupoCategoria(usuarioID, conteudo);
        }
    }
}
