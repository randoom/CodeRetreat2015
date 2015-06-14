using System;
using System.Collections.Generic;
using System.IO;

namespace Iteration1
{
    public class FileProcessor
    {
        private bool mustReverse;
        private bool mustCount;
        private string sequenceToCount;
        private bool mustInsert;
        private string sequenceToInsert;
        private int indexToInsert;
        private bool mustComplete;

        public void Process(string inputPath, string outputPath)
        {
            using (var inputStream = new StreamReader(inputPath))
            {
                using (var outputStream = new StreamWriter(outputPath))
                {
                    string line = inputStream.ReadLine();

                    ParseCommands(line);

                    bool hasCommand = this.mustReverse || this.mustCount || this.mustInsert || this.mustComplete || this.mustTag;

                    if (hasCommand)
                    {
                        line = inputStream.ReadLine();
                    }

                    while (line != null)
                    {
                        line = ProcessLine(line);
                        outputStream.WriteLine(line);

                        line = inputStream.ReadLine();
                    }
                }
            }
        }

        private void ParseCommands(string line)
        {
            this.mustReverse = line == "reverse";

            if (line != null && line.StartsWith("count", StringComparison.InvariantCultureIgnoreCase) && line.Length > 6)
            {
                this.mustCount = true;
                this.sequenceToCount = line.Substring(6, line.Length - 6).Trim();

                this.sequenceToCount = Filter(this.sequenceToCount);
            }

            if (line != null && line.StartsWith("insert", StringComparison.InvariantCultureIgnoreCase) && line.Length > 7)
            {
                int ndSpace = line.IndexOf(" ", 7);
                if (ndSpace >= 0)
                {
                    this.sequenceToInsert = line.Substring(7, ndSpace - 7).Trim();
                    this.indexToInsert = int.Parse(line.Substring(ndSpace + 1, line.Length - ndSpace - 1).Trim());

                    this.sequenceToInsert = Filter(this.sequenceToInsert);

                    this.mustInsert = true;
                }
            }

            if (line != null && line.StartsWith("tag", StringComparison.InvariantCultureIgnoreCase) && line.Length > 4)
            {
                int ndSpace = line.IndexOf(" ", 4);
                if (ndSpace >= 0)
                {
                    this.tag = line.Substring(4, ndSpace - 4).Trim();
                    this.sequenceToTag = line.Substring(ndSpace + 1, line.Length - ndSpace - 1).Trim();

                    this.sequenceToTag = Filter(this.sequenceToTag);

                    this.mustTag = true;
                }
            }

            this.mustComplete = line == "complete";
        }

        private string ProcessLine(string line)
        {
            string result = Filter(line);

            if (this.mustReverse)
            {
                result = Reverse(result);
            }

            if (this.mustCount)
            {
                result = Count(result, this.sequenceToCount);
            }

            if (this.mustInsert)
            {
                result = Insert(result);
            }

            if (this.mustComplete)
            {
                result = Complete(result);
            }

            if (this.mustTag)
            {
                result = Tag(result);
            }

            return result;
        }

        private string Tag(string line)
        {
            int indexOf = line.IndexOf(this.sequenceToTag);
            if (indexOf >= 0)
            {
                var tagLine = new string(' ', indexOf);
                tagLine += "|" + this.tag;
                return line + Environment.NewLine + tagLine;
            }

            return line;
        }

        private readonly IDictionary<char, char> complements = new Dictionary<char, char>
        {
            {'G', 'C'},
            {'A', 'T'},
            {'T', 'A'},
            {'C', 'G'}
        };

        private string tag;
        private string sequenceToTag;
        private bool mustTag;

        private string Complete(string line)
        {
            var complement = "";

            for (var i = 0; i < line.Length; i++)
            {
                complement += this.complements[line[i]];
            }

            return line + Environment.NewLine + complement;
        }

        private string Insert(string result)
        {
            if (this.indexToInsert >= result.Length)
            {
                return result + this.sequenceToInsert;
            }

            if (this.indexToInsert <=0)
            {
                return this.sequenceToInsert + result;
            }

            string firstPart = result.Substring(0, this.indexToInsert - 1);
            string secondPart = result.Substring(this.indexToInsert - 1, result.Length - this.indexToInsert + 1);
            return firstPart + this.sequenceToInsert + secondPart;
        }

        private string Count(string result, string sequence)
        {
            var count = 0;
            var currentIndex = 0;

            int indexOf = result.IndexOf(sequence, currentIndex);
            while (indexOf >= 0)
            {
                count++;
                currentIndex = indexOf + 1;
                indexOf = result.IndexOf(sequence, currentIndex);
            }

            return count.ToString();
        }

        private string Filter(string line)
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

        private string Reverse(string input)
        {
            var result = "";

            for (var i = 0; i < input.Length; i++)
            {
                result += input[input.Length - 1 - i];
            }

            return result;
        }

        private bool IsADNChar(char c)
        {
            var adn = "ATGC";
            return adn.Contains(c.ToString());
        }
    }
}