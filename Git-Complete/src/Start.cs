using System;
using Git_Complete.src;
using Git_Complete.src.entity;
using System.Collections.Generic;
using Git_Complete.src.function.common;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using Git_Complete.function.parser;
using Git_Complete.src.parser;
using Git_Complete.src.props;

namespace Git_Complete
{
    class Start
    {
        /// <summary>
        /// 処理の本流は以下参照
        /// <see cref="https://app.diagrams.net/#Hmonkey999por%2FGit-Complete%2Fmaster%2FGit-Complete%2Ftemp%2FUntitled%20Diagram.drawio"/>
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            EGitCommandList<EGitCommand> eGitCommandList = new EGitCommandList<EGitCommand>();

            String entityPath = PathProps.INSTANCE_DIR + nameof(EGitCommand) + "_HelpScrapeList.xml";

            //gitコマンドとオプションのリストを生成する。
            eGitCommandList.Value = FileCommon.GetInstanceFrom<List<EGitCommand>>(entityPath);

            //読み込み後にファイルにおかしなもしコードの文字が付加されるため、再書き込み
            FileCommon.OutFileTo<List<EGitCommand>>(eGitCommandList.Value, entityPath);

            //test -> コマンド数は136個
            if (!(eGitCommandList.Value.Count == 136))
                throw new Exception("コマンドの数があってない");

            //Gitの公式ヘルプサイトからスクレイピングする用
            if (DebugProps.IS_MAKE_ENTITY_FROM_GIT_HELP)
            {
                eGitCommandList.Value = new List<EGitCommand>();
                foreach (var command in CommonProps.ALL_COMMAND)
                {
                    eGitCommandList.Value.Add(new EGitCommand(command));
                }

                var helpParser = new GitHelpParser();

                //git-scm.comから、synopsisを取得する（html parserを使用）
                eGitCommandList.Value = helpParser.GetSynopsisAll(eGitCommandList.Value);

                //git-scm.comから、オプションの一覧を取得する（html parserを使用）
                eGitCommandList.Value = helpParser.GetOptionsAll(eGitCommandList.Value);

                //xml出力
                FileCommon.OutFileTo<List<EGitCommand>>(eGitCommandList.Value, entityPath);
            }

            //debug -> EGitCommandListの中身を出力
            if (DebugProps.DEGUB_MODE)
            {
                string[] inAry = new string[eGitCommandList.Value.Count];
                var i = 0;
                foreach (var item in eGitCommandList.Value)
                {
                    inAry[i] = item.command;
                    i++;
                }
                eGitCommandList.OutEntity(inAry);

            }


            //個別解析をする
            EGitCommandList<EGitCommand> eParsedHelpScrapeList = 
                new EGitCommandList<EGitCommand>(eGitCommandList.Value);


            //optionsを解析 -> synopsisの解析結果と照らし合わせて、powershellソースに組み込む



            //出来上がったentityをもとに、powershellソースを自動生成する。

        }
    }
}
