using SimpleStart.Kernel.Notificacoes;

namespace SimpleStart.Kernel.ObjetosDeValor
{
    public abstract class ObjetoDeValor
    {
        protected readonly Notificador Notificador;

        protected ObjetoDeValor()
        {
            Notificador = Notificador.Instancia;
        }
    }
}
