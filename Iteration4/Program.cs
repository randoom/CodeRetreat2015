using System;
using System.IO;
using Autofac;

namespace Iteration4
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            const string inputPath = "input.txt";
            const string outputPath = "output.txt";

            try
            {
                var allLines = File.ReadAllLines(inputPath);

                var container = Bootstraper.Initialise();
                var processor = container.Resolve<DnaFileProcessor>();

                allLines = processor.Process(allLines);

                File.WriteAllLines(outputPath, allLines);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                Console.ReadKey();
            }
        }
    }
}