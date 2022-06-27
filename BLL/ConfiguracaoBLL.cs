using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using System.Data;

namespace BLL
{
    public class ConfiguracaoBLL
    {
        public DataTable CarregarConfiguracoes()
        {
            ConfiguracaoDAL dal = new ConfiguracaoDAL();
            return dal.CarregarConfiguracoes();
        }

        public string CaminhoBackup()
        {
            ConfiguracaoDAL dal = new ConfiguracaoDAL();
            return dal.CaminhoBackup();
        }

        public void NovoCaminhoBackup(string caminho)
        {
            ConfiguracaoDAL dal = new ConfiguracaoDAL();
            dal.NovoCaminhoBackup(caminho);
        }

        public void AtualizaDataBackup()
        {
            ConfiguracaoDAL dal = new ConfiguracaoDAL();
            dal.AtualizaDataBackup();
        }

        public string ExecutaBackup(string NomeBase)
        {
            ConfiguracaoDAL dal = new ConfiguracaoDAL();
            return dal.ExecutaBackup(NomeBase);
        }

        public Boolean TruncarArquivoLogSQLServer()
        {
            ConfiguracaoDAL dal = new ConfiguracaoDAL();
            return dal.TruncarArquivoLogSQLServer();
        }

        public void LimparTickers()
        {
            ConfiguracaoDAL dal = new ConfiguracaoDAL();
            dal.LimparTickers();
        }

        public DataTable UltimasCotacoes()
        {
            ConfiguracaoDAL dal = new ConfiguracaoDAL();
            return dal.UltimasCotacoes();
        }
    }
}
