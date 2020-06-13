using Models.Exceptions;
using System;
using System.ComponentModel.DataAnnotations;
using Utils.Enum;
using Utils.Exceptions;

namespace Models.Classes
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

        public void AdicionarValor(double valor, string atendente, string obs)
        {

            ValidarNota(valor, atendente);
            if (valor <= this.NotaConta.LimiteConta)
            {
                var limiteConta = this.NotaConta.LimiteConta;
                var totalConta = this.NotaConta.TotalConta + valor;
                totalConta = double.Parse(totalConta.ToString("F2"));
                var dataConta = VerificaDataNota(Operacao.ADICIONAR, this.NotaConta.DataConta, valor);
                this.NotaConta.AtualizarNota(limiteConta, totalConta, dataConta);
                this.NotaConta.RegistroNotas.Add(new RegistroNota(FormatoDateTime(), atendente, valor, FormataDescricaoNota(Operacao.ADICIONAR, obs)));
            }
            else
            {
                throw new OperacaoException("O valor não pode ser maior que o limite da conta!");
            }
        }
        public void DebitarValor(double valor, string atendente, string obs)
        {

            ValidarNota(valor, atendente);
            if (valor <= this.NotaConta.TotalConta)
            {
                var limiteConta = this.NotaConta.LimiteConta;
                var totalConta = this.NotaConta.TotalConta - valor;
                totalConta = double.Parse(totalConta.ToString("F2"));
                var dataConta = VerificaDataNota(Operacao.DEBITAR, this.NotaConta.DataConta, totalConta);
                this.NotaConta.AtualizarNota(limiteConta, totalConta, dataConta);
                this.NotaConta.RegistroNotas.Add(new RegistroNota(FormatoDateTime(), atendente, valor, FormataDescricaoNota(Operacao.DEBITAR, obs)));
            }
            else
            {
                throw new OperacaoException("O valor do debito não pode ser maior que valor total da conta!");
            }
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
        private void ValidarNota(double valor, string atendente)
        {
            if (valor < 0)
            {
                throw new ArgumentException("O valor não pode ser negativo.");
            }
            if (valor == 0.0)
            {
                throw new OperacaoException("O valor não pode ser zero.");
            }
            if (string.IsNullOrEmpty(atendente))
            {
                throw new ArgumentException("É preciso prenecher o campo Atendente.");
            }
        }
        private string VerificaDataNota(Operacao op, string propriedadeData, double totalConta)
        {
            if (op == Operacao.ADICIONAR)
            {
                if (propriedadeData != "ZERADO")
                {
                    return propriedadeData;
                }
                return DateTime.Now.ToString("dd/MM/yyyy");
            }
            else
            {
                if (totalConta <= 0)
                {
                    return "ZERADO";
                }
                return propriedadeData;
            }
        }
        private string FormataDescricaoNota(Operacao opType, string obs)
        {
            if (opType == Operacao.ADICIONAR)
            {
                if (string.IsNullOrEmpty(obs))
                {
                    return "SEM OBSERVAÇÔES";
                }
                return obs;
            }
            else
            {
                if (string.IsNullOrEmpty(obs))
                {
                    return "DEBITO EFETUADO, SEM OBSERVAÇÔES";
                }
                return $"DEBITO EFETUADO. {obs}";
            }
        }
        private DateTime FormatoDateTime()
        {
            return DateTime.Parse(DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"));
        }

        public override string ToString()
        {
            return $"Cliente: {Nome}, {Apelido}, {Endereco}, {Telefone}, {Cpf}, {Status}";
        }
    }
}
