using System;
using System.Collections.Generic;

using System.Linq;

public class Drug
{
    public string Name { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }
}

public class DrugCategory
{
    public string Name { get; set; }
    public List<Drug> Drugs { get; set; } = new List<Drug>();
}

public class PharmacyManager
{
    public List<DrugCategory> Categories { get; set; } = new List<DrugCategory>();

    public void AddNewDrug(string categoryName, Drug newDrug)
    {
        var category = Categories.Find(c => c.Name.Equals(categoryName, StringComparison.OrdinalIgnoreCase));

        if (category == null)
        {
            category = new DrugCategory { Name = categoryName };
            Categories.Add(category);
        }

        category.Drugs.Add(newDrug);
    }

    public void DisplayDrugsByCategory(string categoryName)
    {
        var category = Categories.Find(c => c.Name.Equals(categoryName, StringComparison.OrdinalIgnoreCase));

        if (category != null)
        {
            foreach (var drug in category.Drugs)
            {
                Console.WriteLine($"Name: {drug.Name}, Quantity: {drug.Quantity}, Price: {drug.Price}");
            }
        }
        else
        {
            Console.WriteLine("Category not found.");
        }
    }

    public void DisplayDrugDetails(string drugName)
    {
        var drug = Categories.SelectMany(c => c.Drugs).FirstOrDefault(d => d.Name.Equals(drugName, StringComparison.OrdinalIgnoreCase));

        if (drug != null)
        {
            Console.WriteLine($"Name: {drug.Name}, Quantity: {drug.Quantity}, Price: {drug.Price}");
        }
        else
        {
            Console.WriteLine("Drug not found.");
        }
    }

    public void SearchDrug(string drugName)
    {
        var drug = Categories.SelectMany(c => c.Drugs).FirstOrDefault(d => d.Name.Equals(drugName, StringComparison.OrdinalIgnoreCase));

        if (drug != null)
        {
            Console.WriteLine($"Name: {drug.Name}, Quantity: {drug.Quantity}, Price: {drug.Price}");
        }
        else
        {
            Console.WriteLine("Drug not found.");
        }
    }

    public void UpdateDrug(string drugName, int newQuantity, decimal newPrice)
    {
        var drug = Categories.SelectMany(c => c.Drugs).FirstOrDefault(d => d.Name.Equals(drugName, StringComparison.OrdinalIgnoreCase));

        if (drug != null)
        {
            drug.Quantity = newQuantity;
            drug.Price = newPrice;
            Console.WriteLine("Drug information updated successfully.");
        }
        else
        {
            Console.WriteLine("Drug not found.");
        }
    }

    public void DeleteDrug(string drugName)
    {
        foreach (var category in Categories)
        {
            var drugToRemove = category.Drugs.FirstOrDefault(d => d.Name.Equals(drugName, StringComparison.OrdinalIgnoreCase));

            if (drugToRemove != null)
            {
                category.Drugs.Remove(drugToRemove);
                Console.WriteLine("Drug removed successfully.");
                return;
            }
        }

        Console.WriteLine("Drug not found.");
    }
}

class Program
{
    static void Main()
    {
        PharmacyManager pharmacyManager = new PharmacyManager();

        while (true)
        {
            Console.WriteLine("\n=== Pharmacy Management System ===");
            Console.WriteLine("1. Add New Drug");
            Console.WriteLine("2. Display Drugs by Category");
            Console.WriteLine("3. Display Drug Details");
            Console.WriteLine("4. Search Drug");
            Console.WriteLine("5. Update Drug Information");
            Console.WriteLine("6. Delete Drug");
            Console.WriteLine("7. Exit");
            Console.Write("Enter your choice (1-7): ");

            if (int.TryParse(Console.ReadLine(), out int choice))
            {
                switch (choice)
                {
                    case 1:
                        Console.Write("Enter Category Name: ");
                        string category = Console.ReadLine();
                        Console.Write("Enter Drug Name: ");
                        string drugName = Console.ReadLine();
                        Console.Write("Enter Quantity: ");
                        int quantity = int.Parse(Console.ReadLine());
                        Console.Write("Enter Price: ");
                        decimal price = decimal.Parse(Console.ReadLine());

                        pharmacyManager.AddNewDrug(category, new Drug { Name = drugName, Quantity = quantity, Price = price });
                        Console.WriteLine("Drug added successfully.");
                        break;

                    case 2:
                        Console.Write("Enter Category Name: ");
                        string displayCategory = Console.ReadLine();
                        pharmacyManager.DisplayDrugsByCategory(displayCategory);
                        break;

                    case 3:
                        Console.Write("Enter Drug Name: ");
                        string displayDrug = Console.ReadLine();
                        pharmacyManager.DisplayDrugDetails(displayDrug);
                        break;

                    case 4:
                        Console.Write("Enter Drug Name: ");
                        string searchDrug = Console.ReadLine();
                        pharmacyManager.SearchDrug(searchDrug);
                        break;

                    case 5:
                        Console.Write("Enter Drug Name: ");
                        string updateDrug = Console.ReadLine();
                        Console.Write("Enter New Quantity: ");
                        int newQuantity = int.Parse(Console.ReadLine());
                        Console.Write("Enter New Price: ");
                        decimal newPrice = decimal.Parse(Console.ReadLine());

                        pharmacyManager.UpdateDrug(updateDrug, newQuantity, newPrice);
                        break;

                    case 6:
                        Console.Write("Enter Drug Name: ");
                        string deleteDrug = Console.ReadLine();
                        pharmacyManager.DeleteDrug(deleteDrug);
                        break;

                    case 7:
                        Environment.Exit(0);
                        break;

                    default:
                        Console.WriteLine("Invalid choice. Please enter a number between 1 and 7.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
            }
        }
    }
}
