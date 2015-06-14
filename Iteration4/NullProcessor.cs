using Iteration4.Commands;

namespace Iteration4
{
    internal class NullProcessor : ICommandProcessor
    {
        public string Process(string input)
        {
            return input;
        }
    }
}