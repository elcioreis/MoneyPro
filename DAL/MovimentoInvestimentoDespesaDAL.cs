using System.Data;
using System.Data.SqlClient;
using System.Text;

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
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("SELECT  ");
            sql.AppendLine("CAST(0 - ROW_NUMBER() OVER(ORDER BY Desp.Ordem) AS int) AS MovimentoInvestimentoDespesaID,  ");
            sql.AppendLine("CAST(-1 AS INT) AS MovimentoInvestimentoID, Desp.CategoriaID, Desp.Ordem,   ");
            sql.AppendLine("Ctgo.vFiltro AS Despesa, CAST(0 AS DECIMAL) AS Valor,   ");
            sql.AppendLine("CAST(CASE WHEN COALESCE(Desp.Descricao, '') <> '' THEN Desp.Descricao   ");
            sql.AppendLine("          WHEN Desp.Saida = 1 THEN 'Despesa de Resgate'   ");
            sql.AppendLine("          ELSE 'Despesa de Aplicação'  ");
            sql.AppendLine("     END AS VARCHAR(25)) AS Parceiro   ");
            sql.AppendLine("FROM InvestimentoDespesa Desp  ");
            sql.AppendLine("INNER JOIN vw_CategoriasSelecionaveis Ctgo ON Ctgo.CategoriaID = Desp.CategoriaID ");
            sql.AppendLine("WHERE Desp.InvestimentoID = @InvestimentoID ");
            if (!saida)
            {
                sql.AppendLine("AND Desp.Entrada = 1 ");
            }
            else
            {
                sql.AppendLine("AND Desp.Saida = 1 ");
            }
            sql.AppendLine("ORDER BY Desp.Ordem ASC; ");

            // Instancia uma tabela
            DataTable table = new DataTable();
            // Instancia uma conexão
            SqlConnection conn = new SqlConnection(Dados.Conexao);
            // Instancia um adaptador
            SqlDataAdapter da = new SqlDataAdapter();
            // Instancia um comando
            SqlCommand query = new SqlCommand(sql.ToString(), conn);
            // Atribui o parâmetro
            query.Parameters.AddWithValue("@InvestimentoID", investimentoID);
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
                @"SELECT 
                             Desp.MovimentoInvestimentoDespesaID, Desp.MovimentoInvestimentoID, Desp.CategoriaID,
                             Desp.Ordem, Ctgo.vFiltro AS Despesa, Desp.Valor, Lcto.Apelido AS Parceiro
                         FROM MovimentoInvestimento Invt
                         INNER JOIN MovimentoInvestimentoDespesa Desp ON Desp.MovimentoInvestimentoID = Invt.MovimentoInvestimentoID
                         LEFT JOIN MovimentoConta Cnta ON Cnta.DoMovimentoContaID = Invt.MovimentoContaID AND Cnta.CategoriaID = Desp.CategoriaID
                         LEFT JOIN Lancamento Lcto ON Lcto.LancamentoID = Cnta.LancamentoID
                         INNER JOIN vw_CategoriasSelecionaveis Ctgo ON Ctgo.CategoriaID = Desp.CategoriaID
                         WHERE Invt.MovimentoContaID = @MovimentoContaID
                         ORDER BY Desp.Ordem ASC;", conn);
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
