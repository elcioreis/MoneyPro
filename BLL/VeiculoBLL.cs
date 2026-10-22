using System;
using DAL;
using System.Data;
using System.Windows.Forms;
using Modelos;

namespace BLL
{
    public class VeiculoBLL
    {
        static private int proximoID = 0;

        static public int ProximoID
        {
            get { return --proximoID; }
        }

        public DataTable Listar()
        {
            VeiculoDAL dal = new VeiculoDAL();
            return dal.Listar();
        }

        public bool PlacaDisponivel(int veiculoID, string placa)
        {
            VeiculoDAL dal = new VeiculoDAL();
            return dal.PlacaDisponivel(veiculoID, placa);
        }

        public int Gravar(Veiculo veiculo)
        {
            VeiculoDAL dal = new VeiculoDAL();
            if (veiculo.VeiculoID < 0)
            {
                return dal.Incluir(veiculo);
            }
            else
            {
                return dal.Atualizar(veiculo);
            }
        }

        public bool Excluir(int veiculoID)
        {
            VeiculoDAL dal = new VeiculoDAL();
            return dal.Excluir(veiculoID);
        }
    }
}