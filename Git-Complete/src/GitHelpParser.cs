using System;
using System.Collections.Generic;
using System.Text;
using AngleSharp;
using AngleSharp.Html.Parser;
using System.IO;
using Git_Complete.src.entity;
using System.Threading.Tasks;
using AngleSharp.Dom;
using AngleSharp.Html.Dom;
using System.ComponentModel;
using System.Net.Http;
using System.Diagnostics;

namespace Git_Complete.src
{
    class GitHelpParser
    {
        private const String helpUrlbase = @"https://git-scm.com/docs/git-add";


        public async Task<MainEntity> GetSynopsisAsync()
        {
            Console.WriteLine("start");

            var config = Configuration.Default;
            var context = BrowsingContext.New(config);
            IDocument document;

            //helpファイルの読み込んでDomを構築
            using (var client = new HttpClient())
            using (var stream = await client.GetStreamAsync(new Uri(helpUrlbase)))
            {
                document = await context.OpenAsync(req => req.Content(stream));
            }

            Console.WriteLine("ggg");



            //get synopsis
            var synopsis = document.QuerySelector("#_synopsis").ParentElement.QuerySelector(".content").InnerHtml;


            synopsis += "testaaa";
            Console.WriteLine("next");

            Console.WriteLine(synopsis);

            return default(MainEntity);

        }


        /*
        public async System.Threading.Tasks.Task GetGitOptions(List<GitCommandAndHelpFilePathEntity> inEntityList, List<GitCommandEntity> entityListOut)
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
                var entity = new GitCommandEntity(inEntity.gitCommand);
                while (gitOptions.MoveNext())
                {
                    entity.options.Add(gitOptions.Current.InnerHtml);
                }
                entityListOut.Add(entity);
            }
        }
        */
    }
}
