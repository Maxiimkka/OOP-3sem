using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Lab_4.Program;

namespace Lab_4
{
    static class StatisticOperation
    {
        public static int Max(this My_Set set)                         // Поиск максимального элемента множества
        {
            int len = set.GetItemByIndex(0).Length;
            foreach (string item in set.GetHash())
            {
                if (len < item.Length)
                    len = item.Length;
            }
            return len;
        }

        public static int Min(this My_Set set)                          // Поиск минимального элемента множества
        {
            int len = set.GetItemByIndex(0).Length;
            foreach (string item in set.GetHash())
            {
                if (len > item.Length)
                    len = item.Length;
            }
            return len;
        }

        public static int Dif(this My_Set set)                          // Разница между максимальным и минимальным элементами множества
        {
            return Max(set) - Min(set);
        }

        public static int CountOfWords(this string str)
        {
            int count = 0;
            string[] words = str.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            count += words.Length;
            return count;
        }

        public static int Sum(this My_Set set)                              // Сумма элементов некоторого множества
        {
            int len = 0;
            foreach (string item in set.GetHash())
            {
                len += item.Length;
            }
            return len;
        }


        public static void K_Element(this string str, int k)            // Поиск k-го элемента
        {

            for (int i = 0; i < str.Length; i++)
            {
                if (i == k - 1)
                {
                    Console.WriteLine(str[i]);
                    break;
                }
            }
        }


        public static void Shortest_word(this string str)               // Поиск самого короткого слова
        {
            string[] words = str.Split(' ');
            string word = "";
            int len = 99999;
            for (int i = 0; i < words.Length; i++)
            {
                if (words[i].Length < len)
                {
                    len = words[i].Length;
                    word = words[i];
                }
            }
            Console.WriteLine(str);
            Console.WriteLine($">>>>> Самое короткое слово в строке: {word}");
        }
    }
}