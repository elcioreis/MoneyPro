using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelos;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class MovimentoInvestimentoDespesaDAL
    {
        public DataTable Listar(int movimentoInvestimentoID)
        {
            // Instancia uma tabela
            DataTable table = new DataTable();
            // Instancia uma conexão
            SqlConnection conn = new SqlConnection(Dados.Conexao);
            // Instancia um adaptador
            SqlDataAdapter da = new SqlDataAdapter();
            // Instancia um comando
            SqlCommand query = new SqlCommand(
                "SELECT " +
                "MovimentoInvestimentoDespesaID, MovimentoInvestimentoID, CategoriaID, Ordem, Valor " +
                "FROM MovimentoInvestimentoDespesa " +
                "WHERE MovimentoInvestimentoID = @MovimentoInvestimentoID " +
                "ORDER BY Ordem ASC;", conn);

            // Atribui os parâmetros
            query.Parameters.AddWithValue("@MovimentoInvestimentoID", movimentoInvestimentoID);
            // Coloca a query no adaptador
            da.SelectCommand = query;
            // Popula a tabela
            da.Fill(table);
            // Retorn a tabela
            return table;
        }

        public DataTable CriarListaDespesas(int investimentoID, bool saida)
        {
            // Instancia uma tabela
            DataTable table = new DataTable();
            // Instancia uma conexão
            SqlConnection conn = new SqlConnection(Dados.Conexao);
            // Instancia um adaptador
            SqlDataAdapter da = new SqlDataAdapter();
            // Instancia um comando
            SqlCommand query = new SqlCommand(
                "SELECT " +
                "CAST(0 - ROW_NUMBER() OVER(ORDER BY Desp.Ordem) AS int) AS MovimentoInvestimentoDespesaID, " +
                "CAST(-1 AS INT) AS MovimentoInvestimentoID, Desp.CategoriaID, Desp.Ordem, " +
                "Ctgo.vFiltro AS Despesa, CAST(0 AS DECIMAL) AS Valor, " +
                "CAST(CASE WHEN COALESCE(Desp.Descricao, '') <> '' THEN Desp.Descricao " +
                          "WHEN Desp.Saida = 1 THEN 'Despesa de Resgate' " +
                          "ELSE 'Despesa de Aplicação' " +
                     "END AS VARCHAR(25)) AS Parceiro " +
                "FROM InvestimentoDespesa Desp " +
                "INNER JOIN vw_CategoriasSelecionaveis Ctgo ON Ctgo.CategoriaID = Desp.CategoriaID " +
                "WHERE Desp.InvestimentoID = @InvestimentoID " +
                "AND Desp.Entrada <> @Saida " +
                "AND Desp.Saida = @Saida " +
                "ORDER BY Desp.Ordem ASC;", conn);
            // Atribui os parâmetros
            query.Parameters.AddWithValue("@InvestimentoID", investimentoID);
            query.Parameters.AddWithValue("@Saida", saida);
            // Coloca a query no adaptador
            da.SelectCommand = query;
            // Popula a tabela
            da.Fill(table);
            // Retorn a tabela
            return table;
        }

        public object CarregarListaDespesas(int movimentoContaID)
        {
            // Instancia uma tabela
            DataTable table = new DataTable();
            // Instancia uma conexão
            SqlConnection conn = new SqlConnection(Dados.Conexao);
            // Instancia um adaptador
            SqlDataAdapter da = new SqlDataAdapter();
            // Instancia um comando
            SqlCommand query = new SqlCommand(
                "SELECT " +
                "Desp.MovimentoInvestimentoDespesaID, Desp.MovimentoInvestimentoID, Desp.CategoriaID,  " +
                "Desp.Ordem, Ctgo.vFiltro AS Despesa, Desp.Valor, Lcto.Apelido AS Parceiro " +
                "FROM MovimentoInvestimento Invt " +
                "INNER JOIN MovimentoInvestimentoDespesa Desp " +
                "ON Desp.MovimentoInvestimentoID = Invt.MovimentoInvestimentoID " +
                "LEFT JOIN MovimentoConta Cnta ON Cnta.DoMovimentoContaID = Invt.MovimentoContaID " +
                "AND Cnta.CategoriaID = Desp.CategoriaID " +
                "LEFT JOIN Lancamento Lcto ON Lcto.LancamentoID = Cnta.LancamentoID " +
                "INNER JOIN vw_CategoriasSelecionaveis Ctgo ON Ctgo.CategoriaID = Desp.CategoriaID  " +
                "WHERE Invt.MovimentoContaID = @MovimentoContaID " +
                "ORDER BY Desp.Ordem ASC;", conn);
            // Atribui os parâmetros
            query.Parameters.AddWithValue("@MovimentoContaID", movimentoContaID);
            // Coloca a query no adaptador
            da.SelectCommand = query;
            // Popula a tabela
            da.Fill(table);
            // Retorn a tabela
            return table;
        }
    }
}
