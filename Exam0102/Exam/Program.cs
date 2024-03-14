using System;

namespace GeometryExample
{
    class Cylinder
    {
        private double Radius { get; }
        private double Height { get; }
        private double BaseArea { get; set; }
        private double LateralArea { get; set; }
        private double TotalArea { get; set; }
        private double Volume { get; set; }

        public Cylinder(double radius, double height)
        {
            Radius = radius;
            Height = height;
        }

        public void Process()
        {
            BaseArea = Math.Round(Radius * Radius * Math.PI, 2);
            LateralArea = Math.Round(2 * Math.PI * Radius * Height, 2);
            TotalArea = Math.Round(2 * Math.PI * Radius * (Height + Radius), 2);
            Volume = Math.Round(Math.PI * Radius * Radius * Height, 2);
        }

        public string Result()
        {
            return $"Base Area: {BaseArea} | Lateral Area: {LateralArea} | Total Area: {TotalArea} | Volume: {Volume}";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the dimenststions of cylinder");
            Console.Write("Radius: ");
            double radius = Convert.ToDouble(Console.ReadLine());
            Console.Write("Height: ");
            double height = Convert.ToDouble(Console.ReadLine());


            Cylinder cylinder = new Cylinder(radius, height);
            cylinder.Process();
            Console.WriteLine("");
            Console.WriteLine("Cylinder Characteristics:");
            Console.Write("Radius: ");
            Console.Write(radius);
            Console.Write(",");
            Console.Write("Height: ");
            Console.WriteLine(height);
            Console.WriteLine(cylinder.Result());
        }
    }
}
