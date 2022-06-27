﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelos;
using DAL;
using System.Data;
using System.Windows.Forms;

namespace BLL
{
    public class TipoInvestimentoBLL
    {
        static private int proximoID = 0;

        /// <summary>
        /// Retorna o próximo número ID disponível (sempre negativo)
        /// </summary>
        static public int ProximoID
        {
            get
            {
                return --proximoID;
            }
        }

        public DataTable Listar(int usuarioID)
        {
            TipoInvestimentoDAL dal = new TipoInvestimentoDAL();
            return dal.Listar(usuarioID);
        }

        public bool Validar(TipoInvestimento modelo)
        {
            string msg = null;

            TipoInstituicaoDAL dal = new TipoInstituicaoDAL();

            // Verifica se o apelido foi preenchido
            if (String.IsNullOrEmpty(modelo.Apelido))
            {
                msg = "O apelido deve ser preenchido.";
            }
            // Verifica se a descrição foi preenchida
            else if (String.IsNullOrEmpty(modelo.Descricao))
            {
                msg = "A descrição deve ser preenchida.";
            }
            // Verifica se o apelido está disponível
            else if (!dal.ApelidoDisponivel(modelo.UsuarioID, modelo.TipoInvestimentoID, modelo.Apelido))
            {
                msg = String.Format("O apelido {0} já está sendo utilizado, por favor, mude o apelido.", modelo.Apelido);
            }

            if (!String.IsNullOrEmpty(msg))
            {
                // Se exibir qualquer mensagem na tela, não será considerado válido
                MessageBox.Show(msg, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else
            {
                return true;
            }
        }

        public int Gravar(TipoInvestimento modelo)
        {
            TipoInvestimentoDAL dal = new TipoInvestimentoDAL();

            if (modelo.TipoInvestimentoID < 0)
            {
                // É uma inclusão
                return dal.Incluir(modelo);
            }
            else
            {
                // É uma alteração
                return dal.Alterar(modelo);
            }
        }

        public void Excluir(int tipoInvestimentoID)
        {
            TipoInvestimentoDAL dal = new TipoInvestimentoDAL();
            dal.Excluir(tipoInvestimentoID);
        }
    }
}
