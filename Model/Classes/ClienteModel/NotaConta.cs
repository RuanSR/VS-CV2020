using System;
using System.Collections.Generic;
using Model.Exceptions;

namespace Model.Classes.ClienteModel
{
    public class NotaConta
    {
        public NotaConta(double limiteConta)
        {
            ValidaDados(limiteConta);
            LimiteConta = limiteConta;
            TotalConta = 0.0;
            DataConta = "ZERADO";
        }
        public int NotaContaId { get; private set; }
        public double LimiteConta { get; private set; }
        public double TotalConta { get; private set; }
        public string DataConta { get; private set; }
        public List<RegistroNota> RegistroNotas { get; private set; } = new List<RegistroNota>();
        public int ClienteId { get; private set; }

        public void AtualizarNota(double limiteConta, double totalConta, string dataConta)
        {
            ValidaDados(limiteConta, totalConta, dataConta);
            LimiteConta = limiteConta;
            TotalConta = totalConta;
            DataConta = dataConta;
        }
        private void ValidaDados(double limiteConta, double totalConta, string dataConta)
        {
            this.ValidaDados(limiteConta);
            if (limiteConta < TotalConta)
            {
                throw new NotaContaException("O valor do limite da conta não pode ser menor que o total da conta.");
            }
            if(totalConta > limiteConta)
            {
                throw new NotaContaException("Não há limite disponível.");
            }
            if(string.IsNullOrEmpty(dataConta))
            {
                throw new ArgumentException($"O argumento {nameof(dataConta)} não pode ser nulo.");
            }
        }
        private void ValidaDados(double limiteConta)
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