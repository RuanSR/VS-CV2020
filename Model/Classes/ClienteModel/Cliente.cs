using Model.Exceptions;
using System;

namespace Model.Classes.ClienteModel
{
    public sealed class Cliente
    {
        public Cliente() { }

        public Cliente(
            string nome, string apelido, string endereco, string telefone,
            string cpf, double limiteConta)
        {
            ValidarDados(nome, apelido, endereco, telefone, limiteConta);
            Nome = nome;
            Apelido = apelido;
            Endereco = endereco;
            Telefone = telefone;
            Cpf = cpf;
            Status = true;
            NotaConta = new NotaConta(limiteConta);
        }
        public int ClienteId { get; private set; }
        public string Nome { get; private set; }
        public string Apelido { get; private set; }
        public string Endereco { get; private set; }
        public string Telefone { get; private set; }
        public string Cpf { get; private set; }
        public bool Status { get; private set; }
        public NotaConta NotaConta { get; private set; }

        public void AtualizarCliente(
            string nome, string apelido, string endereco, string telefone,
            string cpf, bool status)
        {
            ValidarDados(nome, apelido, endereco, telefone);
            Nome = nome;
            Apelido = apelido;
            Endereco = endereco;
            Telefone = telefone;
            Cpf = cpf;
            Status = status;
        }
        private void ValidarDados(string nome, string apelido, string endereco, string telefone, double limiteConta = 0.0)
        {
            if (string.IsNullOrEmpty(nome) || string.IsNullOrEmpty(apelido) || string.IsNullOrEmpty(endereco)
                || string.IsNullOrEmpty(telefone))
            {
                throw new ClienteException("Preencha corretamente os dados requeridos.");
            }

            if (limiteConta < 0)
            {
                throw new ArgumentException("O valor do limite da conta não pode ser negativo.", nameof(limiteConta));
            }
        }

        public override string ToString()
        {
            return $"Cliente: {Nome}, {Apelido}, {Endereco}, {Telefone}, {Cpf}, {Status}";
        }
    }
}
