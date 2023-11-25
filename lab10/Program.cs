using System;
using System.Collections.Generic;
using System.Linq;

public class Abiturient
{
    public int ID { get; }
    public string LastName { get; set; }
    public string FirstName { get; set; }
    public string Patronymic { get; set; }
    public string Address { get; set; }
    public string PhoneNumber { get; set; }
    public int[] Grades { get; set; }

    public Abiturient(int id, string lastName, string firstName, string patronymic, string address, string phoneNumber, int[] grades)
    {
        ID = id;
        LastName = lastName;
        FirstName = firstName;
        Patronymic = patronymic;
        Address = address;
        PhoneNumber = phoneNumber;
        Grades = grades;
    }
}

public class Program
{
    public static void Main()
    {
        string[] months = { "June", "July", "May", "December", "January", "February", "March", "April", "August", "September", "October", "November" };

        // 1. Выбрать месяцы с длиной строки равной n
        int n = 5;
        var monthsWithLengthN = months.Where(m => m.Length == n);

        Console.WriteLine("1. Месяцы с длиной строки равной " + n + ":");
        foreach (var month in monthsWithLengthN)
        {
            Console.WriteLine(month);
        }
        Console.WriteLine();

        // 2. Выбрать только летние и зимние месяцы
        var summerAndWinterMonths = months.Where(m => m == "June" || m == "July" || m == "December" || m == "January" || m == "February");

        Console.WriteLine("2. Летние и зимние месяцы:");
        foreach (var month in summerAndWinterMonths)
        {
            Console.WriteLine(month);
        }
        Console.WriteLine();

        // 3. Вывести месяцы в алфавитном порядке
        var sortedMonths = months.OrderBy(m => m);

        Console.WriteLine("3. Месяцы в алфавитном порядке:");
        foreach (var month in sortedMonths)
        {
            Console.WriteLine(month);
        }
        Console.WriteLine();

        // 4. Выбрать месяцы, содержащие букву 'u' и длиной имени не менее 4
        var monthsWithU = months.Where(m => m.Contains("u") && m.Length >= 4);

        Console.WriteLine("4. Месяцы, содержащие 'u' и длиной не менее 4:");
        foreach (var month in monthsWithU)
        {
            Console.WriteLine(month);
        }
        Console.WriteLine();

        List<Abiturient> abiturients = new List<Abiturient>
        {
            new Abiturient(1, "Иванов", "Иван", "Иванович", "ул. Ленина, 123", "123-456-789", new int[] { 85, 90, 78 }),
            new Abiturient(2, "Петров", "Петр", "Петрович", "ул. Пушкина, 45", "987-654-321", new int[] { 92, 88, 75 }),
            new Abiturient(3, "Сидоров", "Сидор", "Сидорович", "ул. Гагарина, 67", "555-123-789", new int[] { 60, 45, 70 })
            // Добавьте еще абитуриентов
        };

        // Примеры запросов LINQ:

        // 1. Выбрать абитуриентов с суммой баллов выше заданной
        int minTotalScore = 240;
        var highTotalScoreAbiturients = abiturients.Where(a => a.Grades.Sum() > minTotalScore);

        Console.WriteLine("1. Абитуриенты с суммой баллов выше " + minTotalScore + ":");
        foreach (var abiturient in highTotalScoreAbiturients)
        {
            Console.WriteLine(abiturient.FirstName + " " + abiturient.LastName);
        }
        Console.WriteLine();

        // 2. Количество абитуриентов с оценкой 10 по определенному предмету
        int targetSubjectGrade = 10;
        var countAbiturientsWithMaxGrade = abiturients.Count(a => a.Grades.Any(g => g == targetSubjectGrade));

        Console.WriteLine("2. Количество абитуриентов с оценкой " + targetSubjectGrade + " по определенному предмету: " + countAbiturientsWithMaxGrade);
        Console.WriteLine();

        // 3. Абитуриенты, упорядоченные по алфавиту
        var sortedAbiturients = abiturients.OrderBy(a => a.LastName).ThenBy(a => a.FirstName);

        Console.WriteLine("3. Абитуриенты, упорядоченные по алфавиту:");
        foreach (var abiturient in sortedAbiturients)
        {
            Console.WriteLine(abiturient.FirstName + " " + abiturient.LastName);
        }
        Console.WriteLine();

        // 4. Четыре последних абитуриента с самой низкой успеваемостью
        var lastFourAbiturients = abiturients
            .OrderBy(a => a.Grades.Average())
            .Take(4);

        Console.WriteLine("4. Четыре последних абитуриента с самой низкой успеваемостью:");
        foreach (var abiturient in lastFourAbiturients)
        {
            Console.WriteLine(abiturient.FirstName + " " + abiturient.LastName);
        }
        Console.ReadLine();
    }
}
