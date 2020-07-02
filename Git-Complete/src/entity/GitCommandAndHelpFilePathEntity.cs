using System;
using System.Collections.Generic;
using System.Text;

namespace Git_Complete.src.entity
{
    [Serializable]
    class GitCommandAndHelpFilePathEntity
    {
        //gitのコマンドを保持
        public string gitCommand;

        //gitコマンドヘルプファイルのフルパスを保持
        public string gitHelpFileFullPath;

        public GitCommandAndHelpFilePathEntity(string gitCommand, string gitHelpFileFullPath)
        {
            this.gitCommand = gitCommand;
            this.gitHelpFileFullPath = gitHelpFileFullPath;
        }

    }
}
