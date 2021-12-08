using Estacionamento.Domain.Emails_Pessoa_Fisica.Entity;
using Estacionamento.Domain.Services.Emails_Pessoa_Fisica;
using Estacionamento.Infra.Data;
using System.Collections.Generic;
using System.Linq;

namespace Estacionamento.Infra.Repositories.Emails_Pessoa_Fisica
{
    public class EmailsPessoaFisicaRepository : IEmailsPessoaFisicaRepository
    {
        public IEnumerable<EmailsPessoaFisicaEntity> GetByidPessoaFisica(int pessoaFisica)
        {
            using (var context = new ApplicationContext())
            {
                return context.EmailsPessoaFisica.Where(x => x.IdPessoaFisica == pessoaFisica);
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
