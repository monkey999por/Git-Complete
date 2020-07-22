using AngleSharp.Dom;

using Git_Complete.function.parser;
using Git_Complete.src.entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Git_Complete.src.function.scrape
{
    class SynopsisCommonScraper : IScraper
    {
        public List<string> ScrapeBy(string command)
        {
            //ヘルプファイルのDomを取得
            var document = GitHelpDocs.GetHelpDocsDom(command);

            IHtmlCollection<IElement> synopsis = document.QuerySelector("#_synopsis").ParentElement.QuerySelectorAll(".content");

            var ret = new List<string>();

            foreach (var e in synopsis)
            {   
                ret.Add(e.TextContent);
            }
            return ret;
        }

        public EGitCommand ScrapeBy(EGitCommand _in)
        {
            var ret = new EGitCommand(_in);
            ret.synopsis = ScrapeBy(ret.command);
            return ret;

        }

        public EGitCommandList<EGitCommand> ScrapeBy(EGitCommandList<EGitCommand> _in)
        {

            //戻り値初期化(コピー)
            var ret = new List<EGitCommand>(_in.Value);

            IHtmlCollection<IElement> synopsisList;

            //synopsisを読み込む
            foreach (var entity in ret)
            {
                var temp = ScrapeBy(entity);
                _in.Swap(temp);

            }
            return _in;
        }
    }
}
