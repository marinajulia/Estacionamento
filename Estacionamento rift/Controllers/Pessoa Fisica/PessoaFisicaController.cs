using Estacionamento.Domain.Services.Emails_Pessoa_Fisica.Dto;
using Estacionamento.Domain.Services.Pessoa_Fisica;
using Estacionamento.Domain.Services.Pessoa_Fisica.Dto;
using Estacionamento.Domain.Services.Telefones_Pessoa_Fisica.Dto;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.Domain.Notification;

namespace Estacionamento_rift.Controllers.Pessoa_Fisica
{
    //[ApiController]
    [Route("pessoafisica")]
    public class Pessoa_Fisica : Controller
    {
        private readonly INotification _notification;
        private readonly IPessoaFisicaService _pessoaFisicaService;

        public Pessoa_Fisica(INotification notification, IPessoaFisicaService pessoaFisicaService)
        {
            _notification = notification;
            _pessoaFisicaService = pessoaFisicaService;
        }

        [HttpPost]
        public IActionResult Post(PessoaFisicaDto pessoaFisicaDto, string[] telefones, string[] emails)
        {
            var response = _pessoaFisicaService.PostPessoaFisica(pessoaFisicaDto, telefones, emails);

            if (!response)
                return BadRequest(_notification.GetErrors());

            return Ok(_notification.AddWithReturn<IActionResult>("Cadastro realizado com sucesso!"));
        }
    }
}
