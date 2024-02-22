// Program.cs
using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        List<Customer> customers = new List<Customer>();

        // Thêm khách hàng Việt Nam
        VietnameseCustomer vietnameseCustomer = new VietnameseCustomer
        {
            Id = "VN001",
            Name = "Nguyen Van A",
            BillDate = DateTime.Now,
            CustomerType = "sinh hoạt",
            Quantity = 60,
            UnitPrice = 2000
        };
        customers.Add(vietnameseCustomer);

        // Thêm khách hàng nước ngoài
        ForeignCustomer foreignCustomer = new ForeignCustomer
        {
            Id = "F001",
            Name = "John Doe",
            BillDate = DateTime.Now,
            Nationality = "USA",
            Quantity = 80,
            UnitPrice = 1500
        };
        customers.Add(foreignCustomer);

        // In thông tin và tổng tiền của từng khách hàng
        foreach (Customer customer in customers)
        {
            Console.WriteLine($"Customer ID: {customer.Id}");
            Console.WriteLine($"Customer Name: {customer.Name}");
            Console.WriteLine($"Bill Date: {customer.BillDate}");

            if (customer is VietnameseCustomer vnCustomer)
            {
                Console.WriteLine($"Total Amount: {vnCustomer.CalculateTotal()}");
            }
            else if (customer is ForeignCustomer fCustomer)
            {
                Console.WriteLine($"Total Amount: {fCustomer.CalculateTotal()}");
            }

            Console.WriteLine("----------------------------");
        }
    }
}
