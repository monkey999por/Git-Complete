﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Git_Complete.src.entity
{
    [Serializable]
    class GitCommandAndOptionsEntity
    {
        //gitのコマンドを保持
        public string gitCommand;

        //各gitコマンドで使用できるオプションを保持する
        public List<string> gitOptionList;

        public GitCommandAndOptionsEntity()
        {
            gitOptionList = new List<string>();
        }
        public GitCommandAndOptionsEntity(string gitCommand) : this()
        {
            this.gitCommand = gitCommand;
            
        }
    }
}
