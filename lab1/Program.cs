using System;
using System.Linq;
using System.Text;

namespace Lab_2
{
    class Program
    {
        static void Main(string[] args)
        {
            //--------------------ТИПЫ------------------------------------
            a_types();
            //-------------------СТРОКИ-----------------------------------
            b_str();
            //-------------------МАССИВЫ----------------------------------
            с_arr();
            //-------------------КОРТЕЖИ----------------------------------
            d_cort();
            //------------------ЛОКАЛЬНАЯ ФУНКЦИЯ-------------------------
            e_func();
            Console.ReadLine();
        }


        //--------------------ТИПЫ------------------------------------

        static void a_types()
        {
            //	Определение переменных всех возможных примитивных типов и инициализация их: 
            int a1 = 2;
            uint a2 = 1;
            double a3 = 7.467576;
            bool a4 = true;
            char a5 = 'u';
            string a6 = "Hello!";
            decimal a7 = 8.9m;
            float f8 = 5.8F;
            byte a9 = 68;
            sbyte a10 = 120;
            short a11 = 10;
            ushort a12 = 4;
            long a13 = 5689;
            ulong a14 = 3;



            //	Ввод и вывод их значений, используя консоль:
            Console.WriteLine("\tint = {0}, \tuint = {1}, \tdouble = {2}, \tbool = {3}, \tchar = {4}" +
                "\n\tstring = {5}, \tdecimal = {6}, \tfloat = {7}, \tbyte = {8}, \tsbyte = {9}" +
                "\n\tshort = {10}, \tushort = {11}, \tlong = {12}, \tulong = {13}",
                a1, a2, a3, a4, a5, a6, a7, f8, a9, a10, a11, a12, a13, a14);
            Console.WriteLine();




            //	5 операций неявного приведения (преобразованием меньше по размеру типа данных в больший: char -> int -> long -> float -> double):

            Console.WriteLine("\t\tНЕЯВНОЕ ПРЕОБРАЗОВАНИЕ");

            char znach = 'W';
            int cnum = znach;    // char в int
            Console.Write(znach + " -> ");
            Console.WriteLine(cnum);

            byte a = 4;
            ushort b = a; // byte в short
            Console.Write(a + " -> ");
            Console.WriteLine(b);

            int q = 66;
            long d = q;     // int в long
            Console.Write(q + " -> ");
            Console.WriteLine(d);

            int num = 5;
            double dnum = num;   // int в double
            Console.Write(num + " -> ");
            Console.WriteLine(dnum);

            char k = '*';
            long k2 = k;    // char в long
            Console.Write(k + " -> ");
            Console.WriteLine(k2);




            //	5 операций явного приведения (преобразование большего типа в меньший: double -> float -> long -> int -> char):

            Console.WriteLine("\t\tЯВНОЕ ПРЕОБРАЗОВАНИЕ");

            double dnum1 = 5.234;
            int inum = (int)dnum1;    // double в int
            Console.Write(dnum1 + " -> ");
            Console.WriteLine(inum);

            long l1 = 6747;
            int l2 = (int)l1;         // long в int
            Console.Write(l1 + " -> ");
            Console.WriteLine(l2);

            float fa = 1245.67F;
            int fb = (int)dnum1;      // float в int
            Console.Write(dnum1 + " -> ");
            Console.WriteLine(inum);

            double ds = 134.5634;
            long s = (long)ds;         // double в long
            Console.Write(ds + " -> ");
            Console.WriteLine(s);

            long laq = 24;
            char lw = (char)laq;        // long в char
            Console.Write(laq + " -> ");
            Console.WriteLine(lw);
            Console.WriteLine();

            double dper = 621.42;       //	Явное с использованием класса Convert
            int iper = Convert.ToInt32(dper);
            Console.Write(dper + " -> ");
            Console.WriteLine(iper);

            float hei = 346.6789F;
            int height = Convert.ToInt32(hei);
            Console.Write(hei + " -> ");
            Console.WriteLine(height);
            Console.WriteLine();



            //	Упаковка и распаковка значимых типов:
            Object BoxInt = a1;
            int UnboxInt = (int)BoxInt;



            //	Неявная типизация:
            var flprm = 4.3F;
            Console.WriteLine($"\nНеявная типизация переменной = {flprm}");
            Console.WriteLine(flprm.GetType()); //Знаковый тип данных
            Console.WriteLine();



            //	Nullable-переменная:
            /* указав знак вопроса (?) после имени типа, при объявлении переменной, тип значений сможет принимать null */
            int? ia = null;
            Console.WriteLine($"\nNullable int = {ia}");
            double? db = null;
            Console.WriteLine($"\nNullable double = {db}");
            bool? bc = null;
            Console.WriteLine($"\nNullable bool = {bc}");
            Console.WriteLine();



            //	Определите переменную типа var и присвойте ей любое значение. Затем следующей инструкцией присвойте ей значение другого типа:
            //var my = 29;
            //my = 6D;
            //Console.WriteLine($"{my}");
        }

