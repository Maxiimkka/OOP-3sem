using lr4;
using System;
using System.Threading.Tasks;

namespace Program
{
    class Program
    {
        static void Main(string[] argv)
        {
            Rose RedRose = new Rose("Необыкновенно красная");
            Bush Rasberry = new Bush("Малина");
            Tree Oak = new Tree("Дуб");
            Gladiolus Gladiolus = new Gladiolus("Гладиолус Лучезарный");
            Cactus Frailei = new Cactus("Фраили");

            ClassPaper Paper = new ClassPaper(Oak, TypePaper.INCAGE);
            Paper.Write("Всем привет. Эта бумага состоит из дуба. ");
            Console.WriteLine($"Вот что написано на бумаге: {Paper}\n\n");

            ClassBouquet Bouquet = new ClassBouquet();

            ((IPlant)RedRose).Plant();
            ((IPlant)Rasberry).Plant();
            ((IPlant)Oak).Plant();
            ((IPlant)Gladiolus).Plant();
            ((IPlant)Frailei).Plant();

            Console.WriteLine("\n\n----------Ждем, пока не вырастет-----------\n\n");

            ExpectToGrow(RedRose, Gladiolus, Rasberry, Paper.MadeFrom, Frailei);

            Bouquet.AddFlower(Gladiolus);
            Bouquet.AddFlower(RedRose);

            Console.WriteLine("\n\n----------Printer-----------\n\n");

            Printer Printer = new Printer();
            var Plants = new APlant[]
            {
                RedRose,
                Rasberry,
                Paper.MadeFrom,
                Gladiolus,
                Frailei,
            };

            foreach (var El in Plants)
            {
                Printer.IAmPrinting(El);
            }

            Console.WriteLine("\n\n-----------------Букет состоит из:\n");
            Parallel.ForEach(Bouquet.AllFlowerIn, El => Console.WriteLine(El.ToString()));
        }

        private static void ExpectToGrow(params APlant[] Plants)
        {
            bool areGrowed = false;
            bool treeReady = false;
            bool bushReady = false;
            bool cactusReady = false;
            bool roseReady = false;

            while (!areGrowed)
            {
                areGrowed = true;

                foreach (APlant plant in Plants)
                {
                    if (plant is Tree tree && tree.IsGrow() && !treeReady)
                    {
                        Console.WriteLine($"{tree.Type} {tree.Name} is ripen");
                        areGrowed = false;
                        treeReady = true;
                    }
                    else if (plant is Bush bush && bush.IsGrow() && !bushReady)
                    {
                        Console.WriteLine($"{bush.Type} {bush.Name} is ripen");
                        areGrowed = false;
                        bushReady = true;
                    }
                    else if (plant is Cactus cactus && cactus.IsGrow() && !cactusReady)
                    {
                        Console.WriteLine($"{cactus.Type} {cactus.Name} is ripen");
                        areGrowed = false;
                        cactusReady = true;
                    }
                    else if (plant is Rose rose && rose.IsGrow() && !roseReady)
                    {
                        Console.WriteLine($"{rose.Type} {rose.Name} is ripen");
                        areGrowed = false;
                        roseReady = true;
                    }
                    else if (!roseReady || !cactusReady || !treeReady || !bushReady)
                    {
                        areGrowed = false;
                    }
                }
            }
        }
    }
}
