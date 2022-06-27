using System;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class DetalhesMovimentacaoDAL
    {
        public DataTable Listar(int usuarioID, int? contaID, int? lancamentoID, int? categoriaID, int? grupoCategoriaID)
        {
            // Instancia uma tabela
            DataTable table = new DataTable();
            // Instancia uma conexão
            SqlConnection conn = new SqlConnection(Dados.Conexao);
            // Instancia um adaptador
            SqlDataAdapter da = new SqlDataAdapter();
            // Instancia um comando
            SqlCommand query = new SqlCommand(
                @"SELECT 1 Detalhe, Mvto.MovimentoContaID,
                         Mvto.ContaID, Cnta.Apelido Conta,
                         Mvto.Data, 
                         Mvto.LancamentoID, Lcto.Apelido Lancamento,
                         Mvto.Descricao,
                         Mvto.CategoriaID, Ctng.vFiltro Categoria,
                         Mvto.GrupoCategoriaID, Grpo.Apelido GrupoCategoria,
                         Mvto.CrdDeb, Mvto.Credito, Mvto.Debito, Mvto.Conciliacao,
                         Mvto.PlanejamentoID, Mvto.PlanejamentoRepeticao
                  FROM MovimentoConta Mvto
                  INNER JOIN Conta Cnta ON Cnta.ContaID = Mvto.ContaID
                  INNER JOIN Lancamento Lcto ON Lcto.LancamentoID = Mvto.LancamentoID
                  INNER JOIN vw_CategoriasSelecionaveis Ctng ON Ctng.CategoriaID = Mvto.CategoriaID
                  LEFT  JOIN GrupoCategoria Grpo ON Grpo.GrupoCategoriaID = Mvto.GrupoCategoriaID
                  WHERE Mvto.UsuarioID = @UsuarioID
                  AND   Mvto.Conciliacao <> 'F'
                  AND   Mvto.ContaID = COALESCE(@ContaID, Mvto.ContaID)
                  AND   Mvto.LancamentoID = COALESCE(@LancamentoID, Mvto.LancamentoID)
                  AND   Mvto.CategoriaID = COALESCE(@CategoriaID, Mvto.CategoriaID)
                  AND   COALESCE(Mvto.GrupoCategoriaID, 0) = COALESCE(@GrupoCategoriaID, Mvto.GrupoCategoriaID, 0)

                  UNION ALL

                  SELECT 2 Detalhe, NULL MovimentoContaID,
                         NULL ContaID, NULL Conta,
                         NULL Data, 
                         NULL LancamentoID, NULL Lancamento,
                         NULL Descricao,
                         NULL CategoriaID, NULL Categoria,
                         NULL GrupoCategoriaID, NULL GrupoCategoria,
                         NULL CrdDeb, SUM(Mvto.Credito) Credito, SUM(Mvto.Debito) Debito, NULL Conciliacao,
                         NULL PlanejamentoID, NULL PlanejamentoRepeticao
                  FROM MovimentoConta Mvto
                  INNER JOIN Conta Cnta ON Cnta.ContaID = Mvto.ContaID
                  INNER JOIN Lancamento Lcto ON Lcto.LancamentoID = Mvto.LancamentoID
                  INNER JOIN vw_CategoriasSelecionaveis Ctng ON Ctng.CategoriaID = Mvto.CategoriaID
                  LEFT  JOIN GrupoCategoria Grpo ON Grpo.GrupoCategoriaID = Mvto.GrupoCategoriaID
                  WHERE Mvto.UsuarioID = @UsuarioID
                  AND   Mvto.Conciliacao <> 'F'
                  AND   Mvto.ContaID = COALESCE(@ContaID, Mvto.ContaID)
                  AND   Mvto.LancamentoID = COALESCE(@LancamentoID, Mvto.LancamentoID)
                  AND   Mvto.CategoriaID = COALESCE(@CategoriaID, Mvto.CategoriaID)
                  AND   COALESCE(Mvto.GrupoCategoriaID, 0) = COALESCE(@GrupoCategoriaID, Mvto.GrupoCategoriaID, 0)

                  ORDER BY Detalhe ASC, Data ASC, CrdDeb ASC, MovimentoContaID ASC;", conn);

            // Atribui os parâmetros            
            query.Parameters.AddWithValue("@UsuarioID", usuarioID);
            query.Parameters.AddWithValue("@ContaID", (object)contaID ?? DBNull.Value);
            query.Parameters.AddWithValue("@LancamentoID", (object)lancamentoID ?? DBNull.Value);
            query.Parameters.AddWithValue("@CategoriaID", (object)categoriaID ?? DBNull.Value);
            query.Parameters.AddWithValue("@GrupoCategoriaID", (object)grupoCategoriaID ?? DBNull.Value);

            // Coloca a query no adaptador
            da.SelectCommand = query;
            // Popula a tabela
            da.Fill(table);
            // Retorn a tabela
            return table;
        }
    }
}
