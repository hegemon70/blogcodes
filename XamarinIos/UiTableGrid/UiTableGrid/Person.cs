using System.Collections.Generic;

namespace UiTableGrid
{
    public class Person
    {
        public string Name { get; set; }

        public string Country { get; set; }

        public int Age { get; set; }

        public static List<Person> GetPersons()
        {
            return new List<Person>
            {
                new Person
                {
                    Name = "Abc Def", Age = 21
                },
                new Person
                {
                    Name = "Ghijk Lmnopq", Age = 32
                }
                ,new Person
                {
                    Name = "Rstuvw Xyza", Age = 16
                }
                ,new Person
                {
                    Name = "Bcdefg Hijklmn", Age = 45
                }
                ,new Person
                {
                    Name = "Opqrst Uvwzx", Age = 47
                }
            };
        }
    }
}
