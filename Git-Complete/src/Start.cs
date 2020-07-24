using Git_Complete.src.entity;
using Git_Complete.src.exception;
using Git_Complete.src.function.common;
using Git_Complete.src.function.scrape;
using Git_Complete.src.parser;
using Git_Complete.src.props;
using System;
using System.Collections.Generic;

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
            ECommandKeyList<ECommandKeyScrape> eCommandKeyScrapeList = new ECommandKeyList<ECommandKeyScrape>
            {
                //gitコマンドとオプションのリストを生成する。
                Value = FileCommon.GetInstanceFromJson<List<ECommandKeyScrape>>(PathProps.HELP_SCRAPE_JSON_Path),
            };

            //test -> コマンド数は136個
            if (eCommandKeyScrapeList.Value.Count != CommonProps.ALL_COMMAND_COUNT)
                throw new Exception("コマンドの数があってない");

            //test -> xmlに出力して確認
            FileCommon.OutFileToXml<List<ECommandKeyScrape>>(eCommandKeyScrapeList.Value, PathProps.HELP_SCRAPE_XML_Path);
            
            //Gitの公式ヘルプサイトからスクレイピングする用
            if (DebugProps.IS_MAKE_ENTITY_FROM_GIT_HELP)
            {
                eCommandKeyScrapeList.Value = new List<ECommandKeyScrape>();
                foreach (var command in CommonProps.ALL_COMMAND)
                    eCommandKeyScrapeList.Value.Add(new ECommandKeyScrape(command));

                //git-scm.comから、synopsisを取得する（html parserを使用）
                var synopsisCommonScraper = new SynopsisCommonScraper();
                synopsisCommonScraper.ScrapeBy(eCommandKeyScrapeList);

                //git-scm.comから、オプションの一覧を取得する（html parserを使用）
                var optionsCommonScraper = new OptionsCommonScraper();
                optionsCommonScraper.ScrapeBy(eCommandKeyScrapeList);

                //xml出力
                FileCommon.OutFileToXml<List<ECommandKeyScrape>>(eCommandKeyScrapeList.Value, PathProps.HELP_SCRAPE_XML_Path);

                //Json出力
                FileCommon.OutFileToJson<List<ECommandKeyScrape>>(eCommandKeyScrapeList.Value, PathProps.HELP_SCRAPE_JSON_Path);
            }

            //個別解析をする
            ECommandKeyList<ECommandKeyScrape> eParsedHelpScrapeList =
                new ECommandKeyList<ECommandKeyScrape>(eCommandKeyScrapeList.Value);

            GitEntityParser gitEntityParser = new GitEntityParser();

            try
            {
                //test
                var test = new ECommandKeyList<ECommandKeyScrape>
                {
                    Value = new List<ECommandKeyScrape>(eParsedHelpScrapeList.Value)
                };
                test.Value = gitEntityParser.ShapSynopsisCommonAll(eParsedHelpScrapeList.Value);
            }
            catch (ObjectProcessFailureException<ECommandKeyScrape> e)
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
