using DAL;
using Microsoft.Win32.SafeHandles;
using Modelos;
using System;
using System.Data;
using System.Runtime.InteropServices;

namespace BLL
{
    public class ConfiguracaoPrincipalBLL : IDisposable
    {
        // Flag: Has Dispose already been called?
        bool disposed = false;

        // Public implementation of Dispose pattern callable by consumers.
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public ConfiguracaoPrincipal CarregarConfiguracaoPrincipal()
        {
            ConfiguracaoPrincipal config = new ConfiguracaoPrincipal();

            ConfiguracaoPrincipalDAL dal = new ConfiguracaoPrincipalDAL();

            DataTable configuracaoPrincipal = dal.CarregarConfiguracaoPrincipal();

            // A tabela sempre retornará uma única linha
            foreach (DataRow linha in configuracaoPrincipal.Rows)
            {
                config.ConfiguracaoID = (short)linha["ConfiguracaoID"];
                config.PanelEsquerdoWidth = (int)linha["panelEsquerdoWidth"];
                config.Contas_ExibeAtivas = (bool)linha["Contas_ExibeAtivas"];
                config.Planejamento_ExibeAtivas = (bool)linha["Planejamento_ExibeAtivas"];
                config.DiasPrevisaoSaldoNegativo = (int)linha["DiasPrevisaoSaldoNegativo"];
                config.NumeroEmContaBanco = (bool)linha["NumeroEmContaBanco"];
            }

            return config;
        }

        public void ArmazenarConfiguracaoPrincipal(ConfiguracaoPrincipal config)
        {
            ConfiguracaoPrincipalDAL dal = new ConfiguracaoPrincipalDAL();
            dal.ArmazenarConfiguracaoPrincipal(config);
        }

        // Protected implementation of Dispose pattern.
        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
            {
                // Free any other managed objects here.
                //
            }

            // Free any unmanaged objects here.
            //
            disposed = true;
        }

        ~ConfiguracaoPrincipalBLL()
        {
            Dispose(false);
        }
    }
}
