
using Git_Complete.function.parser;
using Git_Complete.src.entity;
using System;
using System.Collections.Generic;

namespace Git_Complete.src.function.scrape
{
    /// <summary>
    /// メソッド詳細はインターフェイス参照
    /// <see cref="IScraper"/>
    /// </summary>
    class CommonScraper : IScraper
    {
        protected static GitHelpDocs gitHelpDocs = new GitHelpDocs();

        public virtual List<string> ScrapeBy(string command)
        {
            throw new Exception("overrideして使ってください");
        }

        public virtual ECommandKeyScrape ScrapeBy(ECommandKeyScrape _in)
        {
            throw new Exception("overrideして使ってください");
        }

        public void ScrapeBy(ECommandKeyList<ECommandKeyScrape> _in)
        {
            //foreachだとループ元が変更されるので
            for (int i = 0; i < _in.Value.Count; i++)
            {
                _in.Swap(ScrapeBy(_in.Value[i]));

            }
        }
    }
}
