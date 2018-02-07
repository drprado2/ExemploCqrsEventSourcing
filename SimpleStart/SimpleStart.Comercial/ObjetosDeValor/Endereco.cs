using SimpleStart.Kernel.Notificacoes;
using SimpleStart.Kernel.ObjetosDeValor;

namespace SimpleStart.Comercial.ObjetosDeValor
{
    public class Endereco : ObjetoDeValor
    {
        public Endereco(string logradouro, int numero, string bairro)
        {
            Logradouro = logradouro;
            Numero = numero;
            Bairro = bairro;

            Validar();
        }

        private void Validar()
        {
            _notificador.CriarContrato()
                .ComComprimentoTexto(Logradouro, 3, 100, "Logradouro Inválido", "O logradouro deve possuir entre 3 e 100 caracteres")
                .ComTextoObrigatorio(Logradouro, "Logradouro Obrigatório", "O logradouro é de preenchimento obrigatório")
                .ComNumeroPositivoMaiorQueZero(Numero, "Número Inválido", "O número deve ser maior que 0")
                .Assinar();
        }

        public string Logradouro { get; private set; }
        public int Numero { get; private set; }
        public string Bairro { get; private set; }
    }
}
