using Git_Complete.src.function.common;
using Git_Complete.src.entity;
using Git_Complete.src.props;
using Git_Complete.src.entity.temp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Git_Complete.src.parser
{
    class GitEntityParser
    {

        //GitCommandEntityをもとに整形したsynopsisを返す
        public static List<ParsedEntity> ParseSynopsis(List<EHelpScrape> _in)
        {
            /*
            //test out synopsis to text file 
            {
                string[] commands = new string[_in.Count];
                var i = 0;
                foreach (var item in _in)
                {
                    commands[i] = item.command;
                    i++;
                }
                StringBuilder temp = _in.OutEntity(commands);
                File.Delete(PathProps.OUT_DIR + "synopsis.txt");
                File.AppendAllText(PathProps.OUT_DIR + "synopsis.txt", temp.ToString(), Encoding.UTF8);

            }
            */

            //test out synopsis to xml
            {
                MultipleKeyList<string> temp = new MultipleKeyList<string>();
                List<MultipleKeyList<string>> temp2 = new List<MultipleKeyList<string>>();

                foreach (var item in _in)
                {
                    temp2.Add(new MultipleKeyList<string>(item.command, item.synopsis));
                }

                FileCommon.OutFileTo<List<MultipleKeyList<String>>>(temp2, PathProps.OUT_DIR + "synopsis.xml");
            }
            

            return default(List<ParsedEntity>);

        }
    }
}
