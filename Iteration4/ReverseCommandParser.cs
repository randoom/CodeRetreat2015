namespace Iteration4
{
    internal class ReverseCommandParser : ICommandParser
    {
        private readonly ISequenceFilter filter;

        public ReverseCommandParser(ISequenceFilter filter)
        {
            this.filter = filter;
        }

        public ICommandProcessor Create(string command)
        {
            if (command == "reverse")
            {
                return new ReverseProcessor();
            }
            return new NullProcessor();
        }
    }
}