using System;

namespace ExemploEFCore
{
    public class Cotacao
    {
        public string Sigla { get; set; }
        public string Nome_Moeda { get; set; }
        public DateTime Ultima_Cotacao { get; set; }
        public Valor Valor { get; set; }
    }

    public class Valor
    {
        public decimal Comercial { get; set; }
        public decimal? Turismo { get; set; }
    }
}