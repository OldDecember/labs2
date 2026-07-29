using System;

namespace AnimalProject.Models
{
    public class Bird : Animal
    {
        public double WingSpan { get; set; }

        public Bird(string name, int age, string habitat, string diet, double wingSpan)
            : base(name, age, habitat, diet)
        {
            WingSpan = wingSpan;
        }

        public override string GetInfo()
        {
            return base.GetInfo() + $", Тип: Птица, Размах крыльев: {WingSpan} м";
        }
    }
}