using Git_Complete.src.entity;
using Git_Complete.src.exception;
using Git_Complete.src.function.common;
using Git_Complete.src.function.scrape;
using Git_Complete.src.parser;
using Git_Complete.src.props;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

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
            ECommandKeyList<ECommandKey> eGitCommandList = new ECommandKeyList<ECommandKey>
            {
                //gitコマンドとオプションのリストを生成する。
                Value = FileCommon.GetInstanceFromXml<List<ECommandKey>>(PathProps.HELP_SCRAPE_XML_Path)
            };

            //読み込み後にファイルにおかしなもしコードの文字が付加されるため、再書き込み
            FileCommon.OutFileToXml<List<ECommandKey>>(eGitCommandList.Value, PathProps.HELP_SCRAPE_XML_Path);

            //test -> コマンド数は136個
            if (eGitCommandList.Value.Count != CommonProps.ALL_COMMAND_COUNT)
                throw new Exception("コマンドの数があってない");

            //jsonのシリアライズ・デシリアライズのテスト
            if (DebugProps.DEBUG_MODE)
            {
                FileCommon.OutFileToJson<List<ECommandKey>>(eGitCommandList.Value, PathProps.HELP_SCRAPE_JSON_Path);

                var temp = FileCommon.GetInstanceFromJson<List<ECommandKey>>(PathProps.HELP_SCRAPE_JSON_Path);

                //読み込み後にファイルにおかしなもしコードの文字が付加されるため、再書き込み
                FileCommon.OutFileToXml<List<ECommandKey>>(temp, PathProps.HELP_SCRAPE_XML_Path);

            }


            //test -> swap
            if (DebugProps.DEBUG_MODE)
            {
                /*
                var test = new EGitCommand("add");
                test.options.Add("nnnnn");
                test.options.Add("--gggg");
                test.synopsis.Add("-ghgh");

                eGitCommandList.Swap(test);

                FileCommon.OutFileToXml<List<EGitCommand>>(eGitCommandList.Value, PathProps.HELP_SCRAPE_XML_Path);
                */
            }


            //Gitの公式ヘルプサイトからスクレイピングする用
            if (DebugProps.IS_MAKE_ENTITY_FROM_GIT_HELP)
            {
                eGitCommandList.Value = new List<ECommandKey>();
                foreach (var command in CommonProps.ALL_COMMAND)
                {
                    eGitCommandList.Value.Add(new ECommandKey(command));
                }

                //git-scm.comから、synopsisを取得する（html parserを使用）
                var synopsisCommonScraper = new SynopsisCommonScraper();
                synopsisCommonScraper.ScrapeBy(eGitCommandList);

                //git-scm.comから、オプションの一覧を取得する（html parserを使用）
                var optionsCommonScraper = new OptionsCommonScraper();
                optionsCommonScraper.ScrapeBy(eGitCommandList);

                //xml出力
                FileCommon.OutFileToXml<List<ECommandKey>>(eGitCommandList.Value, PathProps.HELP_SCRAPE_XML_Path);
            }

            //個別解析をする
            ECommandKeyList<ECommandKey> eParsedHelpScrapeList =
                new ECommandKeyList<ECommandKey>(eGitCommandList.Value);

            GitEntityParser gitEntityParser = new GitEntityParser();

            try
            {
                //test
                var test = new ECommandKeyList<ECommandKey>();
                test.Value = new List<ECommandKey>(eParsedHelpScrapeList.Value);
                test.Value = gitEntityParser.ShapSynopsisCommonAll(eParsedHelpScrapeList.Value);
            }
            catch (MyProcessFailureException<ECommandKey> e)
            {
                Console.WriteLine(e.message);
                Console.WriteLine(e.errorObject.command);
                foreach (var synopsis in e.errorObject.synopsis)
                {
                    Console.WriteLine(synopsis);
                }

            }


            //optionsを解析 -> synopsisの解析結果と照らし合わせて、powershellソースに組み込む



            //出来上がったentityをもとに、powershellソースを自動生成する。

        }
    }
}
