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

namespace Git_Complete.function.parser
{
    class GitHelpParser
    {
        private const String _helpUrlBase = @"https://git-scm.com/docs/";

        private static Dictionary<String, IDocument> _helpDocsDom = null;

        private static async Task<Dictionary<string, IDocument>> GetHelpDocsDom(List<EHelpScrape> _in)
        {
            if (_helpDocsDom != null)
            {
                return _helpDocsDom;
            }

            //return value
            Dictionary<String, IDocument> helpDocs = new Dictionary<string, IDocument>();

            var config = Configuration.Default;
            var context = BrowsingContext.New(config);

            var command = "";
            IDocument document;
            //helpファイルの読み込んでDomを構築
            using (var client = new HttpClient())
                foreach (var entity in _in)
                {
                    command = entity.command;
                    using (var stream = await client.GetStreamAsync(new Uri(_helpUrlBase + "git-" + command)))
                    {
                        document = await context.OpenAsync(req => req.Content(stream));
                        helpDocs.Add(command, document);

                    }
                }
            _helpDocsDom = helpDocs;
            return _helpDocsDom;
        }

        public List<EHelpScrape> GetSynopsisAll(List<EHelpScrape> _in)
        {

            //戻り値初期化(コピー)
            var ret = new List<EHelpScrape>(_in);

            IHtmlCollection<IElement> synopsisList;
            List<String> synopsis = null;
            
            //ヘルプファイルのDomを取得
            Task<Dictionary<String, IDocument>> task = (Task<Dictionary<String, IDocument>>)Task.Run(() =>
            {
                return GitHelpParser.GetHelpDocsDom(ret);
            });
            Dictionary<String, IDocument> helpDocsDom = task.Result;

            //synopsisを読み込む
            foreach (var entity in ret)
            {
                //get synopsis
                var document = helpDocsDom[entity.command];

                synopsisList = document.QuerySelector("#_synopsis").ParentElement.QuerySelectorAll(".content");
                
                synopsis = new List<string>();

                foreach (var e in synopsisList)
                {
                    synopsis.Add(e.TextContent);
                }
                
                entity.synopsis = synopsis;

                Debug.WriteLine(entity.command);

                foreach (var item in synopsis)
                {
                    Debug.WriteLine("   " + item);
                }
            }
            return ret;
        }

        public List<EHelpScrape> GetOptionsAll(List<EHelpScrape> _in)
        {

            //戻り値初期化
            var ret = new List<EHelpScrape>(_in);

            IHtmlCollection<IElement> optionsList;
            List<String> options = null;

            //ヘルプファイルのDomを取得
            Task<Dictionary<String, IDocument>> task = (Task<Dictionary<String, IDocument>>)Task.Run(() =>
            {
                return GitHelpParser.GetHelpDocsDom(ret);
            });
            Dictionary<String, IDocument> helpDocsDom = task.Result;

            //optionを読み込む
            foreach (var entity in ret)
            {
                //get synopsis
                var document = helpDocsDom[entity.command];

                var temp = document.QuerySelector("#_options");
                if (temp is null)
                {
                    continue;
                }
                optionsList = temp.ParentElement.QuerySelectorAll(".hdlist1");

                options = new List<string>();
                foreach (var e in optionsList)
                {
                    options.Add(e.TextContent);
                }
                entity.options = options;

                Debug.WriteLine(entity.command);

                foreach (var item in options)
                {
                    Debug.WriteLine("   " + item);
                }
            }
            return ret;
        }
    }
}
