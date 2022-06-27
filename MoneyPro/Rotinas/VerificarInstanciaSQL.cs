namespace MoneyPro.Rotinas
{
    public class VerificarInstanciaSQL
    {
        // The method to be executed asynchronously.
        public string Verificar()
        {
            string resposta = string.Empty;
            
            // Retrieve the enumerator instance and then the data.
            //SqlDataSourceEnumerator instance = SqlDataSourceEnumerator.Instance;
            //DataTable tabela = instance.GetDataSources();
            //int x = tabela.Rows.Count;

            //if (x == 0)
            //{
            //    resposta = "Não encontrei instância do SQL Server ativa.";
            //}
            //else
            //{
            //    resposta = string.Empty;
            //}

            return resposta;
        }    
    }

    public delegate string AsyncMethodCaller();
}
