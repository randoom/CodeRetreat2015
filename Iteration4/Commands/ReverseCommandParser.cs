namespace Iteration4.Commands
{
    internal class ReverseCommandParser : ICommandParser
    {
        public ICommandProcessor TryCreate(string command)
        {
            if (command == "reverse")
            {
                return new ReverseCommandProcessor();
            }
            return new NullProcessor();
        }
    }
}