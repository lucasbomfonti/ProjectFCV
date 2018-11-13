using System;
using System.ComponentModel.DataAnnotations;
using API.Helper;

namespace API.AnotacaoCustomizada
{
    [AttributeUsage(AttributeTargets.All, AllowMultiple = true, Inherited = false)]
    public class ValidacaoCpf : RequiredAttribute
    {
        private readonly string _property;
        private readonly object _service;

        public ValidacaoCpf(string property, object service)
        {
            _property = property;
            _service = service;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            Guid? id = null;

            var propertyInfo = validationContext.ObjectType.GetProperty(_property);
            if (propertyInfo != null)
                id = (Guid) propertyInfo.GetValue(validationContext.ObjectInstance, null);
            if(!CpfHelper.ValidateCpf(value.ToString()))
                return new ValidationResult("Cpf Inválido");

            return base.IsValid(value, validationContext);
        }
    }
}
