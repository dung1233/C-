using System;


class Lion : Animal
{
    public Lion(double weight, string name)
    {
        SetMe(weight, name);
    }

    public override void Show()
    {
        Console.WriteLine("Lion Details:");
        base.Show();
    }
}