using System;

namespace AnimalProject.Models
{
    public class Reptile : Animal
    {
        public bool IsVenomous { get; set; }

        public Reptile(string name, int age, string habitat, string diet, bool isVenomous)
            : base(name, age, habitat, diet)
        {
            IsVenomous = isVenomous;
        }

        public override string GetInfo()
        {
            return base.GetInfo() + $", Тип: Пресмыкающееся, Ядовитость: {(IsVenomous ? "ядовито" : "неядовито")}";
        }
    }
}