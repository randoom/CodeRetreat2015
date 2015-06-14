using System;

namespace Iteration4.Commands
{
    public class InsertCommandParser : ICommandParser
    {
        private const string Command = "insert";
        private readonly ISequenceCleaner cleaner;

        public InsertCommandParser(ISequenceCleaner cleaner)
        {
            this.cleaner = cleaner;
        }

        public ICommandProcessor TryCreate(string command)
        {
            var commandLength = Command.Length;

            if (command.StartsWith(Command, StringComparison.InvariantCultureIgnoreCase) &&
                command.Length > commandLength + 1)
            {
                var secondSpaceIndex = command.IndexOf(" ", commandLength + 1, StringComparison.InvariantCulture);
                if (secondSpaceIndex >= 0)
                {
                    var sequenceToInsert = command.Substring(commandLength + 1, secondSpaceIndex - commandLength - 1).Trim();
                    var indexToInsertTo = int.Parse(command.Substring(secondSpaceIndex + 1, command.Length - secondSpaceIndex - 1).Trim());

                    sequenceToInsert = this.cleaner.Clean(sequenceToInsert);

                    var processor = new InsertCommandProcessor(sequenceToInsert, indexToInsertTo);
                    return processor;
                }
            }

            return new NullProcessor();
        }
    }
}