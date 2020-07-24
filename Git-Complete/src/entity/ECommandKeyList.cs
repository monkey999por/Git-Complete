using Git_Complete.src.exception;
using Git_Complete.src.props;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Git_Complete.src.entity
{

    [Serializable]
    [DataContract]
    /// <inheritdoc/>
    public class ECommandKeyList<T> : IECommandKeyList<T> where T : ECommandKey
    {
        /// <inheritdoc/>
        [DataMember]
        public List<T> Value { get; set; }
        public ECommandKeyList() { }
        public ECommandKeyList(List<T> value)
        {
            this.Value = new List<T>((List<T>)value);
        }

        /// <inheritdoc/>
        public (int index, T eGitCommand) GetEntityByCommand(String keyCommand)
        {
            if (this.Value is null)
            {
                throw new Exception(nameof(this.Value) + ":" + typeof(T) + "がnullです");
            }

            var index = 0;
            foreach (var entity in this.Value)
            {
                if (entity.command.Equals(keyCommand))
                {
                    return (index, entity);
                }
                index++;
            }
            return (0, null);
        }

        /// <inheritdoc/>
        public List<T> GetEntityListByCommands(String[] keyCommands)
        {
            List<T> ret = new List<T>();
            foreach (var command in keyCommands)
                ret.Add(GetEntityByCommand(command).eGitCommand);

            return ret;
        }

        /// <inheritdoc/>
        public void Swap(T swapObj)
        {
            var (index, eGitCommand) = GetEntityByCommand(swapObj.command);
            if (eGitCommand is null)
                throw new ObjectProcessFailureException<T>("gitのコマンドではありません", eGitCommand);

            this.Value.RemoveAt(index);
            this.Value.Insert(index, swapObj);
        }

        /// <inheritdoc/>
        public void Add(T addObj)
        {
            //重複チェック
            if (GetEntityByCommand(addObj.command).eGitCommand != null)
            {
                throw new ObjectProcessFailureException<T>("コマンドが重複してます。", addObj);
            }

            this.Value.Add(addObj);
        }

    }
}
