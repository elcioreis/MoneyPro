using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class PainelDAL
    {
        public DataTable ApuracaoMensalPorGrupoDeContas(int periodos, bool ateHoje)
        {
            // Instancia uma tabela
            DataTable table = new DataTable();
            // Instancia uma conexão
            SqlConnection conn = new SqlConnection(Dados.Conexao);
            // Instancia um adaptador
            SqlDataAdapter da = new SqlDataAdapter();
            // Instancia um comando

            // É um select simples, apenas tirando os pontos, barras e traços
            SqlCommand proc = new SqlCommand();

            proc.Connection = conn;
            proc.CommandType = CommandType.StoredProcedure;
            proc.CommandText = "stpApuracaoMensalPorGrupoDeContas";

            proc.Parameters.AddWithValue("@Periodos", periodos);
            proc.Parameters.AddWithValue("@AteHoje", ateHoje);

            // Coloca a query no adaptador
            da.SelectCommand = proc;
            // Popula a tabela
            da.Fill(table);
            // Retorn a tabela
            return table;
        }

        public DataTable ApuracaoSemanalPorGrupoDeContas(int periodos)
        {
            // Instancia uma tabela
            DataTable table = new DataTable();
            // Instancia uma conexão
            SqlConnection conn = new SqlConnection(Dados.Conexao);
            // Instancia um adaptador
            SqlDataAdapter da = new SqlDataAdapter();
            // Instancia um comando

            // É um select simples, apenas tirando os pontos, barras e traços
            SqlCommand proc = new SqlCommand();

            proc.Connection = conn;
            proc.CommandType = CommandType.StoredProcedure;
            proc.CommandText = "stpApuracaoSemanalPorGrupoDeContas";

            proc.Parameters.AddWithValue("@Periodos", periodos);

            // Coloca a query no adaptador
            da.SelectCommand = proc;
            // Popula a tabela
            da.Fill(table);
            // Retorn a tabela
            return table;
        }

        public DataTable ApuracaoSemanalAcumulada(int periodos)
        {
            // Instancia uma tabela
            DataTable table = new DataTable();
            // Instancia uma conexão
            SqlConnection conn = new SqlConnection(Dados.Conexao);
            // Instancia um adaptador
            SqlDataAdapter da = new SqlDataAdapter();
            // Instancia um comando

            // É um select simples, apenas tirando os pontos, barras e traços
            SqlCommand proc = new SqlCommand();

            proc.Connection = conn;
            proc.CommandType = CommandType.StoredProcedure;
            proc.CommandText = "stpApuracaoSemanalAcumulada";

            proc.Parameters.AddWithValue("@Periodos", periodos);

            // Coloca a query no adaptador
            da.SelectCommand = proc;
            // Popula a tabela
            da.Fill(table);
            // Retorn a tabela
            return table;
        }

        public DataTable ApuracaoInvestimentos(int periodos)
        {
            // Instancia uma tabela
            DataTable table = new DataTable();
            // Instancia uma conexão
            SqlConnection conn = new SqlConnection(Dados.Conexao);
            // Instancia um adaptador
            SqlDataAdapter da = new SqlDataAdapter();
            // Instancia um comando

            // É um select simples, apenas tirando os pontos, barras e traços
            SqlCommand proc = new SqlCommand();

            proc.Connection = conn;
            proc.CommandType = CommandType.StoredProcedure;
            proc.CommandText = "stpApuracaoInvestimentos";

            proc.Parameters.AddWithValue("@Periodos", periodos);

            // Coloca a query no adaptador
            da.SelectCommand = proc;
            // Popula a tabela
            da.Fill(table);
            // Retorn a tabela
            return table;
        }

        public DataTable ApuracaoDivisaoInvestimento()
        {
            // Instancia uma tabela
            DataTable table = new DataTable();
            // Instancia uma conexão
            SqlConnection conn = new SqlConnection(Dados.Conexao);
            // Instancia um adaptador
            SqlDataAdapter da = new SqlDataAdapter();
            // Instancia um comando

            // É um select simples, apenas tirando os pontos, barras e traços
            SqlCommand proc = new SqlCommand();

            proc.Connection = conn;
            proc.CommandType = CommandType.StoredProcedure;
            proc.CommandText = "stpApuracaoDivisaoInvestimento";

            // Coloca a query no adaptador
            da.SelectCommand = proc;
            // Popula a tabela
            da.Fill(table);
            // Retorn a tabela
            return table;
        }

        public DataTable ApuracaoDivisaoRisco()
        {
            // Instancia uma tabela
            DataTable table = new DataTable();
            // Instancia uma conexão
            SqlConnection conn = new SqlConnection(Dados.Conexao);
            // Instancia um adaptador
            SqlDataAdapter da = new SqlDataAdapter();
            // Instancia um comando

            // É um select simples, apenas tirando os pontos, barras e traços
            SqlCommand proc = new SqlCommand();

            proc.Connection = conn;
            proc.CommandType = CommandType.StoredProcedure;
            proc.CommandText = "stpApuracaoDivisaoRisco";

            // Coloca a query no adaptador
            da.SelectCommand = proc;
            // Popula a tabela
            da.Fill(table);
            // Retorn a tabela
            return table;
        }

        public DataTable ApuracaoDestinoPorCategoria(DateTime data, double perc)
        {
            // Instancia uma tabela
            DataTable table = new DataTable();
            // Instancia uma conexão
            SqlConnection conn = new SqlConnection(Dados.Conexao);
            // Instancia um adaptador
            SqlDataAdapter da = new SqlDataAdapter();
            // Instancia um comando

            // É um select simples, apenas tirando os pontos, barras e traços
            SqlCommand proc = new SqlCommand();

            proc.Connection = conn;
            proc.CommandType = CommandType.StoredProcedure;
            proc.CommandText = "stpApuracaoDestinoPorCategoria";
            proc.Parameters.AddWithValue("@Data", data);
            proc.Parameters.AddWithValue("@Perc", perc);

            // Coloca a query no adaptador
            da.SelectCommand = proc;
            // Popula a tabela
            da.Fill(table);
            // Retorn a tabela
            return table;
        }

        public DataTable ApuracaoComparativoPorCategoria(DateTime data, int periodos, double perc)
        {
            // Instancia uma tabela
            DataTable table = new DataTable();
            // Instancia uma conexão
            SqlConnection conn = new SqlConnection(Dados.Conexao);
            // Instancia um adaptador
            SqlDataAdapter da = new SqlDataAdapter();
            // Instancia um comando

            // É um select simples, apenas tirando os pontos, barras e traços
            SqlCommand proc = new SqlCommand();

            proc.Connection = conn;
            proc.CommandType = CommandType.StoredProcedure;
            proc.CommandText = "stpApuracaoComparativoPorCategoria";
            proc.Parameters.AddWithValue("@UltimoMes", data);
            proc.Parameters.AddWithValue("@Periodos", periodos);
            proc.Parameters.AddWithValue("@Perc", perc);

            // Coloca a query no adaptador
            da.SelectCommand = proc;
            try
            {
                // Popula a tabela
                da.Fill(table);
            }
            catch (SqlException)
            {
                throw;
            }
            // Retorn a tabela
            return table;
        }


        public DataTable ApuracaoInvestimentosAcumulados()
        {
            // Instancia uma tabela
            DataTable table = new DataTable();
            // Instancia uma conexão
            SqlConnection conn = new SqlConnection(Dados.Conexao);
            // Instancia um adaptador
            SqlDataAdapter da = new SqlDataAdapter();
            // Instancia um comando

            // É um select simples, apenas tirando os pontos, barras e traços
            SqlCommand proc = new SqlCommand();

            proc.Connection = conn;
            proc.CommandType = CommandType.StoredProcedure;
            proc.CommandText = "stpApuracaoInvestimentosAcumulados";

            // Coloca a query no adaptador
            da.SelectCommand = proc;
            try
            {
                // Popula a tabela
                da.Fill(table);
            }
            catch (SqlException)
            {
               // throw;
            }
            // Retorn a tabela
            return table;
        }

        public DataTable ApuracaoInvestimentosAcumuladosMensal(int periodos)
        {
            // Instancia uma tabela
            DataTable table = new DataTable();
            // Instancia uma conexão
            SqlConnection conn = new SqlConnection(Dados.Conexao);
            // Instancia um adaptador
            SqlDataAdapter da = new SqlDataAdapter();
            // Instancia um comando

            // É um select simples, apenas tirando os pontos, barras e traços
            SqlCommand proc = new SqlCommand();

            proc.Connection = conn;
            proc.CommandType = CommandType.StoredProcedure;
            proc.CommandText = "stpApuracaoInvestimentosLiquidosAcumulados";
            proc.Parameters.AddWithValue("@Periodos", periodos);
            proc.Parameters.AddWithValue("@Periodo", "M");


            // Coloca a query no adaptador
            da.SelectCommand = proc;
            try
            {
                // Popula a tabela
                da.Fill(table);
            }
            catch (SqlException)
            {
                throw;
            }
            // Retorn a tabela
            return table;
        }

    }
}
