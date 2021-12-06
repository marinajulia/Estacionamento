using Estacionamento.Domain.Services.Telefones_Pessoa_Fisica;
using Estacionamento.Infra.Data;
using Estacionamento.Infra.Telefone_Pessoa_Fisica.Entity;

namespace Estacionamento.Infra.Repositories.Telefones_Pessoa_Fisica
{
    public class TelefonesPessoaFisicaRepository : ITelefonesPessoaFisicaRepository
    {
        public bool PostTelefone(TelefonesPessoaFisicaEntity telefonesPessoaFisica)
        {
            using (var context = new ApplicationContext())
            {
                context.TelefonesPessoaFisica.Add(telefonesPessoaFisica);
                context.SaveChanges();

                return true;
            }
        }
    }
}
