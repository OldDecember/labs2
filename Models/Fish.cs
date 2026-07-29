using System;

namespace AnimalProject.Models
{
    public class Fish : Animal
    {
        public string WaterType { get; set; }

        public Fish(string name, int age, string habitat, string diet, string waterType)
            : base(name, age, habitat, diet)
        {
            WaterType = waterType;
        }

        public override string GetInfo()
        {
            return base.GetInfo() + $", Тип: Рыба, Тип воды: {WaterType}";
        }
    }
}