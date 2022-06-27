using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelos;

namespace DAL
{
    public class CalendarioDAL
    {
        public DataTable Listar(DateTime dataInicio, int periodos)
        {
            // Instancia uma tabela
            DataTable table = new DataTable();
            // Instancia uma conexão
            SqlConnection conn = new SqlConnection(Dados.Conexao);
            // Instancia um adaptador
            SqlDataAdapter da = new SqlDataAdapter();
            // Instancia um comando
            SqlCommand query = new SqlCommand(
                "SELECT FeriadoID, Dia, Mes, Ano, Descricao, " +
                "CAST(CAST(COALESCE(Ano, YEAR(@DataInicio)) AS VARCHAR(4)) + '/' + RIGHT('0' + CAST(Mes AS VARCHAR(2)), 2) + '/' + RIGHT('0' + CAST(Dia AS VARCHAR(2)), 2) AS DATE) Data, " +
                "CAST(CASE WHEN ANO IS NULL THEN 1 ELSE 0 END AS BIT) AS Fixo " +
                "FROM Feriado " +
                "WHERE CAST(CAST(COALESCE(Ano, YEAR(@DataInicio)) AS VARCHAR(4)) + '/' + RIGHT('0' + CAST(Mes AS VARCHAR(2)), 2) + '/' + RIGHT('0' + CAST(Dia AS VARCHAR(2)), 2) AS DATE) BETWEEN @DataInicio AND DATEADD(DAY, -1, DATEADD(MONTH, @Periodos, @DataInicio)) " +
                "ORDER BY Data ASC;", conn);


            query.Parameters.AddWithValue("@DataInicio", dataInicio);
            query.Parameters.AddWithValue("@Periodos", periodos);

            // Coloca a query no adaptador
            da.SelectCommand = query;
            // Popula a tabela
            da.Fill(table);
            // Retorn a tabela
            return table;

        }

        public int Incluir(Calendario feriado)
        {
            int registro = -1;

            SqlConnection conn = new SqlConnection(Dados.Conexao);

            //  A tabela Conta possui uma trigger para inclusão
            SqlCommand cmd = new SqlCommand("INSERT INTO Feriado " +
                                            "(Dia, Mes, Ano, Descricao) " +
                                            "VALUES " +
                                            "(@Dia, @Mes, @Ano, @Descricao); " +
                                            // Retorna o ID do Feriado
                                            "SELECT CAST(@@IDENTITY AS INT) AS FeriadoID;", conn);

            cmd.Parameters.AddWithValue("@Dia", feriado.Dia);
            cmd.Parameters.AddWithValue("@Mes", feriado.Mes);
            cmd.Parameters.AddWithValue("@Ano", (object)feriado.Ano ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@Descricao", feriado.Descricao);

            conn.Open();
            try
            {
                registro = (int)cmd.ExecuteScalar();
            }
            catch (SyntaxErrorException e)
            {
                throw new System.SystemException("Falha ao incluir feriado.", e);
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }

            return registro;
        }

        public int Alterar(Calendario feriado)
        {
            SqlConnection conn = new SqlConnection(Dados.Conexao);

            SqlCommand cmd = new SqlCommand("UPDATE Feriado " +
                                            "SET Dia = @Dia, " +
                                            "Mes = @Mes, " +
                                            "Ano = @Ano, " +
                                            "Descricao = @Descricao " +
                                            "WHERE FeriadoID = @FeriadoID; " +

                                            "SELECT CAST(@@ERROR AS INT) AS Erro;", conn);

            cmd.Parameters.AddWithValue("@Dia", feriado.Dia);
            cmd.Parameters.AddWithValue("@Mes", feriado.Mes);
            cmd.Parameters.AddWithValue("@Ano", feriado.Ano);
            cmd.Parameters.AddWithValue("@Descricao", feriado.Descricao);
            cmd.Parameters.AddWithValue("@FeriadoID", feriado.FeriadoID);

            try
            {
                conn.Open();

                if ((int)cmd.ExecuteScalar() == 0)
                    return feriado.FeriadoID;
                else
                    return -1;
            }
            catch (SyntaxErrorException e)
            {
                throw new System.SystemException("Falha ao alterar feriado.", e);
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }
    }
}
