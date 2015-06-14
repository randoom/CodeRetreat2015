namespace Iteration4
{
    public interface ICommandParser
    {
        ICommandProcessor TryCreate(string command);
    }
}