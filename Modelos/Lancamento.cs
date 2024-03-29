///////////////////////////////////////////////////////////
//  Parceiro.cs
//  Implementation of the Class Lancamento
//  Generated by Enterprise Architect
//  Created on:      02-mai-2015 16:26:06
//  Original author: Elcio
///////////////////////////////////////////////////////////


namespace Modelos
{
    public class Lancamento {

		/// <summary>
		/// ID do lan�amento.
		/// </summary>
		private int _lancamentoID;
		/// <summary>
		/// Usu�rio que incluiu o lan�amento.
		/// </summary>
		private int _usuarioID;
		/// <summary>
		/// Apelido do lan�amento.
		/// </summary>
		private string _apelido;
		/// <summary>
		/// Descri��o do lan�amento.
		/// </summary>
		private string _descricao;
		/// <summary>
		/// Define se � ou n�o um lan�amento ativo.
		/// </summary>
		private bool _ativo = true;
		/// <summary>
		/// Informa se � um lan�amento criado pelo sistema.
		/// </summary>
		private bool _sistema = false;

		public int LancamentoID
        {
            get { return _lancamentoID; }
            set { _lancamentoID = value; }
		}

		public int UsuarioID
        {
            get { return _usuarioID; }
            set { _usuarioID = value; }
		}

		public string Apelido
        {
            get { return _apelido; }
            set { _apelido = value; }
		}

		public string Descricao
        {
            get { return _descricao; }
            set { _descricao = value; }
		}

		public bool Ativo
        {
            get { return _ativo; }
            set { _ativo = value; }
		}

		public bool Sistema
        {
            get { return _sistema; }
            set { _sistema = value; }
		}

	}//end Parceiro

}