using System.Collections.Generic;
using System.Linq;

namespace Iteration4
{
    public class DnaFileProcessor
    {
        private readonly IEnumerable<ICommandParser> parsers;
        private readonly ISequenceFilter sequenceFilter;

        private readonly IList<ICommandProcessor> commandProcessors = new List<ICommandProcessor>();

        public DnaFileProcessor(IEnumerable<ICommandParser> parsers, ISequenceFilter sequenceFilter)
        {
            this.parsers = parsers;
            this.sequenceFilter = sequenceFilter;
        }

        public string[] Process(string[] lines)
        {
            ParseCommands(lines);

            FilterSequences(lines);

            return lines;
        }

        private void FilterSequences(string[] lines)
        {
            for (var i = 0; i < lines.Length; i++)
            {
                lines[i] = this.sequenceFilter.Apply(lines[i]);
            }
        }

        private int ParseCommands(string[] lines)
        {
            for (var i = 0; i < lines.Length; i++)
            {
                ICommandProcessor commandProcessor = this.parsers.Select(p => p.Create(lines[i])).
                    FirstOrDefault(processor => !(processor is NullProcessor));

                if (commandProcessor != null)
                {
                    this.commandProcessors.Add(commandProcessor);
                }
                else
                {
                    return i;
                }
            }

            return lines.Length;
        }
    }
}