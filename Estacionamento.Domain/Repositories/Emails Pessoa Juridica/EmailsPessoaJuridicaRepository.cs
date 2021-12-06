using Estacionamento.Domain.Emails_Pessoa_Juridica;
using Estacionamento.Domain.Services.Emails_Pessoa_Juridica;
using Estacionamento.Infra.Data;

namespace Estacionamento.Infra.Repositories.Emails_Pessoa_Juridica
{
    public class EmailsPessoaJuridicaRepository : IEmailsPessoaJuridicaRepository
    {
        public bool PostEmail(EmailsPessoaJuridicaEntity emailsPessoaJuridica)
        {
            using (var context = new ApplicationContext())
            {
                context.EmailsPessoaJuridica.Add(emailsPessoaJuridica);
                context.SaveChanges();

                return true;
            }
        }
    }
}
