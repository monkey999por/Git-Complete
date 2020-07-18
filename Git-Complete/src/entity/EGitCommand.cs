using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;

namespace Git_Complete.src.entity
{

    /*
     * このクラスは、 フィールド：eGitCommandsのためのクラス
     */
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

        //コマンドの情報を出力する。commandNameは未指定の場合定数で保持しているものを出力する
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
    }

    [Serializable]
    class EGitCommand
    {
        //gitのコマンドを保持. primary key
        public string? command;

        //各gitコマンドで使用できるSYNOPSISを保持する. 公式helpから取得した素の状態
        public List<string> synopsis = new List<string>();

        //各gitコマンドで使用できるオプションを保持する. 公式helpから取得した素の状態
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
