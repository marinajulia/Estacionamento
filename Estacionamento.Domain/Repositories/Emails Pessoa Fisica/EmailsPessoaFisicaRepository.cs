using Estacionamento.Domain.Emails_Pessoa_Fisica.Entity;
using Estacionamento.Domain.Services.Emails_Pessoa_Fisica;
using Estacionamento.Infra.Data;
using System.Text.RegularExpressions;

namespace Estacionamento.Infra.Repositories.Emails_Pessoa_Fisica
{
    public class EmailsPessoaFisicaRepository : IEmailsPessoaFisicaRepository
    {
        public bool EmailIsValid(string email)
        {
            using (var context = new ApplicationContext())
            {
                string validEmail = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
                Regex regex = new Regex(validEmail);

                var isValid = regex.Match(validEmail);

                if (isValid == null)
                    return false;

                return true;
            }
        }

        public bool PostEmail(EmailsPessoaFisicaEntity emailsPessoaFisicaEntity)
        {
            using (var context = new ApplicationContext())
            {
                context.EmailsPessoaFisica.Add(emailsPessoaFisicaEntity);
                context.SaveChanges();

                return true;
            }
        }
    }
}
