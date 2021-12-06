using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estacionamento.SharedKernel.Validations
{
    public interface IValidations
    {
        bool EmailIsValid(string email);
        bool CpfIsValid(string cpf);
        bool RgIsValid(string rg);
    }
}
