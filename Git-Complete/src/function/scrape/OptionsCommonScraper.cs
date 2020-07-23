using AngleSharp.Dom;

using Git_Complete.function.parser;
using Git_Complete.src.entity;
using System.Collections.Generic;

namespace Git_Complete.src.function.scrape
{
    class OptionsCommonScraper : IScraper
    {
        private static GitHelpDocs gitHelpDocs = new GitHelpDocs();

        public List<string> ScrapeBy(string command)
        {
            //ヘルプファイルのDomを取得
            var document = gitHelpDocs.GetDom(command);

            //get synopsis
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

        public EGitCommand ScrapeBy(EGitCommand _in)
        {
            var ret = new EGitCommand(_in);
            ret.options = ScrapeBy(ret.command);
            return ret;
        }

        public void ScrapeBy(EGitCommandList<EGitCommand> _in)
        {
            //foreachだとループ元が変更されるので
            for (int i = 0; i < _in.Value.Count; i++)
            {
                _in.Swap(ScrapeBy(_in.Value[i]));
            }
        }
    }
}
