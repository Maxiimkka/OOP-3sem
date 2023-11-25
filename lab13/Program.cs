using System;
using System.Linq;
using System.Security.Cryptography;
using System.Xml;
using System.Xml.Linq;

namespace Laba_13
{
    public class Program
    {
        [Obsolete("Obsolete")]
        public static void Main()
        {
            var humanArray = new Human[2];
            humanArray[0] = new Human("Vasya", DateTime.Now, "man");
            humanArray[1] = new Human("Marta", DateTime.Now, "girl");

            CustomSerializer.Serialize("humanArray.bin", humanArray);
            CustomSerializer.Serialize("humanArray.xml", humanArray);
            CustomSerializer.Serialize("humanArray.json", humanArray);

            CustomSerializer.Deserialize("humanArray.bin");
            CustomSerializer.Deserialize("humanArray.xml");
            CustomSerializer.Deserialize("humanArray.json");

            var xDoc = new XmlDocument();
            xDoc.Load("humanArray.xml");
            var xRoot = xDoc.DocumentElement;

            Console.WriteLine("\n");
            var nodes = xRoot?.SelectNodes("Human");
            if (nodes != null)
            {
                foreach (XmlNode node in nodes)
                    Console.WriteLine(node.OuterXml);
            }

            Console.WriteLine("\n");

            nodes = xRoot?.SelectNodes("Human/Name");
            if (nodes != null)
            {
                foreach (XmlNode node in nodes)
                    Console.WriteLine(node.OuterXml);
            }

            var doc = XDocument.Load("humanArray.xml");
            var items = from item in doc.Element("ArrayOfHuman").Elements("Human")
                        where item.Element("Name").Value == "Marta"
                        select new Human(item.Element("Name").Value, DateTime.Now);

            foreach (var item in items)
            {
                Console.WriteLine(item);
            }
            Console.ReadLine();
        }
    }
}
