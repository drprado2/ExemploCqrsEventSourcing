using SimpleStart.Comercial.DTO;
using SimpleStart.Kernel.Comandos;

namespace SimpleStart.Comercial.Comandos
{
    public class ComandoClienteCriado : ComandoBase
    {
        public string Nome { get; set; }
        public int? Idade { get; set; }
        public double? Limite { get; set; }
        public EnderecoDto Endereco { get; set; }
    }
}
