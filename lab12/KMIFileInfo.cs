using Lab12;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab12
{
    public class KMIFileInfo
    {
        public static void GetFileInfo(string file)
        {
            Console.WriteLine("********************************");
            Console.WriteLine("GetFileInfo");
            var fileInfo = new FileInfo(file);
            if (!fileInfo.Exists)
            {
                System.Console.WriteLine("File Wasn't Found");
                return;
            }

            Console.WriteLine($"Path: {fileInfo.FullName}");
            Console.WriteLine($"Length: {fileInfo.Length} byte");
            Console.WriteLine($"Name: {fileInfo.Name}");
            Console.WriteLine($"Extension: {fileInfo.Extension}");
            Console.WriteLine($"Creation Time: {fileInfo.CreationTime}");
            Console.WriteLine("********************************\n");

            KMILog.WriteToLog("KMIFileInfo.GetFileInfo()", fileInfo.Name, fileInfo.FullName);

        }

    }
}