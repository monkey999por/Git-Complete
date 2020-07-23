using System;
using System.Collections.Generic;
using System.Text;
using AngleSharp.Dom;
using Git_Complete.function.parser;
using Git_Complete.src.entity;


namespace Git_Complete.src.function.scrape.individual
{
    class SynopsisIndividualScraper
    {

        /// <summary>
        /// 受け取ったコマンドごとの個別関数を呼ぶ
        /// 戻り値は個別関数の戻り値
        /// 
        /// 個別関数は ScrapeIndividualGit{command}の形式です
        /// 文字列で関数名を作成して、呼び出す
        /// 
        /// </summary>
        /// <param name="command">呼び出したい個別関数に対応するコマンド</param>
        /// <returns></returns>
        public virtual List<string> ScrapeBy(string command)
        {
            throw new NotImplementedException();
        }

        public virtual EGitCommand ScrapeBy(EGitCommand _in)
        {
            throw new NotImplementedException();
        }
    }
}
