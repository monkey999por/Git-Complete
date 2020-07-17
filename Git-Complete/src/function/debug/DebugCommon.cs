using Git_Complete.src.entity;
using Git_Complete.src.props;
using System;
using System.Collections.Generic;
using System.Text;

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
            foreach (var command in commandNameAry)
            {

                foreach (var item in _in as List<GitCommandEntity>)
                {
                    if (command.Equals(item.command))
                    {
                        Console.WriteLine("■" + item.command);
                        outText.Append("■" + item.command + Environment.NewLine);

                        if (isOutSynopsis)
                        {
                            foreach (var temp in item.synopsis)
                            {
                                Console.WriteLine("    " + nameof(item.synopsis) + ": " + temp);
                                outText.Append("    " + nameof(item.synopsis) + ": " + temp + Environment.NewLine);
                            }

                        }

                        if (isOutOptions)
                        {
                            if (item.options != null)
                            {
                                foreach (var temp in item.options)
                                {
                                    Console.WriteLine("    " + nameof(item.options) + ": " + temp);
                                    outText.Append("    " + nameof(item.options) + ": " + temp + Environment.NewLine);
                                }

                            }
                        }
                        break;
                    }
                }
            }

            return outText;
        }
    }
}
