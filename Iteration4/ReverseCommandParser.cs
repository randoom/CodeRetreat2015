namespace Iteration4
{
    internal class ReverseCommandParser : ICommandParser
    {
        private readonly ISequenceCleaner cleaner;

        public ReverseCommandParser(ISequenceCleaner cleaner)
        {
            this.cleaner = cleaner;
        }

        public ICommandProcessor TryCreate(string command)
        {
            if (command == "reverse")
            {
                return new ReverseProcessor();
            }
            return new NullProcessor();
        }
    }
}