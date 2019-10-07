using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Resources;
using System.Text;

namespace CodingChallenge.Data.Classes
{
    #region Idiomas

    public enum Idiomas
    {
        CASTELLANO,
        INGLES,
        PORTUGUES
    }

    #endregion

    public class Reporte
    {

        #region Dictionarios

        private static Dictionary<FormasGeometricas, decimal> _cantidadesDictionario;
        private static Dictionary<FormasGeometricas, decimal> _areasDictionario;
        private static Dictionary<FormasGeometricas, decimal> _perimetrosDictionario;

        #endregion

        private static StringBuilder _sb;

        /// <summary>
        /// Imprime un resumen de todas las formas geometricas agregadas
        /// </summary>
        /// <returns>
        /// Un string
        /// </returns>
        /// <param name="formas">Una Lista de FormaGeometrica.</param>
        /// <param name="idioma">El idioma en el que imprime.</param>
        public static string Imprimir(List<FormaGeometrica> formas, Idiomas idioma)
        {
            ConfigurarIdioma(idioma);

            _sb = new StringBuilder();

            if (!formas.Any())
            {
                _sb.AppendFormat("<h1>{0}</h1>", Resx.Strings.EmptyListOfShapes);
            }
            else
            {
                // Hay por lo menos una forma

                Array values = Enum.GetValues(typeof(FormasGeometricas));
                InicializarDictionarios(values);

                // HEADER
                AgregarHeader();

                // BODY
                ResumenDeFormas(formas, values);

                // FOOTER
                AgregarFooter();
            }

            return _sb.ToString();
        }

        /// <summary>
        /// Genera un resumen de las distintas formas en la lista
        /// </summary>
        /// <param name="formas">Una Lista de FormaGeometrica.</param>
        /// <param name="values">Un Array con los distintos tipos de formas</param>
        private static void ResumenDeFormas(List<FormaGeometrica> formas, Array values)
        {
            foreach (FormasGeometricas forma in values)
            {
                for (var i = formas.Count - 1; i >= 0; i--)
                {
                    if (forma == formas[i].Tipo)
                    {
                        _cantidadesDictionario[forma]++;
                        _areasDictionario[forma] += formas[i].CalcularArea();
                        _perimetrosDictionario[forma] += formas[i].CalcularPerimetro();
                    }
                }
                _sb.Append(ObtenerLinea((int)_cantidadesDictionario[forma], _areasDictionario[forma], _perimetrosDictionario[forma], forma));
            }
        }

        /// <summary>
        /// Iniciliza los diccionarios
        /// </summary>
        /// <param name="values">Un Array con los distintos tipos de formas</param>
        private static void InicializarDictionarios(Array values)
        {
            _cantidadesDictionario = new Dictionary<FormasGeometricas, decimal>();
            _areasDictionario = new Dictionary<FormasGeometricas, decimal>();
            _perimetrosDictionario = new Dictionary<FormasGeometricas, decimal>();
            foreach (FormasGeometricas forma in values)
            {
                _cantidadesDictionario.Add(forma, 0);
                _areasDictionario.Add(forma, 0m);
                _perimetrosDictionario.Add(forma, 0m);
            }
        }

        /// <summary>
        /// Genera el Footer del resumen
        /// </summary>
        private static void AgregarFooter()
        {
            _sb.AppendFormat("{0}<br/>", Resx.Strings.Total);
            _sb.AppendFormat("{0} {1} ", ObtenerTotalesDelDiccionario(_cantidadesDictionario), Resx.Strings.Shapes);
            _sb.AppendFormat("{0} {1} ", Resx.Strings.Perimeter, ObtenerTotalesDelDiccionario(_perimetrosDictionario).ToString("#.##"));
            _sb.AppendFormat("{0} {1}", Resx.Strings.Area, ObtenerTotalesDelDiccionario(_areasDictionario).ToString("#.##"));
        }

        /// <summary>
        /// Realiza una sumatoria de los valores del diccionario
        /// </summary>
        /// <returns>
        /// Un decimal
        /// </returns>
        /// <param name="dictionario">Un Diccionario.</param>
        private static decimal ObtenerTotalesDelDiccionario(Dictionary<FormasGeometricas, decimal> dictionario)
        {
            decimal total = 0;
            foreach (var valor in dictionario.Values)
            {
                total += valor;
            }
            return total;
        }

        /// <summary>
        /// Genera el Header del resumen
        /// </summary>
        private static void AgregarHeader()
        {
            _sb.AppendFormat("<h1>{0}</h1>", Resx.Strings.ShapesReport);
        }

        /// <summary>
        /// Configura el idioma en el que se imprime
        /// </summary>
        /// <param name="idioma">El idioma en el que imprime.</param>
        private static void ConfigurarIdioma(Idiomas idioma)
        {
            System.Threading.Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo(Resx.Idiomas.ResourceManager.GetString(idioma.ToString()));       
        }

        /// <summary>
        /// Genera una linea del resumen segun la forma
        /// </summary>
        /// <returns>
        /// Un string
        /// </returns>
        /// <param name="cantidad">La cantidad de formas.</param>
        /// <param name="area">La sumatoria de areas de la forma.</param>
        /// <param name="perimetro">La sumatoria de perimetros de la forma.</param>
        /// <param name="tipo">El tipo de forma.</param>
        private static string ObtenerLinea(int cantidad, decimal area, decimal perimetro, FormasGeometricas tipo)
        {
            if (cantidad > 0)
                return $"{cantidad} {ObtenerNombreDeForma(tipo, cantidad)} | {Resx.Strings.Area} {area.ToString("#.##")} | {Resx.Strings.Perimeter} {perimetro:#.##} <br/>";
            return string.Empty;
        }

        /// <summary>
        /// Obtiene el nombre en singular o plurar de la forma
        /// </summary>
        /// <returns>
        /// Un string
        /// </returns>
        /// <param name="tipo">El tipo de forma.</param>
        /// <param name="cantidad">La cantidad de formas.</param>
        private static string ObtenerNombreDeForma(FormasGeometricas tipo, int cantidad)
        {
            string nombre = cantidad == 1 ? Resx.Strings.ResourceManager.GetString(tipo.ToString()) : Resx.Strings.ResourceManager.GetString(tipo.ToString() + "_PLURAL");
            return nombre;
        }
    }
}
