using Lab12;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab12
{
    public class KMIFileManager
    {
        public static void GetAllDirsAndFilesOfDisk(string diskName)
        {
            var allDrives = DriveInfo.GetDrives();
            if (allDrives.Any(drive => drive.Name == diskName))
            {
                var dir = new DirectoryInfo(@"M:\ооп\Lab12");
                if (dir.GetDirectories("KMIInspect").Length == 0)
                {
                    var subDir = dir.CreateSubdirectory("KMIInspect");
                    var dr = new DirectoryInfo(diskName);
                    using (var file = new StreamWriter(subDir.FullName + @"\" + "KMIDirInfo.txt"))
                    {
                        file.WriteLine("----------Directory----------");
                        foreach (var d in dr.GetDirectories())
                            file.WriteLine($"{d.Name}");
                        file.WriteLine("-------------------------------");

                        file.WriteLine("----------Files----------");
                        foreach (var d in dr.GetFiles())
                            file.WriteLine($"{d.Name}");
                        file.WriteLine("-------------------------");
                    }
                    var dirInfo = new FileInfo(subDir.FullName + @"\" + "KMIDirInfo.txt");
                    dirInfo.CopyTo(subDir.FullName + @"\" + "KMIDirInfoCOPY.txt");
                    dirInfo.Delete();
                }
            }

            KMILog.WriteToLog("KMIFileManager.GetAllDirsAndFilesOfDisk()", "", diskName);
        }

        public static void GetAllFilesWithExtension(string dirPath, string extension)
        {
            var directory = new DirectoryInfo(dirPath);
            if (directory.Exists)
            {
                var temp = new DirectoryInfo(@"M:\ооп\Lab12");
                if (temp.GetDirectories("KMIInspect")[0].GetDirectories("KMIFiles").Length == 0)
                {
                    var files = temp.CreateSubdirectory("KMIFiles");

                    foreach (var file in directory.GetFiles($"*{extension}"))
                        file.CopyTo(files.FullName + @"\" + file.Name);

                    files.MoveTo(temp.GetDirectories("KMIInspect")[0].FullName + "\\KMIFiles");
                }
            }

            KMILog.WriteToLog("KMIFileManager.GetAllFilesWithExtension()", "", dirPath);
        }

        public static void CreateZip(string dir)
        {
            const string zipName = @"M:\ооп\Lab12\KMIInspect\KMIFiles.zip";
            if (new DirectoryInfo(@"M:\ооп\Lab12\KMIInspect").GetFiles("*.zip").Length == 0)
            {
                ZipFile.CreateFromDirectory(dir, zipName);
                var direct = new DirectoryInfo(dir);
                foreach (var innerFile in direct.GetFiles())
                    innerFile.Delete();
                direct.Delete();
                ZipFile.ExtractToDirectory(zipName, dir);
            }

            KMILog.WriteToLog("KMIFileManager.CreateZip()", "", dir);
        }
    }
}