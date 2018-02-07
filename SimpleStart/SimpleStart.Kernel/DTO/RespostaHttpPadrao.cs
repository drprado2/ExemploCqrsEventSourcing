using System;
using System.Collections.Generic;

namespace SimpleStart.Kernel.DTO
{
    public class RespostaHttpPadrao<T>
    {
        public bool Sucesso { get; set; }
        public IList<Tuple<string, string>> Erros;
        public IList<T> Dados;
        public int TotalRegistros { get; set; }
    }
}
