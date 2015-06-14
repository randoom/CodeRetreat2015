namespace Iteration4
{
    public interface ICommandParser
    {
        ICommandProcessor Create(string command);
    }
}