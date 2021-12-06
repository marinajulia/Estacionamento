using Estacionamento.Domain.Services.Pessoa_Juridica;
using Estacionamento.Domain.Services.Pessoa_Juridica.Dto;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.Domain.Notification;

namespace Estacionamento_rift.Controllers.Pessoa_Juridica
{
    [Route("pessoajuridica")]
    public class PessoaJuridicaController : Controller
    {
        private readonly INotification _notification;
        private readonly IPessoaJuridicaService _pessoaJuridicaService;

        public PessoaJuridicaController(INotification notification, IPessoaJuridicaService pessoaJuridicaService)
        {
            _notification = notification;
            _pessoaJuridicaService = pessoaJuridicaService;
        }

        [HttpPost]
        public IActionResult Post(PessoaJuridicaDto pessoaJuridicaDto, string[] telefones, string[] emails)
        {
            var response = _pessoaJuridicaService.PostPessoaJuridica(pessoaJuridicaDto, telefones, emails);

            if (!response)
                return BadRequest(_notification.GetErrors());

            return Ok(_notification.AddWithReturn<IActionResult>("Cadastro realizado com sucesso!"));
        }
    }
}
