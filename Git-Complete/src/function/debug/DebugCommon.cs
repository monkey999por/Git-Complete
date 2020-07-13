using Git_Complete.src.entity;
using Git_Complete.src.entity.props;
using System;
using System.Collections.Generic;
using System.Text;

namespace Git_Complete.src.function.debug
{
    class DebugCommon
    {

        //コマンドの情報を出力する。commandNameは未指定の場合定数で保持しているものを出力する
        public static void ConsoleOut<T>(T _in, string[] commandNameAry, bool isOutSynopsis = true, bool isOutOptions = true)
        {
            if (_in is null || commandNameAry is null)
            {
                throw new ArgumentNullException();
            }

            string type = DebugCommon.TypeCheck(_in);

            if (typeof(List<GitCommandEntity>).FullName.Equals(type))
            {

                foreach (var command in commandNameAry)
                {

                    foreach (var item in _in as List<GitCommandEntity>)
                    {
                        if (command.Equals(item.command))
                        {
                            Console.WriteLine(item.command);

                            if (isOutSynopsis)
                            {
                                foreach (var temp in item.synopsis) { Console.WriteLine("    " + nameof(item.synopsis) + ": " + temp); }
                            }

                            if (isOutOptions)
                            {
                                if (item.options != null)
                                {
                                    foreach (var temp in item.options) { Console.WriteLine("    " + nameof(item.options) + ": " + temp); }
                                }
                            }
                            break;
                        }
                    }
                }
            }
            else if (typeof(List<ParsedEntity>).FullName.Equals(type))
            {
                foreach (var command in commandNameAry)
                {
                    foreach (var item in _in as List<ParsedEntity>)
                    {
                        if (command.Equals(item.command))
                        {
                            Console.WriteLine(item.command);

                            if (isOutSynopsis)
                            {
                                foreach (var temp in item.parsedSynopsis) { Console.WriteLine("    " + nameof(item.parsedSynopsis) + ": " + temp); }
                            }

                            if (isOutOptions)
                            {
                                if (item.parsedOptions != null)
                                {
                                    foreach (var temp in item.parsedOptions) { Console.WriteLine("    " + nameof(item.parsedOptions) + ": " + temp); }
                                }
                            }
                            break;
                        }
                    }
                }
            }
        }


        private static string TypeCheck(Object o)
        {
            bool isTypeOfGitCommandEntityList = typeof(List<GitCommandEntity>).FullName.Equals(o.GetType().FullName);
            bool isTypeOfParsedEntityList = typeof(List<ParsedEntity>).FullName.Equals(o.GetType().FullName);

            if (isTypeOfGitCommandEntityList || isTypeOfParsedEntityList)
            {
                if (isTypeOfGitCommandEntityList)
                {
                    return typeof(List<GitCommandEntity>).FullName;
                }
                else if (isTypeOfParsedEntityList)
                {
                    return typeof(List<ParsedEntity>).FullName;
                }
                else
                {
                    throw new Exception("論外");
                }
            }
            else
            {
                throw new ArgumentException(
                    "この関数の引数は" + typeof(List<GitCommandEntity>).FullName + "、もしくは" + typeof(List<ParsedEntity>).FullName + "を期待しています。" +
                    "\r\n渡された値の型: " + o.GetType().FullName
                );
            }
        }
    }
}
