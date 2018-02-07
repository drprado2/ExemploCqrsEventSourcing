namespace SimpleStart.Kernel.Notificacoes
{
    public static class ExtensoesNotificador
    {
        public static ContratoNotificacao CriarContrato(this Notificador notificador)
        {
            return new ContratoNotificacao(notificador);
        }
    }
}
