
using System.Collections.Generic;
using Entidades;
using InterfazUsuario.Referencia;
using ObjectList = Entidades.ObjectList;


namespace InterfazUsuario
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            EfDemoClient service = new EfDemoClient();
            int cambios = service.ModificarPaisPorId(8);


            //Pais p = service.ObtenerPaisPorId(8);
            //p.Nombre = "Espaniyya";
            //int cambios = service.Modificar(p);

        }
    }
}