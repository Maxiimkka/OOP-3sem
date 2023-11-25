using System;
using System.Linq;

public partial class Abiturient
{
    private static int totalAbiturients = 0; // статическое поле для подсчета созданных абитуриентов
    private static int idCounter = 0; // Добавляем счетчик для генерации уникальных ID
    public int ID { get; } // Свойство ID теперь только для чтения
    private string lastName;
    private string firstName;
    private string patronymic;
    private string address;
    private string phoneNumber;
    private int[] grades;

    public Abiturient()
    {
        ID = ++idCounter; // Увеличиваем счетчик при создании нового объекта 
        totalAbiturients++; // увеличиваем счетчик созданных абитуриентов
        totalObjects++; // Увеличиваем счетчик созданных объектов
    }

    public Abiturient(string lastName, string firstName, string patronymic, string address, string phoneNumber, int[] grades)
        : this()
    {
        // конструктор с параметрами, также вызывает конструктор по умолчанию
        this.lastName = lastName;
        this.firstName = firstName;
        this.patronymic = patronymic;
        this.address = address;
        this.phoneNumber = phoneNumber;
        this.grades = grades;
    }

    public Abiturient(string lastName, string firstName, string address)
        : this(lastName, firstName, "", address, "", new int[0])
    {
        // конструктор с параметрами и параметрами по умолчанию
    }

    // закрытый конструктор
    private Abiturient(int id)
    {
        ID = id; // устанавливаем уникальный ID
    }

    // поле-константа
    private const int MaxGradeValue = 100;

    public static int TotalAbiturients { get { return totalAbiturients; } } // статическое свойство для доступа к счетчику

    public string LastName
    {
        get { return lastName; }
        set { lastName = value; }
    }

    public string FirstName
    {
        get { return firstName; }
        set { firstName = value; }
    }

    public string Patronymic
    {
        get { return patronymic; }
        set { patronymic = value; }
    }

    public string Address
    {
        get { return address; }
        set { address = value; }
    }

    public string PhoneNumber
    { // Ограниченный доступ по set для PhoneNumber
        get { return phoneNumber; }
        private set { phoneNumber = value; }
    }

    public int[] Grades
    {
        get { return grades; }
        set { grades = value; }
    }

    public double AverageGrade()
    {
        if (grades.Length == 0)
            return 0;

        return grades.Average();
    }

    public int MaxGrade()
    {
        if (grades.Length == 0)
            return 0;

        return grades.Max();
    }

    public int MinGrade()
    {
        if (grades.Length == 0)
            return 0;

        return grades.Min();
    }

    // Переопределение метода Equals для сравнения объектов
    public override bool Equals(object obj)
    {
        if (obj == null || GetType() != obj.GetType())
        {
            return false;
        }

        Abiturient other = (Abiturient)obj;
        return ID == other.ID;
    }

    // Переопределение метода GetHashCode для вычисления хэш-кода
    public override int GetHashCode()
    {
        return ID;
    }

    // Переопределение метода ToString для вывода информации об объекте
    public override string ToString()
    {
        return $"ID: {ID}, Фамилия: {LastName}, Имя: {FirstName}, Отчество: {Patronymic}, Адрес: {Address}, Телефон: {PhoneNumber}, Средний балл: {AverageGrade()}";
    }
    // Статический метод для вывода информации о классе Abiturient
    public static void DisplayClassInfo()
    {
        Console.WriteLine("Информация о классе Abiturient:");
        Console.WriteLine($"Всего создано абитуриентов: {TotalAbiturients}");
    }
    // Статические методы для фильтрации абитуриентов по оценкам
    public static Abiturient[] FilterByLowGrades(Abiturient[] abiturients, int minGrade)
    {
        return abiturients.Where(a => a.grades.Any(g => g < minGrade)).ToArray();
    }

    public static Abiturient[] FilterByTotalScore(Abiturient[] abiturients, int minTotalScore)
    {
        return abiturients.Where(a => a.grades.Sum() > minTotalScore).ToArray();
    }

