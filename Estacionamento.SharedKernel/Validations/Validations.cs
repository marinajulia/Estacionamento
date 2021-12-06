using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Estacionamento.SharedKernel.Validations
{
    public class Validations : IValidations
    {
        public bool CnpjIsValid(string cnpj)
        {
            string validCnpj = @"/^\d{2}\.\d{3}\.\d{3}\/\d{4}\-\d{2}$/";
            Regex regex = new Regex(validCnpj);

            var isValid = regex.Match(cnpj);

            if (!isValid.Success)
                return false;

            return true;
        }

        public bool CpfIsValid(string cpf)
        {
            string validCpf = @"[0-9]{3}\.?[0-9]{3}\.?[0-9]{3}\-?[0-9]{2}";
            Regex regex = new Regex(validCpf);

            var isValid = regex.Match(cpf);

            if (!isValid.Success)
                return false;

            return true;
        }

        public bool EmailIsValid(string email)
        {
            string validEmail = @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$";
            Regex regex = new Regex(validEmail);

            var isValid = regex.Match(validEmail);

            if (!isValid.Success)
                return false;

            return true;
        }

        public bool RgIsValid(string rg)
        {
            string validRg = @"(^\d{1,2}).?(\d{3}).?(\d{3})-?(\d{1}|X|x$)";
            Regex regex = new Regex(validRg);

            var isValid = regex.Match(rg);

            if (!isValid.Success)
                return false;

            return true;
        }
    }
}
