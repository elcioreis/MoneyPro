///////////////////////////////////////////////////////////
//  TipoConta.cs
//  Implementation of the Class TipoConta
//  Generated by Enterprise Architect
//  Created on:      26-abr-2015 14:54:57
//  Original author: Elcio
///////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Text;
using System.IO;


namespace Modelos
{
    public class TipoConta
    {
        public int TipoContaID { get; set; }
        public int? GrupoContaID { get; set; }
        public int UsuarioID { get; set; }
        public string Apelido { get; set; }
        public string Descricao { get; set; }
        public bool Ativo { get; set; }
        public bool Investimento { get; set; }
        public bool Cartao { get; set; }
        public bool Banco { get; set; }
        public bool Poupanca { get; set; }
        public bool Cambio { get; set; }
        public bool CDB { get; set; }
    }
}