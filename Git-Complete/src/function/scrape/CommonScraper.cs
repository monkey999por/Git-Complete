
using Git_Complete.function.parser;
using Git_Complete.src.entity;
using System;
using System.Collections.Generic;

namespace Git_Complete.src.function.scrape
{
    /// <inheritdoc/>
    class CommonScraper : IScraper
    {
        protected static GitHelpDocs gitHelpDocs = new GitHelpDocs();

        /// <inheritdoc/>
        public virtual List<string> ScrapeBy(string command)
        {
            throw new Exception("overrideして使ってください");
        }

        /// <inheritdoc/>
        public virtual ECommandKeyScrape ScrapeBy(ECommandKeyScrape _in)
        {
            throw new Exception("overrideして使ってください");
        }

        /// <inheritdoc/>
        /// <summary>
        /// 処理結果を引数にセットする
        /// </summary>
        /// <param name="_in"></param>
        public void ScrapeBy(ECommandKeyList<ECommandKeyScrape> _in)
        {
            //foreachだとループ元が変更されるので
            for (int i = 0; i < _in.Value.Count; i++)
                _in.Swap(ScrapeBy(_in.Value[i]));
        }
    }
}
