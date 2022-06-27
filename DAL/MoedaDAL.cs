using Modelos;
using System;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class MoedaDAL
    {
        /// <summary>
        /// Retorna uma lista contendo todos os registros da tabela Usuario
        /// </summary>
        /// <returns>
        /// Retorna DataTable
        /// </returns>
        public DataTable ListarMoeda()
        {
            // Instancia uma tabela
            DataTable tabela = new DataTable();
            // Instacia um Data Adapter com a query abaixo, usando a conexão informada no login
            SqlDataAdapter da = new SqlDataAdapter(@"SELECT MoedaID, Apelido, Simbolo, Padrao, Virtual, PadraoVirtual, 
                                                            MercadoBitCoin, CodigoMoedaBancoCentral, Observacao, Eletronica
                                                     FROM Moeda
                                                     ORDER BY Apelido ASC;", Dados.Conexao);
            // Carrega a tabela
            da.Fill(tabela);
            // Retorna a listagem
            return tabela;
        }

        public bool ApelidoDisponivel(int moedaID, string apelido)
        {
            bool disponivel = false;

            SqlConnection conn = new SqlConnection(Dados.Conexao);

            SqlCommand cmd = new SqlCommand("SELECT COUNT(*) AS Existe "+
                                            "FROM Moeda "+
                                            "WHERE Apelido = @Apelido "+
                                            "AND MoedaID <> @MoedaID;", conn);

            cmd.Parameters.AddWithValue("@Apelido", apelido);
            cmd.Parameters.AddWithValue("@moedaID", moedaID);

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

        public bool SimboloDisponivel(int moedaID, string simbolo)
        {
            bool disponivel = false;

            SqlConnection conn = new SqlConnection(Dados.Conexao);

            SqlCommand cmd = new SqlCommand("SELECT COUNT(*) AS Existe " +
                                            "FROM Moeda " +
                                            "WHERE Simbolo = @Simbolo " +
                                            "AND MoedaID <> @MoedaID;", conn);

            cmd.Parameters.AddWithValue("@Simbolo", simbolo);
            cmd.Parameters.AddWithValue("@moedaID", moedaID);

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

        /// <summary>
        /// Inclui o registro atual no banco de dados
        /// </summary>
        //public int Incluir(string pelido, string simbolo, bool padrao)
        public int Incluir(Moeda moeda)
        {
            int registro = -1;

            SqlConnection conn = new SqlConnection(Dados.Conexao);

            SqlCommand cmd = new SqlCommand(
                @"INSERT INTO Moeda
                  (Apelido, Simbolo, Padrao, Virtual, PadraoVirtual, CodigoMoedaBancoCentral, Eletronica, MercadoBitCoin)
                  VALUES
                  (@Apelido, @Simbolo, @Padrao, @Virtual, @PadraoVirtual, @CodigoMoedaBancoCentral, @Eletronica, @MercadoBitCoin);
                  
                  DECLARE @MoedaID INT;
                  SELECT @MoedaID = CAST(@@IDENTITY AS INT);
                  
                  IF (@Padrao = 1)
                      UPDATE Moeda
                      SET Padrao = 0
                      WHERE MoedaID <> @MoedaID;
                  
                  IF (@PadraoVirtual = 1)
                      UPDATE Moeda
                      SET PadraoVirtual = 0
                      WHERE MoedaID <> @MoedaID;
                  
                  SELECT @MoedaID AS MoedaID;", conn);

            cmd.Parameters.AddWithValue("@Apelido", moeda.Apelido);
            cmd.Parameters.AddWithValue("@Simbolo", moeda.Simbolo);
            cmd.Parameters.AddWithValue("@Padrao", moeda.Padrao);
            cmd.Parameters.AddWithValue("@Virtual", moeda.Virtual);
            cmd.Parameters.AddWithValue("@PadraoVirtual", moeda.PadraoVirtual);
            cmd.Parameters.AddWithValue("@CodigoMoedaBancoCentral", (object)moeda.CodigoMoedaBancoCentral ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@Eletronica", (object)moeda.Eletronica ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@MercadoBitCoin", moeda.MercadoBitCoin);

            conn.Open();
            try
            {
                registro = (int)cmd.ExecuteScalar();
            }
            catch (SyntaxErrorException e)
            {
                throw new System.SystemException("Falha ao incluir moeda.", e);
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }

            return registro;
        }


        /// <summary>
        /// Atualiza o registro corrente
        /// </summary>
        //public int Atualizar(int moedaID, string apelido, string simbolo, bool padrao)
        public int Atualizar(Moeda moeda)
        {
            int registro = -1;
            
            SqlConnection conn = new SqlConnection(Dados.Conexao);

            SqlCommand cmd = new SqlCommand(
                @"UPDATE Moeda 
                  SET Apelido = @Apelido,
                      Simbolo = @Simbolo,
                      Padrao = @Padrao,
                      Virtual = @Virtual,
                      PadraoVirtual = @PadraoVirtual,
                      CodigoMoedaBancoCentral = @CodigoMoedaBancoCentral,
                      Eletronica = @Eletronica,
                      MercadoBitCoin = @MercadoBitCoin
                  WHERE MoedaID = @MoedaID;

                  IF (@Padrao = 1)
                      UPDATE Moeda
                      SET Padrao = 0
                      WHERE MoedaID <> @MoedaID;

                  IF (@PadraoVirtual = 1) 
                      UPDATE Moeda 
                      SET PadraoVirtual = 0
                      WHERE MoedaID <> @MoedaID;

                  SELECT CAST(@@ERROR AS INT);", conn);

            cmd.Parameters.AddWithValue("@MoedaID", moeda.MoedaID);
            cmd.Parameters.AddWithValue("@Apelido", moeda.Apelido);
            cmd.Parameters.AddWithValue("@Simbolo", moeda.Simbolo);
            cmd.Parameters.AddWithValue("@Padrao", moeda.Padrao);
            cmd.Parameters.AddWithValue("@Virtual", moeda.Virtual);
            cmd.Parameters.AddWithValue("@PadraoVirtual", moeda.PadraoVirtual);
            cmd.Parameters.AddWithValue("@CodigoMoedaBancoCentral", (object)moeda.CodigoMoedaBancoCentral ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@Eletronica", moeda.Eletronica);
            cmd.Parameters.AddWithValue("@MercadoBitCoin", (object)moeda.MercadoBitCoin ?? DBNull.Value);

            conn.Open();
            try
            {
                int numero = (int)cmd.ExecuteScalar();

                if (numero == 0)
                    registro = moeda.MoedaID;
            }
            catch (SyntaxErrorException e)
            {
                throw new System.SystemException("Falha ao atualizar moeda.", e);
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }

            return registro;
        }

        public bool ExcluirMoeda(int moedaID)
        {
            SqlConnection conn = new SqlConnection(Dados.Conexao);

            SqlCommand cmd = new SqlCommand(@"DELETE FROM Moeda
                                              WHERE MoedaID = @MoedaID;", conn);

            cmd.Parameters.AddWithValue("@MoedaID", moedaID);

            conn.Open();
            try
            {
                cmd.ExecuteScalar();
                return true;
            }
            catch (SyntaxErrorException e)
            {
                throw new System.SystemException("Falha ao excluir moeda.", e);
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }

        public int CodigoMoeda(string simbolo)
        {
            // Instancia uma conexão
            using (SqlConnection conn = new SqlConnection(Dados.Conexao))
            {
                SqlCommand query = new SqlCommand("SELECT MoedaID FROM Moeda WHERE Simbolo = @simbolo;", conn);

                query.Parameters.AddWithValue("@simbolo", simbolo);

                try
                {
                    conn.Open();
                    return (int)query.ExecuteScalar();
                }
                finally
                {
                    conn.Close();
                }
            }
        }
    }
}
