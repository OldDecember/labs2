using System;

namespace AnimalProject.Models
{
    public class Mammal : Animal
    {
        public bool HasFur { get; set; }

        public Mammal(string name, int age, string habitat, string diet, bool hasFur)
            : base(name, age, habitat, diet)
        {
            HasFur = hasFur;
        }

        public override string GetInfo()
        {
            return base.GetInfo() + $", Тип: Млекопитающее, Шерсть: {(HasFur ? "есть" : "нет")}";
        }
    }
}