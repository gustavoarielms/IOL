using System;
namespace CodingChallenge.Data.Classes
{
    public class TrianguloEquilatero : Triangulo
    {
        private readonly decimal _ladoBase;
        private readonly decimal _altura;

        public TrianguloEquilatero(decimal lado)
            :base(lado, lado, lado)
        {
            Tipo = FormasGeometricas.TRIANGULO_EQUILATERO;
            _ladoBase = lado;
            _altura = (decimal)Math.Sqrt(3) * lado / 2;
        }

        public override decimal CalcularArea()
        {
            return _ladoBase * _altura / 2;
        }
    }
}
