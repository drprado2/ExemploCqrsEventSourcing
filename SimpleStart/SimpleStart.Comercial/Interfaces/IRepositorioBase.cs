using System.Threading.Tasks;
using SimpleStart.Kernel.Eventos;

namespace SimpleStart.Comercial.Interfaces
{
    public interface IRepositorioBase
    {
        Task CriarAsync<T>(T evento) where T : EventoBase;
    }
}
