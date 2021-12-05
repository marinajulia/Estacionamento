using Estacionamento.Domain.Pessoa_Juridica.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estacionamento.Domain.Emails_Pessoa_Juridica
{
   public class EmailsPessoaJuridicaEntity
    {
        [Key]
        public int Id { get; set; }
        public int IdPessoaJuridica { get; set; }
        public string Email { get; set; }
        public PessoaJuridicaEntity PessoaJuridica { get; set; }
    }
}
