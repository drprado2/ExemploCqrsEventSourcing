using System.Threading.Tasks;
using SimpleStart.Comercial.Interfaces;
using SimpleStart.Infra.Dados.Contextos;
using SimpleStart.Kernel.Eventos;

namespace SimpleStart.Infra.Dados.Repositorios
{
    public class RepositorioBase : IRepositorioBase
    {
        protected readonly SimpleStartContext _contexto;

        protected RepositorioBase(SimpleStartContext contexto)
        {
            _contexto = contexto;
        }

        public async Task CriarAsync<T>(T evento) where T : EventoBase
        {
            await _contexto.AddAsync(evento);
        }
    }
}
