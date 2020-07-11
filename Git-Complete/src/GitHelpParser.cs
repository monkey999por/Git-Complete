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
        private const String helpUrlbase = @"https://git-scm.com/docs/";


        public async Task<List<GitCommandEntity>> GetSynopsisAsync(List<GitCommandEntity> _in)
        {

            //戻り値初期化
            var ret = new List<GitCommandEntity>();

            var config = Configuration.Default;
            var context = BrowsingContext.New(config);
            IDocument document;
            IHtmlCollection<IElement> synopsisList;
            List<String> synopsis = null;

            //helpファイルの読み込んでDomを構築
            using (var client = new HttpClient())
            {
                var command = "";
                foreach (var entity in _in)
                {
                    command = entity.command;
                    synopsis = new List<string>();
                    using (var stream = await client.GetStreamAsync(new Uri(helpUrlbase + "git-" + command)))
                    {
                        document = await context.OpenAsync(req => req.Content(stream));

                        //get synopsis
                        synopsisList = document.QuerySelector("#_synopsis").ParentElement.QuerySelectorAll(".content");
                        foreach (var e in synopsisList)
                        {
                            synopsis.Add(e.TextContent);
                        }
                        entity.synopsis = synopsis;
                        ret.Add(entity);

                        Console.WriteLine(command);

                        foreach (var item in synopsis)
                        {
                            Console.WriteLine("   " + item);
                        }
                    }
                }
            }
            return ret;
        }
    }
}
