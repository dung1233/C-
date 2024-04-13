using System;


class Tiger : Animal
{
    public Tiger(double weight, string name)
    {
        SetMe(weight, name);
    }

    public override void Show()
    {
        Console.WriteLine("Tiger Details:");
        base.Show();
    }
}