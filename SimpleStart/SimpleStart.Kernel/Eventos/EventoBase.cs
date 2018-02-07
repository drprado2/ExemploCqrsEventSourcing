using System;
using SimpleStart.Kernel.Notificacoes;

namespace SimpleStart.Kernel.Eventos
{
    public abstract class EventoBase
    {
        public Guid Id { get; protected set; }
        public Guid IdEntidade { get; protected set; }
        protected readonly Notificador Notificador;

        protected EventoBase(Guid idEntidade)
        {
            Id = Guid.NewGuid();
            IdEntidade = idEntidade;
            Notificador = Notificador.Instancia;
        }
    }
}
