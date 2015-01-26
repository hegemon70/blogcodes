using System;
using System.Collections.Generic;

namespace CompositeEF_Sitemap
{
    internal class Program
    {
        private static void Main()
        {
            Seed();
            Console.WriteLine("Inciando..");
            Console.ReadLine();
        }

        private static void Seed()
        {
            using (var context = new ApplicationContext())
            {
                context.AppSiteMaps.Add(new AppSiteMap
                {
                    DisplayText = "Configuración",
                    Href = "#",
                    Lang = "es",
                    Parent = null,
                    Roles = "Admin",
                    Order = 1,
                    Childs = new List<AppSiteMap>
                                                       {
                                                           new AppSiteMap
                                                           {
                                                               Order = 1,
                                                               DisplayText = "Usuarios",
                                                               Href = "/app/usuarios",
                                                               Lang = "es",
                                                               Roles = "Admin",
                                                           },
                                                           new AppSiteMap
                                                           {
                                                               Order = 2,
                                                               DisplayText = "Menus",
                                                               Href = "/app/menus",
                                                               Lang = "es",
                                                               Roles = "Admin",
                                                           }
                                                       }
                });

                context.AppSiteMaps.Add(new AppSiteMap
                {
                    DisplayText = "Ventas",
                    Href = "#",
                    Lang = "es",
                    Parent = null,
                    Roles = "Admin,User",
                    Order = 2,
                    Childs = new List<AppSiteMap>
                                                       {
                                                           new AppSiteMap
                                                           {
                                                               Order = 1,
                                                               DisplayText = "Crear",
                                                               Href = "/ventas/nuevo",
                                                               Lang = "es",
                                                               Roles = "Admin,User",
                                                           },
                                                           new AppSiteMap
                                                           {
                                                               Order = 2,
                                                               DisplayText = "Listar",
                                                               Href = "/ventas/listar",
                                                               Lang = "es",
                                                               Parent = null,
                                                               Roles = "Admin,User",
                                                           }
                                                       }
                });
                context.SaveChanges();
            }
        }
    }
}
