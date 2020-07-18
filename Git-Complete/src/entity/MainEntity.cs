using System;
using System.Collections.Generic;
using System.Text;

namespace Git_Complete.src.entity
{
    [Serializable]
    class MainEntity
    {
        //singleton 
        private static MainEntity mainEntity = new MainEntity();

        //主にgitの公式ヘルプからスクレイピングした素のオプションやシナプスを保持
        public List<EHelpScrape> eHelpScrape = new List<EHelpScrape>();

        //解析後のgitのオプションやシナプスを保持
        public List<ParsedEntity> parsedEntities = new List<ParsedEntity>();

        private MainEntity() { }

        public static MainEntity getInstance()
        {
            return mainEntity;
        }
    }
}
