using System;
using System.Threading.Tasks;

namespace SimpleStart.Comercial.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        Task CommitAsync();
    }
}
