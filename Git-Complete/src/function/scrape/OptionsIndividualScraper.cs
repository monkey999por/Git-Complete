using AngleSharp.Dom;
using Git_Complete.src.entity;
using Git_Complete.src.props;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Git_Complete.src.function.scrape
{
    class OptionsIndividualScraper : IndividualScraper
    {
        /// <summary>
        /// 受け取ったコマンドごとの個別スクレイプ
        /// 
        /// </summary>
        /// <param name="command">ターゲットコマンド</param>
        /// <returns></returns>
        public override List<string> ScrapeBy(string command)
        {
            CommonScraper cs = new OptionsCommonScraper();
            Console.WriteLine("options個別解析: " + command);

            //return value
            var ret = new List<string>();

            switch (command)
            {
                case "rerere":
                    ret = ScrapeByIdIsCommand(command);
                    break;
                case "merge-tree":
                    //スクレイピングはせずに個別に追加
                    ret.Add(" <base-tree> ");
                    ret.Add(" <branch1> ");
                    ret.Add(" <branch2> ");
                    break;
                case "show-branch": ret = cs.ScrapeBy(command); break;
                case "citool":
                    //オプションなし
                    break;
                case "gui":
                    ret = ScrapeByIdIsCommand(command);
                    break;
                case "sparse-checkout":
                    ret = ScrapeByIdIsCommand(command);
                    break;
                case "get-tar-commit-id":
                    //オプションなし
                    break;
                case "show-index":
                    //オプションなし
                    break;
                case "mktag":
                    // オプションなし
                    break;
                case "update-ref":
                    break;
                case "merge-one-file":
                    // オプションなし
                    break;
                case "credential":
                    //これもスクレイプはしない、、
                    //※synopsisの方も個別に書き換えをしてるので注意
                    //subcommand
                    ret.Add(" fill ");
                    ret.Add(" approve ");
                    ret.Add(" reject ");
                    //format (input to "standard in")
                    ret.Add(" protocol=<protocol> ");
                    ret.Add(" host=<host> ");
                    ret.Add(" path=<path> ");
                    ret.Add(" username=<username> ");
                    ret.Add(" password=<password> ");
                    ret.Add(" url=<url> ");
                    break;
                case "http-backend":
                    break;
                case "update-server-info":
                    // オプションなし
                    break;
                case "stage":
                    //addと同様
                    ret = cs.ScrapeBy("add");
                    break;

                default:
                    break;
            }
            return ret;
        }

        /// <inheritdoc/>
        public override ECommandKeyScrape ScrapeBy(ECommandKeyScrape _in)
        {
            if (CommonProps.OPTIONS_INDEVIDUAL_SCRAPE_COMMAND.Contains(_in.command))
            {
                var ret = new ECommandKeyScrape(_in);
                ret.options = ScrapeBy(ret.command);
                return ret;
            }
            return _in;
        }

        /// <summary>
        /// ID: _commandで取得できるパターンのものが思ったより多かったので
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        private List<string> ScrapeByIdIsCommand(string command)
        {
            var document = gitHelpDocs.GetDom(command);
            var temp = document.QuerySelector("#_commands");
            IHtmlCollection<IElement> options = temp.ParentElement.QuerySelectorAll(".hdlist1");
            var ret = new List<string>();

            foreach (var e in options)
            {
                ret.Add(e.TextContent);
            }
            return ret;
        }
    }
}
