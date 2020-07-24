using Git_Complete.src.entity;
using System;

namespace Git_Complete.src.props
{
    class PathProps
    {

        /// <summary>
        /// instanceのシリアライズ・デシリアライズ先のディレクトリパス。
        /// </summary>
        public const string INSTANCE_DIR = @"C:\develop\Git-Complete\Git-Complete\instance\";


        public const String HELP_SCRAPE_XML_Path = PathProps.INSTANCE_DIR + nameof(ECommandKey) + "_HelpScrapeList.xml";

        public const String HELP_SCRAPE_JSON_Path = PathProps.INSTANCE_DIR + nameof(ECommandKey) + "_HelpScrapeList.JSON";


        /// <summary>
        /// 自動生成されるpowershellソース、DLL等の出力先カレント
        /// </summary>
        public const string OUT_DIR = @"C:\develop\Git-Complete\Git-Complete\out\";



    }
}
