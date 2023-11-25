using System;
using System.IO;

namespace Lab12
{
    public class KMILog
    {
        public static StreamWriter Logfile;

        public static void WriteToLog(string action, string fileName = "", string path = "")
        {
            using (Logfile = new StreamWriter(@"M:\ооп\Lab12\kmilog.txt", true))
            {
                var time = DateTime.Now;
                Logfile.WriteLine("********************************\n");
                Logfile.WriteLine($"Action: {action}");

                if (!string.IsNullOrEmpty(fileName))
                    Logfile.WriteLine($"File Name: {fileName}");

                if (!string.IsNullOrEmpty(path))
                    Logfile.WriteLine($"Path: {path}");

                Logfile.WriteLine($"Date/Time: {time.ToLocalTime()}\n");
            }
        }

        public static void SearchByDate(DateTime date)
        {
            using (var reader = new StringReader(File.ReadAllText(@"M:\ооп\Lab12\kmilog.txt")))
            {
                var lines = reader.ReadToEnd().Split(new string[] { "********************************\n" }, StringSplitOptions.None);
                foreach (var line in lines)
                {
                    if (line.Contains(date.ToString()))
                    {
                        Console.WriteLine(line);
                    }
                }
            }
        }
    }
}
