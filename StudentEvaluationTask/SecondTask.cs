using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

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

        public static (int folders, int files) PrintSubdirectoryTree(string root, string path)
        {

            IList<string> subdirectories = Directory.GetDirectories(path);
            IList<string> files = Directory.GetFiles(path);
            (int folders, int files) counters = (subdirectories.Count, files.Count);

            string relativePath = path.Replace(root, "");
            int identation = IdentationBySlashes(relativePath);

            if (subdirectories.Count > 0)
            {
                foreach (var directory in subdirectories)
                {
                    string name = directory.Split(path).Last().Remove(0, 1);
                    subdirectories = Directory.GetDirectories(directory);
                    files = Directory.GetFiles(directory);
                    var tuple = PrintSubdirectoryTree(root, directory);
                    counters.folders += tuple.folders;
                    counters.files += tuple.files;
                }
            }

            Console.WriteLine(new string('\t', identation) + identation + "." + path + $"[folders :{counters.folders}][files : {counters.files}]");


            if (files.Count > 0)
            {
                foreach (var file in files)
                {
                    string name = file.Split(path).Last().Remove(0,1);
                    Console.WriteLine(new string('\t', identation) + identation + "." + name);
                }
            }
            return counters;
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
                Console.WriteLine(IdentationBySlashes(path.Replace(path, "")) -1 + ". " + path.Split(@"\").Last());
                return;
            }

            if (IsDirectory(path))
            {
                IList<string> subdirectories = Directory.GetDirectories(path);
                IList<string> files = Directory.GetFiles(path);
                Console.WriteLine(IdentationBySlashes(path.Replace(path, ""))-1 + ". " + path.Split(@"\").Last() + $"[folders :{subdirectories.Count}][files : {files.Count}]");
                PrintSubdirectoryTree(path, path);
            }
        }
    }
}
