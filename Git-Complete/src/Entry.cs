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
            //gitのヘルプファイルパスとコマンド名を持ったentityを作成する
            var gitMetaInfoParser = new GitMetaInfoParser();
            List<GitCommandAndHelpFilePathEntity> helpEntityList = gitMetaInfoParser.CreatGitCommandAndHelpFilePathEntity();

            /*
            //test
            if (helpEntityList is null)
            {
                Console.WriteLine("null: " + nameof(helpEntityList));
            }
            else
            {
                foreach (var helpEntity in helpEntityList)
                {
                    Console.WriteLine("コマンド名" + helpEntity.gitCommand);
                    Console.WriteLine("ファイル名" + helpEntity.gitHelpFileFullPath);
                    Console.WriteLine();

                }
            }
            */

            var gitHelpParser = new GitHelpParser();
            var entityList = new List<GitCommandAndOptionsEntity>();

            //gitEnrityListにコマンドごとのインスタンスを入れ込む
            await gitHelpParser.GetGitOptions(helpEntityList, entityList);

            //とりあえず目視確認用のテスト
            foreach (var gitEntity in entityList)
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
