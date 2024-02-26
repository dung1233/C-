using System;
using System.Collections.Generic;
using System.Linq;

abstract class Phone
{
    public abstract void InsertPhone(string name, string phone);
    public abstract void RemovePhone(string name);
    public abstract void UpdatePhone(string name, string newPhone);
    public abstract void SearchPhone(string name);
    public abstract void Sort();
}

class PhoneBook : Phone
{
    private List<string[]> PhoneList = new List<string[]>();

    public override void InsertPhone(string name, string phone)
    {
        bool isExist = false;

        foreach (var entry in PhoneList)
        {
            if (entry[0] == name)
            {
                isExist = true;
                if (entry.Contains(phone))
                {
                    Console.WriteLine($"Phone number {phone} already exists for {name}.");
                }
                else
                {
                    entry[1] += $", {phone}";
                }
                break;
            }
        }

        if (!isExist)
        {
            string[] newEntry = { name, phone };
            PhoneList.Add(newEntry);
        }
    }

    public override void RemovePhone(string name)
    {
        PhoneList.RemoveAll(entry => entry[0] == name);
    }

    public override void UpdatePhone(string name, string newPhone)
    {
        foreach (var entry in PhoneList)
        {
            if (entry[0] == name)
            {
                entry[1] = newPhone;
                break;
            }
        }
    }

    public override void SearchPhone(string name)
    {
        var result = PhoneList.FirstOrDefault(entry => entry[0] == name);

        if (result != null)
        {
            Console.WriteLine($"Name: {result[0]}, Phone: {result[1]}");
        }
        else
        {
            Console.WriteLine($"Name {name} not found.");
        }
    }

    public override void Sort()
    {
        PhoneList = PhoneList.OrderBy(entry => entry[0]).ToList();
    }

    public void DisplayPhoneBook()
    {
        foreach (var entry in PhoneList)
        {
            Console.WriteLine($"Name: {entry[0]}, Phone: {entry[1]}");
        }
    }
}

class Program
{
    static void Main()
    {
        PhoneBook phoneBook = new PhoneBook();

        phoneBook.InsertPhone("John Doe", "123456789");
        phoneBook.InsertPhone("Jane Doe", "987654321");
        phoneBook.InsertPhone("John Doe", "111222333");

        Console.WriteLine("Phone Book:");
        phoneBook.DisplayPhoneBook();

        phoneBook.RemovePhone("Jane Doe");

        Console.WriteLine("\nAfter removing Jane Doe:");
        phoneBook.DisplayPhoneBook();

        phoneBook.UpdatePhone("John Doe", "999000111");

        Console.WriteLine("\nAfter updating John Doe's phone number:");
        phoneBook.DisplayPhoneBook();

        Console.WriteLine("\nSearching for John Doe:");
        phoneBook.SearchPhone("John Doe");

        Console.WriteLine("\nSorting the phone book:");
        phoneBook.Sort();
        phoneBook.DisplayPhoneBook();
    }
}
