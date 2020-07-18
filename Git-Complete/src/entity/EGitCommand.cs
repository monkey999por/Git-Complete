using System;
using System.Collections.Generic;
using System.Text;

namespace Git_Complete.src.entity
{

    class EGitCommandList 
    {
        //主にgitの公式ヘルプからスクレイピングした素のオプションやシナプスを保持
        public List<EGitCommand> eHelpScrape = new List<EGitCommand>();

    }


    [Serializable]
    class EGitCommand {
        //gitのコマンドを保持. primary key
        public string command;

        //各gitコマンドで使用できるSYNOPSISを保持する. 公式helpから取得した素の状態
        public List<string> synopsis = new List<string>();

        //各gitコマンドで使用できるオプションを保持する. 公式helpから取得した素の状態
        public List<string> options = new List<string>();

        //各gitコマンドで使用できるオプションの説明を保持する
        public List<string> optionsDescription = new List<string>();
    }


    [Serializable]
    class EHelpScrape : EGitCommand
    {
        public EHelpScrape() { }
        public EHelpScrape(string command) : this()
        {
            this.command = command;
        }
    }

    [Serializable]
    class EParsedHelpScrape :EGitCommand
    {
        public EParsedHelpScrape() { }
        public EParsedHelpScrape(string command) : this()
        {
            this.command = command;
        }
    }



}
