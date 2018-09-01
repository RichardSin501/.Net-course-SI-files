// <copyright file="SeakAndArchive.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.IO;

namespace SI._02.SeekAndArchive
{
    public class SeakAndArchive
    {
        private readonly string _dirPath;
        private readonly string _searchPattern;
        private readonly DirectoryInfo _workingDir;
        private int _eventCounter = 0;

        public SeakAndArchive(string searchedFileName, string dirPath)
        {
            _dirPath = dirPath;
            _searchPattern = "*" + searchedFileName + "*";
            _workingDir = new DirectoryInfo(_dirPath);
        }

        public void ListFiles()
        {
            var searchedFilesInDirAndSubdirs = new List<FileInfo>(_workingDir.GetFiles(_searchPattern, SearchOption.AllDirectories));
            DrawLine();
            Console.WriteLine("Watched files:");
            foreach (var file in searchedFilesInDirAndSubdirs)
            {
                Console.WriteLine(file.DirectoryName + @"\" + file.Name);
            }
            DrawLine();
        }

        public void Run()
        {
            try
            {
                if (_workingDir.Exists)
                {
                    ListFiles();
                    AddFileSystemWatcher();

                    Console.WriteLine("Press ESC to quit the program.");
                    DrawLine();
                    while (true)
                    {
                        if (Console.KeyAvailable && Console.ReadKey(true).Key == ConsoleKey.Escape) break;
                    }
                    Console.WriteLine();
                }
                else
                {
                    throw new FileNotFoundException("Directory not found.");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"The process failed: {e.ToString()},\n {e.Message}");
            }
        }

        private void AddFileSystemWatcher()
        {
            FileSystemWatcher workingDirWatcher = new FileSystemWatcher(_dirPath, _searchPattern)
            {
                NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite | NotifyFilters.FileName | NotifyFilters.DirectoryName
            };
            workingDirWatcher.IncludeSubdirectories = true;
            workingDirWatcher.Changed += WorkingDirWatcher_EventHandler;
            workingDirWatcher.Created += WorkingDirWatcher_EventHandler;
            workingDirWatcher.Renamed += WorkingDirWatcher_EventHandler;
            workingDirWatcher.Deleted += WorkingDirWatcher_EventHandler;
            workingDirWatcher.EnableRaisingEvents = true;
        }

        private void WorkingDirWatcher_EventHandler(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine($"({++_eventCounter}.) {e.FullPath} {e.ChangeType.ToString().ToLower()}");
            ListFiles();
            Backup.BackupFile(Path.Combine(_workingDir.Parent.FullName + @"\Backups"), e.Name, e.FullPath);
        }

        private static void DrawLine()
        {
            Console.WriteLine("--------------------------------");
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