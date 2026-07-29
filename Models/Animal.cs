
using System;

namespace AnimalProject.Models
{
    public class Animal
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Habitat { get; set; }
        public string Diet { get; set; }

        public Animal(string name, int age, string habitat, string diet)
        {
            Name = name;
            Age = age;
            Habitat = habitat;
            Diet = diet;
        }

        public virtual string GetInfo()
        {
            return $"Кличка: {Name}, Возраст: {Age}, Среда: {Habitat}, Питание: {Diet}";
        }
    }
}