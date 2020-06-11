using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace WinDesktop.Utils
{
    internal static class ValidateEntity
    {
        public static bool GetValidation(object obj)
        {
            var strError = new StringBuilder();
            var errors = ValidatorEntity(obj);
            if (errors.Count() > 0)
            {
                foreach (var erro in errors)
                {
                    strError.AppendLine("- " + erro.ErrorMessage);
                }
                throw new ValidationException("Preencha os campos corretamente!\n" + strError.ToString());
            }
            return true;
        }

        private static IEnumerable<ValidationResult> ValidatorEntity(object obj)
        {
            var resultadoValidacao = new List<ValidationResult>();
            var context = new ValidationContext(obj, null, null);
            Validator.TryValidateObject(obj, context, resultadoValidacao);
            return resultadoValidacao;
        }
    }
}
