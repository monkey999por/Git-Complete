using Git_Complete.src.entity;
using Git_Complete.src.props;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Git_Complete.src.function.scrape
{
    class SynopsisIndividualScraper : IndividualScraper
    {
        /// <summary>
        /// 受け取ったコマンドごとの個別スクレイプ
        /// 
        /// </summary>
        /// <param name="command">ターゲットコマンド</param>
        /// <returns></returns>
        public override List<string> ScrapeBy(string command)
        {
            CommonScraper cs = new SynopsisCommonScraper();

            var ret = new List<string>();

            switch (command)
            {
                case "annotate": Console.WriteLine("synopsis個別解析: " + command); ret = cs.ScrapeBy(command); break;
                case "blame": Console.WriteLine("synopsis個別解析: " + command); ret = cs.ScrapeBy(command); break;
                case "rerere": Console.WriteLine("synopsis個別解析: " + command); ret = cs.ScrapeBy(command); break;
                case "bugreport": Console.WriteLine("synopsis個別解析: " + command); ret = cs.ScrapeBy(command); break;
                case "count-objects": Console.WriteLine("synopsis個別解析: " + command); ret = cs.ScrapeBy(command); break;
                case "difftool": Console.WriteLine("synopsis個別解析: " + command); ret = cs.ScrapeBy(command); break;
                case "fsck": Console.WriteLine("synopsis個別解析: " + command); ret = cs.ScrapeBy(command); break;
                case "help": Console.WriteLine("synopsis個別解析: " + command); ret = cs.ScrapeBy(command); break;
                case "instaweb": Console.WriteLine("synopsis個別解析: " + command); ret = cs.ScrapeBy(command); break;
                case "merge-tree": Console.WriteLine("synopsis個別解析: " + command); ret = cs.ScrapeBy(command); break;
                case "show-branch": Console.WriteLine("synopsis個別解析: " + command); ret = cs.ScrapeBy(command); break;
                case "verify-commit": Console.WriteLine("synopsis個別解析: " + command); ret = cs.ScrapeBy(command); break;
                case "verify-tag": Console.WriteLine("synopsis個別解析: " + command); ret = cs.ScrapeBy(command); break;
                case "reflog": Console.WriteLine("synopsis個別解析: " + command); ret = cs.ScrapeBy(command); break;
                case "remote": Console.WriteLine("synopsis個別解析: " + command); ret = cs.ScrapeBy(command); break;
                case "repack": Console.WriteLine("synopsis個別解析: " + command); ret = cs.ScrapeBy(command); break;
                case "replace": Console.WriteLine("synopsis個別解析: " + command); ret = cs.ScrapeBy(command); break;
                case "config": Console.WriteLine("synopsis個別解析: " + command); ret = cs.ScrapeBy(command); break;
                case "filter-branch": Console.WriteLine("synopsis個別解析: " + command); ret = cs.ScrapeBy(command); break;
                case "mergetool": Console.WriteLine("synopsis個別解析: " + command); ret = cs.ScrapeBy(command); break;
                case "pack-refs": Console.WriteLine("synopsis個別解析: " + command); ret = cs.ScrapeBy(command); break;
                case "prune": Console.WriteLine("synopsis個別解析: " + command); ret = cs.ScrapeBy(command); break;
                case "svn": Console.WriteLine("synopsis個別解析: " + command); ret = cs.ScrapeBy(command); break;
                case "archimport": Console.WriteLine("synopsis個別解析: " + command); ret = cs.ScrapeBy(command); break;
                case "cvsexportcommit": Console.WriteLine("synopsis個別解析: " + command); ret = cs.ScrapeBy(command); break;
                case "cvsimport": Console.WriteLine("synopsis個別解析: " + command); ret = cs.ScrapeBy(command); break;
                case "imap-send": Console.WriteLine("synopsis個別解析: " + command); ret = cs.ScrapeBy(command); break;
                case "p4": Console.WriteLine("synopsis個別解析: " + command); ret = cs.ScrapeBy(command); break;
                case "quiltimport": Console.WriteLine("synopsis個別解析: " + command); ret = cs.ScrapeBy(command); break;
                case "request-pull": Console.WriteLine("synopsis個別解析: " + command); ret = cs.ScrapeBy(command); break;
                case "send-email": Console.WriteLine("synopsis個別解析: " + command); ret = cs.ScrapeBy(command); break;
                case "bisect": Console.WriteLine("synopsis個別解析: " + command); ret = cs.ScrapeBy(command); break;
                case "format-patch": Console.WriteLine("synopsis個別解析: " + command); ret = cs.ScrapeBy(command); break;
                case "init": Console.WriteLine("synopsis個別解析: " + command); ret = cs.ScrapeBy(command); break;
                case "rm": Console.WriteLine("synopsis個別解析: " + command); ret = cs.ScrapeBy(command); break;
                case "show": Console.WriteLine("synopsis個別解析: " + command); ret = cs.ScrapeBy(command); break;
                case "stash": Console.WriteLine("synopsis個別解析: " + command); ret = cs.ScrapeBy(command); break;
                case "archive": Console.WriteLine("synopsis個別解析: " + command); ret = cs.ScrapeBy(command); break;
                case "describe": Console.WriteLine("synopsis個別解析: " + command); ret = cs.ScrapeBy(command); break;
                case "shortlog": Console.WriteLine("synopsis個別解析: " + command); ret = cs.ScrapeBy(command); break;
                case "clean": Console.WriteLine("synopsis個別解析: " + command); ret = cs.ScrapeBy(command); break;
                case "pull": Console.WriteLine("synopsis個別解析: " + command); ret = cs.ScrapeBy(command); break;
                case "reset": Console.WriteLine("synopsis個別解析: " + command); ret = cs.ScrapeBy(command); break;
                case "add": Console.WriteLine("synopsis個別解析: " + command); ret = cs.ScrapeBy(command); break;
                case "am": Console.WriteLine("synopsis個別解析: " + command); ret = cs.ScrapeBy(command); break;
                case "branch": Console.WriteLine("synopsis個別解析: " + command); ret = cs.ScrapeBy(command); break;
                case "bundle": Console.WriteLine("synopsis個別解析: " + command); ret = cs.ScrapeBy(command); break;
                case "checkout": Console.WriteLine("synopsis個別解析: " + command); ret = cs.ScrapeBy(command); break;
                case "cherry-pick": Console.WriteLine("synopsis個別解析: " + command); ret = cs.ScrapeBy(command); break;
                case "citool": Console.WriteLine("synopsis個別解析: " + command); ret = cs.ScrapeBy(command); break;
                case "clone": Console.WriteLine("synopsis個別解析: " + command); ret = cs.ScrapeBy(command); break;
                case "commit": Console.WriteLine("synopsis個別解析: " + command); ret = cs.ScrapeBy(command); break;
                case "diff": Console.WriteLine("synopsis個別解析: " + command); ret = cs.ScrapeBy(command); break;
                case "fetch": Console.WriteLine("synopsis個別解析: " + command); ret = cs.ScrapeBy(command); break;
                case "gc": Console.WriteLine("synopsis個別解析: " + command); ret = cs.ScrapeBy(command); break;
                case "grep": Console.WriteLine("synopsis個別解析: " + command); ret = cs.ScrapeBy(command); break;
                case "gui": Console.WriteLine("synopsis個別解析: " + command); ret = cs.ScrapeBy(command); break;
                case "log": Console.WriteLine("synopsis個別解析: " + command); ret = cs.ScrapeBy(command); break;
                case "merge": Console.WriteLine("synopsis個別解析: " + command); ret = cs.ScrapeBy(command); break;
                case "mv": Console.WriteLine("synopsis個別解析: " + command); ret = cs.ScrapeBy(command); break;
                case "notes": Console.WriteLine("synopsis個別解析: " + command); ret = cs.ScrapeBy(command); break;
                case "push": Console.WriteLine("synopsis個別解析: " + command); ret = cs.ScrapeBy(command); break;
                case "range-diff": Console.WriteLine("synopsis個別解析: " + command); ret = cs.ScrapeBy(command); break;
                case "rebase": Console.WriteLine("synopsis個別解析: " + command); ret = cs.ScrapeBy(command); break;
                case "restore": Console.WriteLine("synopsis個別解析: " + command); ret = cs.ScrapeBy(command); break;
                case "revert": Console.WriteLine("synopsis個別解析: " + command); ret = cs.ScrapeBy(command); break;
                case "sparse-checkout": Console.WriteLine("synopsis個別解析: " + command); ret = cs.ScrapeBy(command); break;
                case "status": Console.WriteLine("synopsis個別解析: " + command); ret = cs.ScrapeBy(command); break;
                case "submodule": Console.WriteLine("synopsis個別解析: " + command); ret = cs.ScrapeBy(command); break;
                case "switch": Console.WriteLine("synopsis個別解析: " + command); ret = cs.ScrapeBy(command); break;
                case "tag": Console.WriteLine("synopsis個別解析: " + command); ret = cs.ScrapeBy(command); break;
                case "worktree": Console.WriteLine("synopsis個別解析: " + command); ret = cs.ScrapeBy(command); break;
                case "diff-tree": Console.WriteLine("synopsis個別解析: " + command); ret = cs.ScrapeBy(command); break;
                case "get-tar-commit-id": Console.WriteLine("synopsis個別解析: " + command); ret = cs.ScrapeBy(command); break;
                case "rev-parse": Console.WriteLine("synopsis個別解析: " + command); ret = cs.ScrapeBy(command); break;
                case "cat-file": Console.WriteLine("synopsis個別解析: " + command); ret = cs.ScrapeBy(command); break;
                case "cherry": Console.WriteLine("synopsis個別解析: " + command); ret = cs.ScrapeBy(command); break;
                case "diff-files": Console.WriteLine("synopsis個別解析: " + command); ret = cs.ScrapeBy(command); break;
                case "diff-index": Console.WriteLine("synopsis個別解析: " + command); ret = cs.ScrapeBy(command); break;
                case "for-each-ref": Console.WriteLine("synopsis個別解析: " + command); ret = cs.ScrapeBy(command); break;
                case "ls-files": Console.WriteLine("synopsis個別解析: " + command); ret = cs.ScrapeBy(command); break;
                case "ls-remote": Console.WriteLine("synopsis個別解析: " + command); ret = cs.ScrapeBy(command); break;
                case "ls-tree": Console.WriteLine("synopsis個別解析: " + command); ret = cs.ScrapeBy(command); break;
                case "merge-base": Console.WriteLine("synopsis個別解析: " + command); ret = cs.ScrapeBy(command); break;
                case "name-rev": Console.WriteLine("synopsis個別解析: " + command); ret = cs.ScrapeBy(command); break;
                case "pack-redundant": Console.WriteLine("synopsis個別解析: " + command); ret = cs.ScrapeBy(command); break;
                case "rev-list": Console.WriteLine("synopsis個別解析: " + command); ret = cs.ScrapeBy(command); break;
                case "show-index": Console.WriteLine("synopsis個別解析: " + command); ret = cs.ScrapeBy(command); break;
                case "show-ref": Console.WriteLine("synopsis個別解析: " + command); ret = cs.ScrapeBy(command); break;
                case "unpack-file": Console.WriteLine("synopsis個別解析: " + command); ret = cs.ScrapeBy(command); break;
                case "var": Console.WriteLine("synopsis個別解析: " + command); ret = cs.ScrapeBy(command); break;
                case "verify-pack": Console.WriteLine("synopsis個別解析: " + command); ret = cs.ScrapeBy(command); break;
                case "commit-tree": Console.WriteLine("synopsis個別解析: " + command); ret = cs.ScrapeBy(command); break;
                case "hash-object": Console.WriteLine("synopsis個別解析: " + command); ret = cs.ScrapeBy(command); break;
                case "read-tree": Console.WriteLine("synopsis個別解析: " + command); ret = cs.ScrapeBy(command); break;
                case "symbolic-ref": Console.WriteLine("synopsis個別解析: " + command); ret = cs.ScrapeBy(command); break;
                case "index-pack": Console.WriteLine("synopsis個別解析: " + command); ret = cs.ScrapeBy(command); break;
                case "prune-packed": Console.WriteLine("synopsis個別解析: " + command); ret = cs.ScrapeBy(command); break;
                case "mktree": Console.WriteLine("synopsis個別解析: " + command); ret = cs.ScrapeBy(command); break;
                case "apply": Console.WriteLine("synopsis個別解析: " + command); ret = cs.ScrapeBy(command); break;
                case "checkout-index": Console.WriteLine("synopsis個別解析: " + command); ret = cs.ScrapeBy(command); break;
                case "commit-graph": Console.WriteLine("synopsis個別解析: " + command); ret = cs.ScrapeBy(command); break;
                case "merge-file": Console.WriteLine("synopsis個別解析: " + command); ret = cs.ScrapeBy(command); break;
                case "merge-index": Console.WriteLine("synopsis個別解析: " + command); ret = cs.ScrapeBy(command); break;
                case "mktag": Console.WriteLine("synopsis個別解析: " + command); ret = cs.ScrapeBy(command); break;
                case "multi-pack-index": Console.WriteLine("synopsis個別解析: " + command); ret = cs.ScrapeBy(command); break;
                case "pack-objects": Console.WriteLine("synopsis個別解析: " + command); ret = cs.ScrapeBy(command); break;
                case "unpack-objects": Console.WriteLine("synopsis個別解析: " + command); ret = cs.ScrapeBy(command); break;
                case "update-index": Console.WriteLine("synopsis個別解析: " + command); ret = cs.ScrapeBy(command); break;
                case "update-ref": Console.WriteLine("synopsis個別解析: " + command); ret = cs.ScrapeBy(command); break;
                case "write-tree": Console.WriteLine("synopsis個別解析: " + command); ret = cs.ScrapeBy(command); break;
                case "check-ref-format": Console.WriteLine("synopsis個別解析: " + command); ret = cs.ScrapeBy(command); break;
                case "merge-one-file": Console.WriteLine("synopsis個別解析: " + command); ret = cs.ScrapeBy(command); break;
                case "patch-id": Console.WriteLine("synopsis個別解析: " + command); ret = cs.ScrapeBy(command); break;
                case "column": Console.WriteLine("synopsis個別解析: " + command); ret = cs.ScrapeBy(command); break;
                case "mailsplit": Console.WriteLine("synopsis個別解析: " + command); ret = cs.ScrapeBy(command); break;
                case "check-attr": Console.WriteLine("synopsis個別解析: " + command); ret = cs.ScrapeBy(command); break;
                case "check-ignore": Console.WriteLine("synopsis個別解析: " + command); ret = cs.ScrapeBy(command); break;
                case "check-mailmap": Console.WriteLine("synopsis個別解析: " + command); ret = cs.ScrapeBy(command); break;
                case "credential": Console.WriteLine("synopsis個別解析: " + command); ret = cs.ScrapeBy(command); break;
                case "fmt-merge-msg": Console.WriteLine("synopsis個別解析: " + command); ret = cs.ScrapeBy(command); break;
                case "interpret-trailers": Console.WriteLine("synopsis個別解析: " + command); ret = cs.ScrapeBy(command); break;
                case "mailinfo": Console.WriteLine("synopsis個別解析: " + command); ret = cs.ScrapeBy(command); break;
                case "stripspace": Console.WriteLine("synopsis個別解析: " + command); ret = cs.ScrapeBy(command); break;
                case "receive-pack": Console.WriteLine("synopsis個別解析: " + command); ret = cs.ScrapeBy(command); break;
                case "http-fetch": Console.WriteLine("synopsis個別解析: " + command); ret = cs.ScrapeBy(command); break;
                case "http-push": Console.WriteLine("synopsis個別解析: " + command); ret = cs.ScrapeBy(command); break;
                case "upload-archive": Console.WriteLine("synopsis個別解析: " + command); ret = cs.ScrapeBy(command); break;
                case "upload-pack": Console.WriteLine("synopsis個別解析: " + command); ret = cs.ScrapeBy(command); break;
                case "daemon": Console.WriteLine("synopsis個別解析: " + command); ret = cs.ScrapeBy(command); break;
                case "fetch-pack": Console.WriteLine("synopsis個別解析: " + command); ret = cs.ScrapeBy(command); break;
                case "http-backend": Console.WriteLine("synopsis個別解析: " + command); ret = cs.ScrapeBy(command); break;
                case "send-pack": Console.WriteLine("synopsis個別解析: " + command); ret = cs.ScrapeBy(command); break;
                case "update-server-info": Console.WriteLine("synopsis個別解析: " + command); ret = cs.ScrapeBy(command); break;
                case "stage": Console.WriteLine("synopsis個別解析: " + command); ret = cs.ScrapeBy(command); break;


                default:
                    break;
            }
            return ret;

        }
        /// <inheritdoc/>
        public override ECommandKeyScrape ScrapeBy(ECommandKeyScrape _in)
        {
            if (CommonProps.SYNOPSIS_INDEVIDUAL_SCRAPE_COMMAND.Contains(_in.command))
            {
                var ret = new ECommandKeyScrape(_in);
                ret.synopsis = ScrapeBy(ret.command);
                return ret;
            }
            return _in;
        }

    }
}
