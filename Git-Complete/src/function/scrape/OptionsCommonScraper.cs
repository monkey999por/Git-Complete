using AngleSharp.Dom;
using Git_Complete.src.entity;
using System.Collections.Generic;

namespace Git_Complete.src.function.scrape
{
    /// <inheritdoc/>
    class OptionsCommonScraper : CommonScraper
    {
        /// <inheritdoc/>
        /// <summary>
        /// ■取得ルール
        /// 取得URL : https://git-scm.com/docs/git-{command}(Dom)
        /// {id: _options}を持った要素の親要素の中で、{class: .hdlist1}を持った項目すべて
        /// 
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public override List<string> ScrapeBy(string command)
        {
            //ヘルプファイルのDomを取得
            var document = gitHelpDocs.GetDom(command);

            //get options
            var temp = document.QuerySelector("#_options");
            if (temp is null)
                return null;

            IHtmlCollection<IElement> options = temp.ParentElement.QuerySelectorAll(".hdlist1");

            var ret = new List<string>();

            foreach (var e in options)
            {
                ret.Add(e.TextContent);
            }
            return ret;
        }

        /// <inheritdoc/>
        public override ECommandKeyScrape ScrapeBy(ECommandKeyScrape _in)
        {
            var ret = new ECommandKeyScrape(_in);
            ret.options = ScrapeBy(ret.command);
            return ret;
        }
    }
}
