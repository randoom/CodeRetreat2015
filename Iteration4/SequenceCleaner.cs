using System.Collections.Generic;

namespace Iteration4
{
    internal class SequenceCleaner : ISequenceCleaner
    {
        public string Clean(string line)
        {
            var outputChars = new List<char>();
            for (var i = 0; i < line.Length; i++)
            {
                var c = line[i];
                if (this.IsADNChar(c))
                {
                    outputChars.Add(c);
                }
            }

            var result = string.Join("", outputChars);
            return result;
        }

        private bool IsADNChar(char c)
        {
            var adn = "ATGC";
            return adn.Contains(c.ToString());
        }
    }
}