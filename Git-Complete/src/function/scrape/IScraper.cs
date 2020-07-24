using Git_Complete.src.entity;
using Git_Complete.src.props;
using System.Collections.Generic;

namespace Git_Complete.src.function.scrape
{

    /// <summary>
    /// Gitの公式Helpのスクレイピングのための関数を提供する。
    /// 
    /// ※注意
    /// 共通スクレイプ、個別スクレイプの両方でこのinterfaseを実装する。
    /// 重要なのはスクレイプ方法であり、引数と戻り値はスクレイプ手法によって
    /// 変化するものではないことが理由となる.
    /// </summary>
    public interface IScraper
    {

        /// <summary> 
        /// 引数で渡されたコマンドに対応するGitの公式Helpから、スクレイプを行う。
        /// 何をスクレイプするかは実装を参照。
        /// </summary>
        /// <param name="command">スクレイプ対象。<see cref="CommonProps.ALL_COMMAND"/>に存在するGitコマンド</param>
        /// <returns>Synopsisのリスト</returns>
        public List<string> ScrapeBy(string command);


        /// <summary>
        /// 引数の<see cref="ECommandKey.command"/>をもとに<see cref="ScrapeBy(string)"/>の呼び出しを行う
        /// </summary>
        /// <param name="_in"></param>
        /// <returns></returns>
        public ECommandKeyScrape ScrapeBy(ECommandKeyScrape _in);

        /// <summary>
        /// <see cref="ScrapeBy(ECommandKeyScrape)"/>に引数のリストを個別に渡す。
        /// </summary>
        /// <param name="_in"></param>
        public void ScrapeBy(ECommandKeyList<ECommandKeyScrape> _in);
    }
}
