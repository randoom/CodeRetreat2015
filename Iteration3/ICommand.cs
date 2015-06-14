using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iteration3
{
    public interface IParser
    {
        IProcess Create(string command);
    }

    class ReverseParser : IParser
    {
        public IProcess Create(string command)
        {
            if (command == "reverse")
            {
                return new ReverseProcessor();
            }
            else
            {
                return new NullProcessor();
            } 
        }
    }

    internal class NullProcessor : IProcess
    {
        public string Process(string input)
        {
            return input;
        }
    }

    public interface IProcess
    {

        string Process(string input);
    }

    class ReverseProcessor : IProcess
    {
        private readonly ISequenceFilter filter;
 
        public string Process(string input)
        {
            input = filter.Apply(input);
            var result = "";

            for (var i = 0; i < input.Length; i++)
            {
                result += input[input.Length - 1 - i];
            }

            return result;
        }
    }

    internal interface ISequenceFilter
    {
        string Apply(string input);
    }

    class SequenceFilter : ISequenceFilter
    {
        public string Apply(string input)
        {
            return input; // FAAAAAAKE
        }
    }
}
