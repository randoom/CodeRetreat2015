namespace Iteration4.Commands
{
    public interface ICommandParser
    {
        ICommandProcessor TryCreate(string command);
    }
}