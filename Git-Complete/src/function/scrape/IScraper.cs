using Git_Complete.src.entity;
using System.Collections.Generic;
using Git_Complete.src.props;

namespace Git_Complete.src.function.scrape
{
    public interface IScraper
    {

        /// <summary>
        /// Gitの公式HelpからSysnopsisをスクレイピングする。
        /// 対象は引数で渡されたコマンド
        /// 公式Helpは（おそらく）自動生成されているわけではなく、形式にばらつきがあるため、
        /// ここでは下記のルールでスクレイピングし、正常に取得できなかったものについては
        /// 別メソッドで個別に補正を行う。
        /// 
        /// </summary>
        /// <param name="command"><see cref="CommonProps.ALL_COMMAND"/>に存在するGitコマンド</param>
        /// <returns>Synopsisのリスト</returns>
        public List<string> ScrapeBy(string command);


        /// <summary>
        /// <see cref="EGitCommand.command"/>をもとに<see cref="ScrapeBy(string)"/>の呼び出しを行う
        /// 戻り値は、引数に<see cref="EGitCommand.synopsis"/>または<see cref="EGitCommand.options"/>をセットしたもの
        /// このあたりは実装参照
        /// </summary>
        /// <param name="_in">commandが入っていること</param>
        /// <returns></returns>
        public EGitCommand ScrapeBy(EGitCommand _in);

        /// <summary>
        /// <see cref="ScrapeBy(EGitCommand)"/>に引数のリストを個別に渡す。
        /// 結果は引数にセットする。
        /// </summary>
        /// <param name="_in"></param>
        public void ScrapeBy(EGitCommandList<EGitCommand> _in);
    }
}
