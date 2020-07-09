﻿using System;
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
        static void Main(string[] args)
        {

            //初期化
            ref var gitCommandEntityList = ref MainEntity.gitCommandEntityList;
            
            String outDir = @"C:\develop\Git-Complete\Git-Complete\instance";
            String entityPath = outDir + @"\entity.xml";

            //gitコマンドとオプションのリストを生成する。
            FileCommon fileCommon = new FileCommon();
            gitCommandEntityList = fileCommon.getInstanceFrom<List<GitCommandEntity>>(entityPath);

            //test
            if (!(gitCommandEntityList.Count == 136))
            {
                throw new Exception("コマンドの数があってない");

            }

            //なぜか↑の読み込みでおかしな文字コードの空白がxmlに付加されて、再度xmlを読もうとするとエラーになる
            //なので、ここで再書き込みする
            fileCommon.OutFileTo <List < GitCommandEntity >> (gitCommandEntityList, entityPath);


            //git-scm.comから、synopsisを取得する（html parserを使用）


            //git-scm.comから、オプションの一覧を取得する（html parserを使用）

            //xml出力


            //xml読み込み


            //synopsisを解析 -> パターンを検討し、生成するpowershellでどうやって使うかを検討する

            //optionsを解析 -> synopsisの解析結果と照らし合わせて、powershellソースに組み込む

            //出来上がったentityをもとに、powershellソースを自動生成する。







            /*

            //gitのヘルプファイルパスとコマンド名を持ったentityを作成する
            var gitMetaInfoParser = new GitMetaInfoParser();
            gitInstance.commandAndOptionsList = gitMetaInfoParser.CreatGitCommandAndHelpFilePathEntity();

            //xml出力
            var fileCommon = new FileCommon();
            fileCommon.OutFileFrom<List<GitCommandAndHelpFilePathEntity>>(helpEntityList, outDir + @"\git_help.xml");

            var gitHelpParser = new GitHelpParser();
            var entityListOut = new List<GitCommandEntity>();

            //gitEnrityListにコマンドごとのインスタンスを入れ込む
            await gitHelpParser.GetGitOptions(helpEntityList, entityListOut);

            //xml出力
            fileCommon.OutFileFrom<List<GitCommandEntity>>(entityListOut, outDir + @"\git_command_and_options.xml");

            //とりあえず目視確認用のテスト and ファイル出力
            StringBuilder sb = new StringBuilder();

            foreach (var gitEntity in entityListOut)
            {
                sb.AppendLine(gitEntity.command);
                Console.WriteLine("git command: " + gitEntity.command);
                foreach (var gitOption in gitEntity.options)
                {
                    sb.AppendLine("  options: " + gitOption);
                    Console.WriteLine("  options: " + gitOption);
                }

            }
            //コマンドとオプションのツリーをファイルに出力
            string outFullPath = outDir + @"\command_and_options_list.txt";
            File.WriteAllText(outFullPath, sb.ToString());
            */
        }
    }
}
