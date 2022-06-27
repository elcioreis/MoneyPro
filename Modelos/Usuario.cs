using System;

namespace Modelos
{
    public class Usuario
    {
        /// <summary>
        /// Id do usuário no sistema
        /// </summary>
        private int usuarioId = 0;
        public int UsuarioID
        {
            get { return usuarioId; }
            set { usuarioId = value; }
        }

        /// <summary>
        /// Apelido do usuário no sistema.
        /// </summary>
        private string apelido = "";
        public string Apelido
        {
            get { return apelido; }
            set { apelido = value; }
        }

        /// <summary>
        /// Nome do usuário no sistema.
        /// </summary>
        private string nome = "";
        public string Nome
        {
            get { return nome; }
            set { nome = value; }
        }

        /// <summary>
        /// Senha do usuário (criptografada)
        /// </summary>
        private string senha = "";
        public string Senha
        {
            get { return senha; }
            set { senha = value; }
        }


        /// <summary>
        /// Email do usuário
        /// </summary>
        private string email = "";
        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        /// <summary>
        /// Informa se o usuário é ativo ou inativo.
        /// </summary>
        private bool ativo = true;
        public bool Ativo
        {
            get { return ativo; }
            set { ativo = value; }
        }

        /// <summary>
        /// Define faz parte do sistema ou não.
        /// (Se for parte do sistema, não poderá ser apagado).
        /// </summary>
        private bool sistema = false;
        public bool Sistema
        {
            get { return sistema; }
            set { sistema = value; }
        }
    }
}
