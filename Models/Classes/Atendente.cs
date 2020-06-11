using Models.Enum;
using Models.Exceptions;
using System.ComponentModel.DataAnnotations;

namespace Models.Classes
{
    public class Atendente
    {
        public Atendente() { }
        public Atendente(string nome, string usuario, string senha, NivelAcesso nivelAcesso)
        {
            ValidaAtendente(nome, usuario, senha);
            Nome = nome;
            Usuario = usuario;
            Senha = senha;
            NivelAcesso = nivelAcesso;
        }
        public int AtendenteId { get; private set; }

        [Required]
        [MinLength(3)]
        public string Nome { get; private set; }

        [Required]
        [MinLength(3)]
        public string Usuario { get; private set; }

        [Required]
        public string Senha { get; private set; }

        [Required]
        public NivelAcesso NivelAcesso { get; private set; }

        public void AtualizarAtendente(string nome, string usuario, string senha, NivelAcesso nivelAcesso)
        {
            ValidaAtendente(nome, usuario, senha);
            Nome = nome;
            Usuario = usuario;
            Senha = senha;
            NivelAcesso = nivelAcesso;
        }
        private void ValidaAtendente(string nome, string usuario, string senha)
        {
            if (string.IsNullOrEmpty(nome))
            {
                throw new AtendenteException("Preencha seu nome corretamente.");
            }
            if (string.IsNullOrEmpty(usuario))
            {
                throw new AtendenteException("Seu nome de usuário não pode ser vazio.");
            }
            if (string.IsNullOrEmpty(senha))
            {
                throw new AtendenteException("Sua senha não pode ser vazia.");
            }
        }
        public override bool Equals(object obj)
        {
            var atend = obj as Atendente;
            if (atend != null)
            {
                return atend.Nome == Nome && atend.Usuario == Usuario;
            }
            return false;
        }
        public override string ToString()
        {
            return $"{Nome}, {Usuario}, {Senha}, {NivelAcesso}";
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
