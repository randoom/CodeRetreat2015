using System.Collections.Generic;
using System.Linq;
using Iteration4.Commands;

namespace Iteration4
{
    public class DnaFileProcessor
    {
        private readonly IEnumerable<ICommandParser> parsers;
        private readonly ISequenceCleaner sequenceCleaner;

        private readonly IList<ICommandProcessor> commandProcessors = new List<ICommandProcessor>();

        public DnaFileProcessor(IEnumerable<ICommandParser> parsers, ISequenceCleaner sequenceCleaner)
        {
            this.parsers = parsers;
            this.sequenceCleaner = sequenceCleaner;
        }

        public string[] Process(string[] lines)
        {
            var firstSequenceIndex = this.ParseCommands(lines);

            this.CleanSequences(lines, firstSequenceIndex);

            lines = this.ProcessCommands(lines, firstSequenceIndex);

            return lines;
        }

        private string[] ProcessCommands(string[] lines, int firstSequenceIndex)
        {
            IList<string> result = new List<string>();

            for (var i = firstSequenceIndex; i < lines.Length; i++)
            {
                var line = lines[i];
                foreach (var processor in this.commandProcessors)
                {
                    line = processor.Process(line);
                }
                result.Add(line);
            }

            return result.ToArray();
        }

        private void CleanSequences(string[] lines, int firstSequenceIndex)
        {
            for (var i = firstSequenceIndex; i < lines.Length; i++)
            {
                lines[i] = this.sequenceCleaner.Clean(lines[i]);
            }
        }

        private int ParseCommands(string[] lines)
        {
            for (var i = 0; i < lines.Length; i++)
            {
                var commandProcessor = this.parsers.Select(p => p.TryCreate(lines[i])).
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