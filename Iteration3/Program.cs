using System;
using System.IO;
using Iteration3;

namespace Iteration1
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