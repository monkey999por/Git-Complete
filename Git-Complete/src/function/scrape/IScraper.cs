using Git_Complete.src.entity;
using Git_Complete.src.props;
using System.Collections.Generic;

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
        /// <see cref="ECommandKey.command"/>をもとに<see cref="ScrapeBy(string)"/>の呼び出しを行う
        /// 戻り値は、引数に<see cref="ECommandKey.synopsis"/>または<see cref="ECommandKey.options"/>をセットしたもの
        /// このあたりは実装参照
        /// </summary>
        /// <param name="_in">commandが入っていること</param>
        /// <returns></returns>
        public ECommandKey ScrapeBy(ECommandKey _in);

        /// <summary>
        /// <see cref="ScrapeBy(ECommandKey)"/>に引数のリストを個別に渡す。
        /// 結果は引数にセットする。
        /// </summary>
        /// <param name="_in"></param>
        public void ScrapeBy(ECommandKeyList<ECommandKey> _in);
    }
}
