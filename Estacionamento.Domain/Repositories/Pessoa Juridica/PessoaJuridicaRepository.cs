using Estacionamento.Domain.Pessoa_Juridica.Entity;
using Estacionamento.Domain.Services.Pessoa_Juridica;
using Estacionamento.Infra.Data;
using System.Linq;

namespace Estacionamento.Infra.Repositories.Pessoa_Juridica
{
    public class PessoaJuridicaRepository : IPessoaJuridicaRepository
    {
        public bool GetByCNPJ(string cnpj)
        {
            using (var context = new ApplicationContext())
            {
                var CNPJ = context.PessoaJuridica.FirstOrDefault(x => x.CNPJ == cnpj);

                if (CNPJ == null)
                    return false;

                return true;
            }
        }

        public PessoaJuridicaEntity PostPessoaJuridica(PessoaJuridicaEntity pessoaJuridicaEntity)
        {
            using (var context = new ApplicationContext())
            {
                var pessoaFisica = context.PessoaJuridica.Add(pessoaJuridicaEntity);
                context.SaveChanges();

                return pessoaJuridicaEntity;
            }
        }
    }
}
