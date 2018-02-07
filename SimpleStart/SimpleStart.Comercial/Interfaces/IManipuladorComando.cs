using System.Threading.Tasks;
using SimpleStart.Kernel.Comandos;

namespace SimpleStart.Comercial.Interfaces
{
    public interface IManipuladorComando<T> where T : ComandoBase
    {
        Task ResolverAsync(T comando);
    }
}
