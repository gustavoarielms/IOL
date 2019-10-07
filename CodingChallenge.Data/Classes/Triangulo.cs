using System;
namespace CodingChallenge.Data.Classes
{
    public class Triangulo : FormaGeometrica
    {

        protected readonly decimal _ladoA;
        protected readonly decimal _ladoB;
        protected readonly decimal _ladoC;

        public Triangulo(decimal ladoA, decimal ladoB, decimal ladoC)
        {
            _ladoA = ladoA;
            _ladoB = ladoB;
            _ladoC = ladoC;
        }

        public FormasGeometricas Tipo { get; set; }

        public virtual decimal CalcularArea()
        {
            throw new NotImplementedException();
        }

        public decimal CalcularPerimetro()
        {
            return _ladoA + _ladoB + _ladoC;
        }
    }
}
