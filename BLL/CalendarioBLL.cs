using DAL;
using Modelos;
using System;
using System.Data;
using System.Windows.Forms;

namespace BLL
{
    public class CalendarioBLL
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

        public DataTable Listar(DateTime dataInicio, int periodos)
        {
            CalendarioDAL dal = new CalendarioDAL();
            return dal.Listar(dataInicio, periodos);
        }

        public bool Validar(Calendario feriado)
        {
            string msg = null;

            // Verifica se o apelido foi preenchido
            if (String.IsNullOrEmpty(feriado.Descricao))
            {
                msg = "A descrição deve ser informada.";
            }


            if (!String.IsNullOrEmpty(msg))
            {
                // Se exibir qualquer mensagem na tela, não será considerado válido
                MessageBox.Show(msg, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else
            {
                return true;
            }
        }

        public int Gravar(Calendario feriado)
        {
            CalendarioDAL dal = new CalendarioDAL();

            if (feriado.FeriadoID < 0)
            {
                // É uma inclusão
                return dal.Incluir(feriado);
            }
            else
            {
                // É uma alteração
                return dal.Alterar(feriado);
            }
        }
    }
}
