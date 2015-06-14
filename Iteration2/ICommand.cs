using System;

namespace Iteration2
{
    public interface ICommand
    {
        bool CanProcess(string input);
        string Process(string input);
    }
}