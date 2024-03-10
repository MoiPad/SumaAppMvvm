

namespace SumaAppMvvm.Models
{
    internal class Suma
    {
        public double Valor1 { get; set; }
        public double Valor2 { get; set;}


        public double SumarValores()
        {
            return Valor1 + Valor2;
        }
    }
}
