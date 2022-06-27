using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    /// <summary>
    /// Agrupamento de categorias, visa unificar lançamentos diferentes como:
    /// Alimentação:Refeição
    /// Transporte:Ônibus
    /// Serviços:Contabilidade
    /// 
    /// Todos como Trabalho
    /// </summary>
    public class GrupoCategoria
    {
        /// <summary>
        /// ID do Grupo
        /// </summary>
        private int grupoCategoriaID = 0;
        public int GrupoCategoriaID
        {
            get { return grupoCategoriaID; }
            set { grupoCategoriaID = value; }
        }

        /// <summary>
        /// Usuário que criou o Grupo de categorias
        /// </summary>
        private int usuarioID = 0;
        public int UsuarioID
        {
            get { return usuarioID; }
            set { usuarioID = value; }
        }

        /// <summary>
        /// Apelido do grupo
        /// </summary>
        private string apelido;
        public string Apelido
        {
            get { return apelido; }
            set { apelido = value; }
        }

        /// <summary>
        /// Descrição do grupo
        /// </summary>
        private string descricao;
        public string Descricao
        {
            get { return descricao; }
            set { descricao = value; }
        }

        /// <summary>
        /// Informa se o grupo está ou não ativo.
        /// </summary>
        private bool ativo = true;
        public bool Ativo
        {
            get { return ativo; }
            set { ativo = value; }
        }

        public bool Automatico { get; set; }
        public decimal Proporcao { get; set; }
    }//end GrupoCategoria

}
