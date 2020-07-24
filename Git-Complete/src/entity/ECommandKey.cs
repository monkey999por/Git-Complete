using System;
using System.Runtime.Serialization;

namespace Git_Complete.src.entity
{
    /// <summary>
    /// <see cref="ECommandKeyList{T}"/>のジェネリックで使用するためのクラス
    /// 本処理では上記以外の方法で直接使用することはない想定。
    ///（デバッグコード等での一時的な使用はあるが、正規の使い方ではない） 
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
