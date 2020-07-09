using System;
using System.Collections.Generic;
using System.Text;

namespace Git_Complete.src.entity
{
    [Serializable]
    class GitSummarizedToList
    {
        //singleton 
        private static GitSummarizedToList forCommandEntity = new GitSummarizedToList();

        public List<GitCommandEntity> gitCommandEntityList = new List<GitCommandEntity>();

        private GitSummarizedToList() { }

        public static GitSummarizedToList getInstance()
        {
            return forCommandEntity;
        }

        




    }
}
