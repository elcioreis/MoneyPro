using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Modelos;
using System.Data;

namespace BLL
{
    public class CategoriaBLL
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
        /// Lista com todos os registros da tabela de categoria pertencente ao usuário
        /// </summary>
        /// <returns>
        /// Retorna um DataTable
        /// </returns>
        public DataTable Listar(int usuarioID)
        {
            CategoriaDAL obj = new CategoriaDAL();
            return obj.Listar(usuarioID);
        }

        /// <summary>
        /// Lista somente as categorias selecionáveis
        /// </summary>
        /// <returns>
        /// Retorna um DataTable
        /// </returns>
        public DataTable ListarSelecionaveis(int usuarioID, int nivel = 0)
        {
            CategoriaDAL dal = new CategoriaDAL();
            return dal.ListarSelecionaveis(usuarioID, nivel);
        }


        /// <summary>
        /// Lista com todas as categorias que podem ser selecionadas como ancestral
        /// </summary>
        /// <returns>
        /// Retorna um DataTable
        /// </returns>
        public DataTable Ancestral(int usuarioID)
        {
            CategoriaDAL obj = new CategoriaDAL();
            return obj.Ancestral(usuarioID);
        }

        public int Gravar(Categoria registro)
        {
            CategoriaDAL obj = new CategoriaDAL();

            if (registro.CategoriaID < 0)
                return obj.Incluir(registro);
            else
                return obj.Atualizar(registro);
        }

        public int IDdaCategoriaPadraoCDB(int idUsuario)
        {
            CategoriaDAL obj = new CategoriaDAL();
            return obj.IDdaCategoriaPadraoCDB(idUsuario);
        }

        public bool Excluir(int categoriaID)
        {
            CategoriaDAL obj = new CategoriaDAL();
            return obj.Excluir(categoriaID);
        }

        public int IDdaCategoria(int usuarioID, string conteudo)
        {
            CategoriaDAL dal = new CategoriaDAL();

            // Tenta buscar a categoria sem manipular a string.
            int id = dal.PesquisaCategoriaID(usuarioID, conteudo);

            if (id > 0)
            {
                // encontrou a categoria, retornará a id
                return id;
            }
            else
            {
                // Não encontrou a categoria.
                int lastPos = conteudo.LastIndexOf(':');

                // Se tem dois pontos, tentará quebrar e procurar a categoria principal.
                if (lastPos >= 0)
                {
                    // pega a categoria principal
                    string primeiraParte = conteudo.Substring(0, lastPos).Trim();
                    // pega a categoria secundária
                    string ultimaParte = conteudo.Substring(lastPos + 1).Trim();

                    // Pesquisa a categoria principal
                    id = dal.PesquisaCategoriaID(usuarioID, primeiraParte);

                    if (id > 0)
                    {
                        // Se encontrou a categoria principal, incluirá a categoria secundária nela.
                        return dal.AdicionaCategoriaID(usuarioID, id, ultimaParte);
                    }
                    else
                    {
                        // Se não encontrou
                        return 0;
                    }
                }
                else
                {
                    // Se não encontrou
                    return 0;
                }

            }
//            return dal.IDdaCategoria(usuarioID, conteudo);
        }
    }
}
