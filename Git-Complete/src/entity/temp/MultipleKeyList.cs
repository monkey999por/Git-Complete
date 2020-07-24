using System;
using System.Collections.Generic;

namespace Git_Complete.src.entity.temp
{
    /// <summary>
    /// 複数キーの<see cref="Dictionary{TKey, TValue}"/>を再現するためのクラス
    /// 下記のように利用する
    /// 
    /// <code>
    /// List<MultipleKeyList<string>> m = new List<MultipleKeyList<string>>("key", new List<string>());
    /// </code>
    /// </summary>
    /// <typeparam name="T">value</typeparam>
    [Serializable]
    class MultipleKeyList<T>
    {
        public string key;

        public List<T> list = new List<T>();

        public MultipleKeyList() { }
        public MultipleKeyList(string key, List<T> list) : this()
        {
            this.key = key;
            this.list = list;
        }
    }
}
