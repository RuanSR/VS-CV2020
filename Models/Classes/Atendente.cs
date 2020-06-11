using Models.Enum;
using Models.Exceptions;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Models.Classes
{
    public class Atendente
    {
        public Atendente() { }
        public Atendente(string nome, string usuario, string senha, NivelAcesso nivelAcesso)
        {
            Nome = nome;
            Usuario = usuario;
            Senha = senha;
            NivelAcesso = nivelAcesso;
            ValidaAtendente(this);
        }
        public int AtendenteId { get; private set; }

        [Required]
        [MinLength(3)]
        public string Nome { get; private set; }

        [Required]
        [MinLength(3)]
        public string Usuario { get; private set; }

        [Required]
        public string Senha { get; private set; }

        [Required]
        public NivelAcesso NivelAcesso { get; private set; }

        public void AtualizarAtendente(string nome, string usuario, string senha, NivelAcesso nivelAcesso)
        {
            Nome = nome;
            Usuario = usuario;
            Senha = senha;
            NivelAcesso = nivelAcesso;
            ValidaAtendente(this);
        }
        private bool ValidaAtendente(object obj)
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

        public override bool Equals(object obj)
        {
            var atend = obj as Atendente;
            if (atend != null)
            {
                return atend.Nome == Nome && atend.Usuario == Usuario;
            }
            return false;
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
