using System;
using Git_Complete.src;
using Git_Complete.src.entity;
using System.Collections.Generic;
using Git_Complete.src.common;
using System.Text;
using System.IO;

namespace Git_Complete
{
    class Entry
    {
        static async System.Threading.Tasks.Task Main(string[] args)
        {
            //gitのヘルプファイルパスとコマンド名を持ったentityを作成する
            var gitMetaInfoParser = new GitMetaInfoParser();
            List<GitCommandAndHelpFilePathEntity> helpEntityList = gitMetaInfoParser.CreatGitCommandAndHelpFilePathEntity();

            //xml出力
            var fileCommon = new FileCommon();
            fileCommon.OutFileFrom<List<GitCommandAndHelpFilePathEntity>>(helpEntityList, @"C:\develop\Project_Git-Complete\Git-Complete\out\git_help.xml");




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
            var entityListOut = new List<GitCommandAndOptionsEntity>();

            //gitEnrityListにコマンドごとのインスタンスを入れ込む
            await gitHelpParser.GetGitOptions(helpEntityList, entityListOut);

            //xml出力
            fileCommon.OutFileFrom<List<GitCommandAndOptionsEntity>>(entityListOut, @"C:\develop\Project_Git-Complete\Git-Complete\out\git_command_and_options.xml");

            //とりあえず目視確認用のテスト and ファイル出力
            StringBuilder sb = new StringBuilder();

            foreach (var gitEntity in entityListOut)
            {
                sb.AppendLine(gitEntity.gitCommand);
                Console.WriteLine("git command: " + gitEntity.gitCommand);
                foreach (var gitOption in gitEntity.gitOptionList)
                {
                    sb.AppendLine("  options: " + gitOption);
                    Console.WriteLine("  options: " + gitOption);
                }

            }
            //コマンドとオプションのツリーをファイルに出力
            string outFullPath = @"C:\develop\Project_Git-Complete\Git-Complete\out\command_and_options_list.txt";
            File.WriteAllText(outFullPath, sb.ToString());

        }
    }
}
