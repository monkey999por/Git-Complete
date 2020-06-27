using System;
using Git_Complete.src;
using Git_Complete.src.entity;
using System.Collections.Generic;

namespace Git_Complete
{
    class Entry
    {
        static async System.Threading.Tasks.Task Main(string[] args)
        {
            var gitHelpParser = new GitHelpParser();
            var gitEntityList = new List<GitCommandAndOptionsEntity>();

            //gitEnrityListにコマンドごとのインスタンスを入れ込む
            gitHelpParser.GetGitOptions(@"test", gitEntityList);

            
            //とりあえず目視確認用のテスト
            
            foreach (var gitEntity in gitEntityList)
            {
                Console.WriteLine("git command: " + gitEntity.gitCommand);
                foreach (var gitOption in gitEntity.gitOptionList)
                {
                    Console.WriteLine("  options: " + gitOption);
                }
                
            }        
        }
    }
}
