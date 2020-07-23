using AngleSharp.Dom;

using Git_Complete.function.parser;
using Git_Complete.src.entity;
using System.Collections.Generic;

namespace Git_Complete.src.function.scrape
{
    /// <summary>
    /// メソッド詳細はインターフェイス参照
    /// <see cref="IScraper"/>
    /// </summary>
    class SynopsisCommonScraper : CommonScraper
    {
        /// <summary>
        /// ■取得ルール
        /// 取得URL : https://git-scm.com/docs/git-{command}(Dom)
        /// {id: _synopsis}を持った要素の親要素の中で、{class: .content}を持った項目すべて
        /// 
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public override List<string> ScrapeBy(string command)
        {
            //ヘルプファイルのDomを取得
            var document = gitHelpDocs.GetDom(command);

            IHtmlCollection<IElement> synopsis = document.QuerySelector("#_synopsis").ParentElement.QuerySelectorAll(".content");

            var ret = new List<string>();

            foreach (var e in synopsis)
            {
                ret.Add(e.TextContent);
            }
            return ret;
        }

        public override EGitCommand ScrapeBy(EGitCommand _in)
        {
            var ret = new EGitCommand(_in);
            ret.synopsis = ScrapeBy(ret.command);
            return ret;
        }
    }
}
