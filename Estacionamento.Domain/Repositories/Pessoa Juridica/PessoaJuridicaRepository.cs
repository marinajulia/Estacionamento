using Estacionamento.Domain.Pessoa_Juridica.Entity;
using Estacionamento.Domain.Services.Pessoa_Juridica;
using Estacionamento.Infra.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Estacionamento.Infra.Repositories.Pessoa_Juridica
{
    public class PessoaJuridicaRepository : IPessoaJuridicaRepository
    {
        public bool GetByCNPJ(string cnpj)
        {
            using (var context = new ApplicationContext())
            {
                var CNPJ = context.PessoaJuridica.FirstOrDefault(x => x.CNPJ.Trim() == cnpj.Trim());

                if (CNPJ == null)
                    return false;

                return true;
            }
        }

        public IEnumerable<PessoaJuridicaEntity> GetByCNPJPessoaJuridica(string cnpj)
        {
            using (var context = new ApplicationContext())
            {
                return context.PessoaJuridica.Where(x=> x.CNPJ.Trim().Contains(cnpj.Trim()))
                    .Include(x => x.Telefones)
                    .Include(x => x.Emails)
                    .ToList();
            }
        }
        public IEnumerable<PessoaJuridicaEntity> GetByNomeFantasia(string nomeFantasia)
        {
            using (var context = new ApplicationContext())
            {
                return context.PessoaJuridica.Where(x => x.NomeFantasia.Trim().ToLower().Contains(nomeFantasia.Trim().ToLower()))
                    .Include(x => x.Telefones)
                    .Include(x => x.Emails)
                    .ToList();
            }
        }

        public IEnumerable<PessoaJuridicaEntity> GetByRazaoSocial(string razaoSocial)
        {
            using (var context = new ApplicationContext())
            {
                return context.PessoaJuridica.Where(x => x.RazaoSocial.Trim().ToLower().Contains(razaoSocial.Trim().ToLower()))
                    .Include(x => x.Telefones)
                    .Include(x => x.Emails)
                    .ToList();
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
