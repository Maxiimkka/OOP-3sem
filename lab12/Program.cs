using System;

namespace Lab12
{
    public class Program
    {
        public static void Main()
        {
           KMIDiskInfo.GetFreeDrivesSpace();
           
           KMIFileInfo.GetFileInfo(@"M:ооп\Lab12\nndlog.txt");
           
           KMIDirInfo.GetDirInfo(@"M:\ооп\Lab12");
           
           KMIFileManager.GetAllDirsAndFilesOfDisk(@"M:\");
           
           KMIFileManager.GetAllFilesWithExtension(@"M:\ооп\FoIS", ".txt");
           
           KMIFileManager.CreateZip(@"M:\ооп\Lab12\KMIInspect\KMIFiles");
           
           KMILog.SearchByDate(DateTime.Now);
        }
    }
}