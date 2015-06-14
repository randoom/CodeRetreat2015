using System.Collections.Generic;

namespace Iteration4
{
    class SequenceFilter : ISequenceFilter
    {
        public string Apply(string line)
        {
            var outputChars = new List<char>();
            for (var i = 0; i < line.Length; i++)
            {
                char c = line[i];
                if (IsADNChar(c))
                {
                    outputChars.Add(c);
                }
            }

            string result = string.Join("", outputChars);
            return result;
        }

        private bool IsADNChar(char c)
        {
            var adn = "ATGC";
            return adn.Contains(c.ToString());
        }
    }
}