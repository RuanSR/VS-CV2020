using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Models.Exceptions;
using Utils.Enum;
using Utils.Exceptions;

namespace Models.Classes
{
    public class NotaConta
    {
        public NotaConta(double limiteConta)
        {
            ValidarPropriedades(limiteConta);
            LimiteConta = limiteConta;
            TotalConta = 0.0;
            DataConta = "ZERADO";
        }
        public int NotaContaId { get; private set; }

        [Required]
        public double LimiteConta { get; private set; }

        [Required]
        public double TotalConta { get; private set; }

        [Required]
        public string DataConta { get; private set; }

        public List<RegistroNota> RegistroNotas { get; private set; } = new List<RegistroNota>();
        public int ClienteId { get; private set; }

        public void AdicionarValor(double valor, string atendente, string obs)
        {

            ValidarNota(valor, atendente);
            if (valor <= LimiteConta)
            {
                var limiteConta = LimiteConta;
                var totalConta = TotalConta + valor;
                totalConta = double.Parse(totalConta.ToString("F2"));
                var dataConta = VerificaDataNota(Operacao.ADICIONAR, DataConta, valor);
                AtualizarNota(limiteConta, totalConta, dataConta);
                RegistroNotas.Add(new RegistroNota(FormatoDateTime(), atendente, valor, FormataDescricaoNota(Operacao.ADICIONAR, obs)));
            }
            else
            {
                throw new OperacaoException("O valor não pode ser maior que o limite da conta!");
            }
        }
        public void DebitarValor(double valor, string atendente, string obs)
        {

            ValidarNota(valor, atendente);
            if (valor <= TotalConta)
            {
                var limiteConta = LimiteConta;
                var totalConta = TotalConta - valor;
                totalConta = double.Parse(totalConta.ToString("F2"));
                var dataConta = VerificaDataNota(Operacao.DEBITAR, DataConta, totalConta);
                AtualizarNota(limiteConta, totalConta, dataConta);
                RegistroNotas.Add(new RegistroNota(FormatoDateTime(), atendente, valor, FormataDescricaoNota(Operacao.DEBITAR, obs)));
            }
            else
            {
                throw new OperacaoException("O valor do debito não pode ser maior que valor total da conta!");
            }
        }

        public void AtualizarNota(double limiteConta, double totalConta, string dataConta)
        {
            ValidarPropriedades(limiteConta, totalConta, dataConta);
            LimiteConta = limiteConta;
            TotalConta = totalConta;
            DataConta = dataConta;
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

        private void ValidarPropriedades(double limiteConta, double totalConta, string dataConta)
        {
            this.ValidarPropriedades(limiteConta);
            if (limiteConta < TotalConta)
            {
                throw new NotaContaException("O valor do limite da conta não pode ser menor que o total da conta.");
            }
            if (totalConta > limiteConta)
            {
                throw new NotaContaException("Não há limite disponível.");
            }
            if (string.IsNullOrEmpty(dataConta))
            {
                throw new ArgumentException($"O argumento {nameof(dataConta)} não pode ser nulo.");
            }
        }
        private void ValidarPropriedades(double limiteConta)
        {
            if (limiteConta < 0)
            {
                throw new ArgumentException("O valor do limite da conta não pode ser negativo.", nameof(limiteConta));
            }
        }
        public override string ToString()
        {
            return $"Conta: Limite: {LimiteConta.ToString("F2")}, Total: {TotalConta.ToString("F2")}, Data Conta: {DataConta}";
        }
    }
}
