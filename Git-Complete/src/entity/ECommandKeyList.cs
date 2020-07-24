using Git_Complete.src.exception;
using Git_Complete.src.props;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Git_Complete.src.entity
{
    /// <summary>
    /// EGitCommandクラスをリストで保持するためのクラス。
    /// 今後EGitCommandクラスを継承したクラスでインスタンス化するためにジェネリック指定がある、
    /// （現在はEGitCommandクラスのみを想定）
    /// 
    /// 利用側では下記のように利用する。
    /// 
    /// <code>
    /// EGitCommandList<EGitCommand> eGitCommandList = new EGitCommandList<EGitCommand>();
    /// 
    /// //<see cref="value"/>は<see cref="List{EGitCommand}"/>型。メソッドメンバが<see cref="value"/>フィールドに値が設定されていることを前提に作られているので、下記のように使用すること
    /// eGitCommandList.Value = FileCommon.GetInstanceFrom<List<EGitCommand>>(entityPath);
    /// 
    /// //こういうのは基本的にNG
    /// var temp = eGitCommandList.Value;
    /// temp.Add(null);
    /// eGitCommandList.Value = temp;
    /// </code>
    /// </summary>
    /// <see cref="ECommandKey"/>
    /// <typeparam name="T"></typeparam>
    [Serializable]
    [DataContract]
    public class ECommandKeyList<T> where T : ECommandKey
    {
        //主にgitの公式ヘルプからスクレイピングした素のオプションやシナプスを保持
        [DataMember]
        private List<T> value = new List<T>();

        public List<T> Value
        {
            get { return this.value; }
            set { this.value = value; }
        }

        public ECommandKeyList() { }
        public ECommandKeyList(List<T> value)
        {
            this.value = new List<T>((List<T>)value);
        }

        /// <summary>
        /// コマンド名をもとに、フィールド:valueから一致するものを返す。
        /// </summary>
        /// 
        /// <param name="keyCommand">Gitのコマンド名。例:add , commit</param>
        /// <returns></returns>
        public (int index, ECommandKey eGitCommand) GetEntityByCommand(String keyCommand)
        {
            if (this.value is null)
            {
                throw new Exception(nameof(this.value) + ":" + typeof(T) + "がnullです");
            }

            var index = 0;
            foreach (var entity in this.value)
            {
                if (entity.command.Equals(keyCommand))
                {
                    return (index, entity);
                }
                index++;
            }
            return (0, null);
        }

        /// <summary>
        /// コマンド名の配列をもとに、フィールド:valueから一致するものをすべて返す。
        /// </summary>
        /// 
        /// <param name="keyCommands">Gitのコマンド名配列。例:new String[]{"add", "commin","pull"}</param>
        /// <returns></returns>
        public List<ECommandKey> GetEntityListByCommands(String[] keyCommands)
        {
            List<ECommandKey> ret = new List<ECommandKey>();
            foreach (var command in keyCommands)
                ret.Add(GetEntityByCommand(command).eGitCommand);

            return ret;
        }

        /// <summary>
        /// <see cref="ECommandKeyList.value"/>の中から引数で渡されたオブジェクトの<see cref="ECommandKey.command"/>に
        /// 一致するオブジェクトを見つけ、取り替えます（一致した元のオブジェクトを削除し、引数のオブジェクトで入れ替える）
        /// </summary>
        public void Swap(T swapObj)
        {
            //確認用
            if (this.Value.Count != CommonProps.ALL_COMMAND_COUNT)
                throw new MyProcessFailureException<T>("オブジェクトの入れ替えで例外が発生しました。", swapObj);

            var target = GetEntityByCommand(swapObj.command);
            if (target.eGitCommand is null)
                throw new Exception("gitのコマンドではありません");

            this.Value.RemoveAt(target.index);
            this.Value.Insert(target.index, (T)new ECommandKey(swapObj));

            //確認用
            if (this.Value.Count != CommonProps.ALL_COMMAND_COUNT)
                throw new MyProcessFailureException<T>("オブジェクトの入れ替えで例外が発生しました。", swapObj);

        }

        /// <summary>
        /// <see cref="ECommandKeyList.value"/>の中から引数で渡されたオブジェクトを<see cref="Value"/>に追加します
        /// </summary>
        /// <param name="addObj"></param>
        public void Add(T addObj)
        {
            //重複チェック
            if (GetEntityByCommand(addObj.command).eGitCommand != null)
            {
                throw new MyProcessFailureException<T>("コマンドが重複してます。", addObj);
            } 
            
            this.Value.Add((T)new ECommandKey(addObj));
        }

    }
}
