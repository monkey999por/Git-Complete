using Git_Complete.src.common;
using Git_Complete.src.entity;
using Git_Complete.src.entity.props;
using Git_Complete.src.entity.temp;
using Git_Complete.src.function.debug;
using System;
using System.Collections.Generic;
using System.Text;

namespace Git_Complete.src.function.parser
{
    class GitEntityParser
    {

        //GitCommandEntityをもとに整形したシナプスを返す
        public static List<ParsedEntity> parseSynopsis(List<GitCommandEntity> _in)
        {
            DebugCommon.ConsoleOut<List<GitCommandEntity>>(_in, new string[] { "commit" }, isOutOptions:false);

            //test
            MultipleKeyList<string> temp = new MultipleKeyList<string>();
            List<MultipleKeyList<string>> temp2 = new List<MultipleKeyList<string>>();


            foreach (var item in _in)
            {
                temp2.Add(new MultipleKeyList<string>(item.command, item.synopsis));
            }

            FileCommon f = new FileCommon();
            f.OutFileTo<List<MultipleKeyList<String>>>(temp2,PathProps.OUT_DIR + "synopsis.xml");

            return default(List<ParsedEntity>);

        }
    }
}
