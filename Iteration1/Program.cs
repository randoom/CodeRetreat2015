using System;

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
                var fileProcessor = new FileProcessor();
                fileProcessor.Process(inputPath, outputPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                Console.ReadKey();
            }
        }
    }
}