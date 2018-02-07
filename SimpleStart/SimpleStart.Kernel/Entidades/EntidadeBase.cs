using System;
using System.ComponentModel.DataAnnotations;
using SimpleStart.Kernel.Notificacoes;

namespace SimpleStart.Kernel.Entidades
{
    public abstract class EntidadeBase
    {
        public Guid Id { get; private set; }
        protected readonly Notificador _notificador;

        protected EntidadeBase()
        {
            Id = Guid.NewGuid();
            _notificador = Notificador.Instancia;
        }

        public override bool Equals(object objeto)
        {
            return objeto.GetType() == typeof(EntidadeBase) 
                   && (Guid)objeto.GetType().GetProperty("Id").GetValue(objeto) == Id;
        }
    }
}
