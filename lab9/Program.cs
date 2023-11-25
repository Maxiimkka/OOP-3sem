using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

class Student
{
    public string Name { get; set; }
    public int Age { get; set; }

    public Student(string name, int age)
    {
        Name = name;
        Age = age;
    }
}

class Program
{
    static void Main()
    {
        // Создаем наблюдаемую коллекцию
        ObservableCollection<Student> students = new ObservableCollection<Student>();

        // Регистрируем обработчик события CollectionChanged
        students.CollectionChanged += (sender, e) =>
        {
            Console.WriteLine("Collection Changed:");
            foreach (var student in students)
            {
                Console.WriteLine($"Name: {student.Name}, Age: {student.Age}");
            }
        };

        // Добавление элементов
        students.Add(new Student("Alice", 20));
        students.Add(new Student("Bob", 22));
        students.Add(new Student("Charlie", 25));

        // Удаление элемента
        students.RemoveAt(1);

        // Создание универсальной коллекции List<T> и заполнение данными
        List<int> numbers = Enumerable.Range(1, 10).ToList();
        List<int> anotherNumbers = new List<int>(numbers);

        // Вывод коллекции на консоль
        Console.WriteLine("Original Collection:");
        foreach (var number in numbers)
        {
            Console.WriteLine(number);
        }

        // Удаление n последовательных элементов
        int n = 3;
        numbers.RemoveRange(0, n);

        // Добавление других элементов
        numbers.AddRange(new[] { 11, 12, 13 });

        // Создание второй коллекции
        Dictionary<string, int> keyValuePairs = new Dictionary<string, int>();
        foreach (var number in anotherNumbers)
        {
            keyValuePairs.Add($"Key{number}", number);
        }

        // Вывод второй коллекции на консоль
        Console.WriteLine("\nSecond Collection (Dictionary):");
        foreach (var kvp in keyValuePairs)
        {
            Console.WriteLine($"{kvp.Key}: {kvp.Value}");
        }

        // Поиск значения во второй коллекции
        int searchValue = 7;
        if (keyValuePairs.ContainsValue(searchValue))
        {
            Console.WriteLine($"\nFound {searchValue} in the second collection.");
        }
        else
        {
            Console.WriteLine($"\n{searchValue} not found in the second collection.");
        }
        Console.ReadLine();
    }
}

