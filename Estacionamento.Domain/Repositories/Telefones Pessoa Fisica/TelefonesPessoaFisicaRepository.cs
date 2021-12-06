using Estacionamento.Domain.Services.Telefones_Pessoa_Fisica;
using Estacionamento.Infra.Data;
using Estacionamento.Infra.Telefone_Pessoa_Fisica.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estacionamento.Infra.Repositories.Telefones_Pessoa_Fisica
{
    public class TelefonesPessoaFisicaRepository : ITelefonesPessoaFisicaRepository
    {
        public bool PostTelefone(TelefonesPessoaFisicaEntity telefonesPessoaFisica)
        {
            using (var context = new ApplicationContext())
            {
                var telefonePessoaFisica = context.TelefonesPessoaFisica.Add(telefonesPessoaFisica);
                context.SaveChanges();

                return true;
            }
        }
    }
}
