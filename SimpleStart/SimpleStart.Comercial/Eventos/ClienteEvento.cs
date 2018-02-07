using System;
using SimpleStart.Comercial.ObjetosDeValor;
using SimpleStart.Kernel.Eventos;
using SimpleStart.Kernel.Notificacoes;

namespace SimpleStart.Comercial.Eventos
{
    public class ClienteEvento : EventoBase
    {
        public ClienteEvento(Guid idEntidade, string nome, int? idade, double? limite, Endereco endereco) : base(idEntidade)
        {
            Nome = nome;
            Idade = idade;
            Limite = limite;
            Endereco = endereco;
        }

        public void Validar()
        {
            var contrato = Notificador
                .CriarContrato()
                .ComComprimentoTexto(Nome, 3, 50, "Nome Inválido", "O nome deve ter entre 3 e 50 caracteres");

            if (Idade.HasValue)
                contrato = contrato.ComNumeroPositivoMaiorQueZero(Idade.Value, "Idade Inválida", "A idade é inválida");

            if (Limite.HasValue)
                contrato = contrato.ComNumeroPositivoMaiorQueZero(Limite.Value, "Limite Inválido", "O limite dever ser um valor positivo maior que zero");
            
            contrato.Assinar();
        }

        public string Nome { get; private set; }
        public int? Idade { get; private set; }
        public double? Limite { get; private set; }
        public Endereco Endereco { get; private set; }
    }
}
