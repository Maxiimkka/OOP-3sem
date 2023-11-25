using System;

interface ICloneable
{
    bool DoClone();
}

abstract class Product : ICloneable
{
    public string Name { get; set; }
    public double Price { get; set; }

    public Product(string name, double price)
    {
        Name = name;
        Price = price;
    }

    public override string ToString()
    {
        return $"Товар: {Name}, Цена: {Price:C}";
    }

    public abstract bool DoClone();
}

class Printer : Product
{
    public string Type { get; set; }

    public Printer(string name, double price, string type) : base(name, price)
    {
        Type = type;
    }

    public override string ToString()
    {
        return $"Печатающее устройство: {Name}, Тип: {Type}, Цена: {Price:C}";
    }

    public override bool DoClone()
    {
        // Реализация клонирования для Printer
        Console.WriteLine("Производим клонирование принтера.");
        return true;
    }

    public void IAmPrinting(ICloneable obj)
    {
        Console.WriteLine(obj.ToString());
        obj.DoClone();
    }
}

class Scanner : Product
{
    public int Resolution { get; set; }

    public Scanner(string name, double price, int resolution) : base(name, price)
    {
        Resolution = resolution;
    }

    public override string ToString()
    {
        return $"Сканер: {Name}, Разрешение: {Resolution} dpi, Цена: {Price:C}";
    }

    public override bool DoClone()
    {
        // Реализация клонирования для Scanner
        Console.WriteLine("Производим клонирование сканера.");
        return false;
    }
}

sealed class Computer : Product
{
    public string Processor { get; set; }

    public Computer(string name, double price, string processor) : base(name, price)
    {
        Processor = processor;
    }

    public override string ToString()
    {
        return $"Компьютер: {Name}, Процессор: {Processor}, Цена: {Price:C}";
    }

    public override bool DoClone()
    {
        // Реализация клонирования для Computer
        Console.WriteLine("Производим клонирование компьютера.");
        return true;
    }
}

class Tablet : Product
{
    public string OS { get; set; }

    public Tablet(string name, double price, string os) : base(name, price)
    {
        OS = os;
    }

    public override string ToString()
    {
        return $"Планшет: {Name}, ОС: {OS}, Цена: {Price:C}";
    }

    public override bool DoClone()
    {
        // Реализация клонирование для Tablet
        Console.WriteLine("Производим клонирование планшета.");
        return false;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Printer printer = new Printer("Принтер HP", 199.99, "Лазерный");
        ICloneable product1 = new Scanner("Сканер Epson", 149.99, 1200);
        ICloneable product2 = new Computer("Ноутбук Dell", 799.99, "Intel Core i7");
        ICloneable product3 = new Tablet("Планшет Samsung", 299.99, "Android");

        Console.WriteLine("Используем метод IAmPrinting:");
        printer.IAmPrinting(product1);
        printer.IAmPrinting(product2);
        printer.IAmPrinting(product3);
        Console.ReadLine();

    }

}
