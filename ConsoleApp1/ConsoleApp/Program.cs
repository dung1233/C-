using System;
using System.Collections.Generic;

class Customer
{
    public string Id { get; set; }
    public string Name { get; set; }
    public DateTime BillDate { get; set; }
}

class VietnameseCustomer : Customer
{
    public string CustomerType { get; set; }
    public double Quantity { get; set; }
    public double UnitPrice { get; set; }

    public double CalculateTotal()
    {
        double standardQuantity = 50;
        double exceedQuantity = Math.Max(0, Quantity - standardQuantity);
        double newUnitPrice = 0;

        if (CustomerType == "sinh hoạt")
        {
            newUnitPrice = 1000;
        }
        else if (CustomerType == "kinh doanh")
        {
            newUnitPrice = 1200;
        }
        else if (CustomerType == "sản xuất")
        {
            newUnitPrice = 1500;
        }

        double total = (Quantity <= standardQuantity) ? Quantity * UnitPrice : (standardQuantity * UnitPrice) + (exceedQuantity * newUnitPrice);
        return total;
    }
}

class ForeignCustomer : Customer
{
    public string Nationality { get; set; }
    public double Quantity { get; set; }
    public double UnitPrice { get; set; }

    public double CalculateTotal()
    {
        double total = 0;

        if (Nationality == "Việt Nam")
        {
            if (Quantity < 50)
            {
                total = Quantity * UnitPrice;
            }
            else if (Quantity <= 100)
            {
                total = Quantity * 1200;
            }
            else if (Quantity <= 200)
            {
                total = Quantity * 1500;
            }
            else
            {
                total = Quantity * 2000;
            }
        }
        else
        {
            total = Quantity * 2000;
        }

        return total;
    }
}


