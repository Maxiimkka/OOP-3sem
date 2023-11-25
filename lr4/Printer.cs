using lr4;
using System;

namespace lr4;
class Printer
{
    public void IAmPrinting(APlant Plant)
    {
        if (Plant is Tree tree)
        {
            Console.WriteLine(
                $"Тип данных: класс Tree\n" +
                $"{tree.ToString()}\n"
                );
        }
        else if (Plant is Bush bush)
        {
            Console.WriteLine(
                $"Тип данных: класс Bush\n" +
                $"{bush.ToString()}\n"
                );
        }
        else if (Plant is Cactus cactus)
        {
            Console.WriteLine(
                $"Тип данных: класс Cactus\n" +
                $"{cactus.ToString()}\n"
                );
        }
        else if (Plant is Rose rose)
        {
            Console.WriteLine(
                $"Тип данных: класс Rose\n" +
                $"{rose.ToString()}\n"
                );
        }
    }
}