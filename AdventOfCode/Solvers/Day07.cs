using AdventOfCode.Models;
using AdventOfCode.Utils;

namespace AdventOfCode.Solvers
{
    internal class Day07 : IDay
    {
        public static object PartOne(string input)
        {
            Directory root = GetDirectories(input);
            List<Directory>? directories = new();
            FlattenDirectories(root, directories);

            return directories.Where(d => d.GetTotalSize() <= 100000).Sum(d => d.GetTotalSize());
        }

        public static object PartTwo(string input)
        {
            Directory root = GetDirectories(input);
            int currentSpace = 70000000 - root.GetTotalSize();
            List<Directory>? directories = new();

            FlattenDirectories(root, directories);

            directories = directories.OrderBy(d => d.GetTotalSize()).ToList();

            return directories.First(x => x.GetTotalSize() + currentSpace > 30000000).GetTotalSize();
        }

        static void FlattenDirectories(Directory root, List<Directory> directories)
        {
            directories.Add(root);
            root.Subdirectories.ForEach(d => FlattenDirectories(d, directories));
        }


        static Directory FindParentDirectory(Directory root, Directory current)
        {
            foreach (Directory subdir in root.Subdirectories)
            {
                if (subdir == current)
                    return root;
                Directory parent = FindParentDirectory(subdir, current);
                if (parent != null)
                    return parent;
            }
            return null;
        }


        public static Directory GetDirectories(string input) 
        {
            Directory root = new("/");
            Directory currentDirectory = root;
            foreach (string line in input.GetLines())
            {
                if (line.StartsWith("$ cd"))
                {
                    if (line.StartsWith("$ cd /"))
                    {
                        currentDirectory = root;
                        continue;
                    }
                    if (line.StartsWith("$ cd .."))
                    {
                        if (currentDirectory != root)
                            currentDirectory = FindParentDirectory(root, currentDirectory);
                        continue;
                    }
                    string directoryName = line.Split("cd ")[1];
                    Directory? directory = currentDirectory.Subdirectories.FirstOrDefault(d => d.Name == directoryName);
                    if (directory == null)
                    {
                        directory = new(directoryName);
                        currentDirectory.Subdirectories.Add(directory);
                    }
                    currentDirectory = directory;
                }
                else if (line.StartsWith("$ ls"))
                {
                    continue;
                }
                else
                {
                    var parts = line.Split(" ");
                    if (parts.Length == 2)
                    {
                        if (!int.TryParse(parts[0], out int size))
                            continue;
                        currentDirectory.Files.Add(new File(parts[1], size));
                    }
                }
            }
            return root;
        }
    }
    class File
    {
        public string Name { get; set; }
        public int Size { get; set; }

        public File(string name, int size)
        {
            Name = name;
            Size = size;
        }
    }

    class Directory
    {
        public string Name { get; set; }
        public List<File> Files { get; set; }
        public List<Directory> Subdirectories { get; set; }

        public Directory(string name)
        {
            Name = name;
            Files = new List<File>();
            Subdirectories = new List<Directory>();
        }

        public int GetTotalSize()
        {
            return Files.Sum(f => f.Size) + Subdirectories.Sum(d => d.GetTotalSize());
        }
    }
}
