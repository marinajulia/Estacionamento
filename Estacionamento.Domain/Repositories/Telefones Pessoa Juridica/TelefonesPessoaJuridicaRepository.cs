using Estacionamento.Domain.Services.Telefones_Pessoa_Juridica;
using Estacionamento.Domain.Telefones_Pessoa_Juridica;
using Estacionamento.Infra.Data;

namespace Estacionamento.Infra.Repositories.Telefones_Pessoa_Juridica
{
    public class TelefonesPessoaJuridicaRepository : ITelefonesPessoaJuridicaRepository
    {
        public bool PostTelefone(TelefonesPessoaJuridicaEntity telefonesPessoaJuridica)
        {
            using (var context = new ApplicationContext())
            {
                context.TelefonesPessoaJuridica.Add(telefonesPessoaJuridica);
                context.SaveChanges();

                return true;
            }
        }
    }
}
