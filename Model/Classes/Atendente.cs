using Model.Enum;
using Model.Exceptions;

namespace Model.Classes
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
        public string Nome { get; private set; }
        public string Usuario { get; private set; }
        public string Senha { get; private set; }
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
            if(string.IsNullOrEmpty(nome))
            {
                throw new AtendenteException("Preencha seu nome corretamente.");
            }
            if(string.IsNullOrEmpty(usuario))
            {
                throw new AtendenteException("Seu nome de usuário não pode ser vazio.");
            }
            if(string.IsNullOrEmpty(senha))
            {
                throw new AtendenteException("Sua senha não pode ser vazia.");
            }
        }

        public override bool Equals(object obj)
        {
            var atend = obj as Atendente;
            return atend.Nome == Nome && atend.Usuario == Usuario;
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
