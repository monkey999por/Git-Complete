using AngleSharp;
using AngleSharp.Dom;
using Git_Complete.src.entity;
using Git_Complete.src.props;
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
        /// key   : command
        /// value : git help Document Dom
        /// <see cref=">GetHelpDocsDom"/>
        /// </summary>
        private static Dictionary<String, IDocument> _helpDocsDom = null;

        public GitHelpParser()
        {
            _helpDocsDom = GetHelpDocsDomDic(CommonProps.ALL_COMMAND);
        }

        /// <summary>
        /// 引数のコマンド名と一致するヘルプファイルのDomを返す
        /// </summary>
        /// <param name="command">key</param>
        /// <returns></returns>
        public static IDocument GetHelpDocsDom(string command)
        {
            if (_helpDocsDom is null)
            {
                //ヘルプファイルのDomを取得
                Task<Dictionary<String, IDocument>> task = (Task<Dictionary<String, IDocument>>)Task.Run(() =>
                {
                    return GitHelpParser.CreateHelpDocsDomAll();
                });
                _helpDocsDom = task.Result;
            }

            return _helpDocsDom[command];
        }

        /// <summary>
        /// 引数のコマンド名配列と一致するヘルプファイル辞書のDomを返す
        /// </summary>
        /// <param name="commands">key</param>
        /// <returns></returns>
        public static Dictionary<String, IDocument> GetHelpDocsDomDic(string[] commands)
        {
            var ret = new Dictionary<String, IDocument>();
            foreach (var command in commands)
            {
                ret.Add(command, GetHelpDocsDom(command));
            }
            return ret;
        }

        /// <summary>
        /// Gitの公式Help(https://git-scm.com/docs/git-{command})のコマンドごとのDomを取得し、フィールド:<c>_helpDocsDom</c>に保存する
        /// </summary>
        /// <returns></returns>
        private static async Task<Dictionary<string, IDocument>> CreateHelpDocsDomAll()
        {
            if (_helpDocsDom != null) { return _helpDocsDom; }

            _helpDocsDom = new Dictionary<string, IDocument>();

            var config = Configuration.Default;
            var context = BrowsingContext.New(config);

            IDocument document;
            //helpファイルの読み込んでDomを構築
            using (var client = new HttpClient())
                foreach (var command in CommonProps.ALL_COMMAND)
                {
                    using var stream = await client.GetStreamAsync(new Uri(_helpUrlBase + "git-" + command));
                    document = await context.OpenAsync(req => req.Content(stream));
                    _helpDocsDom.Add(command, document);
                }
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

            //synopsisを読み込む
            foreach (var entity in ret)
            {
                //ヘルプファイルのDomを取得
                var document = GetHelpDocsDom(entity.command);

                synopsisList = document.QuerySelector("#_synopsis").ParentElement.QuerySelectorAll(".content");

                List<string> synopsis = new List<string>();

                foreach (var e in synopsisList)
                    synopsis.Add(e.TextContent);
                entity.synopsis = synopsis;
            }
            return ret;
        }

        public EGitCommand GetSynopsis(EGitCommand _in)
        {
            var ret = new EGitCommand(_in);

            //ヘルプファイルのDomを取得
            var document = GetHelpDocsDom(ret.command);

            IHtmlCollection<IElement> synopsisList = document.QuerySelector("#_synopsis").ParentElement.QuerySelectorAll(".content");

            List<string> synopsis = new List<string>();

            foreach (var e in synopsisList)
                synopsis.Add(e.TextContent);
            ret.synopsis = synopsis;

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
            List<string> options = null;

            //optionを読み込む
            foreach (var entity in ret)
            {
                //ヘルプファイルのDomを取得
                var document = GetHelpDocsDom(entity.command);

                //get synopsis
                var temp = document.QuerySelector("#_options");
                if (temp is null)
                    continue;

                optionsList = temp.ParentElement.QuerySelectorAll(".hdlist1");

                options = new List<string>();
                foreach (var e in optionsList)
                    options.Add(e.TextContent);

                entity.options = options;
            }
            return ret;
        }
    }
}
