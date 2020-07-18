using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Security.Claims;
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
    /// //valueはList<EGitCommand>型。メソッドメンバがvalueフィールドに値が設定されていることを前提に作られているので、下記のように使用すること
    /// eGitCommandList.Value = FileCommon.GetInstanceFrom<List<EGitCommand>>(entityPath);
    /// 
    /// //こういうのは基本的にNG
    /// var temp = eGitCommandList.Value;
    /// temp.Add(null);
    /// eGitCommandList.Value = temp;
    /// </code>
    /// </summary>
    /// <see cref="EGitCommand"/>
    /// <typeparam name="T"></typeparam>
    [Serializable]
    class EGitCommandList<T> where T : EGitCommand
    {
        //主にgitの公式ヘルプからスクレイピングした素のオプションやシナプスを保持
        private List<T> value = new List<T>();

        public List<T> Value
        {
            get { return this.value; }
            set { this.value = value; }
        }

        public EGitCommandList() { }
        public EGitCommandList(List<T> value)
        {
            this.value = new List<T>((List<T>)value);
        }

        /// <summary>
        /// コマンド名をもとに、フィールド:valueから一致するものを返す。
        /// </summary>
        /// 
        /// <param name="keyCommand">Gitのコマンド名。例:add , commit</param>
        /// <returns></returns>
        public EGitCommand GetEntityByCommand(String keyCommand)
        {
            if (this.value is null)
            {
                throw new Exception(nameof(this.value) + ":" + typeof(T) + "がnullです");
            }

            foreach (var entity in this.value)
            {
                if (entity.command.Equals(keyCommand))
                {
                    return entity;
                }
            }
            return null;
        }

        /// <summary>
        /// コマンドの情報をコンソールに出力する。
        /// 形式
        ///  {command_name}
        ///    ■synopsis: {synopsis}
        ///    ■opsion  : {option}
        ///    ......
        /// </summary>
        /// <param name="commandAry">出力するコマンドを指定する。</param>
        /// <param name="isOutSynopsis">synopsisを出力するか。デフォルト:true</param>
        /// <param name="isOutOptions">optionを出力するか。デフォルト:true</param>
        /// <returns>コンソールに出力した文字列</returns>
        public StringBuilder OutEntity(string[] commandAry, bool isOutSynopsis = true, bool isOutOptions = true)
        {
            if (commandAry is null)
            {
                throw new ArgumentNullException("引数のコマンド名の配列がnullです");
            }

            //戻り値用の文字列.　コンソールに出力する内容と同じもの
            StringBuilder outText = new StringBuilder();
#nullable enable
            EGitCommand? target;
            foreach (var command in commandAry)
            {
                target = GetEntityByCommand(command) ?? new EGitCommand();

                Console.WriteLine("■" + target.command);
                outText.Append("■" + target.command + Environment.NewLine);

                if (isOutSynopsis)
                {
                    foreach (var temp in target.synopsis)
                    {
                        Console.WriteLine("    " + nameof(target.synopsis) + ": " + temp);
                        outText.Append("    " + nameof(target.synopsis) + ": " + temp + Environment.NewLine);
                    }

                }

                if (isOutOptions)
                {
                    if (target.options != null)
                    {
                        foreach (var temp in target.options)
                        {
                            Console.WriteLine("    " + nameof(target.options) + ": " + temp);
                            outText.Append("    " + nameof(target.options) + ": " + temp + Environment.NewLine);
                        }

                    }
                }
            }
            return outText;
        }

        /// <summary>
        /// コマンド名の配列をもとに、フィールド:valueから一致するものをすべて返す。
        /// </summary>
        /// 
        /// <param name="keyCommands">Gitのコマンド名配列。例:new String[]{"add", "commin","pull"}</param>
        /// <returns></returns>
        public List<EGitCommand> GetEntityListByCommands(String[] keyCommands)
        {
            List<EGitCommand> ret = new List<EGitCommand>();
            foreach (var command in keyCommands)
                ret.Add(GetEntityByCommand(command));

            return ret;
        }

        
    }


    /// <summary>
    /// <see cref="EGitCommandList{T}"/>のジェネリックで使用するためのクラス
    /// 本処理では上記以外の方法で直接使用することはない想定。
    ///（デバッグコード等での一時的な使用はあるが、正規の使い方ではない） 
    /// </summary>
    [Serializable]
    class EGitCommand
    {
        //gitのコマンドを保持. primary key
        public string? command;

        //各gitコマンドで使用できるSYNOPSISを保持する. 
        public List<string> synopsis = new List<string>();

        //各gitコマンドで使用できるオプションを保持する. 
        public List<string> options = new List<string>();

        //各gitコマンドで使用できるオプションの説明を保持する
        public List<string> optionsDescription = new List<string>();

        public EGitCommand() { }
        public EGitCommand(string command)
        {
            this.command = command;
        }
    }
}
