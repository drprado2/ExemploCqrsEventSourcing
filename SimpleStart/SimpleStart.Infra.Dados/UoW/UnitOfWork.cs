using System.Threading.Tasks;
using SimpleStart.Comercial.Interfaces;
using SimpleStart.Infra.Dados.Contextos;

namespace SimpleStart.Infra.Dados.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private SimpleStartContext _contexto;

        public UnitOfWork(SimpleStartContext contexto)
        {
            _contexto = contexto;
        }

        public async Task CommitAsync()
        {
            await _contexto.SaveChangesAsync();
        }

        public void Dispose()
        {
            Dispose(true);
        }

        private void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_contexto != null)
                {
                    _contexto.Dispose();
                    _contexto = null;
                }
            }
        }
    }
}
