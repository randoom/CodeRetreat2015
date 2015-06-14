namespace Iteration4.Commands
{
    class ReverseCommandProcessor : ICommandProcessor
    {
        public string Process(string input)
        {
            var result = "";

            for (var i = 0; i < input.Length; i++)
            {
                result += input[input.Length - 1 - i];
            }

            return result;
        }
    }
}