        //-------------------СТРОКИ-----------------------------------
        static void b_str()
        {
            //	Объявление строковых литералов:
            Console.WriteLine();
            var str_1 = "My";
            var str_2 = "first";
            var str_3 = "string";
            var str_4 = "!!!";


            //	Их сравнение: 
            int res = String.Compare(str_1, str_2);
            if (res == 0)
                Console.WriteLine($"Строка {str_1} равна {str_2}");         // false
            else
                Console.WriteLine($"Строка {str_1} не равна {str_2}");      // true
            Console.WriteLine();


            /*	Создайте три строки на основе String. Выполните: сцепление, копирование, выделение подстроки, разделение строки на слова, 
     вставки подстроки в заданную позицию, удаление заданной подстроки. */

            Console.WriteLine();
            string str1 = "Hello world:)";
            string str2 = "This is C# language";
            string str3 = "Nice to meet you!";

            str1 += str2;                       // сцепление (то же самое: str1=str1+str2)

            string str4 = str1;                 // копирование
            Console.WriteLine(str4);

            string word = str1.Substring(0, 5); // выделение подстроки и её копирование
            Console.WriteLine(word);

            string[] words = str2.Split();      // разделение строки на слова
            Console.WriteLine(words[3]);        // output: language

            // вставка в определенную позицию
            string message = "Hello, ";
            string name = "Kristina";
            // Insert(pos, str);
            Console.WriteLine(message.Insert(message.Length, name));

            // удаление
            string question = "Object-oriented programming language";
            question.Remove(0, 16);             // output: programming language

            Console.WriteLine($"Hello, {name}! {str3}");  //интерполирование строк



            /* Создайте пустую и null строку. Продемонстрируйте использование метода string.IsNullOrEmpty */

            string firstname = null;
            string lastname = "";


            /* простейший пример использования isNullOrEmpty ((Это удобный метод, 
			позволяющий одновременно проверить, является ли String null - значение значением или String.Empty)) */


            if (String.IsNullOrEmpty(firstname) || String.IsNullOrEmpty(lastname))
            {
                Console.WriteLine("\nОбе строки равны null или пустые!");
            }
            else
            {
                Console.WriteLine("\nОдна из строк не null или не пустая!");
            }


            /* Создайте строку на основе StringBuilder. Удалите определенные позиции и добавьте новые символы в начало и конец строки */

            StringBuilder STR = new StringBuilder("watermelon melon peach ");
            STR.Insert(0, "Pineapple ");
            STR.Remove(15, 5);
            STR.Append("apple.");
            Console.WriteLine("\n" + STR);
        }

        //-------------------МАССИВЫ----------------------------------
        static void с_arr()
        {
            /* Создайте целый двумерный массив и выведите его на консоль в отформатированном виде (матрица) */

            Console.Write("\n");
            int[,] array = { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write($"{array[i, j]}\t");
                }
                Console.Write("\n");
            }


            /* Создайте одномерный массив строк. Выведите на консоль его содержимое, длину массива. Поменяйте произвольный элемент 
			(пользователь определяет позицию и значение) */

            Console.WriteLine();
            string[] str_array = { "Hello! ", "My name is", "Kris" };
            Console.WriteLine("Содержание массива: ");
            for (int i = 0; i < str_array.Length; i++)
                Console.WriteLine($"[{i}]. {str_array[i]}");

            Console.WriteLine("Выберите номер строки, которую хотите заменить: ");
            int a = System.Convert.ToInt32(Console.ReadLine());

