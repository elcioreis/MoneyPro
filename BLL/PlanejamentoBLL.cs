using DAL;
using Modelos;
using System;
using System.Data;

namespace BLL
{
    public class PlanejamentoBLL
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
        /// Lista com todos os registros da tabela de tipo de contas pertencente ao usuário
        /// </summary>
        /// <returns>
        /// Retorna um DataTable
        /// </returns>
        public DataTable Listar(int usuarioID, Boolean TodosPlanejamentos)
        {
            PlanejamentoDAL dal = new PlanejamentoDAL();
            return dal.Listar(usuarioID, TodosPlanejamentos);
        }

        public DateTime PrimeiroDiaPlanejamento(int usuarioID)
        {
            PlanejamentoDAL dal = new PlanejamentoDAL();
            return dal.PrimeiroDiaPlanejamento(usuarioID);
        }

        public DataTable Planejamento(int planejamentoID)
        {
            PlanejamentoDAL dal = new PlanejamentoDAL();
            return dal.Planejamento(planejamentoID);
        }

        public bool GravarPlanejamento(Planejamento modelo)
        {
            PlanejamentoDAL dal = new PlanejamentoDAL();
            if (modelo.PlanejamentoID <= 0)
                return dal.IncluirPlanejamento(modelo);
            else
                return dal.AlterarPlanejamento(modelo);
        }

        public Boolean ExcluirPlanejamento(int planejamentoID)
        {
            PlanejamentoDAL dal = new PlanejamentoDAL();
            return dal.ExcluirPlanejamento(planejamentoID);
        }

        public bool ExistePlanejamento(int contaID, int lancamentoID, int categoriaID)
        {
            PlanejamentoDAL dal = new PlanejamentoDAL();
            return dal.ExcluirPlanejamento(contaID, lancamentoID, categoriaID);
        }

        public bool EfetivarPlanejamento(Planejamento modelo, out DateTime dataProximoEvento)
        {
            PlanejamentoDAL dal = new PlanejamentoDAL();
            return dal.EfetivarPlanejamento(modelo, out dataProximoEvento);
        }
    }
}
