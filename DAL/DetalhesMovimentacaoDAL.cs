using System;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class DetalhesMovimentacaoDAL
    {
        public DataTable Listar(int usuarioID, int? contaID, int? lancamentoID, int? categoriaID, int? grupoCategoriaID, int? veiculoID)
        {
            // Instancia uma tabela
            DataTable table = new DataTable();
            // Instancia uma conexão
            SqlConnection conn = new SqlConnection(Dados.Conexao);
            // Instancia um adaptador
            SqlDataAdapter da = new SqlDataAdapter();
            // Instancia um comando
            SqlCommand query = new SqlCommand(
                @"
                select 1 Detalhe, Mvto.MovimentoContaID,
                       Mvto.ContaID, Cnta.Apelido Conta,
                       Mvto.Data, 
                       Mvto.LancamentoID, Lcto.Apelido Lancamento,
                       Mvto.Descricao,
                       Mvto.CategoriaID, Ctng.vFiltro Categoria,
                       Mvto.GrupoCategoriaID, Grpo.Apelido GrupoCategoria,
                       Mvto.VeiculoID, Vcl.Placa Veiculo,
                       Mvto.CrdDeb, Mvto.Credito, Mvto.Debito, Mvto.Conciliacao,
                       Mvto.PlanejamentoID, Mvto.PlanejamentoRepeticao
                from MovimentoConta Mvto
                inner join Conta Cnta ON Cnta.ContaID = Mvto.ContaID
                inner join Lancamento Lcto ON Lcto.LancamentoID = Mvto.LancamentoID
                inner join vw_CategoriasSelecionaveis Ctng ON Ctng.CategoriaID = Mvto.CategoriaID
                left  join GrupoCategoria Grpo ON Grpo.GrupoCategoriaID = Mvto.GrupoCategoriaID
                left  join Veiculo Vcl ON Vcl.VeiculoID = Mvto.VeiculoID    
                where Mvto.UsuarioID = @UsuarioID
                  and Mvto.Conciliacao <> 'F'
                  and Mvto.ContaID = COALESCE(@ContaID, Mvto.ContaID)
                  and Mvto.LancamentoID = COALESCE(@LancamentoID, Mvto.LancamentoID)
                  and Mvto.CategoriaID = COALESCE(@CategoriaID, Mvto.CategoriaID)
                  and coalesce(Mvto.VeiculoID, 0) = coalesce(@VeiculoID, Mvto.VeiculoID, 0)
                  and coalesce(Mvto.GrupoCategoriaID, 0) = coalesce(@GrupoCategoriaID, Mvto.GrupoCategoriaID, 0)

                union all

                select 2 Detalhe, null MovimentoContaID,
                       null ContaID, null Conta,
                       null Data, 
                       null LancamentoID, null Lancamento,
                       null Descricao,
                       null CategoriaID, null Categoria,
                       null VeiculoID, null Veiculo,
                       null GrupoCategoriaID, null GrupoCategoria,
                       null CrdDeb, SUM(Mvto.Credito) Credito, SUM(Mvto.Debito) Debito, null Conciliacao,
                       null PlanejamentoID, null PlanejamentoRepeticao
                from MovimentoConta Mvto
                inner join Conta Cnta ON Cnta.ContaID = Mvto.ContaID
                inner join Lancamento Lcto ON Lcto.LancamentoID = Mvto.LancamentoID
                inner join vw_CategoriasSelecionaveis Ctng ON Ctng.CategoriaID = Mvto.CategoriaID
                left  join GrupoCategoria Grpo ON Grpo.GrupoCategoriaID = Mvto.GrupoCategoriaID
                left  join Veiculo Vcl ON Vcl.VeiculoID = Mvto.VeiculoID
                where Mvto.UsuarioID = @UsuarioID
                  and Mvto.Conciliacao <> 'F'
                  and Mvto.ContaID = COALESCE(@ContaID, Mvto.ContaID)
                  and Mvto.LancamentoID = COALESCE(@LancamentoID, Mvto.LancamentoID)
                  and Mvto.CategoriaID = COALESCE(@CategoriaID, Mvto.CategoriaID)
                  and coalesce(Mvto.VeiculoID, 0) = coalesce(@VeiculoID, Mvto.VeiculoID, 0)
                  and coalesce(Mvto.GrupoCategoriaID, 0) = coalesce(@GrupoCategoriaID, Mvto.GrupoCategoriaID, 0)

                order by Detalhe ASC, Data ASC, CrdDeb ASC, MovimentoContaID ASC;", conn);

            // Atribui os parâmetros            
            query.Parameters.AddWithValue("@UsuarioID", usuarioID);
            query.Parameters.AddWithValue("@ContaID", (object)contaID ?? DBNull.Value);
            query.Parameters.AddWithValue("@LancamentoID", (object)lancamentoID ?? DBNull.Value);
            query.Parameters.AddWithValue("@CategoriaID", (object)categoriaID ?? DBNull.Value);
            query.Parameters.AddWithValue("@GrupoCategoriaID", (object)grupoCategoriaID ?? DBNull.Value);
            query.Parameters.AddWithValue("@VeiculoID", (object)veiculoID ?? DBNull.Value);

            // Coloca a query no adaptador
            da.SelectCommand = query;
            // Popula a tabela
            da.Fill(table);
            // Retorn a tabela
            return table;
        }
    }
}
