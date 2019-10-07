using System;
namespace CodingChallenge.Data.Classes
{
    public class Trapecio : FormaGeometrica
    {

        private decimal _baseA;
        private decimal _baseB;
        private decimal _ladoA;
        private decimal _ladoB;

        public Trapecio(decimal baseA, decimal baseB, decimal ladoA, decimal ladoB)
        {
            Tipo = FormasGeometricas.TRAPECIO;
            _baseA = baseA;
            _baseB = baseB;
            _ladoA = ladoA;
            _ladoB = ladoB;
        }

        public FormasGeometricas Tipo { get; set; }

        public decimal CalcularArea()
        {
            decimal sqrt = (decimal)Math.Sqrt((double)((- _baseA + _ladoA + _baseB + _ladoB) * (- _baseA - _ladoA + _baseB + _ladoB) * (- _baseA - _ladoA + _baseB - _ladoB) * (_baseA - _ladoA - _baseB + _ladoB)));
            return (_baseA + _baseB) / (4 * Math.Abs(_baseA - _baseB)) * sqrt;
        }

        public decimal CalcularPerimetro()
        {
            return _ladoA + _ladoB + _baseA + _baseB;
        }
    }
}
 