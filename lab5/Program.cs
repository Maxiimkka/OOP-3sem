using System;
using System.Collections.Generic;
using System.Linq;

// Перечисление для типов техники
enum TechType
{
    Printer,
    Scanner,
    Computer,
    Tablet
}

// Структура для хранения информации о технике
struct TechInfo
{
    public string Name;
    public double Price;
    public int YearOfManufacture;
    public TechType Type;

    public TechInfo(string name, double price, int yearOfManufacture, TechType type)
    {
        Name = name;
        Price = price;
        YearOfManufacture = yearOfManufacture;
        Type = type;
    }
}

// Класс-контейнер для хранения техники
class TechContainer
{
    private List<TechInfo> techList = new List<TechInfo>();

    public void AddTech(TechInfo tech)
    {
        techList.Add(tech);
    }

    public void RemoveTech(TechInfo tech)
    {
        techList.Remove(tech);
    }

    public void DisplayTechList()
    {
        foreach (var tech in techList)
        {
            Console.WriteLine($"Тип: {tech.Type}, Название: {tech.Name}, Цена: {tech.Price:C}, Год выпуска: {tech.YearOfManufacture}");
        }
    }

    public List<TechInfo> GetTechList()
    {
        return techList;
    }

    public List<TechInfo> FindTechOlderThan(int year)
    {
        return techList.Where(tech => tech.YearOfManufacture < year).ToList();
    }

    public Dictionary<TechType, int> CountTechByType()
    {
        var countByType = new Dictionary<TechType, int>();

        foreach (var tech in techList)
        {
            if (countByType.ContainsKey(tech.Type))
            {
                countByType[tech.Type]++;
            }
            else
            {
                countByType[tech.Type] = 1;
            }
        }

        return countByType;
    }

    public void DisplayTechByDescendingPrice()
    {
        var sortedTech = techList.OrderByDescending(tech => tech.Price);

        foreach (var tech in sortedTech)
        {
            Console.WriteLine($"Тип: {tech.Type}, Название: {tech.Name}, Цена: {tech.Price:C}, Год выпуска: {tech.YearOfManufacture}");
        }
    }
}

// Контроллер для управления контейнером
class TechController
{
    private TechContainer techContainer = new TechContainer();

    public void AddTech(TechInfo tech)
    {
        techContainer.AddTech(tech);
    }

    public void RemoveTech(TechInfo tech)
    {
        techContainer.RemoveTech(tech);
    }

    public void DisplayTechList()
    {
        techContainer.DisplayTechList();
    }

    public void DisplayTechOlderThan(int year)
    {
        var olderTech = techContainer.FindTechOlderThan(year);
        if (olderTech.Count > 0)
        {
            Console.WriteLine($"Техника старше {year} года:");
            foreach (var tech in olderTech)
            {
                Console.WriteLine($"Тип: {tech.Type}, Название: {tech.Name}, Год выпуска: {tech.YearOfManufacture}");
            }
        }
        else
        {
            Console.WriteLine($"Нет техники старше {year} года.");
        }
    }

    public void DisplayTechCountByType()
    {
        var countByType = techContainer.CountTechByType();
        foreach (var kvp in countByType)
        {
            Console.WriteLine($"Тип: {kvp.Key}, Количество: {kvp.Value}");
        }
    }

    public void DisplayTechByDescendingPrice()
    {
        techContainer.DisplayTechByDescendingPrice();
    }
}

class Program
{
    static void Main(string[] args)
    {
        TechController techController = new TechController();

        // Добавляем технику в контейнер
        techController.AddTech(new TechInfo("Принтер HP", 199.99, 2019, TechType.Printer));
        techController.AddTech(new TechInfo("Сканер Epson", 149.99, 2020, TechType.Scanner));
        techController.AddTech(new TechInfo("Ноутбук Dell", 799.99, 2018, TechType.Computer));
        techController.AddTech(new TechInfo("Планшет Samsung", 299.99, 2019, TechType.Tablet));

        Console.WriteLine("Список техники:");
        techController.DisplayTechList();

        int yearToCompare = 2019;
        techController.DisplayTechOlderThan(yearToCompare);

        Console.WriteLine("Количество техники по типам:");
        techController.DisplayTechCountByType();

        Console.WriteLine("Список техники в порядке убывания цены:");
        techController.DisplayTechByDescendingPrice();
        Console.ReadLine();
    }
}

