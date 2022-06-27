using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Dados
    {
        #region Conexão Banco de dados

        private static string _conexao = String.Empty;

        public static string Conexao
        {
            get
            {
                return CriptografaConexao(_conexao);
            }

            set
            {
                _conexao = CriptografaConexao(value);
            }

        }

        public static string CriptografaConexao(string plano)
        {
            // Essa função é vai e volta.

            // Codifica(texto-plano) > texto-criptografado
            // Codifica(texto-criptografado) > texto-plano

            StringBuilder cripto = new StringBuilder();

            for (int i = 0; i < plano.Length; i++)
            {
                cripto.Append(Convert.ToChar(255 - (Convert.ToInt32(plano[i]) - 28)));
            }

            return cripto.ToString();
        }

        #endregion Conexão Banco de dados

    }
}
