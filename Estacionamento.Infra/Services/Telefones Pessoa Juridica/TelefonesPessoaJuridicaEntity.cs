using Estacionamento.Domain.Pessoa_Juridica.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estacionamento.Domain.Telefones_Pessoa_Juridica
{
    public class TelefonesPessoaJuridicaEntity
    {
        [Key]
        public int Id { get; set; }
        public int IdPessoaJuridica { get; set; }
        public string Telefone { get; set; }
        public PessoaJuridicaEntity PessoaJuridica { get; set; }
    }
}
