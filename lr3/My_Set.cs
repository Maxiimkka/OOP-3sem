using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lr3
{
    public class My_Set
    {
        private readonly Owner owner;
        public HashSet<String> collection;
        private readonly Date date;
        public int Size;

        public My_Set(int ownerId, string ownerFIO)
        {
            this.owner = new Owner(ownerId, ownerFIO);
            this.collection = new HashSet<string>();
            this.date = new Date();
        }

        public My_Set()
        {
        }

        public HashSet<string> GetHash()
        {
            return collection;
        }

        public void Show()                                           // Вывод множества
        {
            foreach (string item in collection)
            {
                Console.WriteLine(item);
            }
        }


        public int GetSize()                                        // Размер множества
        {
            int size = 0;
            foreach (string item in collection)
            {
                size++;
            }
            return size;
        }

        internal string[] Split(char v)
        {
            throw new NotImplementedException();
        }

        public void AddItem(string item)                            // Добавление элемента во множество
        {
            collection.Add(item);
        }


        public class Date                                           // Вложенный класс, содержащий дату
        {
            public readonly DateTime time;

            public Date()                                           // Конструктор
            {
                time = DateTime.Now;
            }
            public void ShowDate()                                  // Метод для вывода времени
            {
                Console.WriteLine(time);
            }
        }


        public string GetItemByIndex(int index)                     // Получение элемента множества по индексу
        {
            if (index > this.GetSize() - 1)
                throw new Exception("GetItemByIndex: OutOfRange");

            int size = -1;
            foreach (string item in collection)
            {
                size++;
                if (size == index)
                    return item;
            }
            return "";
        }


        public static My_Set operator -(My_Set set, string item)            // Удалить элемент из множества
        {
            Console.WriteLine("Удаление элемента из множества\n");
            set.collection.Remove(item);
            return set;
        }

        public static My_Set operator +(My_Set set, string item)            // Добавить элемент в множество 
        {
            Console.WriteLine("Добавление элемента в множество\n");
            set.collection.Add(item);
            return set;
        }


        public static bool operator >(My_Set set3, My_Set set2)              // Проверка на подмножество
        {
            Console.WriteLine("Проверка на подмножество\n");
            if (set3.collection.IsSubsetOf(set2.collection))
                return true;
            else
                return false;
        }


        public static bool operator <(My_Set set, My_Set set2)
        {
            Console.WriteLine("Проверка на подмножество\n");
            if (set.collection.IsSubsetOf(set2.collection))
                return false;
            else
                return true;
        }


        public static bool operator !=(My_Set set, My_Set set2)                 // Проверка на неравенство множеств
        {
            Console.WriteLine("Проверка множеств на неравенство\n");
            foreach (string item in set.collection)
            {
                Console.Write($"{item}\t");
            }
            Console.WriteLine();
            foreach (string item in set2.collection)
            {
                Console.Write($"{item}\t");
            }
            Console.WriteLine();

            int c = 0;
            foreach (string item in set.collection)
            {
                if (set2.collection.Contains(item))
                {
                    c++;
                }

            }
            if (c == set2.Size && c == set.Size)
            {
                return false;
            }
            else return true;
        }


        public static bool operator ==(My_Set set, My_Set set2)                     // Проверка на равенство множеств
        {
            Console.WriteLine("Проверка множеств на равенство\n");
            foreach (string item in set.collection)
            {
                Console.Write($"{item}\t");
            }
            Console.WriteLine();
            foreach (string item in set2.collection)
            {
                Console.Write($"{item}\t");
            }
            Console.WriteLine();

            int c = 0;
            foreach (string item in set.collection)
            {
                if (set2.collection.Contains(item))
                {
                    c++;
                }

            }
            if (c == set2.Size && c == set.Size)
            {
                return true;
            }
            else return false;
        }



        public static My_Set operator %(My_Set set, My_Set set2)           // Пересечение множеств
        {
            Console.WriteLine("Пересечение множеств\n");
            set.collection.IntersectWith(set2.collection);
            return set;
        }


        internal class Owner
        {
            private int ownerId;
            private string ownerFIO;

            public Owner()
            {
            }

            public Owner(int ownerId, string ownerFIO)
            {
                this.ownerId = ownerId;
                this.ownerFIO = ownerFIO;
            }
        }
    }
}