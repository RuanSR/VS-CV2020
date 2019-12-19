using System;

namespace Business.Class
{
    public sealed class Cliente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Apelido { get; set; }
        public string Endereco { get; set; }
        public string Telefone { get; set; }
        public string Cpf { get; set; }
        public double LimiteConta { get; set; }
        public double TotalConta { get; set; }
        public double TotalPago { get; set; }
        public int NumNotas { get; set; }
        public string DataConta { get; set; }
        public bool Status { get; set; }

        public Cliente(int id, string nome, string apelido, string endereco, string telefone, string cpf, double limiteConta)
        {
            Id = id;
            Nome = nome;
            Apelido = apelido;
            Endereco = endereco;
            Telefone = telefone;
            Cpf = cpf;
            LimiteConta = limiteConta;
            TotalConta = 0;
            NumNotas = 0;
            DataConta = "SEM DADOS";
            Status = true;

        }
        public Cliente(){}
    }
}
