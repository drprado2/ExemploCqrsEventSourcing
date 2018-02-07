using System;
using System.Collections.Generic;
using System.Linq;

namespace SimpleStart.Kernel.Notificacoes
{
    public class Notificador 
    {
        private readonly IList<Tuple<string, string>> _notificacoes;
        private static Notificador _instancia;

        public static Notificador Instancia => _instancia ?? new Notificador();

        private Notificador()
        {
            _notificacoes = new List<Tuple<string, string>>();
        }

        public IList<Tuple<string, string>> Notificacoes
        {
            get { return _notificacoes.Select(x => new Tuple<string, string>(x.Item1, x.Item2)).ToList(); }
        }

        public void Notificar(string nome, string descricao)
        {
            _notificacoes.Add(new Tuple<string, string>(nome, descricao));
        }

        public bool TemNotificacoes()
        {
            return Notificacoes.Count > 0;
        }
    }
}
