using Modelos;
using System;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class VeiculoDAL
    {

        public DataTable Listar()
        {
            // Instancia uma tabela
            DataTable tabela = new DataTable();
            // Instacia um Data Adapter com a query abaixo, usando a conexão informada no login
            SqlDataAdapter da = new SqlDataAdapter(@"
                                                    SELECT VeiculoID, Placa, Descricao, Ativo
                                                    FROM Veiculo
                                                    ORDER BY Placa ASC;", Dados.Conexao);
            // Carrega a tabela
            da.Fill(tabela);
            // Retorna a listagem
            return tabela;
        }

        public bool PlacaDisponivel(int veiculoID, string placa)
        {
            bool disponivel = false;
            SqlConnection conn = new SqlConnection(Dados.Conexao);
            SqlCommand cmd = new SqlCommand(@"
                                            SELECT COUNT(*) AS Existe
                                            FROM Veiculo
                                            WHERE Placa = @Placa
                                            AND VeiculoID <> @VeiculoID;", conn);
            cmd.Parameters.AddWithValue("@Placa", placa);
            cmd.Parameters.AddWithValue("@VeiculoID", veiculoID);
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

        public int Incluir(Veiculo veiculo)
        {
            int veiculoID = 0;
            SqlConnection conn = new SqlConnection(Dados.Conexao);
            SqlCommand cmd = new SqlCommand(@"
                                            INSERT INTO Veiculo (Placa, Descricao, Ativo)
                                            VALUES (@Placa, @Descricao, @Ativo);
                                            SELECT SCOPE_IDENTITY();", conn);
            cmd.Parameters.AddWithValue("@Placa", veiculo.Placa);
            cmd.Parameters.AddWithValue("@Descricao", veiculo.Descricao);
            cmd.Parameters.AddWithValue("@Ativo", veiculo.Ativo);
            conn.Open();
            try
            {
                veiculoID = Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch (SyntaxErrorException e)
            {
                throw new System.SystemException("Falha ao incluir veículo.", e);
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
            return veiculoID;
        }

        public int Atualizar(Veiculo veiculo)
        {
            int linhasAfetadas = 0;
            SqlConnection conn = new SqlConnection(Dados.Conexao);
            SqlCommand cmd = new SqlCommand(@"
                                            UPDATE Veiculo
                                            SET Placa = @Placa,
                                                Descricao = @Descricao,
                                                Ativo = @Ativo
                                            WHERE VeiculoID = @VeiculoID;", conn);
            cmd.Parameters.AddWithValue("@Placa", veiculo.Placa);
            cmd.Parameters.AddWithValue("@Descricao", veiculo.Descricao);
            cmd.Parameters.AddWithValue("@Ativo", veiculo.Ativo);
            cmd.Parameters.AddWithValue("@VeiculoID", veiculo.VeiculoID);
            conn.Open();
            try
            {
                linhasAfetadas = cmd.ExecuteNonQuery();
            }
            catch (SyntaxErrorException e)
            {
                throw new System.SystemException("Falha ao atualizar veículo.", e);
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
            return linhasAfetadas;
        }

        public bool Excluir(int veiculoID)
        {
            bool excluido = false;
            SqlConnection conn = new SqlConnection(Dados.Conexao);
            SqlCommand cmd = new SqlCommand(@"
                                            DELETE FROM Veiculo
                                            WHERE VeiculoID = @VeiculoID;", conn);
            cmd.Parameters.AddWithValue("@VeiculoID", veiculoID);
            conn.Open();
            try
            {
                excluido = (cmd.ExecuteNonQuery() > 0);
            }
            catch (SyntaxErrorException e)
            {
                throw new System.SystemException("Falha ao excluir veículo.", e);
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
            return excluido;
        }
    }
}
