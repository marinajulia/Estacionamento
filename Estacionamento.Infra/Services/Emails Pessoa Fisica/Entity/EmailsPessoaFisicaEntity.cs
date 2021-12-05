using Estacionamento.Infra.Pessoa_Fisica.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estacionamento.Domain.Emails_Pessoa_Fisica.Entity
{
    [Table("EmailsPessoaFisica")]
    public class EmailsPessoaFisicaEntity
    {
        [Key]
        public int Id { get; set; }
        public int IdPessoaFisica { get; set; }
        public string Email { get; set; }

        public PessoaFisicaEntity PessoaFisica { get; set; }
    }
}
