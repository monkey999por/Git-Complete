using Git_Complete.src.entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Git_Complete.src.common
{
    class RetrieveEntity
    {
        public static GitCommandEntity retrieveGitCommandEntity(string command)
        {
            var list = FullBurst.getInstance().commandAndOptionsList;

            foreach (var entity in list)
            {
                if (! entity.gitCommand.Equals(command)){ continue; }
                return entity;
            }
        return null;
        }
    }
}
