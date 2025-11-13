using BLL;
using DAL;
using Modelos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace MoneyPro
{
    static public class Geral
    {
        static public Color CorTotal = Color.Gold;

        static private int _userID = 0;

        private static readonly string[] palavras = new string[] { "da", "das", "de", "do", "dos",
                                                                   "a", "à", "e", "o", "é", "ao",
                                                                   "ou", "com", "sem", "em", "no", "até",
                                                                   "na", "por", "pro", "pra", "para" };

        internal static int UserID
        {
            get { return _userID; }
            set { _userID = value; }
        }

        internal static string CriptografaSenha(string entrada)
        {
            // Primeiro passo, calcular o MD5 hash a partir da string
            MD5 md5 = MD5.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes("MoneyPro" + entrada);
            byte[] hash = md5.ComputeHash(inputBytes);

            // Segundo passo, converter o array de bytes em uma string haxadecimal
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }
            return sb.ToString();
        }

        internal static int CasasDecimais(int contaID)
        {
            int casasDecimais = 0;

            SqlConnection conn = new SqlConnection(Dados.Conexao);
            SqlCommand cmd = new SqlCommand(@"SELECT Decimais 
                                              FROM Conta
                                              WHERE ContaID = @ContaID;", conn);
            cmd.Parameters.AddWithValue("@ContaID", contaID);

            try
            {
                conn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    // Verifica se há linhas (se não há, é porque não encontrou registro com usuário e senha).
                    if (dr.HasRows)
                    {
                        // posiciona no primeiro registro
                        dr.Read();
                        // Há somente um campo na query
                        casasDecimais = dr.GetInt32(0);
                    }
                }
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }

            return casasDecimais;
        }

        internal static string Sistema(bool completo)
        {
            string nome = Application.ProductName;
            string versao = Application.ProductVersion;

            if (completo)
            {
                return nome + " " + versao;
            }
            else
            {
                return nome;
            }
        }

        internal static string LocalArquivo(string extensao)
        {
            // Pasta do software no windows

            // Normalmente em c:\Program Files\Inside\MoneyPro

            string pasta = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles) +
                "\\" + Application.CompanyName + "\\" + Application.ProductName;

            if (!Directory.Exists(pasta))
            {
                Directory.CreateDirectory(pasta);
            }

            string arquivo = pasta + "\\" + Application.ProductName + "." + extensao.ToUpper();

            return arquivo;
        }

        internal static int NumeroUsuario(string usuario, string senha)
        {
            int userID = 0;

            // O apelido pode ser maiúsculo ou minúsculo.
            // A senha é case sensitive.

            SqlConnection conn = new SqlConnection(Dados.Conexao);
            SqlCommand cmd = new SqlCommand(@"SELECT UsuarioID
                                              FROM Usuario
                                              WHERE UPPER(Apelido) = @Apelido
                                              AND Senha = @Senha", conn);
            cmd.Parameters.AddWithValue("@Apelido", usuario.ToUpper());
            cmd.Parameters.AddWithValue("@Senha", senha);

            conn.Open();

            using (SqlDataReader dr = cmd.ExecuteReader())
            {
                // Verifica se há linhas (se não há, é porque não encontrou registro com usuário e senha).
                if (dr.HasRows)
                {
                    // posiciona no primeiro registro
                    dr.Read();
                    // Há somente um campo na query
                    userID = dr.GetInt32(0);
                }
            }

            conn.Close();
            conn.Dispose();

            return userID;
        }

        internal static bool BaseTrabalho()
        {
            SqlConnection conn = new SqlConnection(Dados.Conexao);
            SqlCommand cmd = new SqlCommand(@"SELECT TOP 1 BaseProducao
                                              FROM MoneyPro
                                              ORDER BY MoneyProID ASC;", conn);

            conn.Open();

            try
            {
                return (bool)cmd.ExecuteScalar();
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }

        internal static DateTime UltimoBackupEfetuado()
        {
            DateTime resposta = new DateTime(2001, 1, 1);

            using (SqlConnection conn = new SqlConnection(Dados.Conexao))
            {
                using (SqlCommand cmd = new SqlCommand(@"SELECT TOP 1 UltimoBackup
                                                         FROM MoneyPro
                                                         ORDER BY MoneyProID ASC;", conn))
                {
                    conn.Open();
                    try
                    {
                        resposta = (DateTime)cmd.ExecuteScalar();
                    }
                    finally
                    {
                        conn.Close();
                    }
                }
            }
            return resposta;
        }

        internal static void AtualizarCotacoesCVM(fmDownloadCotacoes fmDownloadCotacoes, string mensagem)
        {
            fmDownloadCotacoes.IncluirProcessamento(mensagem);

            // Instancia uma conexão
            using (SqlConnection conn = new SqlConnection(Dados.Conexao))
            {
                DataTable table = ListaInvestimentosID();

                conn.Open();

                int r = 0;

                foreach (DataRow linha in table.Rows)
                {
                    switch (r++ % 4)
                    {
                        case 0:
                            fmDownloadCotacoes.AtualizarProcessamento(mensagem + "  -");
                            break;
                        case 1:
                            fmDownloadCotacoes.AtualizarProcessamento(mensagem + "  \\");
                            break;
                        case 2:
                            fmDownloadCotacoes.AtualizarProcessamento(mensagem + "  |");
                            break;
                        case 3:
                            fmDownloadCotacoes.AtualizarProcessamento(mensagem + "  /");
                            break;
                        default:
                            break;
                    }

                    // Instancia um comando
                    using (SqlCommand comando = new SqlCommand("EXEC stpAtualizaCotacaoEspecificaCVM @InvestimentoID;", conn))
                    {
                        comando.Parameters.AddWithValue("@InvestimentoID", linha.Field<int>("InvestimentoID"));
                        comando.ExecuteNonQuery();
                    }
                }
            }
        }

        internal static void AtualizarInvestimentoVariacao(fmDownloadCotacoes fmDownloadCotacoes, string mensagem)
        {
            fmDownloadCotacoes.AtualizarProcessamento(mensagem);

            // Instancia uma conexão
            using (SqlConnection conn = new SqlConnection(Dados.Conexao))
            {
                DataTable table = ListaInvestimentosID();

                conn.Open();

                foreach (DataRow linha in table.Rows)
                {
                    int investimentoID = linha.Field<int>("InvestimentoID");
                    string apelido = linha.Field<string>("Apelido");

                    fmDownloadCotacoes.IncluirProcessamento($"    Atualizando {apelido}");

                    // Instancia um comando
                    using (SqlCommand comando = new SqlCommand("EXEC stpPopulaInvestimentoEspecificoVariacao @InvestimentoID;", conn))
                    {
                        comando.Parameters.AddWithValue("@InvestimentoID", investimentoID);
                        // O processamento da variação de investimentos pode ser demorado, então 
                        // permite o time out com 240 segundos ao invés de 30 segundos padrão.
                        comando.CommandTimeout = 240;
                        comando.ExecuteNonQuery();
                    }
                }
            }
        }

        public static int PrimeiraColunaVisivel(DataGridView grid)
        {
            int primeira = -1;
            foreach (DataGridViewColumn col in grid.Columns)
            {
                if (col.Visible)
                {
                    primeira = col.Index;
                    break;
                }
            }
            return primeira;
        }

        public static string Capitaliza(string sequencia)
        {
            // Capitaliza o texto digitado no textbox
            StringBuilder texto = new StringBuilder(CultureInfo.CurrentCulture.TextInfo.ToTitleCase(sequencia));

            // Troca eventuais palavras que não devem ser capitalizadas
            foreach (var palavra in palavras)
            {
                string monosilabo = " " + CultureInfo.CurrentCulture.TextInfo.ToTitleCase(palavra) + " ";
                texto.Replace(monosilabo, " " + palavra + " ");
            }

            return texto.ToString();
        }

        public static void Capitaliza(TextBox tbx)
        {
            // Armazena o local da seleção
            int a = tbx.SelectionStart;
            // Armazena o tamanho da seleção
            int b = tbx.SelectionLength;

            // Capitaliza o texto digitado no textbox
            StringBuilder texto = new StringBuilder(CultureInfo.CurrentCulture.TextInfo.ToTitleCase(tbx.Text.ToString()));

            // Troca eventuais palavras que não devem ser capitalizadas
            foreach (var palavra in palavras)
            {
                string monosilabo = " " + CultureInfo.CurrentCulture.TextInfo.ToTitleCase(palavra) + " ";
                texto.Replace(monosilabo, " " + palavra + " ");
            }

            tbx.Text = texto.ToString();
            // Sempre que o valor de Text é mudado, SeleciontStart e SelectionLength são zerados
            // As linhas abaixo recuperam os valores originais            
            tbx.SelectionStart = a;
            tbx.SelectionLength = b;
        }

        public static void Capitaliza(ComboBox combobox)
        {
            // Armazena a posição inicial da seleção do texto
            int a = combobox.SelectionStart;
            // Armazena o tamanho da seleção
            int b = combobox.SelectionLength;

            // Capitaliza o texto digitado no textbox
            StringBuilder texto = new StringBuilder(CultureInfo.CurrentCulture.TextInfo.ToTitleCase(combobox.Text.ToString()));

            // Troca eventuais palavras que não devem ser capitalizadas
            foreach (var palavra in palavras)
            {
                string monosilabo = " " + CultureInfo.CurrentCulture.TextInfo.ToTitleCase(palavra) + " ";
                texto.Replace(monosilabo, " " + palavra + " ");
            }

            combobox.Text = texto.ToString();

            combobox.SelectionStart = a;
            combobox.SelectionLength = b;
        }

        public static bool ValidarDataNaDigitacao(string texto)
        {
            int tam = texto.Length;

            bool resp = false;

            switch (tam)
            {
                case 1:
                    // dia pode começar por 0, 1, 2 ou 3
                    resp = Regex.IsMatch(texto, "^[0123]$");
                    break;
                case 2:
                    // se o dia começa por 0, o segundo dígito pode ser de 1 a 9
                    // se o dia começa por 1 ou 2, o segundo dígito pode ser de 0 a 9
                    // se o dia começa por 3, o segundo dígito somente pode ser 0 ou 1
                    resp = Regex.IsMatch(texto, "^(0[1-9]|[12][0-9]|3[01])$");
                    break;
                case 3:
                    // Igual a regra anterior, porém somente aceita a bara no terceiro dígito
                    resp = Regex.IsMatch(texto, "^(0[1-9]|[12][0-9]|3[01])/$");
                    break;
                case 4:
                    // O quarto dígito somente pode ser 0 ou 1
                    resp = Regex.IsMatch(texto, "^(0[1-9]|[12][0-9]|3[01])/[01]$");
                    break;
                case 5:
                    // Se o quarto dígito for 0, o segundo pode ser de 1 a 9
                    // Se o quarto dígito for 1, o segundo pode ser 0 a 2
                    resp = Regex.IsMatch(texto, "^(0[1-9]|[12][0-9]|3[01])/(0[1-9]|1[0-2])$");
                    break;
                case 6:
                    // Igual a regra anterior, porém somente aceita a bara no sexto dígito
                    resp = Regex.IsMatch(texto, "^(0[1-9]|[12][0-9]|3[01])/(0[1-9]|1[0-2])/$");
                    break;
                case 7:
                    // A setima posição pode ser 1 ou 2
                    resp = Regex.IsMatch(texto, "^(0[1-9]|[12][0-9]|3[01])/(0[1-9]|1[0-2])/[12]$");
                    break;
                case 8:
                // A oitava posição pode ser qualquer dígito de 0 a 9
                case 9:
                // A nona posição pode ser qualquer dígito de 0 a 9
                case 10:
                    // A decima posicação pode ser qualquer dígito de 0 a 9
                    resp = Regex.IsMatch(texto, "^(0[1-9]|[12][0-9]|3[01])/(0[1-9]|1[0-2])/[12][0-9]{1,3}$");
                    break;
                default:
                    resp = false;
                    break;
            }

            if (resp && (tam == 10))
            {
                // Se o regex passou e tem 10 caracteres, tenta converte a data
                DateTime dt;
                resp = DateTime.TryParse(texto, out dt);
            }

            return resp;
        }

        internal static DateTime UltimoInvestimentoFeito(string listaInvestimentos)
        {
            using (SqlConnection conn = new SqlConnection(Dados.Conexao))
            {
                conn.Open();
                // Instancia um comando
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT dbo.fncUltimoInvestimentoFeito(@ListaInvestimento) UltimoInvestimento;";

                    cmd.Parameters.AddWithValue("@ListaInvestimento", listaInvestimentos);

                    return (DateTime)cmd.ExecuteScalar();
                }
            }
        }

        public static bool ValidaDigitacaoData(string texto, ref char keyChar, bool trataHora)
        {
            bool resp = false;

            int tam = texto.Length;

            //
            // A rotina abaixo permite que seja usado o ponto (.) como separador, 
            // ele será trocado pelo caracter esperado.
            if ((tam == 2 || tam == 5) && keyChar == '.')
            {
                // Se tamanho antes da inclusão do caracter for 2 ou 5, somente poderá aceitar a barra de data (/)
                // Neste caso troca o ponto (.) pela barra (/)
                keyChar = '/';
                texto += keyChar;
                tam++;
            }
            else if (tam == 10 && keyChar == '.')
            {
                // Se tamanho antes da inclusão do caracter for 10, o próximo caracter somente poderá ser espaço
                // Neste caso troca o ponto (.) por espaço
                keyChar = ' ';
                texto += keyChar;
                tam++;
            }
            else if ((tam == 13 || tam == 16) && keyChar == '.')
            {
                // Se tamanho antes da inclusão do caracter for 13 ou 16, somente poderá aceitar os dois pontos (:)
                // Neste caso trcao o ponto (.) por dois pontos (:)
                keyChar = ':';
                texto += keyChar;
                tam++;
            }
            else
            {
                texto += keyChar;
                tam++;
            }

            switch (tam)
            {
                case 1:
                    // dia pode começar por 0, 1, 2 ou 3
                    resp = Regex.IsMatch(texto, "^[0123]$");
                    break;
                case 2:
                    // se o dia começa por 0, 1 ou 2, o segundo dígito pode ser de 0 a 9
                    // se o dia começa por 3, o segundo dígito somente pode ser 0 ou 1
                    //resp = (Regex.IsMatch(texto, "^(0[1-9]|[12][0-9]|3[01])$"));
                    resp = Regex.IsMatch(texto, "^([012][0-9]|3[01])$");
                    break;
                case 3:
                    // Igual a regra anterior, porém somente aceita a bara no terceiro dígito
                    resp = Regex.IsMatch(texto, "^([012][0-9]|3[01])/$");
                    break;
                case 4:
                    // O quarto dígito somente pode ser 0 ou 1
                    resp = Regex.IsMatch(texto, "^([012][0-9]|3[01])/[01]$");
                    break;
                case 5:
                    // Se o quarto dígito for 0, o segundo pode ser de 1 a 9
                    // Se o quarto dígito for 1, o segundo pode ser 0 a 2
                    resp = Regex.IsMatch(texto, "^([012][0-9]|3[01])/(0[1-9]|1[0-2])$");
                    break;
                case 6:
                    // Igual a regra anterior, porém somente aceita a bara no sexto dígito
                    resp = Regex.IsMatch(texto, "^([012][0-9]|3[01])/(0[1-9]|1[0-2])/$");
                    break;
                case 7:
                    // A setima posição pode ser 1 ou 2
                    resp = Regex.IsMatch(texto, "^([012][0-9]|3[01])/(0[1-9]|1[0-2])/[12]$");
                    break;
                case 8:
                // A oitava posição pode ser qualquer dígito de 0 a 9
                case 9:
                // A nona posição pode ser qualquer dígito de 0 a 9
                case 10:
                    // A decima posicação pode ser qualquer dígito de 0 a 9
                    resp = Regex.IsMatch(texto, "^([012][0-9]|3[01])/(0[1-9]|1[0-2])/[12][0-9]{1,3}$");
                    break;
                case 11:
                    // A 11a posição pode ser somente branco caso a conta permita data e hora
                    if (!trataHora)
                        resp = false;
                    else
                        resp = Regex.IsMatch(texto, @"^([012][0-9]|3[01])/(0[1-9]|1[0-2])/[12][0-9]{1,3}\s$");
                    break;
                case 12:
                    // A 12a posição pode ser qualquer dígito de 0 a 2([012]) caso a conta permita data e hora
                    if (!trataHora)
                        resp = false;
                    else
                        resp = Regex.IsMatch(texto, @"^([012][0-9]|3[01])/(0[1-9]|1[0-2])/[12][0-9]{1,3}\s[012]$");
                    break;
                case 13:
                    // A 13a posição pode ser qualquer dígito se a 12a for 0 ou 1
                    // ou de 0 a 3 caso a 12a for 2.
                    if (!trataHora)
                        resp = false;
                    else
                        resp = Regex.IsMatch(texto, @"^([012][0-9]|3[01])/(0[1-9]|1[0-2])/[12][0-9]{1,3}\s([01][0-9]|2[0-3])$");
                    break;
                case 14:
                    // A 14a posição pode ser somente dois pontos (:)
                    if (!trataHora)
                        resp = false;
                    else
                        resp = Regex.IsMatch(texto, @"^([012][0-9]|3[01])/(0[1-9]|1[0-2])/[12][0-9]{1,3}\s([01][0-9]|2[0-3]):$");
                    break;
                case 15:
                    // A 15a posição pode ser qualquer dígito de 0 a 5
                    if (!trataHora)
                        resp = false;
                    else
                        resp = Regex.IsMatch(texto, @"^([012][0-9]|3[01])/(0[1-9]|1[0-2])/[12][0-9]{1,3}\s([01][0-9]|2[0-3]):[0-5]$");
                    break;
                case 16:
                    // A 16a posição pode ser qualquer dígito de 0 a 9
                    if (!trataHora)
                        resp = false;
                    else
                        resp = Regex.IsMatch(texto, @"^([012][0-9]|3[01])/(0[1-9]|1[0-2])/[12][0-9]{1,3}\s([01][0-9]|2[0-3]):[0-5][0-9]$");
                    break;
                case 17:
                    // A 17a posição pode ser somente dois pontos (:)
                    if (!trataHora)
                        resp = false;
                    else
                        resp = Regex.IsMatch(texto, @"^([012][0-9]|3[01])/(0[1-9]|1[0-2])/[12][0-9]{1,3}\s([01][0-9]|2[0-3]):[0-5][0-9]:$");
                    break;
                case 18:
                    // A 18a posição pode ser qualquer dígito de 0 a 5
                    if (!trataHora)
                        resp = false;
                    else
                        resp = Regex.IsMatch(texto, @"^([012][0-9]|3[01])/(0[1-9]|1[0-2])/[12][0-9]{1,3}\s([01][0-9]|2[0-3]):[0-5][0-9]:[0-5]$");
                    break;
                case 19:
                    // A 19a posição pode ser qualquer dígito de 0 a 9
                    if (!trataHora)
                        resp = false;
                    else
                        resp = Regex.IsMatch(texto, @"^([012][0-9]|3[01])/(0[1-9]|1[0-2])/[12][0-9]{1,3}\s([01][0-9]|2[0-3]):[0-5][0-9]:[0-5][0-9]$");
                    break;
                default:
                    resp = false;
                    break;
            }

            if (resp && (tam == 10))
            {
                // Se o regex passou e tem 10 caracteres, tenta converte a data
                DateTime dt;
                resp = DateTime.TryParse(texto, out dt);
            }

            return resp;
        }

        public static bool Feriado(DateTime data)
        {
            // Instancia uma conexão
            using (SqlConnection conn = new SqlConnection(Dados.Conexao))
            {
                conn.Open();
                // Instancia um comando
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "stpFeriadoNesteDia";

                    cmd.Parameters.AddWithValue("@Data", data);

                    bool ehFeriado = (bool)cmd.ExecuteScalar();

                    return ehFeriado;
                }
            }
        }

        public static bool SiteDePe(string siteParaPingar)
        {
            var ping = new System.Net.NetworkInformation.Ping();

            var result = ping.Send(siteParaPingar);

            return result.Status == System.Net.NetworkInformation.IPStatus.Success;
        }

        public static DateTime UltimoDiaUtil(DateTime data)
        {
            // Instancia uma conexão
            using (SqlConnection conn = new SqlConnection(Dados.Conexao))
            {
                conn.Open();
                // Instancia um comando
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "stpUltimoDiaUtil";

                    cmd.Parameters.AddWithValue("@Data", data);

                    return (DateTime)cmd.ExecuteScalar();
                }
            }
        }

        public static DateTime PrimeiroDiaSistema()
        {
            // Instancia uma conexão
            using (SqlConnection conn = new SqlConnection(Dados.Conexao))
            {
                conn.Open();
                // Instancia um comando
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT DtInicioUtilizacao FROM MoneyPro;";

                    return (DateTime)cmd.ExecuteScalar();
                }
            }
        }

        public static DateTime PrimeiroDiaMovimento(int usuarioID)
        {
            // Instancia uma conexão
            using (SqlConnection conn = new SqlConnection(Dados.Conexao))
            {
                conn.Open();
                // Instancia um comando
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = @"SELECT CAST(MIN(Data) AS DATE) DATA
                                        FROM MovimentoConta
                                        WHERE UsuarioID = @UsuarioID;";

                    cmd.Parameters.AddWithValue("@UsuarioID", usuarioID);

                    return (DateTime)cmd.ExecuteScalar();
                }
            }
        }

        public static DateTime UltimoDiaMovimento(int usuarioID)
        {
            // Instancia uma conexão
            using (SqlConnection conn = new SqlConnection(Dados.Conexao))
            {
                conn.Open();
                // Instancia um comando
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = @"SELECT CAST(MAX(Data) AS DATE) DATA
                                        FROM MovimentoConta
                                        WHERE UsuarioID = @UsuarioID;";

                    cmd.Parameters.AddWithValue("@UsuarioID", usuarioID);

                    return (DateTime)cmd.ExecuteScalar();
                }
            }
        }

        public static DateTime UltimoDiaComCotacao()
        {
            // Instancia uma conexão
            using (SqlConnection conn = new SqlConnection(Dados.Conexao))
            {
                conn.Open();
                // Instancia um comando
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT MAX(Data) UltimoDia FROM InvestimentoCotacao;";

                    return (DateTime)cmd.ExecuteScalar();
                }
            }
        }

        public static DateTime ProximaFaturaCartao(int UsuarioID)
        {
            // Instancia uma conexão
            using (SqlConnection conn = new SqlConnection(Dados.Conexao))
            {
                conn.Open();
                // Instancia um comando
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT dbo.fncProximaFaturaCartao(@UsuarioID);";

                    cmd.Parameters.AddWithValue("@UsuarioID", UsuarioID);

                    try
                    {
                        return (DateTime)cmd.ExecuteScalar();
                    }
                    catch
                    {
                        return new DateTime(1900, 1, 1);
                    }
                }
            }
        }

        public static int ContasQueFicaraoNegativas(int usuarioID, int diasPrevisao)
        {
            // Instancia uma conexão
            using (SqlConnection conn = new SqlConnection(Dados.Conexao))
            {
                conn.Open();
                // Instancia um comando
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT dbo.fncPrevisaoSaldoNegativo(@UsuarioID, @DiasDePrevisao);";

                    cmd.Parameters.AddWithValue("@UsuarioID", usuarioID);
                    cmd.Parameters.AddWithValue("@DiasDePrevisao", diasPrevisao);

                    try
                    {
                        return (int)cmd.ExecuteScalar();
                    }
                    catch
                    {
                        return 0;
                    }
                }
            }
        }

        public static string ListaDeInvestimento(DataGridView fonte)
        {
            // Percorre um DataGridView da carteira (que contenha coluna InvestimentoID) para identificar quais os investimentos selecionados, 
            // estes serão colocados numa string separados por ponto-e-vírgula, para ser enviado a uma procedure do SQL Server.

            //
            // Só funciona se houver uma coluna InvestimentoID na grid.
            //

            // Cria uma lista que receberá todos os códigos de investimentos conforme seleção na grade
            List<int> investimentos = new List<int>();

            // Percorre todos as linhas selecionadas
            foreach (DataGridViewRow linha in fonte.SelectedRows)
            {
                // Se a linha selecionada tiver um InvestimentoID não nulo
                if (linha.Cells["InvestimentoID"].Value != DBNull.Value)
                {
                    // Inclui o código do investimento na lista
                    investimentos.Add((int)linha.Cells["InvestimentoID"].Value);
                }
            }

            // A lista deve contér de 1 a 8 investimentos
            if (investimentos.Count > 0 && investimentos.Count <= 8)
            {
                // Ordena os códigos de investimento
                investimentos.Sort();

                // Retorna a lista como uma string separada por ponto-e-virgula
                return string.Join(";", investimentos.Select(n => n.ToString()).ToArray()) + ";";
            }
            else
            {
                return "";
            }
        }

        internal static void CarregarArquivoTradeHitBTC()
        {
            string pathUser = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            string pathDownload = Path.Combine(pathUser, "Downloads");

            DateTime separar = new DateTime(1990, 1, 1);
            short vezes = 0;

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = pathDownload;
            openFileDialog.Filter = "Arquivos CSV (*.CSV)|*.CSV";
            openFileDialog.FilterIndex = 2;
            openFileDialog.RestoreDirectory = true;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string fileName = openFileDialog.FileName;

                    string[] linhas = File.ReadAllLines(fileName);

                    if (linhas.Count() > 0)
                    {
                        if (linhas[0] == "\"Date (-02)\",\"Instrument\",\"Trade ID\",\"Order ID\",\"Side\",\"Quantity\",\"Price\",\"Volume\",\"Fee\",\"Rebate\",\"Total\"" ||
                            linhas[0] == "\"Date (-03)\",\"Instrument\",\"Trade ID\",\"Order ID\",\"Side\",\"Quantity\",\"Price\",\"Volume\",\"Fee\",\"Rebate\",\"Total\"")
                        {
                            NumberStyles style = NumberStyles.AllowDecimalPoint | NumberStyles.AllowLeadingSign;
                            CultureInfo provider = new CultureInfo("en-US");

                            for (int i = 1; i < linhas.Count(); i++)
                            {
                                // se a linha começar por -- ou por // será considerada como comentário e será ignorada
                                if (!(linhas[i].Trim().StartsWith("--") || linhas[i].Trim().StartsWith("//")))
                                {
                                    string[] itens = linhas[i].Replace("\"", "").Split(',');

                                    if (itens.Count() == 11)
                                    {
                                        HitBTCTrade trade = new HitBTCTrade();

                                        // Data no formato "2017-11-13 21:22:11"

                                        if (separar != DateTime.ParseExact(itens[0], "yyyy-MM-dd H:mm:ss", CultureInfo.InvariantCulture))
                                        {
                                            separar = DateTime.ParseExact(itens[0], "yyyy-MM-dd H:mm:ss", CultureInfo.InvariantCulture);
                                            trade.Date = DateTime.ParseExact(itens[0], "yyyy-MM-dd H:mm:ss", CultureInfo.InvariantCulture);
                                            vezes = 0;
                                        }
                                        else
                                        {
                                            trade.Date = DateTime.ParseExact(itens[0], "yyyy-MM-dd H:mm:ss", CultureInfo.InvariantCulture).AddMilliseconds(++vezes * 3);
                                        }

                                        trade.Instrument = itens[1];
                                        trade.TradeID = Int64.Parse(itens[2]);
                                        trade.OrderID = Int64.Parse(itens[3]);
                                        trade.Side = itens[4];
                                        trade.Quantity = decimal.Parse(itens[5], style, provider);
                                        trade.Price = decimal.Parse(itens[6], style, provider);
                                        trade.Volume = decimal.Parse(itens[7], style, provider);
                                        trade.Fee = decimal.Parse(itens[8], style, provider);
                                        trade.Rebate = decimal.Parse(itens[9], style, provider);
                                        trade.Total = decimal.Parse(itens[10], style, provider);

                                        TransacaoCambioBLL transacao = new TransacaoCambioBLL();
                                        transacao.ManterTradeHitBTC(trade);
                                    }
                                    else
                                    {
                                        throw new Exception("Quantidade de campos diferente do esperado.");
                                    }
                                }
                            }
                        }
                        else
                        {
                            throw new Exception("Arquivo com formato diferente do esperado.");
                        }
                    }
                    else
                    {
                        throw new Exception("Arquivo vazio.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Não foi possível ler o arquivo.\n" + ex.Message, "Erro",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                }
            }
        }

        internal static void ExecutarMovimentosContaTradeHitBTC(int usuarioID, int contaID)
        {
            using (SqlConnection conn = new SqlConnection(Dados.Conexao))
            {
                conn.Open();
                // Instancia um comando
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "stpExecutarCSVTradeHitBTC";

                    cmd.Parameters.AddWithValue("@UsuarioID", usuarioID);
                    cmd.Parameters.AddWithValue("@ContaID", contaID);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        internal static string CaminhoBackup()
        {
            // Instancia uma conexão
            using (SqlConnection conn = new SqlConnection(Dados.Conexao))
            {
                conn.Open();
                // Instancia um comando
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = @"SELECT CaminhoBackup FROM MoneyPro;";

                    return ((String)cmd.ExecuteScalar()).TrimEnd('\\');
                }
            }
        }

        internal static DateTime UltimaAtualizacaoInvestimentos()
        {
            // Instancia uma conexão
            using (SqlConnection conn = new SqlConnection(Dados.Conexao))
            {
                conn.Open();
                // Instancia um comando
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = @"SELECT dbo.fncUltimaAtualizacaoInvestimentos() AS Ultima;";
                    cmd.CommandTimeout = 240;
                    return (DateTime)cmd.ExecuteScalar();
                }
            }
        }

        internal static DataTable ListarPrevisaoSaldoNegativo(int usuarioID, int diasPrevisao)
        {
            DataTable tabela = new DataTable();

            using (SqlConnection conn = new SqlConnection(Dados.Conexao))
            {

                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                using (SqlCommand comando = new SqlCommand("EXEC stpPrevisaoSaldoNegativo @UsuarioID, @DiasDePrevisao;", conn))
                {
                    comando.Parameters.AddWithValue("@UsuarioID", usuarioID);
                    comando.Parameters.AddWithValue("@DiasDePrevisao", diasPrevisao);

                    SqlDataReader reader = comando.ExecuteReader();
                    tabela.Load(reader);
                }
            }

            return tabela;
        }

        internal static DataTable ListaInvestimentosID()
        {
            DataTable table = new DataTable();

            using (SqlConnection conn = new SqlConnection(Dados.Conexao))
            {
                conn.Open();
                // Instancia um adaptador
                using (SqlDataAdapter da = new SqlDataAdapter())
                {
                    // Instancia um comando
                    //SqlCommand query = new SqlCommand(@"
                    //    SELECT DISTINCT INVE.InvestimentoID
                    //    FROM Investimento Inve
                    //    ORDER BY INVE.InvestimentoID ASC;", conn);

                    SqlCommand query = new SqlCommand(
                        @"SELECT cf.InvestimentoID, cf.Apelido
                                 FROM vw_CarteiraFormatada cf
                                      INNER JOIN Investimento iv ON iv.InvestimentoID = cf.InvestimentoID
                                 WHERE ((COALESCE(cf.VrAplicado, 0) > 0) OR  Ativo = 1) AND (cf.Fundo = 1 OR cf.Acao = 1)
                                 ORDER BY cf.Acao ASC, cf.Apelido ASC;", conn);

                    // Coloca a query no adaptador
                    da.SelectCommand = query;
                    // Popula a tabela
                    da.Fill(table);
                }
            }
            return table;
        }

        internal static void AjustaAparenciaSubForm(Form principal, Form subForm)
        {
            // Ajusta o form de detalhes para que seja semelhante ao da movimentação de contas

            // Atribui o MdiParent ao form atual
            subForm.MdiParent = principal.MdiParent;
            // Remove as bordas
            subForm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            // Remove os botões (remover todos os botões faz com que o menu do filho não seja fundido (merged))
            subForm.ControlBox = false;
            subForm.MaximizeBox = false;
            subForm.MinimizeBox = false;
            // Desabilita exibição do ícone
            subForm.ShowIcon = false;
            // Maximiza
            subForm.WindowState = FormWindowState.Maximized;
            // Remove o título da janela
            subForm.Text = string.Empty;
            // Preenche o dock
            subForm.Dock = DockStyle.Fill;
            // Atribui o padding 3;3;3;3 (todos lados iguais)
            subForm.Padding = new Padding(3);
            // Procura groupbox no formulário
            foreach (Control C1 in subForm.Controls)
            {
                if (C1 is GroupBox)
                {
                    C1.Font = new Font("Microsoft Sans Serif", 10, FontStyle.Bold);
                    foreach (Control C2 in C1.Controls)
                    {
                        C2.Font = new Font("Microsoft Sans Serif", 8, FontStyle.Regular);
                    }
                }
                else
                {
                    C1.Font = new Font("Microsoft Sans Serif", 8, FontStyle.Regular);
                }
            }
        }


        // A rotina abaixo, que é apenas uma chamada à dll do windows, verifica se há conexão de rede ativa.
        [System.Runtime.InteropServices.DllImport("wininet.dll")]
        internal static extern bool InternetGetConnectedState(out int Description, int ReservedValue);
    }
}