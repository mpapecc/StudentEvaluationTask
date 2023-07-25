using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentEvaluationTask
{
    internal class SecondTask
    {
        public static int IdentationBySlashes(string path)
        {
            return path.Split(@"\").Length;
        }

        public static bool IsFile(string path)
        {
            return File.Exists(path);
        }

        public static bool IsDirectory(string path)
        {
            return Directory.Exists(path);
        }

        public static void PrintSubdirectoryTree(string root, string path)
        {
            IList<string> subdirectories = Directory.GetDirectories(path);
            IList<string> files = Directory.GetFiles(path);
            string relativePath = path.Replace(root, "");
            int identation = IdentationBySlashes(relativePath)+1;
            if (files.Count > 0)
            {
                foreach (var file in files)
                {
                    string name = file.Split(path).Last();
                    Console.WriteLine(new string('\t', identation) + identation + "." + name);
                }
            }
             
            if (subdirectories.Count > 0)
            {
                foreach (var directory in subdirectories)
                {
                    string name = directory.Split(path).Last();
                    subdirectories = Directory.GetDirectories(directory);
                    files = Directory.GetFiles(directory);
                    Console.WriteLine(new string('\t', identation) + identation + "." + name + $"[folders :{subdirectories.Count}][files : {files.Count}]");
                    PrintSubdirectoryTree(root, directory);
                }
            }

 
        }

        public static void Solution(string path)
        {
            if (path.EndsWith(@"\"))
            {
                path = path.Remove(path.Length - 1);
                Console.WriteLine(path);
            }

            if (IsFile(path))
            {
                Console.WriteLine(IdentationBySlashes(path.Replace(path, "")) + 1 + ". " + path.Split(@"\").Last());
                return;
            }

            if (IsDirectory(path))
            {
                IList<string> subdirectories = Directory.GetDirectories(path);
                IList<string> files = Directory.GetFiles(path);
                Console.WriteLine(IdentationBySlashes(path.Replace(path, "")) + ". " + path.Split(@"\").Last() + $"[folders :{subdirectories.Count}][files : {files.Count}]");
                PrintSubdirectoryTree(path, path);
            }
        }
    }
}