            if (a < str_array.Length)
            {
                Console.WriteLine("Напишите предложение: ");
                string answer = Console.ReadLine();
                str_array[a] = answer;
                for (int i = 0; i < str_array.Length; i++)
                    Console.WriteLine($"[{i}]. {str_array[i]}");
            }
            else Console.WriteLine("Вы ввели неправильное число :(");
            Console.WriteLine();


            /* Создайте ступечатый (не выровненный) массив вещественных чисел с 3-мя строками, в каждой из которых 2, 3 и 4 столбцов соответственно. 
			 Значения массива введите с консоли. */

            Console.WriteLine();
            int arraySize = 4;
            int[][] array_2 = new int[arraySize][];

            for (int i = 0; i < arraySize; i++)
            {
                array_2[i] = new int[i + 1];
                Console.WriteLine($"заполните массив {i} из {arraySize - 1}");
                for (int j = 0; j < array_2[i].Length; j++)
                {
                    array_2[i][j] = Convert.ToInt32(Console.ReadLine());
                }
            }

            for (int i = 0; i < arraySize; i++)
            {
                for (int j = 0; j < array_2[i].Length; j++)
                {
                    Console.Write($"{array_2[i][j]}\t");
                }
                Console.Write("\n");
            }

            /* Создайте неявно типизированные переменные для хранения массива и строки */

            Console.WriteLine();
            var ntArr = new int[] { 1, 2, 3, 4 };
            var ntStr = "Неявно типизированная строка";
            Console.WriteLine("\n" + ntStr);
        }

        //-------------------КОРТЕЖИ----------------------------------
        static void d_cort()
        {
            //Кортежи - обобщение нескольких элементов в структуру с упрощенным синтаксисом
            // Задайте кортеж из 5 элементов с типами int, string, char, string, ulong:

            (int, string, char, string, ulong) Cortege = (18, "Кристина", 'Ж', "Миневич", 680388);
            Console.WriteLine("\n\t-> И Н Ф О Р М А Ц И Я <- \t");
            Console.WriteLine("Возраст:         " + Cortege.Item1);
            Console.WriteLine("Имя:             " + Cortege.Item2);
            Console.WriteLine("Пол:             " + Cortege.Item3);
            Console.WriteLine("Фамилия:         " + Cortege.Item4);
            Console.WriteLine("Дом. телефон:    " + Cortege.Item5);


            // Частичный вывод:
            Console.WriteLine("\n" + Cortege.Item1 + " " + Cortege.Item2 + " " + Cortege.Item3 + " " + Cortege.Item4 + " " + Cortege.Item5 + " ");


            //	Выполните распаковку кортежа в переменные:
            (var a, var b) = (35, "12345");
            Console.WriteLine("\n" + a + " " + b);


            //	Сравните два кортежа:
            (int o, byte k) One = (3, 56);
            (long l, uint d) Two = (3, 56);
            Console.WriteLine(One == Two);
        }

        //------------------ЛОКАЛЬНАЯ ФУНКЦИЯ-------------------------
        static void e_func()
        {
            /* Формальные параметры функции – массив целых и строка. Функция должна вернуть кортеж, содержащий: 
			максимальный и минимальный элементы массива, сумму элементов массива и первую букву строки */

            void function(int[] arr, string s)
            {
                int max, min, sum;
                char frstchr;
                max = arr.Max<int>();
                min = arr.Min<int>();
                sum = arr.Sum();
                frstchr = s[0];
                var T = Tuple.Create(max, min, sum, frstchr);       //	Создает новый объект кортежа
                Console.WriteLine(T);
            }
            string strF = "Program";
            int[] arrF = { 0, 1, 2, 3, 4 };
            function(arrF, strF);


            //	Работа с checked/unchecked:

            void first1()
            {
                checked
                {
                    int ai = 2147483647;
                    Console.WriteLine(ai + 1);
                    Console.ReadLine();
                }
            }
            void second2()
            {
                unchecked
                {
                    int ai2 = 2147483647;
                    Console.WriteLine(ai2 + 1);
                     Console.ReadLine();
                }
            }
            first1();
            second2();
            
        }
    }
}
/*выражение будет проверяться на переполнение, 
 * следует использовать ключевое слово checked, а если требуется проигнорировать переполнение — 
 * ключевое слово unchecked. В последнем случае результат усекается, чтобы не выйти за пределы диапазона 
 * представления чисел для целевого типа выражения.*/