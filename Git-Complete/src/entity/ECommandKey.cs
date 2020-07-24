using System;
using System.Runtime.Serialization;

namespace Git_Complete.src.entity
{
    /// <summary>
    /// <see cref="ECommandKeyList{T}"/>のジェネリックで使用するためのクラス
    /// </summary>
    [Serializable]
    public abstract class ECommandKey
    {
        //gitのコマンドを保持. primary key
#nullable enable
        [DataMember]
        public string? command;
    }
}