    public static void PrintClassInfo()
    {
        Console.WriteLine("Информация о классе Abiturient:");
        Console.WriteLine($"Всего создано абитуриентов: {TotalAbiturients}");
    }
    // Статический метод для создания массива абитуриентов
    public static Abiturient[] CreateAbiturientsArray()
    {
        Abiturient[] abiturients = new Abiturient[]
        {
            new Abiturient("Соловей","Руслан","Петрович", "ул. Ленина, 123", "123-456-789", new int[] { 85, 90, 78 }),
            new Abiturient("Парфенов", "Данила", "Иванович", "ул. Пушкина, 45", "987-654-321", new int[] { 92, 88, 75 }),
            new Abiturient("Шикунец", "Максим", "Сидорович", "ул. Гагарина, 67", "555-123-789", new int[] { 60, 45, 70 })
        }; 
        return abiturients;
    }
    // Статический метод для обновления оценок абитуриента
    public static void UpdateGrades(ref Abiturient abiturient, int[] newGrades, out double newAverageGrade)
    {
        abiturient.Grades = newGrades; //изменяем оценки абитуриента на новые
        newAverageGrade = abiturient.AverageGrade();// вычисляем средний балл
    }

    // статическое поле, хранящее количество созданных объектов
    private static int totalObjects = 0;

    // статический метод вывода информации о классе
    public static void PrintClassStatistics()
    {
        Console.WriteLine("Статистика класса Abiturient:");
        Console.WriteLine($"Всего создано абитуриентов: {TotalAbiturients}");
        Console.WriteLine($"Всего создано объектов: {totalObjects}");
    }
}

public partial class Abiturient
{
    // создание класса partial

    public static void Main(string[] args)
    {
        // Создаем несколько абитуриентов
        Abiturient[] abiturients = CreateAbiturientsArray(); // Создание нескольких объектов

        // Вывод информации о каждом абитуриенте
        foreach (var abiturient in abiturients)
        {
            Console.WriteLine(abiturient.ToString());
        }

        // Вывод информации о классе Abiturient
        Abiturient.PrintClassInfo(); // Вызов метода для вывода информации о классе

        // Фильтрация абитуриентов с неудовлетворительными оценками (балл < 60)
        Abiturient[] lowGradesAbiturients = Abiturient.FilterByLowGrades(abiturients, 60); //Вызов метода для фильтрации
        Console.WriteLine("Список абитуриентов с неудовлетворительными оценками:");
        foreach (var abiturient in lowGradesAbiturients)
        {
            Console.WriteLine(abiturient.ToString());
        }

        // Фильтрация абитуриентов с суммой баллов выше 250
        Abiturient[] highTotalScoreAbiturients = Abiturient.FilterByTotalScore(abiturients, 250); // Вызов метода для фильтрации
        Console.WriteLine("Список абитуриентов с суммой баллов выше 250:");
        foreach (var abiturient in highTotalScoreAbiturients)
        {
            Console.WriteLine(abiturient.ToString());
        }

        // Создание нового абитуриента и обновление его оценок
        Abiturient newAbiturient = new Abiturient("Новиков", "Новик", "Новикович", "ул. Новая, 1", "111-222-333", new int[] { 70, 75, 80 });
        int[] newGrades = { 85, 90, 95 };
        double newAverageGrade;
        Abiturient.UpdateGrades(ref newAbiturient, newGrades, out newAverageGrade); // Использование ref и out параметров
        Console.WriteLine("Обновленные оценки:");
        foreach (var grade in newAbiturient.Grades)
        {
            Console.Write(grade + " ");
        }
        Console.WriteLine("\nНовый средний балл: " + newAverageGrade);

        // переопределение методов класса Object
        Abiturient abiturient1 = new Abiturient("Иванов", "Иван", "Петрович", "ул. Ленина, 123", "123-456-789", new int[] { 85, 90, 78 });
        Abiturient abiturient2 = new Abiturient("Петров", "Петр", "Иванович", "ул. Пушкина, 45", "987-654-321", new int[] { 92, 88, 75 });
        Console.WriteLine("Сравнение двух абитуриентов:");
        Console.WriteLine($"abiturient1.Equals(abiturient2): {abiturient1.Equals(abiturient2)}"); // Вызов метода Equals

        // создание и вывод анонимного типа
        var anonymousAbiturient = new
        {
            LastName = "Анонимный",
            FirstName = "Абитуриент",
            AverageGrade = 85.5
        };
        Console.WriteLine("\nАнонимный абитуриент:");
        Console.WriteLine($"Фамилия: {anonymousAbiturient.LastName}, Имя: {anonymousAbiturient.FirstName}, Средний балл: {anonymousAbiturient.AverageGrade}");

        // вывод статистики класса Abiturient
        Abiturient.PrintClassStatistics();
        Console.ReadLine();
    }
}
