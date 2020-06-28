using System;
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

        public async System.Threading.Tasks.Task GetGitOptions(List<GitCommandAndHelpFilePathEntity> inEntityList, List<GitCommandAndOptionsEntity> entityListOut)
        {

            if (inEntityList is null)
            {
                throw new ArgumentNullException(nameof(inEntityList));
            }
            if (entityListOut is null)
            {
                throw new ArgumentNullException(nameof(entityListOut));
            }

            var config = Configuration.Default;
            var context = BrowsingContext.New(config);
            string source;
            foreach (var inEntity in inEntityList)
            {
                //helpファイルの読み込んでDomを構築
                Console.WriteLine(inEntity.gitHelpFileFullPath);

                using (var reader = new StreamReader(inEntity.gitHelpFileFullPath))
                {
                    source = reader.ReadToEnd();
                }
                AngleSharp.Dom.IDocument document = await context.OpenAsync(req => req.Content(source));

                //使用可能なオプションリストの取得
                var gitOptions = document.GetElementsByClassName(gitCommandOptionClassName).GetEnumerator();

                //取得したコマンドとオプションをentityListに詰め込む処理
                var entity = new GitCommandAndOptionsEntity(inEntity.gitCommand);
                while (gitOptions.MoveNext())
                {
                    entity.gitOptionList.Add(gitOptions.Current.InnerHtml);
                }
                entityListOut.Add(entity);
            }
        }
    }
}
