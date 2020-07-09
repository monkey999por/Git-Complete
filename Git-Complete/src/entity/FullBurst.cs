using System;
using System.Collections.Generic;
using System.Text;

namespace Git_Complete.src.entity
{
    [Serializable]
    class FullBurst
    {
        //singleton 
        private static FullBurst forCommandEntity = new FullBurst();

        public List<GitCommandEntity> gitCommandEntityList = new List<GitCommandEntity>();

        private FullBurst() { }

        public static FullBurst getInstance()
        {
            return forCommandEntity;
        }

        




    }
}
