using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace SI._02.SeekAndArchive
{
    public class SeakAndArchive
    {
        private List<FileInfo> _foundFiles = new List<FileInfo>();
        private readonly string _searchedFileName;
        private readonly string _dirPath;
        private readonly string _searchPattern;
        private readonly DirectoryInfo _workingDir;
        private readonly DirectoryInfo _tempDir;
        private List<FileSystemWatcher> _fileSystemWatchers = new List<FileSystemWatcher>();

        public SeakAndArchive(string searchedFileName, string dirPath)
        {
            _searchedFileName = searchedFileName;
            _dirPath = dirPath;
            _searchPattern = "*" + searchedFileName + "*";
            _workingDir = new DirectoryInfo(_dirPath);
            _tempDir = new DirectoryInfo(_workingDir.FullName + @"\..\temp");
        }

        public void List_foundFiles()
        {
            foreach (var file in _foundFiles)
            {
                Console.WriteLine(file.DirectoryName + @"\" + file.Name);
            }
        }

        public void Update_foundFiles()
        {
            if (_workingDir.Exists)
            {
                _foundFiles = new List<FileInfo>(_workingDir.GetFiles(_searchPattern, SearchOption.AllDirectories));
            }
        }

        private void UpdateFileWatchers()
        {
            foreach (var fsw in _fileSystemWatchers)
            {
                fsw.EnableRaisingEvents = false;
            }
            _fileSystemWatchers = new List<FileSystemWatcher>();
            for (int i = 0; i < _foundFiles.Count; i++)
            {
                var watcher = new FileSystemWatcher(_foundFiles[i].DirectoryName, _foundFiles[i].Name)
                {
                    NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite | NotifyFilters.FileName | NotifyFilters.DirectoryName
                };
                watcher.Changed += Watcher_Changed;
                watcher.Renamed += Watcher_Renamed;
                watcher.Deleted += Watcher_Deleted;
                watcher.Created += Watcher_Created;

                watcher.EnableRaisingEvents = true;

                _fileSystemWatchers.Add(watcher);
            }
        }

        private void Watcher_Created(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine($"File has been created: {e.FullPath}");
        }

        private void Watcher_Changed(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine($"File has been changed: {e.FullPath}");
        }

        private void Watcher_Deleted(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine($"File has been been deleted: {e.FullPath}");
        }

        private void Watcher_Renamed(object sender, RenamedEventArgs e)
        {
            Console.WriteLine($"File has been renamed: {e.FullPath}");
        }

        public void Run()
        {
            try
            {
                Update_foundFiles();
                List_foundFiles();

                Console.WriteLine("Press ESC to quit the program.");
                while (true)
                {
                    Thread.Sleep(1000);
                    Update_foundFiles();
                    UpdateFileWatchers();

                    if (Console.KeyAvailable && Console.ReadKey(true).Key == ConsoleKey.Escape) break;
                }
                Console.WriteLine();
            }
            catch (Exception e)
            {
                Console.WriteLine("The process failed: {0}", e.ToString());
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