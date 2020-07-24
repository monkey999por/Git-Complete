using Git_Complete.src.props;
using System.Collections.Generic;

namespace Git_Complete.src.entity
{
    /// <summary>
    /// <see cref="ECommandKey"/>を継承したクラス(例：<see cref="ECommandKeyScrape"/>)をリストで保持する
    /// リストに対して、検索、追加、入れ替え等を提供する
    /// ※メソッドメンバが<see cref="Value"/>フィールドに値が設定されていることを前提に作られているので注意
    /// 
    /// 利用側では下記のように利用する。
    /// <code>
    /// var e = new <see cref="ECommandKeyList{T}"/>(); ※Tは<see cref="ECommandKey"/>を継承したクラス(例：<see cref="ECommandKeyScrape"/>)
    /// </code>
    /// </summary>
    /// <typeparam name="T"><see cref="ECommandKey"/>を継承したクラス</typeparam>
    public interface IECommandKeyList<T> where T : ECommandKey
    {
        /// <value>
        /// <see cref="ECommandKey"/>を継承したクラスをリストで保持する。
        /// リストサイズは最大<see cref="CommonProps.ALL_COMMAND_COUNT"/>となる前提
        /// </value>
        List<T> Value { get; set; }

        /// <summary>
        /// 引数で渡されたオブジェクトを<see cref="Value"/>に追加します.
        /// 追加の際に、<see cref="Value"/>リストが保持するentityのコマンドと、<see cref="ECommandKey.command"/>の重複は許されません.
        /// </summary>
        /// <param name="addObj"></param>
        void Add(T addObj);

        /// <summary>
        /// 引数をもとに、<see cref="Value"/>から一致するものを返す　
        /// </summary>
        /// 
        /// <param name="keyCommand">Gitのコマンド名。例:add , commit</param>
        /// <returns>
        /// 
        /// 
        /// </returns>
        /// 

        (int index, T eGitCommand) GetEntityByCommand(string keyCommand);

        /// <summary>
        /// コマンド名の配列をもとに、<see cref="Value"/>から一致するものをすべて返す。
        /// </summary>
        /// 
        /// <param name="keyCommands">Gitのコマンド名配列。例:<code>new String[]{"add", "commin","pull"}</code></param>
        /// <returns></returns>
        List<T> GetEntityListByCommands(string[] keyCommands);


        /// <summary>
        /// <see cref="Value"/>の中から引数で渡されたオブジェクトの<see cref="ECommandKey.command"/>に
        /// 一致するオブジェクトを見つけ、取り替えます.
        /// (一致した元のオブジェクトを削除し、引数のオブジェクトで入れ替える)
        /// </summary>
        /// <param name="swapObj">取り替え元</param>
        void Swap(T swapObj);
    }
}