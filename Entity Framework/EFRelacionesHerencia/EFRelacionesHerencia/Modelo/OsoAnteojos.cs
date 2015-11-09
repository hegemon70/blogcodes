namespace EFRelacionesHerencia.Modelo
{
    using System.Collections.Generic;

    public class OsoAnteojos : Animal
    {
        public virtual ICollection<Pais> Paises { get; set; }
    }
}