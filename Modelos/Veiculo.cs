using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    public class Veiculo
    {
        private int veiculoID;
        private string placa;
        private string descricao;
        private bool ativo = true;

        public int VeiculoID
        {
            get { return veiculoID; }
            set { veiculoID = value; }
        }

        public string Placa
        {
            get { return placa; }
            set { placa = value; }
        }

        public string Descricao
        {
            get { return descricao; }
            set { descricao = value; }
        }

        public bool Ativo
        {
            get { return ativo; }
            set { ativo = value; }
        }
    }
}
