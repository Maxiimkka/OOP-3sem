using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

// Обобщенный интерфейс для коллекции
public interface ICollection<T>
{
    void Add(T item);
    void Remove(T item);
    void Display();
}

// Обобщенный класс CollectionType<T>
public class CollectionType<T> : ICollection<T> where T: class
{
    private List<T> collection = new List<T>();

    public void Add(T item)
    {
        collection.Add(item);
    }

    public void Remove(T item)
    {
        collection.Remove(item);
    }

    public void Display()
    {
        foreach (T item in collection)
        {
            Console.WriteLine(item);
        }
    }

    // Метод для сохранения коллекции в JSON-файл
    public void SaveToFile(string filePath)
    {
        string jsonData = JsonConvert.SerializeObject(collection);
        File.WriteAllText(filePath, jsonData);
    }

    // Метод для загрузки коллекции из JSON-файла
    public void LoadFromFile(string filePath)
    {
        if (File.Exists(filePath))
        {
            string jsonData = File.ReadAllText(filePath);
            collection = JsonConvert.DeserializeObject<List<T>>(jsonData);
        }
        else
        {
            Console.WriteLine("Файл не существует.");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Пример использования обобщенной коллекции с разными типами данных
        CollectionType<int> intCollection = new CollectionType<int>();
        intCollection.Add(42);
        intCollection.Add(123);
        intCollection.Add(999);

        CollectionType<string> stringCollection = new CollectionType<string>();
        stringCollection.Add("Hello");
        stringCollection.Add("World");
        stringCollection.Add("C#");

        intCollection.Remove(42);

        // Вывод данных
        Console.WriteLine("Содержимое коллекции intCollection:");
        intCollection.Display();
        Console.WriteLine("\nСодержимое коллекции stringCollection:");
        stringCollection.Display();

        // Сохранение и загрузка коллекции
        string intCollectionFile = "intCollection.json";
        string stringCollectionFile = "stringCollection.json";

        intCollection.SaveToFile(intCollectionFile);
        stringCollection.SaveToFile(stringCollectionFile);

        CollectionType<int> loadedIntCollection = new CollectionType<int>();
        loadedIntCollection.LoadFromFile(intCollectionFile);

        CollectionType<string> loadedStringCollection = new CollectionType<string>();
        loadedStringCollection.LoadFromFile(stringCollectionFile);

        Console.WriteLine("\nСодержимое загруженной коллекции loadedIntCollection:");
        loadedIntCollection.Display();

        Console.WriteLine("\nСодержимое загруженной коллекции loadedStringCollection:");
        loadedStringCollection.Display();
        Console.ReadLine();
    }
}
