using System;
using System.IO;

namespace Iteration4
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var inputPath = "input.txt";
            var outputPath = "output.txt";
            
            try
            {
                string[] allLines = File.ReadAllLines(inputPath);

                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                Console.ReadKey();
            }
        }
    }
}