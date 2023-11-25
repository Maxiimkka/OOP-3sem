using System;
using System.IO;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;

public static class Reflector
{
    // Метод для записи информации о классе в файл
    public static void WriteClassInfoToFile(string className, string outputPath)
    {
        Type type = Type.GetType(className);

        if (type != null)
        {
            using (StreamWriter writer = new StreamWriter(outputPath))
            {
                // a. Определение имени сборки
                writer.WriteLine($"Сборка, в которой определен класс: {type.Assembly.FullName}");

                // b. Проверка на наличие публичных конструкторов
                ConstructorInfo[] constructors = type.GetConstructors();
                if (constructors.Any())
                {
                    writer.WriteLine("Публичные конструкторы:");
                    foreach (ConstructorInfo constructor in constructors)
                    {
                        writer.WriteLine($"- {constructor}");
                    }
                }
                else
                {
                    writer.WriteLine("Класс не имеет публичных конструкторов.");
                }

                // c. Извлечение всех общедоступных публичных методов
                writer.WriteLine("Общедоступные публичные методы:");
                MethodInfo[] methods = type.GetMethods(BindingFlags.Public | BindingFlags.Instance);
                foreach (MethodInfo method in methods)
                {
                    writer.WriteLine($"- {method}");
                }

                // d. Получение информации о полях и свойствах
                writer.WriteLine("Поля и свойства класса:");
                FieldInfo[] fields = type.GetFields(BindingFlags.Public | BindingFlags.Instance);
                PropertyInfo[] properties = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);
                foreach (FieldInfo field in fields)
                {
                    writer.WriteLine($"- Поле: {field}");
                }
                foreach (PropertyInfo property in properties)
                {
                    writer.WriteLine($"- Свойство: {property}");
                }

                // e. Получение всех реализованных интерфейсов
                writer.WriteLine("Реализованные интерфейсы:");
                Type[] interfaces = type.GetInterfaces();
                foreach (Type iface in interfaces)
                {
                    writer.WriteLine($"- {iface}");
                }
            }
        }
        else
        {
            Console.WriteLine("Класс с указанным именем не найден.");
        }
    }

    // f. Метод для вывода методов, которые содержат заданный тип параметра
    public static void GetMethodsWithParameterType(string className, Type parameterType)
    {
        Type type = Type.GetType(className);

        if (type != null)
        {
            MethodInfo[] methods = type.GetMethods(BindingFlags.Public | BindingFlags.Instance)
                .Where(method => method.GetParameters().Any(param => param.ParameterType == parameterType))
                .ToArray();

            if (methods.Length > 0)
            {
                Console.WriteLine($"Методы класса {className}, которые содержат параметр типа {parameterType}:");
                foreach (MethodInfo method in methods)
                {
                    Console.WriteLine($"- {method}");
                }
            }
            else
            {
                Console.WriteLine($"В классе {className} не найдено методов, содержащих параметр типа {parameterType}.");
            }
        }
        else
        {
            Console.WriteLine("Класс с указанным именем не найден.");
        }
    }

    // g. Метод для вызова метода класса
    public static object InvokeMethod(string className, string methodName, object instance, object[] parameters)
    {
        Type type = Type.GetType(className);

        if (type != null)
        {
            MethodInfo method = type.GetMethod(methodName);

            if (method != null)
            {
                return method.Invoke(instance, parameters);
            }
            else
            {
                Console.WriteLine($"Метод {methodName} не найден в классе {className}.");
            }
        }
        else
        {
            Console.WriteLine("Класс с указанным именем не найден.");
        }

        return null;
    }

    // 2. Обобщенный метод для создания объекта указанного типа
    public static T Create<T>()
    {
        Type type = typeof(T);

        ConstructorInfo[] constructors = type.GetConstructors();

        if (constructors.Length == 0)
        {
            Console.WriteLine("Указанный тип не имеет публичных конструкторов.");
            return default(T);
        }

        // Выбираем первый попавшийся конструктор
        ConstructorInfo constructor = constructors[0];
        ParameterInfo[] parameters = constructor.GetParameters();
        List<object> args = new List<object>();

        foreach (ParameterInfo param in parameters)
        {
            // Генерируем значения по умолчанию для параметров конструктора
            object arg = param.ParameterType.IsValueType ? Activator.CreateInstance(param.ParameterType) : null;
            args.Add(arg);
        }

        return (T)constructor.Invoke(args.ToArray());
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Пример 1: Исследование классов
        Reflector.WriteClassInfoToFile("System.String", "StringInfo.txt");
        Reflector.WriteClassInfoToFile("System.Console", "ConsoleInfo.txt");

        // Пример 2: Поиск методов с параметром типа int
        Reflector.GetMethodsWithParameterType("System.String", typeof(int));

        // Пример 3: Вызов метода класса
        string input = "Hello, World!";
        int length = (int)Reflector.InvokeMethod("System.String", "get_Length", input, null);
        Console.WriteLine($"Длина строки: {length}");

        // Пример 4: Создание объекта класса с обобщенным методом
        List<int> list = Reflector.Create<List<int>>();
        Console.WriteLine("Создан объект типа List<int>.");
    }
}
