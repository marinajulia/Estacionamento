using Estacionamento.Domain.Services.Pessoa_Juridica.Dto;

namespace Estacionamento.Domain.Services.Pessoa_Juridica
{
    public interface IPessoaJuridicaService
    {
        bool PostPessoaJuridica(PessoaJuridicaDto pessoajuridica, string[] telefones, string[] emails);
    }
}
