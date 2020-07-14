using System;
using System.Collections.Generic;
using System.Text;

namespace Git_Complete.src.entity.temp
{
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
