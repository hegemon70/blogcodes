// Nicolas Herrera
// :)
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Calculadora.Test
{
    [TestClass]
    public class CalculadoraTest
    {
        [TestMethod]
        public void SumarDosNumeros()
        {
            Operacion operacion = new Operacion();
            int resultado = operacion.Sumar(2, 5);
            Assert.AreEqual(7, resultado);
        }

        [TestMethod]
        public void RestarDosNumeros()
        {
            Operacion operacion = new Operacion();
            int resultado = operacion.Restar(8, 5);
            Assert.AreEqual(3, resultado);
        }

        [TestMethod]
        public void MultiplicarDosNumeros()
        {
            Operacion operacion = new Operacion();
            int resultado = operacion.Multiplicar(8, 5);
            Assert.AreEqual(40, resultado);
        }

        [TestMethod]
        public void DividirDosNumerosResiduoCero()
        {
            Operacion operacion = new Operacion();
            float resultado = operacion.Dividir(24, 8);
            Assert.AreEqual(3, resultado);
        }

        [TestMethod]
        public void DividirDosNumerosResiduoDiferenteDeCero()
        {
            Operacion operacion = new Operacion();
            float resultado = operacion.Dividir(9, 2);
            Assert.AreEqual(4.5, resultado);
        }
    }
}