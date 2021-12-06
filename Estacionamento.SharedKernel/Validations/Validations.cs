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
            var convertedInput = $"{cnpj}";
            convertedInput = convertedInput.PadLeft(14, '0');

            var first = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            var second = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };

            if (convertedInput.Length != 14)
                return false;

            var cnpjRange = convertedInput.Substring(0, 12);
            var sumValue = 0;

            for (var i = 0; i < 12; i++)
                sumValue += int.Parse(cnpjRange[i].ToString()) * first[i];

            var remnant = (sumValue % 11);

            if (remnant < 2)
                remnant = 0;

            remnant = 11 - remnant;
            var digit = remnant.ToString();
            cnpjRange = cnpjRange + digit;
            sumValue = 0;
            for (var i = 0; i < 13; i++)
                sumValue += int.Parse(cnpjRange[i].ToString()) * second[i];
            remnant = (sumValue % 11);
            if (remnant < 2)
                remnant = 0;

            remnant = 11 - remnant;
            digit += remnant;

            return convertedInput.EndsWith(digit);
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
