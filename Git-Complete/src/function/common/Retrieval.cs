using Git_Complete.src.entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Git_Complete.src.function.common
{
    class Retrieval
    {
        public static EHelpScrape GetEntityByCommand(List<EHelpScrape> entitys,String keyCommand)
        {
            if (entitys is null)
            {
                throw new Exception(nameof(entitys) + ":" + typeof(List<EHelpScrape>) + "がnullです");
            }

            foreach (var entity in entitys)
            {
                if (entity.command.Equals(keyCommand))
                {
                    return entity;
                } 
            }
            return null;
        }
    }
}
