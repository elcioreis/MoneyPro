using DAL;
using Modelos;
using System;
using System.Data;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace BLL
{
    public class UsuarioBLL
    {
        static private int proximoID = 0;

        /// <summary>
        /// Retorna o próximo número ID disponível (sempre negativo)
        /// </summary>
        static public int ProximoID
        {
            get
            {
                return --proximoID;
            }
        }

        /// <summary>
        /// Lista com todos os registros da tabela de usuários
        /// </summary>
        /// <returns>
        /// Retorna um DataTable
        /// </returns>
        public DataTable Listagem()
        {
            UsuarioDAL obj = new UsuarioDAL();
            return obj.Listagem();
        }


        /// <summary>
        /// Valida os campos e, se estiverem ok, chama atualização do banco de dados.
        /// </summary>
        /// <param name="registro">Usuário a ser atualizado ou incluído</param>
        /// <returns>
        /// Retorna true se houve sucesso
        /// </returns>
        public bool AtualizaSeValido(Usuario registro)
        {
            bool resposta = false;

            // Apelido deve ser preenchido
            if (String.IsNullOrEmpty(registro.Apelido))
            {
                throw new System.ArgumentException("", "O Apelido deve ser preenchido.");
            }
            // Verifica se o apelido está disponível (Apelido é unique)
            else if (!ApelidoDisponivel(registro.UsuarioID, registro.Apelido))
            {
                throw new System.ArgumentException("", String.Format("O Apelido {0} já está sendo utilizado.", registro.Apelido));
            }
            // Nome deve ser preenchido
            else if (String.IsNullOrEmpty(registro.Nome))
            {
                throw new System.ArgumentException("", "O Nome deve ser preenchido.");
            }
            // Email não é obrigatório, mas se existir deverá ser válido
            else if (!String.IsNullOrEmpty(registro.Email))
            {
                if (!Regex.IsMatch(registro.Email, @"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$"))
                {
                    throw new System.ArgumentException("", "O Email informado é inválido.");
                }
                else
                {
                    resposta = true;
                }
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

                UsuarioDAL obj = new UsuarioDAL();
                try
                {
                    if (registro.UsuarioID > 0)
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

        public bool Excluir(int UsuarioId)
        {
            UsuarioDAL obj = new UsuarioDAL();
            return obj.Excluir(UsuarioId);
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
            UsuarioDAL obj = new UsuarioDAL();
            return obj.ApelidoDisponivel(UsuarioID, apelido);
        }
    }
}
