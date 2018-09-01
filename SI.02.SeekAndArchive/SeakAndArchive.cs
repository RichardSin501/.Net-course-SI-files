using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace SI._02.SeekAndArchive
{
    public class SeakAndArchive
    {
        private readonly string _dirPath;
        private readonly string _searchPattern;
        private readonly DirectoryInfo _workingDir;

        public SeakAndArchive(string searchedFileName, string dirPath)
        {
            _dirPath = dirPath;
            _searchPattern = "*" + searchedFileName + "*";
            _workingDir = new DirectoryInfo(_dirPath);
        }

        private void AddFileSystemWatcher()
        {
            if (_workingDir.Exists)
            {
                FileSystemWatcher workingDirWatcher = new FileSystemWatcher(_dirPath, _searchPattern)
                {
                    NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite | NotifyFilters.FileName | NotifyFilters.DirectoryName
                };
                workingDirWatcher.IncludeSubdirectories = true;
                workingDirWatcher.Changed += _workingDirWatcher_EventHandler;
                workingDirWatcher.Created += _workingDirWatcher_EventHandler;
                workingDirWatcher.Renamed += _workingDirWatcher_EventHandler;
                workingDirWatcher.Deleted += _workingDirWatcher_EventHandler;
                workingDirWatcher.EnableRaisingEvents = true;
            }
            else
            {
                throw new FileNotFoundException("Directory not found.");
            }
        }

        private void _workingDirWatcher_EventHandler(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine("Change happened in the working directory.");
        }

        public void Run()
        {
            try
            {
                AddFileSystemWatcher();

                Console.WriteLine("Press ESC to quit the program.");
                while (true)
                {
                    Thread.Sleep(1000);

                    if (Console.KeyAvailable && Console.ReadKey(true).Key == ConsoleKey.Escape) break;
                }
                Console.WriteLine();
            }
            catch (Exception e)
            {
                Console.WriteLine("The process failed: {0}, {1}", e.ToString(), e.Message);
            }
        }

        private static void Main(string[] args)
        {
            if (args.Length != 2)
            {
                Console.WriteLine("Invalid args");
                return;
            }

            var seakAndArchive = new SeakAndArchive(args[0], args[1]);
            seakAndArchive.Run();
        }
    }
}