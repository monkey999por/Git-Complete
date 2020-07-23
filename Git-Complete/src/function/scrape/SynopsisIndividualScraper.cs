using Git_Complete.src.entity;
using System;
using System.Collections.Generic;

namespace Git_Complete.src.function.scrape
{
    class SynopsisIndividualScraper : IScraper
    {
        /// <summary>
        /// 受け取ったコマンドごとの個別スクレイプ
        /// 
        /// </summary>
        /// <param name="command">ターゲットコマンド</param>
        /// <returns></returns>
        public virtual List<string> ScrapeBy(string command)
        {
            throw new Exception("オーバーライドしてください");
        }

        public EGitCommand ScrapeBy(EGitCommand _in)
        {
            var ret = new EGitCommand(_in);
            ret.synopsis = ScrapeBy(ret.command);
            return ret;
        }

        public void ScrapeBy(EGitCommandList<EGitCommand> _in)
        {
            //foreachだとループ元が変更されるので
            for (int i = 0; i < _in.Value.Count; i++)
            {
                var temp = ScrapeBy(_in.Value[i]);
                _in.Swap(temp);
            }
        }

        public virtual void ScrapeBy(EGitCommandList<EGitCommand> _in, string[] targetCommands)
        {

        }

    }
}
