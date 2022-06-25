using System;
using System.ComponentModel.DataAnnotations;

namespace CVirtual.Shared.Classes
{
    public class RegistroNota
    {
        public RegistroNota(DateTime dataHora, string nomeAtendente, double valor, string textoDescricao)
        {
            if (DataHora == null)
            {
                throw new ArgumentException("O argumento precisa ser válido.", nameof(dataHora));
            }
            if (string.IsNullOrEmpty(nomeAtendente))
            {
                throw new ArgumentException("O argumento precisa ser válido.", nameof(nomeAtendente));
            }
            if (valor < 0)
            {
                throw new ArgumentException("O argumento não pode ser negativo.", nameof(valor));
            }
            DataHora = ParseToDefaultDateTime(dataHora);
            NomeAtendente = nomeAtendente;
            Valor = valor;
            TextoDescricao = textoDescricao;
        }
        public int RegistroNotaId { get; private set; }

        [Required]
        public DateTime DataHora { get; private set; }

        [Required]
        public string NomeAtendente { get; private set; }

        [Required]
        public double Valor { get; private set; }

        [MaxLength(200)]
        public string TextoDescricao { get; private set; }

        public int NotaContaId { get; private set; }
        private DateTime ParseToDefaultDateTime(DateTime dateTime)
        {
            return DateTime.Parse(dateTime.ToString("dd/MM/yyyy hh:mm:ss"));
        }
        public override string ToString()
        {
            return $"Registro: {DataHora}, {NomeAtendente}, {Valor}, {TextoDescricao}";
        }
    }
}