using Estacionamento.Domain.Services.Pessoa_Fisica;
using Estacionamento.Domain.Services.Pessoa_Fisica.Dto;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.Domain.Notification;

namespace Estacionamento_rift.Controllers.Pessoa_Fisica
{
    [ApiController]
    [Route("pessoafisica")]
    public class PessoaFisicaController : Controller
    {
        private readonly INotification _notification;
        private readonly IPessoaFisicaService _pessoaFisicaService;

        public PessoaFisicaController(INotification notification, IPessoaFisicaService pessoaFisicaService)
        {
            _notification = notification;
            _pessoaFisicaService = pessoaFisicaService;
        }

        [HttpPost]
        public IActionResult Post(PessoaFisicaDto pessoaFisicaDto)
        {
            var response = _pessoaFisicaService.PostPessoaFisica(pessoaFisicaDto);

            if (!response)
                return BadRequest(_notification.GetErrors());

            return Ok(_notification.AddWithReturn<IActionResult>("Cadastro realizado com sucesso!"));
        }

        [HttpGet("getbycpf")]
        public IActionResult GetByCPF(string cpf)
        {
            var response = _pessoaFisicaService.GetByCpfPessoaFisica(cpf);
            return Ok(response);
        }

        [HttpGet("getbyname")]
        public IActionResult GetByName(string nome)
        {
            var response = _pessoaFisicaService.GetByName(nome);
            return Ok(response);
        }

        [HttpGet("getbyrg")]
        public IActionResult GetByRg(string rg)
        {
            var response = _pessoaFisicaService.GetByRgPessoaFisica(rg);
            return Ok(response);
        }
    }
}
