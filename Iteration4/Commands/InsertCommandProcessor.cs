using System;

namespace Iteration4.Commands
{
    class InsertCommandProcessor : ICommandProcessor
    {
        private readonly string sequence;
        private readonly int index;

        public InsertCommandProcessor(string sequence, int index)
        {
            this.sequence = sequence;
            this.index = index;
        }

        public string Process(string input)
        {
            if (this.index >= input.Length)
            {
                return input + this.sequence;
            }

            if (this.index <= 0)
            {
                return this.sequence + input;
            }

            string firstPart = input.Substring(0, this.index - 1);
            string secondPart = input.Substring(this.index - 1, input.Length - this.index + 1);
            return firstPart + this.sequence + secondPart;
        }
    }
}