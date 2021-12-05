using Estacionamento.Domain.Emails_Pessoa_Fisica.Entity;
using Estacionamento.Infra.Telefone_Pessoa_Fisica.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estacionamento.Infra.Pessoa_Fisica.Entity
{
    public class PessoaFisicaEntity
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sexo { get; set; }
        public string DataNascimento { get; set; }
        public string RG { get; set; }
        public string Endereço { get; set; }
        public IEnumerable<TelefonesPessoaFisicaEntity> Telefones { get; set; }
        public IEnumerable<EmailsPessoaFisicaEntity> Emails { get; set; }

    }
}
