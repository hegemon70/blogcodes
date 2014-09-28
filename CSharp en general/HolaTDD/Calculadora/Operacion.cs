using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Calculadora
{
    public class Operacion
    {
        public int Sumar(int a, int b)
        {
            return a + b;
        }

        public int Restar(int i, int i1)
        {
            return i - i1;
        }

        public int Multiplicar(int i, int i1)
        {
            return i*i1;
        }

        public float Dividir(int i, int i1)
        {
            return (float)i/i1;
        }
    }
}
