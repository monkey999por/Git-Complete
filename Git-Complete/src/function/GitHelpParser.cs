using AngleSharp;
using AngleSharp.Dom;
using Git_Complete.src.entity;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Git_Complete.function.parser
{
    class GitHelpParser
    {
        private const String _helpUrlBase = @"https://git-scm.com/docs/";

        /// <summary>
        /// <see cref=">GetHelpDocsDom"/>
        /// </summary>
        private static Dictionary<String, IDocument> _helpDocsDom = null;

        /// <summary>
        /// Gitの公式Help(https://git-scm.com/docs/git-{command})のコマンドごとのDomを取得し、フィールド:<c>_helpDocsDom</c>に保存する
        /// </summary>
        /// <param name="_in"></param>
        /// <returns></returns>
        private static async Task<Dictionary<string, IDocument>> GetHelpDocsDom(List<EGitCommand> _in)
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

        /// <summary>
        /// Gitの公式HelpからSysnopsisをスクレイピングする。
        /// 公式Helpは（おそらく）自動生成されているわけではなく、形式にばらつきがあるため、
        /// ここでは下記のルールでスクレイピングし、正常に取得できなかったものについては
        /// 別メソッドで個別に補正を行う。
        /// 
        /// ■ルール
        /// 取得URL : https://git-scm.com/docs/git-{command}(Dom)
        /// {id: _synopsis}を持った要素の親要素の中で、{class: .content}を持った項目すべて
        /// 
        /// 
        /// </summary>
        /// <param name="_in">コマンドが入っているinstance</param>
        /// <returns>引数にSynopsisのリストをセットしたもの（それ以外には影響なし）</returns>
        public List<EGitCommand> GetSynopsisAll(List<EGitCommand> _in)
        {

            //戻り値初期化(コピー)
            var ret = new List<EGitCommand>(_in);

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

                foreach (var e in synopsisList) { synopsis.Add(e.TextContent); }
                entity.synopsis = synopsis;
            }
            return ret;
        }

        /// <summary>
        /// <see cref="GetSynopsisAll(List{EGitCommand})"/>と同じ
        /// 取得ルールは下記。
        /// 
        /// ■ルール
        /// 取得URL : https://git-scm.com/docs/git-{command}(Dom)
        /// {id: _options}を持った要素の親要素の中で、{class: .hdlist1}を持った項目すべて
        /// 
        /// </summary>
        /// <param name="_in">コマンドが入っているinstance</param>
        /// <returns>引数にOptionsのリストをセットしたもの（それ以外には影響なし）</returns>
        public List<EGitCommand> GetOptionsAll(List<EGitCommand> _in)
        {

            //戻り値初期化
            var ret = new List<EGitCommand>(_in);

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
                    continue;

                optionsList = temp.ParentElement.QuerySelectorAll(".hdlist1");

                options = new List<string>();
                foreach (var e in optionsList) { options.Add(e.TextContent); }
                entity.options = options;
            }
            return ret;
        }
    }
}
