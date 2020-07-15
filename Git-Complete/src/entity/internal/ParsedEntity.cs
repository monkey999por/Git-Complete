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



        public ParsedEntity() { }
        public ParsedEntity(string command) : this()
        {
            this.command = command;
            
        }

    }
}
