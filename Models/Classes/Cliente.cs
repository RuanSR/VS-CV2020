using Models.Exceptions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Models.Classes
{
    public class Cliente
    {
        public Cliente() { }

        public Cliente(
            string nome, string apelido, string endereco, string telefone,
            string cpf, double limiteConta)
        {
            Nome = nome;
            Apelido = apelido;
            Endereco = endereco;
            Telefone = telefone;
            Cpf = cpf;
            Status = true;
            NotaConta = new NotaConta(limiteConta);
            ValidarDados(this);
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
            Nome = nome;
            Apelido = apelido;
            Endereco = endereco;
            Telefone = telefone;
            Cpf = cpf;
            Status = status;
            ValidarDados(this);
        }

        public bool ValidarDados(object obj)
        {
            var strError = new StringBuilder();
            var errors = ValidatorEntity(obj);
            if (errors.Count() > 0)
            {
                throw new ValidationException("Preencha os campos corretamente!");
            }
            return true;
        }

        private IEnumerable<ValidationResult> ValidatorEntity(object obj)
        {
            var resultadoValidacao = new List<ValidationResult>();
            var context = new ValidationContext(obj, null, null);
            Validator.TryValidateObject(obj, context, resultadoValidacao);
            return resultadoValidacao;
        }

        public override string ToString()
        {
            return $"Cliente: {Nome}, {Apelido}, {Endereco}, {Telefone}, {Cpf}, {Status}";
        }
    }
}
