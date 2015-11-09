namespace EFRelacionesHerencia
{
    using System.Data.Entity;
    using Modelo;
    using System.Collections.Generic;

    public class ApplicationContext : DbContext
    {
        public ApplicationContext()
        {
            Database.SetInitializer(new DatabaseInit());
        }

        public IDbSet<Animal> Animales { get; set; }

        public IDbSet<Tigre> Tigres { get; set; }

        class DatabaseInit : DropCreateDatabaseAlways<ApplicationContext>
        {
            protected override void Seed(ApplicationContext context)
            {
                base.Seed(context);
                
                var tigre = new Tigre
                {
                    Patas = 4,
                    Habitat = new Habitat
                    {
                        Nombre = "Bosques",
                    },
                    Paises = new List<Pais>
                    {
                        new Pais
                        {
                            Nombre = "India"
                        },
                        new Pais
                        {
                            Nombre = "Nepal"
                        }
                    }
                };

                var osoAnteojos = new OsoAnteojos
                {
                    Patas = 4,
                    Paises = new List<Pais>
                    {
                        new Pais
                        {
                            Nombre = "Colombia"
                        },
                        new Pais
                        {
                            Nombre = "Ecuador"
                        },
                        new Pais
                        {
                            Nombre = "Perú"
                        },
                        new Pais
                        {
                            Nombre = "Bolivia"
                        }
                    }
                };
                context.Tigres.Add(tigre);
                context.Animales.Add(osoAnteojos);
                context.SaveChanges();
            }
        }
    }

}