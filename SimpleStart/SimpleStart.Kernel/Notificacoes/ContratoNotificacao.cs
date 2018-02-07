using System;
using System.Collections.Generic;

namespace SimpleStart.Kernel.Notificacoes
{
    public class ContratoNotificacao
    {
        private readonly IList<Tuple<string, string>> _notificacoes = new List<Tuple<string, string>>();
        private readonly Notificador _notificador;

        public ContratoNotificacao(Notificador notificador)
        {
            _notificador = notificador;
        }

        public void Assinar()
        {
            foreach (var notificao in _notificacoes)
            {
                _notificador.Notificar(notificao.Item1, notificao.Item2);
            }
        }

        public ContratoNotificacao ComComprimentoTexto(
            string texto,
            int quantidadeMinimaCaracteres,
            int quantidadeMaximaCaracteres,
            string nomeNotificao,
            string descricaoNotificao)
        {
            if (texto?.Length < quantidadeMinimaCaracteres|| texto?.Length > quantidadeMaximaCaracteres)
                _notificacoes.Add(new Tuple<string, string>(nomeNotificao, descricaoNotificao));

            return this;
        }

        public ContratoNotificacao ComTextoObrigatorio(
            string texto,
            string nomeNotificao,
            string descricaoNotificao)
        {
            if(string.IsNullOrWhiteSpace(texto))
                _notificacoes.Add(new Tuple<string, string>(nomeNotificao, descricaoNotificao));

            return this;
        }

        public ContratoNotificacao ComNumeroPositivoMaiorQueZero(
            int numero,
            string nomeNotificao,
            string descricaoNotificao)

        {
            if(numero <= 0)
                _notificacoes.Add(new Tuple<string, string>(nomeNotificao, descricaoNotificao));

            return this;
        }

        public ContratoNotificacao ComNumeroPositivoMaiorQueZero(
            double numero,
            string nomeNotificao,
            string descricaoNotificao)

        {
            if(numero <= 0)
                _notificacoes.Add(new Tuple<string, string>(nomeNotificao, descricaoNotificao));

            return this;
        }
    }
}
