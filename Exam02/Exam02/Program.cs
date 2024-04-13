using System;

class Program
{
    static void Main(string[] args)
    {
      
        Lion lion = new Lion(100, "Lion");
        Tiger tiger = new Tiger(200, "Tiger");

      
        Animal[] animals = new Animal[] { lion, tiger };

       
        foreach (var animal in animals)
        {
            animal.Show();
        }
    }
}
