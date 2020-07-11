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

        public List<GitCommandEntity> gitCommandEntityList = new List<GitCommandEntity>();

        private MainEntity() { }

        public static MainEntity getInstance()
        {
            return mainEntity;
        }

        




    }
}
