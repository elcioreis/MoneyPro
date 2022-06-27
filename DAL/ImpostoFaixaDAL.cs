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
    public class ImpostoFaixaDAL
    {
        public DataTable Listar(int impostoID)
        {
            // Instancia uma tabela
            DataTable table = new DataTable();
            // Instancia uma conexão
            SqlConnection conn = new SqlConnection(Dados.Conexao);
            // Instancia um adaptador
            SqlDataAdapter da = new SqlDataAdapter();
            // Instancia um comando
            SqlCommand query = new SqlCommand("SELECT FaixaID, ImpostoID, Apelido, Dias, Porcentagem " +
                                              "FROM ImpostoFaixa " +
                                              "WHERE ImpostoID = @ImpostoID " +
                                              "ORDER BY Dias;", conn);

            query.Parameters.AddWithValue("@ImpostoID", impostoID);

            // Coloca a query no adaptador
            da.SelectCommand = query;
            // Popula a tabela
            da.Fill(table);
            // Retorn a tabela
            return table;
        }

        public bool ApelidoDisponivel(int impostoID, int faixaID, string apelido)
        {
            bool disponivel = false;

            SqlConnection conn = new SqlConnection(Dados.Conexao);

            SqlCommand cmd = new SqlCommand("SELECT COUNT(*) AS Existe " +
                                            "FROM ImpostoFaixa " +
                                            "WHERE ImpostoID = @ImpostoID " +
                                            "AND Apelido = @Apelido " +
                                            "AND FaixaID <> @FaixaID;", conn);

            cmd.Parameters.AddWithValue("@Apelido", apelido);
            cmd.Parameters.AddWithValue("@ImpostoID", impostoID);
            cmd.Parameters.AddWithValue("@FaixaID", faixaID);

            conn.Open();
            try
            {
                if ((int)cmd.ExecuteScalar() == 0)
                    disponivel = true;
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
            return disponivel;
        }

        public bool DiasDisponivel(int impostoID, int faixaID, int dias)
        {
            bool disponivel = false;

            SqlConnection conn = new SqlConnection(Dados.Conexao);

            SqlCommand cmd = new SqlCommand("SELECT COUNT(*) AS Existe " +
                                            "FROM ImpostoFaixa " +
                                            "WHERE ImpostoID = @ImpostoID " +
                                            "AND Dias = @Dias " +
                                            "AND FaixaID <> @FaixaID;", conn);

            cmd.Parameters.AddWithValue("@Dias", dias);
            cmd.Parameters.AddWithValue("@ImpostoID", impostoID);
            cmd.Parameters.AddWithValue("@FaixaID", faixaID);

            conn.Open();
            try
            {
                if ((int)cmd.ExecuteScalar() == 0)
                    disponivel = true;
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
            return disponivel;
        }

        public bool PorcentagemDisponivel(int impostoID, int faixaID, decimal porcentagem)
        {
            bool disponivel = false;

            SqlConnection conn = new SqlConnection(Dados.Conexao);

            SqlCommand cmd = new SqlCommand("SELECT COUNT(*) AS Existe " +
                                            "FROM ImpostoFaixa " +
                                            "WHERE ImpostoID = @ImpostoID " +
                                            "AND Porcentagem = @Porcentagem " +
                                            "AND FaixaID <> @FaixaID;", conn);

            cmd.Parameters.AddWithValue("@Porcentagem", porcentagem);
            cmd.Parameters.AddWithValue("@ImpostoID", impostoID);
            cmd.Parameters.AddWithValue("@FaixaID", faixaID);

            conn.Open();
            try
            {
                if ((int)cmd.ExecuteScalar() == 0)
                    disponivel = true;
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
            return disponivel;
        }

        public int Incluir(ImpostoFaixa modelo)
        {
            int registro = -1;

            SqlConnection conn = new SqlConnection(Dados.Conexao);

            conn.Open();

            SqlTransaction transacao = conn.BeginTransaction("Transacao");

            try
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.Transaction = transacao;

                    cmd.CommandText = "INSERT INTO ImpostoFaixa " +
                                      "(ImpostoID, Dias, Porcentagem, Apelido) " +
                                      "VALUES " +
                                      "(@ImpostoID, @Dias, @Porcentagem, @Apelido); " +

                                      "SELECT CAST(@@IDENTITY AS INT) AS NovoID;";

                    cmd.Parameters.AddWithValue("@ImpostoID", modelo.ImpostoID);
                    cmd.Parameters.AddWithValue("@Dias", modelo.Dias);
                    cmd.Parameters.AddWithValue("@Porcentagem", modelo.Porcentagem);
                    cmd.Parameters.AddWithValue("@Apelido", modelo.Apelido);

                    registro = (int)cmd.ExecuteScalar();
                    transacao.Commit();
                }
            }
            catch (SyntaxErrorException e)
            {
                transacao.Rollback();
                throw new System.SystemException("Falha ao incluir faixa de imposto.", e);
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }

            return registro;

        }

        public int Alterar(ImpostoFaixa modelo)
        {
            int registro = -1;

            SqlConnection conn = new SqlConnection(Dados.Conexao);

            conn.Open();

            SqlTransaction transacao = conn.BeginTransaction("Transacao");

            try
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.Transaction = transacao;

                    cmd.CommandText = "UPDATE ImpostoFaixa SET " +
                                      "Dias = @Dias, " +
                                      "Porcentagem = @Porcentagem, " +
                                      "Apelido = @Apelido " +
                                      "WHERE FaixaID = @FaixaID; " +

                                      "SELECT CAST(@@ERROR AS INT) AS Erro;";

                    cmd.Parameters.AddWithValue("@Dias", modelo.Dias);
                    cmd.Parameters.AddWithValue("@Porcentagem", modelo.Porcentagem);
                    cmd.Parameters.AddWithValue("@Apelido", modelo.Apelido);
                    cmd.Parameters.AddWithValue("@FaixaID", modelo.FaixaID);

                    if ((int)cmd.ExecuteScalar() == 0)
                        registro = (int)modelo.ImpostoID;

                    transacao.Commit();

                    return registro;
                }
            }
            catch (SyntaxErrorException e)
            {
                transacao.Rollback();
                throw new System.SystemException("Falha ao alterar faixa de imposto.", e);
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }
    }
}
