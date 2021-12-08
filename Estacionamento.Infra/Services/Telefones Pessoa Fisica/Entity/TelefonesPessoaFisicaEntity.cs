using Estacionamento.Infra.Pessoa_Fisica.Entity;
using System.ComponentModel.DataAnnotations;

namespace Estacionamento.Infra.Telefone_Pessoa_Fisica.Entity
{
    public class TelefonesPessoaFisicaEntity
    {
        [Key]
        public int Id { get; set; }
        public int IdPessoaFisica { get; set; }
        public string Telefone { get; set; }
        public PessoaFisicaEntity PessoaFisica { get; set; }
    }
}
