using System.Collections.Generic;

namespace Git_Complete.src.entity
{
    public interface IECommandKeyList<T> where T : ECommandKey
    {
        List<T> Value { get; set; }

        void Add(T addObj);
        (int index, T eGitCommand) GetEntityByCommand(string keyCommand);
        List<T> GetEntityListByCommands(string[] keyCommands);
        void Swap(T swapObj);
    }
}