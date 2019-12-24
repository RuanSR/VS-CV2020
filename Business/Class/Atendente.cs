namespace Business.Class
{
    public class Atendente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Senha { get; set; }

        public Atendente() { }
        public Atendente(int id, string nome, string senha)
        {
            Id = id;
            Nome = nome;
            Senha = senha;
        }
    }
}
