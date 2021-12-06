using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estacionamento.Domain.Services.Emails_Pessoa_Fisica.Dto
{
   public class EmailsPessoaFisicaDto
    {
        public int Id { get; set; }
        public int IdPessoaFisica { get; set; }
        public string Email { get; set; }
    }
}
