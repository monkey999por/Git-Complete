using AngleSharp;
using AngleSharp.Dom;
using Git_Complete.src.props;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Git_Complete.function.parser
{

    /// <summary>
    /// Gitの公式ヘルプのDomを取得・保持する。
    /// </summary>
    public class GitHelpDocs
    {
        private const String HELP_URL_BASE = @"https://git-scm.com/docs/";

        /// <summary>
        /// key   : command
        /// value : git help Document Dom
        /// <see cref=">GetHelpDocsDom"/>
        /// </summary>
        private static Dictionary<String, IDocument> domDic = null;

        public GitHelpDocs()
        {
            if (domDic is null)
                domDic = GetDomDic(CommonProps.ALL_COMMAND);
        }

        /// <summary>
        /// 引数のコマンド名と一致するヘルプファイルのDomを返す
        /// </summary>
        /// <param name="command">key</param>
        /// <returns></returns>
        public IDocument GetDom(string command)
        {
            if (domDic is null)
            {
                //ヘルプファイルのDomを取得
                Task<Dictionary<String, IDocument>> task = (Task<Dictionary<String, IDocument>>)Task.Run(() =>
                {
                    return CreateDomAll();
                });
                domDic = task.Result;
            }
            return domDic[command];
        }

        /// <summary>
        /// 引数のコマンド名配列と一致するヘルプファイル辞書のDomを返す
        /// </summary>
        /// <param name="commands">key</param>
        /// <returns></returns>
        public Dictionary<String, IDocument> GetDomDic(string[] commands)
        {
            var ret = new Dictionary<String, IDocument>();
            foreach (var command in commands)
            {
                ret.Add(command, GetDom(command));
            }
            return ret;
        }

        /// <summary>
        /// Gitの公式Help(https://git-scm.com/docs/git-{command})のコマンドごとのDomを取得し、
        /// <see cref="domDic"/>保存する
        /// </summary>
        private async Task<Dictionary<string, IDocument>> CreateDomAll()
        {
            if (domDic != null) { return domDic; }

            domDic = new Dictionary<string, IDocument>();

            var config = Configuration.Default;
            var context = BrowsingContext.New(config);

            IDocument document;
            //helpファイルの読み込んでDomを構築
            using (var client = new HttpClient())
                foreach (var command in CommonProps.ALL_COMMAND)
                {
                    using var stream = await client.GetStreamAsync(new Uri(HELP_URL_BASE + "git-" + command));
                    document = await context.OpenAsync(req => req.Content(stream));
                    domDic.Add(command, document);
                }
            return domDic;
        }

    }
}
