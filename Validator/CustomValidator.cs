using DocumentValidator;
using System.ComponentModel.DataAnnotations;

namespace LR_Projeto_Api.Validation
{
    public static class CustomValidator
    {
        public static ValidationResult IsEven(object entity)
        {

            var cpf = (string)Convert.ChangeType(entity, TypeCode.String)!;

            if (cpf.Length == 11 || cpf.Length == 14)
            {
                return new ValidationResult($"CPF {cpf} NÃO É VALIDO.");
            }

            if (CpfValidation.Validate(cpf))
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult($"CPF {cpf} NÃO É VALIDO.");
            } 
                
        }
    }
}
