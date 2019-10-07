using System;
namespace CodingChallenge.Data.Classes
{
    public class Cuadrado : Rectangulo
    {

        public Cuadrado(decimal lado)
            :base(lado, lado)

        {
            Tipo = FormasGeometricas.CUADRADO;
        }
    }
}
