using Git_Complete.src.entity;
using Git_Complete.src.props;
using System;
using System.Collections.Generic;
using System.Text;
using Git_Complete.src.function.common;

namespace Git_Complete.src.function.debug
{
    class DebugCommon
    {

        //コマンドの情報を出力する。commandNameは未指定の場合定数で保持しているものを出力する
        public static StringBuilder OutEntity(List<GitCommandEntity> _in, string[] commandNameAry, bool isOutSynopsis = true, bool isOutOptions = true)
        {
            if (_in is null || commandNameAry is null)
            {
                throw new ArgumentNullException("引数がnullです");
            }

            //戻り値用の文字列.　コンソールに出力する内容と同じもの
            StringBuilder outText = new StringBuilder();
#nullable enable
            GitCommandEntity? target;
            foreach (var command in commandNameAry)
            {
                target = Retrieval.GetEntityByCommand(_in, command) ?? new GitCommandEntity();

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
}
