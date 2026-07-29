// Models/Amphibian.cs
using System;

namespace AnimalProject.Models
{
    public class Amphibian : Animal
    {
        public string SkinMoisture { get; set; }

        public Amphibian(string name, int age, string habitat, string diet, string skinMoisture)
            : base(name, age, habitat, diet)
        {
            SkinMoisture = skinMoisture;
        }

        public override string GetInfo()
        {
            return base.GetInfo() + $", Тип: Земноводное, Влажность кожи: {SkinMoisture}";
        }
    }
}