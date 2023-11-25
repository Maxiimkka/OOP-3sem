using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_4
{
    class Program
    {
        static void Main(string[] args)
        {
            My_Set.Date today = new My_Set.Date();
            Console.WriteLine($"Сегодня {today.time}\n");

            Owner inf = new Owner();
            Console.WriteLine($"\tИнформация о создателе:\n > ID: {inf.id}\n > NAME: {inf.name}\n > ORGANISATION: {inf.organization}\n\n");


            My_Set set = new My_Set(1, "MKI");
            Console.WriteLine("\t\tПЕРВОЕ МНОЖЕСТВО:\n");
            set.AddItem("Lara");
            set.AddItem("Nika");
            set.AddItem("Max");
            set.Show();

            My_Set set2 = new My_Set(2, "SNA");
            Console.WriteLine("\t\tВТОРОЕ МНОЖЕСТВО:\n");
            set2.AddItem("Olya");
            set2.AddItem("Gleb");
            set2.AddItem("Masha");
            set2.AddItem("Nastya");
            set2.AddItem("Mari");
            set2.AddItem("Eva");
            set2.AddItem("Max");
            set2.Show();

            My_Set set3 = new My_Set(3, "RAO");
            Console.WriteLine("\t\tТРЕТЬЕ МНОЖЕСТВО:\n");
            set3.AddItem("Nastya");
            set3.AddItem("Mari");
            set3.Show();

            My_Set set4 = new My_Set(4, "RSD");
            Console.WriteLine("\t\tЧЕТВЁРТОЕ МНОЖЕСТВО:\n");
            set4.AddItem("Kira");
            set4.AddItem("Nina");
            set4.AddItem("Leo");
            set4.Show();


            //--------- УДАЛЕНИЕ ЭЛЕМЕНТА ИЗ МНОЖЕСТВА ---------
            Console.WriteLine("--------- Перегрузка оператора - ---------");
            string name = "Mari";
            set3 = set3 - name;
            set3.Show();
            Console.WriteLine();


            //--------- ДОБАВЛЕНИЕ ЭЛЕМЕНТА ИЗ МНОЖЕСТВА ---------
            Console.WriteLine("--------- Перегрузка оператора + ---------");
            string name2 = "Kostya";
            set3 = set3 + name2;
            set3.Show();
            Console.WriteLine();


            //--------- ПЕРЕСЕЧЕНИЕ МНОЖЕСТВ ---------
            Console.WriteLine("--------- Перегрузка оператора % ------------");
            set2 = set2 % set;
            set2.Show();
            Console.WriteLine();


            //--------- ПРОВЕРКА НА ПОДМНОЖЕСТВО ---------
            Console.WriteLine("--------- Перегрузка оператора > ----------------");
            Console.WriteLine(set3 > set);
            Console.WriteLine();


            //--------- ПРОВЕРКА МНОЖЕСТВ НА НЕРАВЕНСТВО ---------
            Console.WriteLine("--------- Перегрузка оператора != ----------------");
            Console.WriteLine(set != set3);
            Console.WriteLine();


            //--------- ПРОВЕРКА МНОЖЕСТВ НА РАВЕНСТВО ---------
            Console.WriteLine("--------- Перегрузка оператора == ----------------");
            Console.WriteLine(set == set4);
            Console.WriteLine();




            string str = "1234567890";
            Console.WriteLine($">>>>> Поиск k-го элемента: ");
            StatisticOperation.K_Element(str, 10);


            string s = "Help, I lost myself again";
            StatisticOperation.Shortest_word(s);
            Console.WriteLine();


            Console.WriteLine();
            int r = set2.Dif();
            Console.WriteLine($">>>>> Разница между максимальным и минимальным элементами множества: {r} ");
            Console.WriteLine();


            string abc = "awdg rgrt rghol rgh jes";
            Console.WriteLine($">>>>> Количество слов в строке (_awdg rgrt rghol rgh jes_): {abc.CountOfWords()}\n");


            int r2 = set4.Sum();
            Console.WriteLine($">>>>> Сумма длин всех слов: {r2}");
            Console.WriteLine($"\tМножество элементов:");
            set4.Show();                                                                // Вывод элементов множества
            Console.WriteLine();

            Console.ReadLine();                                                          // Для отображения консоли
        }
    }
}