namespace Estacionamento.SharedKernel.Validations
{
    public interface IValidations
    {
        bool EmailIsValid(string email);
        bool CpfIsValid(string cpf);
        bool RgIsValid(string rg);
        bool CnpjIsValid(string cnpj);
    }
}
