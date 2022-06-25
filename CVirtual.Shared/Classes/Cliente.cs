using CVirtual.Shared.Exceptions;
using System;
using System.ComponentModel.DataAnnotations;

namespace CVirtual.Shared.Classes
{
    public class Cliente
    {
        public Cliente() { }

        public Cliente(
            string nome, string apelido, string endereco, string telefone,
            string cpf, double limiteConta)
        {
            ValidarPropriedades(nome, apelido, endereco, telefone);
            Nome = nome;
            Apelido = apelido;
            Endereco = endereco;
            Telefone = telefone;
            Cpf = cpf;
            Status = true;
            NotaConta = new NotaConta(limiteConta);
        }
        public int ClienteId { get; private set; }

        [Required]
        [MinLength(3)]
        public string Nome { get; private set; }

        [Required]
        [MinLength(3)]
        public string Apelido { get; private set; }

        [Required]
        [MinLength(6)]
        public string Endereco { get; private set; }

        [Required]
        [MinLength(16)]
        public string Telefone { get; private set; }

        public string Cpf { get; private set; }

        [Required]
        public bool Status { get; private set; }

        [Required]
        public NotaConta NotaConta { get; private set; }

        public void AtualizarCliente(
            string nome, string apelido, string endereco, string telefone,
            string cpf, bool status)
        {
            ValidarPropriedades(nome, apelido, endereco, telefone);
            Nome = nome;
            Apelido = apelido;
            Endereco = endereco;
            Telefone = telefone;
            Cpf = cpf;
            Status = status;
        }
        private void ValidarPropriedades(string nome, string apelido, string endereco, string telefone, double limiteConta = 0.0)
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
