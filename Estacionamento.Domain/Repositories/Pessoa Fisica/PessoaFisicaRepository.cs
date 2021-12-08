using Estacionamento.Domain.Services.Pessoa_Fisica;
using Estacionamento.Infra.Data;
using Estacionamento.Infra.Pessoa_Fisica.Entity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Estacionamento.Infra.Repositories.PessoaFisica
{
    public class PessoaFisicaRepository : IPessoaFisicaRepository
    {
        public bool GetByCpf(string cpf)
        {
            using (var context = new ApplicationContext())
            {
                var CPF = context.PessoaFisica.FirstOrDefault(x => x.CPF.Trim() == cpf.Trim());

                if (CPF == null)
                    return false;

                return true;
            }
        }

        public IEnumerable<PessoaFisicaEntity> GetByCpfPessoaFisica(string cpf)
        {
            using (var context = new ApplicationContext())
            {
                return context.PessoaFisica.Where(x => x.CPF.Trim().Contains(cpf.Trim()))
                    .Include(x => x.Telefones)
                    .Include(x => x.Emails)
                    .ToList();
            }
        }

        public IEnumerable<PessoaFisicaEntity> GetByName(string name)
        {
            using (var context = new ApplicationContext())
            {
                return context.PessoaFisica.Where(x => x.Nome.Trim().ToLower().Contains(name.Trim().ToLower()))
                    .Include(x=> x.Telefones)
                    .Include(x=> x.Emails)
                    .ToList();
            }
        }

        public IEnumerable<PessoaFisicaEntity> GetByRgPessoaFisica(string rg)
        {
            using (var context = new ApplicationContext())
            {
                return context.PessoaFisica.Where(x => x.RG.Trim().Contains(rg.Trim()))
                    .Include(x => x.Telefones)
                    .Include(x => x.Emails).ToList();
            }
        }

        public PessoaFisicaEntity PostPessoaFisica(PessoaFisicaEntity pessoaFisicaEntity)
        {
            using (var context = new ApplicationContext())
            {
                var pessoaFisica = context.PessoaFisica.Add(pessoaFisicaEntity);
                context.SaveChanges();

                return pessoaFisicaEntity;
            }
        }

        public bool SexoIsValid(string sexo)
        {
            if (string.IsNullOrEmpty(sexo) || sexo.Trim().ToLower() == "feminino" || sexo.Trim().ToLower() == "masculino")
                return true;

            return false;
        }
    }
}

