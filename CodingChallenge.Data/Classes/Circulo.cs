using System;
namespace CodingChallenge.Data.Classes
{
    public class Circulo : FormaGeometrica
    {
        private readonly decimal _diametro;
        public Circulo(decimal diametro)
        {
            Tipo = FormasGeometricas.CIRCULO;
            _diametro = diametro;
        }

        public FormasGeometricas Tipo { get; set; }

        public decimal CalcularArea()
        {
            return (decimal)Math.PI * (_diametro / 2) * (_diametro / 2);
        }

        public decimal CalcularPerimetro()
        {
            return (decimal)Math.PI * _diametro;
        }
    }
}
