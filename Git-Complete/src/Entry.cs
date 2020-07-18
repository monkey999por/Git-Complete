using System;
using Git_Complete.src;
using Git_Complete.src.entity;
using System.Collections.Generic;
using Git_Complete.src.function.common;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using Git_Complete.function.parser;
using Git_Complete.src.function.parser;
using Git_Complete.src.function.debug;
using Git_Complete.src.props;

namespace Git_Complete
{
    class Entry
    {
        static void Main(string[] args)
        {
            //初期化
            MainEntity mainEntity = MainEntity.getInstance();
            var eHelpScrape = mainEntity.eHelpScrape;
            var parsedEntity = mainEntity.parsedEntities;

            String entityPath = PathProps.INSTANCE_DIR + nameof(EHelpScrape) + "_List.xml";
            String readPath = DebugProps.IS_MAKE_ENTITY_FROM_GIT_HELP ? 
                                PathProps.INSTANCE_DIR + nameof(EHelpScrape) + "_OnlyCommand.xml" : entityPath;

            //gitコマンドとオプションのリストを生成する。
            FileCommon fileCommon = new FileCommon();
            eHelpScrape = fileCommon.GetInstanceFrom<List<EHelpScrape>>(readPath);

            //なぜか↑の読み込みでおかしな文字コードの空白がxmlに付加されて、再度xmlを読もうとするとエラーになる
            //なので、ここで再書き込みする
            fileCommon.OutFileTo<List<EHelpScrape>>(eHelpScrape, readPath);

            //test
            if (!(eHelpScrape.Count == 136))
            {
                throw new Exception("コマンドの数があってない");
            }

            if (DebugProps.IS_MAKE_ENTITY_FROM_GIT_HELP)
            {

                var helpParser = new GitHelpParser();

                //git-scm.comから、synopsisを取得する（html parserを使用）
                eHelpScrape = helpParser.GetSynopsisAll(eHelpScrape);

                //git-scm.comから、オプションの一覧を取得する（html parserを使用）
                eHelpScrape = helpParser.GetOptionsAll(eHelpScrape);

                //xml出力
                fileCommon.OutFileTo<List<EHelpScrape>>(eHelpScrape, entityPath);
            }

            //MainEntityに保存する
            mainEntity.eHelpScrape = eHelpScrape;

            //debug
            if (DebugProps.DEGUB_MODE)
            {
                string[] inAry = new string[eHelpScrape.Count];
                var i = 0;
                foreach (var item in eHelpScrape)
                {
                    inAry[i] = item.command;
                    i++;
                }
                DebugCommon.OutEntity(eHelpScrape, inAry);

            }
            

            //synopsisを解析 -> パターンを検討し、生成するpowershellでどうやって使うかを検討する
            parsedEntity = GitEntityParser.ParseSynopsis(eHelpScrape);





            //optionsを解析 -> synopsisの解析結果と照らし合わせて、powershellソースに組み込む



            //出来上がったentityをもとに、powershellソースを自動生成する。

        }
    }
}
