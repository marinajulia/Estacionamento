using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estacionamento.Infra.Telefone_Pessoa_Fisica.Entity
{
    public class TelefonesPessoaFisicaEntity
    {
        [Key]
        public int Id { get; set; }
        public int IdPessoaFisica { get; set; }
        public string Telefone { get; set; }
    }
}
