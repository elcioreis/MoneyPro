﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelos;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class TransacaoDAL
    {
        public DataTable Listar()
        {
            // Instancia uma tabela
            DataTable table = new DataTable();
            // Instancia uma conexão
            SqlConnection conn = new SqlConnection(Dados.Conexao);
            // Instancia um adaptador
            SqlDataAdapter da = new SqlDataAdapter();
            // Instancia um comando
            SqlCommand query = new SqlCommand(@"SELECT Trns.TransacaoID, Trns.Tipo, Trns.Apelido, Trns.Descricao, 
                                                       Trns.CrdDeb, Cate.CategoriaID, Trns.Fundo, Trns.Acao
                                                FROM Transacao Trns
                                                LEFT JOIN Categoria Cate
                                                ON Cate.CategoriaPaiID = (SELECT TOP 1 CategoriaID FROM Categoria WHERE CrdDeb = 'I')
                                                AND Cate.CrdDeb = Trns.CrdDeb
                                                ORDER BY Trns.TransacaoID;", conn);
                
            // Coloca a query no adaptador
            da.SelectCommand = query;
            // Popula a tabela
            da.Fill(table);
            // Retorn a tabela
            return table;
        }
    }
}
