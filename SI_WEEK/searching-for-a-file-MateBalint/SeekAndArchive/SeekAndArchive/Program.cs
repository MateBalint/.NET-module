using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SeekAndArchive
{
    class Program
    {
        static void Main(string[] args)
        {
            string patterName = InputParameters.GetFileName();
            string directoryName = InputParameters.GetDirectoryName();
            Search.RecursiveFileSearch(directoryName, patterName);
        }
    }

    class InputParameters
    {
        internal static string GetFileName()
        {
            Console.WriteLine("Please enter the name of the file: ");
            string fileName = Console.ReadLine();
            return fileName;
        }

        internal static string GetDirectoryName()
        {
            Console.WriteLine("Please enter the name of the directory: ");
            string directoryName = Console.ReadLine();
            return directoryName;
        }
    }

    class Search
    {

        internal static void RecursiveFileSearch(string directoryName, string pattern)
        {
            string[] drives = System.Environment.GetLogicalDrives();
            DirectoryInfo di = new DirectoryInfo(directoryName);
            WalkDirectoryTree(di, pattern);

            Console.WriteLine("Press any key.");
            Console.ReadKey();
        }

        internal static void WalkDirectoryTree(DirectoryInfo rootDir, string pattern)
        {
            FileInfo[] files = null;

            try
            {
                files = rootDir.GetFiles(pattern);
            }
            catch (UnauthorizedAccessException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (System.IO.DirectoryNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }

            if (files != null)
            {
                foreach (var fileInfo in files)
                {
                    Console.WriteLine("\nThe file path of the requested file(s): {0}", fileInfo.FullName);
                }

                foreach (var subDir in rootDir.GetDirectories())

                {
                    WalkDirectoryTree(subDir, pattern);
                }
            }
        }
    }
    /*
    private void RecursiveTraversing(DirectoryInfo rootDir, string pattern)
    {

        FileInfo[] files = null;

        try
        {
            files = rootDir.GetFiles(pattern);
        }
        catch (UnauthorizedAccessException exception)
        {
            Console.WriteLine(exception.Message);
        }
        catch (DirectoryNotFoundException)
        {
            Console.WriteLine("Directory not found");
        }
        if (files != null)
        {
            foreach (var file in files)
            {
                FoundFiles.Add(file.FullName, file);
            }
            foreach (var subDir in rootDir.GetDirectories())
            {
                RecursiveTraversing(subDir, pattern);
            }
        }
        */
}