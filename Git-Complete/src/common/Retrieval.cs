using Git_Complete.src.entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Git_Complete.src.common
{
    class Retrieval
    {
        public static GitCommandEntity retrievalFrom(List<GitCommandEntity> entitys,String keyCommand)
        {
            if (entitys is null)
            {
                throw new Exception(nameof(entitys) + ":" + typeof(List<GitCommandEntity>) + "がnullです");
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
