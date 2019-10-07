using System;
namespace CodingChallenge.Data.Classes
{
    public class Rectangulo : FormaGeometrica
    {
        protected readonly decimal _base;
        protected readonly decimal _altura;
        public Rectangulo(decimal ladoBase, decimal ladoAltura)
        {
            Tipo = FormasGeometricas.RECTANGULO;
            _base = ladoBase;
            _altura = ladoAltura;
        }

        public FormasGeometricas Tipo { get; set; }

        public decimal CalcularArea()
        {
            return _base * _altura;
        }

        public decimal CalcularPerimetro()
        {
            return (2 * _base) + (2 * _altura);
        }
    }
}
