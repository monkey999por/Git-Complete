﻿using System;
using System.Collections.Generic;
using System.Text;
using AngleSharp;
using AngleSharp.Html.Parser;
using System.IO;
using Git_Complete.src.entity;

namespace Git_Complete.src
{
    class GitHelpParser
    {
        //gitのコマンドオプションは、下記のクラス名の中に定義されている。
        string gitCommandOptionClassName = "hdlist1";
        private string gitHelpFile = @"C:\Program Files\Git\mingw64\share\doc\git-doc\git-help.html";

        public async System.Threading.Tasks.Task GetGitOptions(string gitHelpFileDirPath, List<GitCommandAndOptionsEntity> entityList)
        {
            if (string.IsNullOrEmpty(gitHelpFileDirPath))
            {
                throw new ArgumentException("gitのヘルプファイルのパスが不正です", nameof(gitHelpFileDirPath));
            }

            if (entityList is null)
            {
                throw new ArgumentNullException(nameof(entityList));
            }

            //helpファイルの読み込み
            var config = Configuration.Default;
            var context = BrowsingContext.New(config);
            string source;
            using (var reader = new StreamReader(gitHelpFile))
            {
                source = reader.ReadToEnd();
            }

            AngleSharp.Dom.IDocument document = await context.OpenAsync(req => req.Content(source));

            //使用可能なオプションリストの取得
            var gitOptions = document.GetElementsByClassName(gitCommandOptionClassName).GetEnumerator();

            //取得したコマンドとオプションをentityListに詰め込む処理
            //test
            string gitCommand = "help";
            var entity = new GitCommandAndOptionsEntity();
            entity.gitCommand = gitCommand;
            while (gitOptions.MoveNext())
            {
                entity.gitOptionList.Add(gitOptions.Current.InnerHtml);
            }
            entityList.Add(entity);
        }
    }
}
