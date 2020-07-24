using AngleSharp.Dom;

using Git_Complete.function.parser;
using Git_Complete.src.entity;
using Git_Complete.src.props;
using System;
using System.Collections.Generic;

namespace Git_Complete.src.function.scrape
{
    /// <summary>
    /// メソッド詳細はインターフェイス参照
    /// <see cref="IScraper"/>
    /// </summary>
    class IndividualScraper : IScraper
    {
        protected static GitHelpDocs gitHelpDocs = new GitHelpDocs();

        public virtual List<string> ScrapeBy(string command)
        {
            throw new Exception("overrideして使ってください");
        }

        public virtual EGitCommand ScrapeBy(EGitCommand _in)
        {
            throw new Exception("overrideして使ってください");
        }

        public void ScrapeBy(EGitCommandList<EGitCommand> _in)
        {
            //foreachだとループ元が変更されるので
            for (int i = 0; i < _in.Value.Count; i++)
            {
                _in.Swap(ScrapeBy(_in.Value[i]));

            }
        }

        /// <summary>
        /// 特定コマンドのみ処理を行う
        /// </summary>
        /// <param name="_in"></param>
        /// <param name="targetCommands"></param>
        public virtual void ScrapeBy(EGitCommandList<EGitCommand> _in, string[] targetCommands)
        {

            //前提
            if (_in.Value.Count != CommonProps.ALL_COMMAND_COUNT)
                throw new Exception();

            targetCommands ??= CommonProps.ALL_COMMAND;

            //スクレイプ対象のコマンドを持ったの作る
            var target = new EGitCommandList<EGitCommand>();
            var targetEnt = _in.GetEntityListByCommands(targetCommands);
            target.Value = new List<EGitCommand>(targetEnt);

            ScrapeBy(target);

            //結果を設定する
            //処理対象外のコマンドは引数のやつを単純移送する
            foreach (var swapObj in target.Value)
                _in.Swap(swapObj);

            //確認用
            if (target.Value.Count != CommonProps.ALL_COMMAND_COUNT)
                throw new Exception();
        }
    }
}
