using System;
using System.IO;
using System.IO.Compression;

namespace SI._02.SeekAndArchive
{
    internal static class Backup
    {
        public static void BackupFile(string backupDirPath, string fileName, string fileFullPath)
        {
            var backupFileName = $"Backup_{fileName.Replace(':', '_')}_{DateTime.UtcNow.ToString("hh.mm.ss.ffffff")}";
            var tempDirName = Path.Combine(backupDirPath, backupFileName);

            try
            {
                Directory.CreateDirectory(tempDirName);
                File.Copy(fileFullPath, Path.Combine(tempDirName, fileName));
                ZipFile.CreateFromDirectory(tempDirName, tempDirName + ".zip");
                Directory.Delete(tempDirName, true);
            }
            catch (Exception e)
            {
                Console.WriteLine($"The process failed: {e.ToString()},\n {e.Message}");
            }
        }
    }
}