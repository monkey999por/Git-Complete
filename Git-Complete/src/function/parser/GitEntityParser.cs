using Git_Complete.src.entity;
using Git_Complete.src.function.debug;
using System;
using System.Collections.Generic;
using System.Text;

namespace Git_Complete.src.function.parser
{
    class GitEntityParser
    {

        //GitCommandEntityをもとに
        public static List<ParsedEntity> parseSynopsis(List<GitCommandEntity> _in)
        {
            DebugCommon.ConsoleOut<List<GitCommandEntity>>(_in, new string[] { "commit" });
            
            

            return default(List<ParsedEntity>);

        }
    }
}
