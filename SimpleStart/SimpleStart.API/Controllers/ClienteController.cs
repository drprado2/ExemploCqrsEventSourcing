using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SimpleStart.Comercial.Comandos;
using SimpleStart.Comercial.Interfaces;
using SimpleStart.Kernel.DTO;
using SimpleStart.Kernel.Notificacoes;

namespace SimpleStart.API.Controllers
{
    [Route("clientes")]
    public class ClienteController : Controller
    {
        private readonly IManipuladorComando<ComandoClienteCriado> _manipuladorClienteCriado;
        private readonly IUnitOfWork _unitOfWork;
        private readonly Notificador _notificador;

        public ClienteController(
            IManipuladorComando<ComandoClienteCriado> manipuladorClienteCriado,
            IUnitOfWork unitOfWork)
        {
            _manipuladorClienteCriado = manipuladorClienteCriado;
            _unitOfWork = unitOfWork;
            _notificador = Notificador.Instancia;
        }

        [HttpPost]
        [Route("/")]
        public async Task<IActionResult> Criar([FromBody] ComandoClienteCriado requisicao)
        {
            try
            {
                using (_unitOfWork)
                {
                    await _manipuladorClienteCriado.ResolverAsync(requisicao);

                    if (_notificador.TemNotificacoes())
                    {
                        var resposta = new RespostaHttpPadrao<object>()
                        {
                            Sucesso = false,
                            Erros = _notificador.Notificacoes
                        };

                        return BadRequest(resposta);
                    }

                    await _unitOfWork.CommitAsync();

                    return Ok();
                }
            }
            catch (Exception erro)
            {
                // Criar geração de logs para exceções não esperadas
                var resposta = new RespostaHttpPadrao<object>()
                {
                    Sucesso = false,
                    Erros = new List<Tuple<string, string>>()
                    {
                        new Tuple<string, string>("Erro Não Tratado", erro.Message)
                    }
                };

                return BadRequest(resposta);
            }

        }
    }
}
