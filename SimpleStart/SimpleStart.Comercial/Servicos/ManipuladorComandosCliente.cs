using System;
using System.Threading.Tasks;
using SimpleStart.Comercial.Comandos;
using SimpleStart.Comercial.Eventos;
using SimpleStart.Comercial.Interfaces;
using SimpleStart.Comercial.ObjetosDeValor;
using SimpleStart.Kernel.Notificacoes;

namespace SimpleStart.Comercial.Servicos
{
    public class ManipuladorComandosCliente 
        : IManipuladorComando<ComandoClienteCriado>
    {
        private readonly IRepositorioBase _repositorioBase;
        private readonly Notificador _notificador;

        public ManipuladorComandosCliente(IRepositorioBase repositorioBase)
        {
            _repositorioBase = repositorioBase;
            _notificador = Notificador.Instancia;
        }

        public async Task ResolverAsync(ComandoClienteCriado comando)
        {
            var endereco = comando.Endereco != null
                ? new Endereco(comando.Endereco.Logradouro, comando.Endereco.Numero, comando.Endereco.Bairro)
                : null; 

            var clienteEvento = new ClienteEvento(Guid.NewGuid(), comando.Nome, comando.Idade, comando.Limite, endereco);

            if (_notificador.TemNotificacoes())
                return;

            await _repositorioBase.CriarAsync(clienteEvento);
        }
    }
}
