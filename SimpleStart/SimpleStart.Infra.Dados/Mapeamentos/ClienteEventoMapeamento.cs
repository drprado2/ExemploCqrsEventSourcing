using Microsoft.EntityFrameworkCore;
using SimpleStart.Comercial.Eventos;

namespace SimpleStart.Infra.Dados.Mapeamentos
{
    public class ClienteEventoMapeamento
    {
        public ClienteEventoMapeamento(ModelBuilder modelBuilder)
        {
            var mapeamento = modelBuilder.Entity<ClienteEvento>();

            mapeamento.ToTable("ClienteEvento", "Comercial");

            mapeamento.HasKey(x => new {x.Id, x.IdEntidade});
            mapeamento.OwnsOne(x => x.Endereco);
            mapeamento.Property(x => x.Idade).HasColumnName("Idade");
            mapeamento.Property(x => x.Nome).HasColumnName("Nome");
            mapeamento.Property(x => x.Limite).HasColumnName("Limite");
        }
    }
}
