using Git_Complete.src.entity;
using Git_Complete.src.entity.props;
using System;
using System.Collections.Generic;
using System.Text;

namespace Git_Complete.src.function.debug
{
    class DebugCommon
    {
        public static void ConsoleOut<T>(T _in)
        {
            if (_in is null)
            {
                throw new ArgumentNullException();
            }

            if (typeof(GitCommandEntity).FullName.Equals(_in.GetType().FullName) ||
                typeof(ParsedEntity).FullName.Equals(_in.GetType().FullName))
            {
                if (typeof(GitCommandEntity).FullName.Equals(_in.GetType().FullName))
                {
                    GitCommandEntity e = _in as GitCommandEntity;

                    foreach (var command in DebugProps.DEBUG_COMMAND_ARRAY)
                    {
                        if (command.Equals(e.command))
                        {
                            Console.WriteLine(e.command);
                            foreach (var temp in e.synopsis) { Console.WriteLine("    " + nameof(e.synopsis) + ": " + temp); }

                            if (e.options != null)
                            {
                                foreach (var temp in e.options) { Console.WriteLine("    " + nameof(e.options) + ": " + temp); }
                            }
                        }
                    }


                }
                else if (typeof(ParsedEntity).FullName.Equals(_in.GetType().FullName))
                {
                    ParsedEntity e = _in as ParsedEntity;

                    foreach (var command in DebugProps.DEBUG_COMMAND_ARRAY)
                    {
                        if (command.Equals(e.command))
                        {
                            Console.WriteLine(e.command);
                            foreach (var temp in e.parsedSynopsis) { Console.WriteLine("    " + nameof(e.parsedSynopsis) + ": " + temp); }

                            if (e.parsedOptions != null)
                            {
                                foreach (var temp in e.parsedOptions) { Console.WriteLine("    " + nameof(e.parsedOptions) + ": " + temp); }
                            }
                        }
                    }

                }
            }
            else
            {
                throw new ArgumentException(
                    "この関数の引数は" + nameof(GitCommandEntity) + "、もしくは" + nameof(ParsedEntity) + "を期待しています。" +
                    "\n渡された値の型: " + _in.GetType().ToString()
                );
            }
        }
    }
}
