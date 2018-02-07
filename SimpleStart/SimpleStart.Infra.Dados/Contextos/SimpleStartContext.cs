using Microsoft.EntityFrameworkCore;
using SimpleStart.Comercial.Eventos;
using SimpleStart.Infra.Dados.Mapeamentos;

namespace SimpleStart.Infra.Dados.Contextos
{
    public class SimpleStartContext : DbContext
    {
        public DbSet<ClienteEvento> ClientesEventos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new ClienteEventoMapeamento(modelBuilder);
        }
    }
}
