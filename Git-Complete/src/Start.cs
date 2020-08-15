using Git_Complete.src.entity;
using Git_Complete.src.exception;
using Git_Complete.src.function.scrape;
using Git_Complete.src.parser;
using Git_Complete.src.props;
using System;
using System.Collections.Generic;
using ComFunc;

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
            var eCommandKeyScrapeList = new ECommandKeyList<ECommandKeyScrape>
            {
                //gitコマンドとオプションのリストを生成する。
                Value = FileCommon.GetInstanceFromJson<List<ECommandKeyScrape>>(PathProps.HELP_SCRAPE_JSON_PATH),
            };

            //test -> xmlに出力して確認
            FileCommon.OutFileToXml<List<ECommandKeyScrape>>(eCommandKeyScrapeList.Value, PathProps.HELP_SCRAPE_XML_PATH);

            //Gitの公式ヘルプサイトからスクレイピングする用
            if (DebugProps.IS_MAKE_ENTITY_FROM_GIT_HELP)
            {
                eCommandKeyScrapeList.Value = new List<ECommandKeyScrape>();
                foreach (var command in CommonProps.ALL_COMMAND)
                    eCommandKeyScrapeList.Value.Add(new ECommandKeyScrape(command));


                //*******synopsisを共通スクレイプ*******
                var synopsisCommonScraper = new SynopsisCommonScraper();
                synopsisCommonScraper.ScrapeBy(eCommandKeyScrapeList);

                //*******optionsを共通スクレイプ*******
                var optionsCommonScraper = new OptionsCommonScraper();
                optionsCommonScraper.ScrapeBy(eCommandKeyScrapeList);

                //*******synopsisを共通スクレイプ*******
                var synopsisIndividualScraper = new SynopsisIndividualScraper();
                ///解析対象は<see cref="CommonProps.SYNOPSIS_INDEVIDUAL_SCRAPE_COMMAND"/>
                synopsisIndividualScraper.ScrapeBy(eCommandKeyScrapeList);

                //*******optionsを共通スクレイプ*******
                var optionsIndividualScraper = new OptionsIndividualScraper();
                ///解析対象は<see cref="CommonProps.OPTIONS_INDEVIDUAL_SCRAPE_COMMAND"/>
                optionsIndividualScraper.ScrapeBy(eCommandKeyScrapeList);

                //xml出力
                FileCommon.OutFileToXml<List<ECommandKeyScrape>>(eCommandKeyScrapeList.Value, PathProps.HELP_SCRAPE_XML_PATH);

                //Json出力
                FileCommon.OutFileToJson<List<ECommandKeyScrape>>(eCommandKeyScrapeList.Value, PathProps.HELP_SCRAPE_JSON_PATH);
            }

            //test
            

            //個別解析をする
            var eParsedHelpScrapeList =
                new ECommandKeyList<ECommandKeyScrape>(eCommandKeyScrapeList.Value);

            var gitEntityParser = new GitEntityParser();

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
