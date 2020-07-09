using System;
using System.Collections.Generic;
using System.Text;

namespace Git_Complete.src.entity
{
    [Serializable]
    class GitCommandEntity
    {
        //gitのコマンドを保持. primary key
        public string command;

        //各gitコマンドで使用できるSYNOPSISを保持する
        public List<string> synopsis = new List<string>();


        //各gitコマンドで使用できるオプションを保持する
        public List<string> options = new List<string>();

        //各gitコマンドで使用できるオプションの説明を保持する
        public List<string> optionsDescription = new List<string>();


        public GitCommandEntity()
        {
            options = new List<string>();
        }
        public GitCommandEntity(string command) : this()
        {
            this.command = command;
            
        }

    }
}
