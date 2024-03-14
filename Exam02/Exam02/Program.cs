using System;

namespace InheritancePolymorphismExample
{
    class Animal
    {
        protected string Name { get; set; }
        protected double Weight { get; set; }

        public Animal(double weight, string name)
        {
            Weight = weight;
            Name = name;
        }

        public virtual void Show()
        {
            Console.WriteLine($"Name: {Name}, Weight: {Weight}kg");
        }
    }

    class Lion : Animal
    {
        public Lion(double weight, string name) : base(weight, name) { }
    }

    class Tiger : Animal
    {
        public Tiger(double weight, string name) : base(weight, name) { }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Lion lion = new Lion(100, "Tiger");
            Tiger tiger = new Tiger(180, "lion");

            
            lion.Show();
            tiger.Show();
        }
    }
}
