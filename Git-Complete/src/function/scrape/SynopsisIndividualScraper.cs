using Git_Complete.src.entity;
using Git_Complete.src.props;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Git_Complete.src.function.scrape
{
    class SynopsisIndividualScraper : IndividualScraper
    {
        /// <summary>
        /// 受け取ったコマンドごとの個別スクレイプ
        /// 
        /// </summary>
        /// <param name="command">ターゲットコマンド</param>
        /// <returns></returns>
        public override List<string> ScrapeBy(string command)
        {
            CommonScraper cs = new SynopsisCommonScraper();

            var ret = new List<string>();
            Console.WriteLine("synopsis個別解析: " + command);

            switch (command)
            {
                case "dummy":
                    break;
                default:
                    break;
            }
            return ret;

        }
        /// <inheritdoc/>
        public override ECommandKeyScrape ScrapeBy(ECommandKeyScrape _in)
        {
            if (CommonProps.SYNOPSIS_INDEVIDUAL_SCRAPE_COMMAND.Contains(_in.command))
            {
                var ret = new ECommandKeyScrape(_in);
                ret.synopsis = ScrapeBy(ret.command);
                return ret;
            }
            return _in;
        }

    }
}
