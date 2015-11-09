using System;
using System.Data.Entity;
using System.Linq;

namespace EFRelacionesHerencia
{
    class Program
    {
        static void Main()
        {
            using (var context = new ApplicationContext())
            {
                context.Configuration.LazyLoadingEnabled = false;

                var tigre = context.Tigres.Include("Paises").First(x => x.Id == 2);

                Console.WriteLine("El tigre tiene {0} patas y habita en: {1}", tigre.Patas,
                    string.Join(", ", tigre.Paises.Select(p => p.Nombre)));

                Console.ReadLine();
            }
        }
    }
}
