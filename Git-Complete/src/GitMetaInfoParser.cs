using System;
using System.Collections.Generic;
using System.Text;
using Git_Complete.src.entity;
using System.IO;

namespace Git_Complete.src
{

    /// <summary>
    /// gitのメタ情報(ヘルプファイルの場所とか名前とか)を解析するクラス
    /// 
    /// </summary>
    class GitMetaInfoParser
    {
        private string gitHelpFileDirPath = @"C:\Program Files\Git\mingw64\share\doc\git-doc\";
        private const string DOTHTML = ".html";

        // gitのヘルプファイルとコマンドの一覧を作成する
        public List<GitCommandEntity> CreatGitCommandAndHelpFilePathEntity()
        {
            //init
            List<GitCommandEntity> retEntity = new List<GitCommandEntity>();
            string[] helpFileArray = Directory.GetFiles(gitHelpFileDirPath, "git-*" + DOTHTML);

            //parse and add return list
            try
            {
                string commandName;
                foreach (string helpFile in helpFileArray)
                {
                    commandName = helpFile.Substring(gitHelpFileDirPath.Length, helpFile.Length - gitHelpFileDirPath.Length - DOTHTML.Length);

                    //このあたりのファイルはgitのコマンドのヘルプじゃない
                    if (commandName.Equals("git-bisect-lk2009") ||
                        commandName.Equals("git-credential-cache--daemon") ||
                        commandName.Equals("git-credential-cache") ||
                        commandName.Equals("git-mergetool--lib") ||
                        commandName.Equals("git-parse-remote") ||
                        commandName.Equals("git-remote-helpers") ||
                        commandName.Equals("git-shell") ||
                        commandName.Equals("git-tools") ||
                        commandName.Equals("git-sh-i18n") ||
                        commandName.Equals("git-sh-setup")
                        )
                    {
                        continue;
                    }
                    
                    //retEntity.Add(new GitCommandEntity(commandName, helpFile));
                }
            }
            catch (Exception)
            {
                throw new Exception();
            }

            return retEntity;

        }
    }
}
