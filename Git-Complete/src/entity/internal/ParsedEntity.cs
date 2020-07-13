using System;
using System.Collections.Generic;
using System.Text;

namespace Git_Complete.src.entity
{
    [Serializable]
    class ParsedEntity
    {
        //gitのコマンドを保持. primary key
        public string command;

        //各gitコマンドで使用できるSYNOPSISを保持する. 公式helpから取得した素の状態の解析あとの状態
        public List<string> parsedSynopsis = new List<string>();

        //各gitコマンドで使用できるオプションを保持する. 公式helpから取得した素の状態の解析あとの状態
        public List<string> parsedOptions = new List<string>();

        public ParsedEntity() { }
        public ParsedEntity(string command) : this()
        {
            this.command = command;
            
        }

    }
}
