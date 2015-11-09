namespace EFRelacionesHerencia.Modelo
{
    using System.Collections.Generic;

    public class Tigre : Animal
    {
        public int HabitatId { get; set; }

        public virtual Habitat Habitat { get; set; }

        public virtual ICollection<Pais> Paises { get; set; }
        
    }
}