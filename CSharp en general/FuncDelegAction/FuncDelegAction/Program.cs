// Nicolas Herrera
// :)
using System;

namespace FuncDelegAction
{
    internal class Program
    {
        public delegate double Operacion(double num1, double num2);

        private static void Main(string[] args)
        {
            double num1 = 8;
            double num2 = 6;

            #region Delegados

            Operacion operacionSuma = new Operacion(Sumar);
            double resultSuma = RealizarOperacion(num1, num2, operacionSuma);

            Operacion operacionResta = new Operacion(Restar);
            double resultResta = RealizarOperacion(num1, num2, operacionResta);

            Console.WriteLine(string.Format("Suma: {0}", resultSuma));
            Console.WriteLine(string.Format("Resta: {0}", resultResta));

            #endregion

            #region Action<t1,t2>

            Action<double, double> dividir = Dividir;
            dividir(num1, num2);

            #endregion

            #region Func<t1,t2>

            Func<double, double, double> operacionMultipl = Multiplicar;
            double resultMultipl = operacionMultipl(num1, num2);
            Console.WriteLine(string.Format("Multiplicacion: {0}", resultMultipl));

            #endregion

            double resultSumaLambda = RealizarOperacion(num1, num2, (x, y) => (x*y));
            Console.ReadKey();
        }

        private static double RealizarOperacion(double num1, double num2, Operacion operacion)
        {
            return operacion(num1, num2);
        }

        private static double Sumar(double num1, double num2)
        {
            return num1 + num2;
        }

        private static double Restar(double num1, double num2)
        {
            return num1 - num2;
        }

        private static void Dividir(double num1, double num2)
        {
            double resultado = num1/num2;
            Console.WriteLine(string.Format("Division: {0}", resultado));
        }

        private static double Multiplicar(double num1, double num2)
        {
            return num1*num2;
        }
    }
}