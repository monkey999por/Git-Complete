using Git_Complete.src.entity;
using Git_Complete.src.props;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Git_Complete.src.function.scrape
{
    class OptionsIndividualScraper : IndividualScraper
    {
        /// <summary>
        /// 受け取ったコマンドごとの個別スクレイプ
        /// 
        /// </summary>
        /// <param name="command">ターゲットコマンド</param>
        /// <returns></returns>
        public override List<string> ScrapeBy(string command)
        {
            CommonScraper cs = new OptionsCommonScraper();

            //return value
            var ret = new List<string>();

            switch (command)
            {
                case "annotate": Console.WriteLine("options個別解析: " + command); ret = cs.ScrapeBy(command); break;
                case "blame": Console.WriteLine("options個別解析: " + command); ret = cs.ScrapeBy(command); break;
                case "rerere": Console.WriteLine("options個別解析: " + command);

                    
                    
                    break;
                case "bugreport": Console.WriteLine("options個別解析: " + command); ret = cs.ScrapeBy(command); break;
                case "count-objects": Console.WriteLine("options個別解析: " + command); ret = cs.ScrapeBy(command); break;
                case "difftool": Console.WriteLine("options個別解析: " + command); ret = cs.ScrapeBy(command); break;
                case "fsck": Console.WriteLine("options個別解析: " + command); ret = cs.ScrapeBy(command); break;
                case "help": Console.WriteLine("options個別解析: " + command); ret = cs.ScrapeBy(command); break;
                case "instaweb": Console.WriteLine("options個別解析: " + command); ret = cs.ScrapeBy(command); break;
                case "merge-tree": Console.WriteLine("options個別解析: " + command); ret = cs.ScrapeBy(command); break;
                case "show-branch": Console.WriteLine("options個別解析: " + command); ret = cs.ScrapeBy(command); break;
                case "verify-commit": Console.WriteLine("options個別解析: " + command); ret = cs.ScrapeBy(command); break;
                case "verify-tag": Console.WriteLine("options個別解析: " + command); ret = cs.ScrapeBy(command); break;
                case "whatchanged": Console.WriteLine("options個別解析: " + command); ret = cs.ScrapeBy(command); break;
                case "reflog": Console.WriteLine("options個別解析: " + command); ret = cs.ScrapeBy(command); break;
                case "remote": Console.WriteLine("options個別解析: " + command); ret = cs.ScrapeBy(command); break;
                case "repack": Console.WriteLine("options個別解析: " + command); ret = cs.ScrapeBy(command); break;
                case "replace": Console.WriteLine("options個別解析: " + command); ret = cs.ScrapeBy(command); break;
                case "config": Console.WriteLine("options個別解析: " + command); ret = cs.ScrapeBy(command); break;
                case "filter-branch": Console.WriteLine("options個別解析: " + command); ret = cs.ScrapeBy(command); break;
                case "mergetool": Console.WriteLine("options個別解析: " + command); ret = cs.ScrapeBy(command); break;
                case "pack-refs": Console.WriteLine("options個別解析: " + command); ret = cs.ScrapeBy(command); break;
                case "prune": Console.WriteLine("options個別解析: " + command); ret = cs.ScrapeBy(command); break;
                case "svn": Console.WriteLine("options個別解析: " + command); ret = cs.ScrapeBy(command); break;
                case "archimport": Console.WriteLine("options個別解析: " + command); ret = cs.ScrapeBy(command); break;
                case "cvsexportcommit": Console.WriteLine("options個別解析: " + command); ret = cs.ScrapeBy(command); break;
                case "cvsimport": Console.WriteLine("options個別解析: " + command); ret = cs.ScrapeBy(command); break;
                case "imap-send": Console.WriteLine("options個別解析: " + command); ret = cs.ScrapeBy(command); break;
                case "p4": Console.WriteLine("options個別解析: " + command); ret = cs.ScrapeBy(command); break;
                case "quiltimport": Console.WriteLine("options個別解析: " + command); ret = cs.ScrapeBy(command); break;
                case "request-pull": Console.WriteLine("options個別解析: " + command); ret = cs.ScrapeBy(command); break;
                case "send-email": Console.WriteLine("options個別解析: " + command); ret = cs.ScrapeBy(command); break;
                case "bisect": Console.WriteLine("options個別解析: " + command); ret = cs.ScrapeBy(command); break;
                case "format-patch": Console.WriteLine("options個別解析: " + command); ret = cs.ScrapeBy(command); break;
                case "init": Console.WriteLine("options個別解析: " + command); ret = cs.ScrapeBy(command); break;
                case "rm": Console.WriteLine("options個別解析: " + command); ret = cs.ScrapeBy(command); break;
                case "show": Console.WriteLine("options個別解析: " + command); ret = cs.ScrapeBy(command); break;
                case "stash": Console.WriteLine("options個別解析: " + command); ret = cs.ScrapeBy(command); break;
                case "archive": Console.WriteLine("options個別解析: " + command); ret = cs.ScrapeBy(command); break;
                case "describe": Console.WriteLine("options個別解析: " + command); ret = cs.ScrapeBy(command); break;
                case "shortlog": Console.WriteLine("options個別解析: " + command); ret = cs.ScrapeBy(command); break;
                case "clean": Console.WriteLine("options個別解析: " + command); ret = cs.ScrapeBy(command); break;
                case "pull": Console.WriteLine("options個別解析: " + command); ret = cs.ScrapeBy(command); break;
                case "reset": Console.WriteLine("options個別解析: " + command); ret = cs.ScrapeBy(command); break;
                case "add": Console.WriteLine("options個別解析: " + command); ret = cs.ScrapeBy(command); break;
                case "am": Console.WriteLine("options個別解析: " + command); ret = cs.ScrapeBy(command); break;
                case "branch": Console.WriteLine("options個別解析: " + command); ret = cs.ScrapeBy(command); break;
                case "bundle": Console.WriteLine("options個別解析: " + command); ret = cs.ScrapeBy(command); break;
                case "checkout": Console.WriteLine("options個別解析: " + command); ret = cs.ScrapeBy(command); break;
                case "cherry-pick": Console.WriteLine("options個別解析: " + command); ret = cs.ScrapeBy(command); break;
                case "citool": Console.WriteLine("options個別解析: " + command); ret = cs.ScrapeBy(command); break;
                case "clone": Console.WriteLine("options個別解析: " + command); ret = cs.ScrapeBy(command); break;
                case "commit": Console.WriteLine("options個別解析: " + command); ret = cs.ScrapeBy(command); break;
                case "diff": Console.WriteLine("options個別解析: " + command); ret = cs.ScrapeBy(command); break;
                case "fetch": Console.WriteLine("options個別解析: " + command); ret = cs.ScrapeBy(command); break;
                case "gc": Console.WriteLine("options個別解析: " + command); ret = cs.ScrapeBy(command); break;
                case "grep": Console.WriteLine("options個別解析: " + command); ret = cs.ScrapeBy(command); break;
                case "gui": Console.WriteLine("options個別解析: " + command); ret = cs.ScrapeBy(command); break;
                case "log": Console.WriteLine("options個別解析: " + command); ret = cs.ScrapeBy(command); break;
                case "merge": Console.WriteLine("options個別解析: " + command); ret = cs.ScrapeBy(command); break;
                case "mv": Console.WriteLine("options個別解析: " + command); ret = cs.ScrapeBy(command); break;
                case "notes": Console.WriteLine("options個別解析: " + command); ret = cs.ScrapeBy(command); break;
                case "push": Console.WriteLine("options個別解析: " + command); ret = cs.ScrapeBy(command); break;
                case "range-diff": Console.WriteLine("options個別解析: " + command); ret = cs.ScrapeBy(command); break;
                case "rebase": Console.WriteLine("options個別解析: " + command); ret = cs.ScrapeBy(command); break;
                case "restore": Console.WriteLine("options個別解析: " + command); ret = cs.ScrapeBy(command); break;
                case "revert": Console.WriteLine("options個別解析: " + command); ret = cs.ScrapeBy(command); break;
                case "sparse-checkout": Console.WriteLine("options個別解析: " + command); ret = cs.ScrapeBy(command); break;
                case "status": Console.WriteLine("options個別解析: " + command); ret = cs.ScrapeBy(command); break;
                case "submodule": Console.WriteLine("options個別解析: " + command); ret = cs.ScrapeBy(command); break;
                case "switch": Console.WriteLine("options個別解析: " + command); ret = cs.ScrapeBy(command); break;
                case "tag": Console.WriteLine("options個別解析: " + command); ret = cs.ScrapeBy(command); break;
                case "worktree": Console.WriteLine("options個別解析: " + command); ret = cs.ScrapeBy(command); break;
                case "diff-tree": Console.WriteLine("options個別解析: " + command); ret = cs.ScrapeBy(command); break;
                case "get-tar-commit-id": Console.WriteLine("options個別解析: " + command); ret = cs.ScrapeBy(command); break;
                case "rev-parse": Console.WriteLine("options個別解析: " + command); ret = cs.ScrapeBy(command); break;
                case "cat-file": Console.WriteLine("options個別解析: " + command); ret = cs.ScrapeBy(command); break;
                case "cherry": Console.WriteLine("options個別解析: " + command); ret = cs.ScrapeBy(command); break;
                case "diff-files": Console.WriteLine("options個別解析: " + command); ret = cs.ScrapeBy(command); break;
                case "diff-index": Console.WriteLine("options個別解析: " + command); ret = cs.ScrapeBy(command); break;
                case "for-each-ref": Console.WriteLine("options個別解析: " + command); ret = cs.ScrapeBy(command); break;
                case "ls-files": Console.WriteLine("options個別解析: " + command); ret = cs.ScrapeBy(command); break;
                case "ls-remote": Console.WriteLine("options個別解析: " + command); ret = cs.ScrapeBy(command); break;
                case "ls-tree": Console.WriteLine("options個別解析: " + command); ret = cs.ScrapeBy(command); break;
                case "merge-base": Console.WriteLine("options個別解析: " + command); ret = cs.ScrapeBy(command); break;
                case "name-rev": Console.WriteLine("options個別解析: " + command); ret = cs.ScrapeBy(command); break;
                case "pack-redundant": Console.WriteLine("options個別解析: " + command); ret = cs.ScrapeBy(command); break;
                case "rev-list": Console.WriteLine("options個別解析: " + command); ret = cs.ScrapeBy(command); break;
                case "show-index": Console.WriteLine("options個別解析: " + command); ret = cs.ScrapeBy(command); break;
                case "show-ref": Console.WriteLine("options個別解析: " + command); ret = cs.ScrapeBy(command); break;
                case "unpack-file": Console.WriteLine("options個別解析: " + command); ret = cs.ScrapeBy(command); break;
                case "var": Console.WriteLine("options個別解析: " + command); ret = cs.ScrapeBy(command); break;
                case "verify-pack": Console.WriteLine("options個別解析: " + command); ret = cs.ScrapeBy(command); break;
                case "commit-tree": Console.WriteLine("options個別解析: " + command); ret = cs.ScrapeBy(command); break;
                case "hash-object": Console.WriteLine("options個別解析: " + command); ret = cs.ScrapeBy(command); break;
                case "read-tree": Console.WriteLine("options個別解析: " + command); ret = cs.ScrapeBy(command); break;
                case "symbolic-ref": Console.WriteLine("options個別解析: " + command); ret = cs.ScrapeBy(command); break;
                case "index-pack": Console.WriteLine("options個別解析: " + command); ret = cs.ScrapeBy(command); break;
                case "prune-packed": Console.WriteLine("options個別解析: " + command); ret = cs.ScrapeBy(command); break;
                case "mktree": Console.WriteLine("options個別解析: " + command); ret = cs.ScrapeBy(command); break;
                case "apply": Console.WriteLine("options個別解析: " + command); ret = cs.ScrapeBy(command); break;
                case "checkout-index": Console.WriteLine("options個別解析: " + command); ret = cs.ScrapeBy(command); break;
                case "commit-graph": Console.WriteLine("options個別解析: " + command); ret = cs.ScrapeBy(command); break;
                case "merge-file": Console.WriteLine("options個別解析: " + command); ret = cs.ScrapeBy(command); break;
                case "merge-index": Console.WriteLine("options個別解析: " + command); ret = cs.ScrapeBy(command); break;
                case "mktag": Console.WriteLine("options個別解析: " + command); ret = cs.ScrapeBy(command); break;
                case "multi-pack-index": Console.WriteLine("options個別解析: " + command); ret = cs.ScrapeBy(command); break;
                case "pack-objects": Console.WriteLine("options個別解析: " + command); ret = cs.ScrapeBy(command); break;
                case "unpack-objects": Console.WriteLine("options個別解析: " + command); ret = cs.ScrapeBy(command); break;
                case "update-index": Console.WriteLine("options個別解析: " + command); ret = cs.ScrapeBy(command); break;
                case "update-ref": Console.WriteLine("options個別解析: " + command); ret = cs.ScrapeBy(command); break;
                case "write-tree": Console.WriteLine("options個別解析: " + command); ret = cs.ScrapeBy(command); break;
                case "check-ref-format": Console.WriteLine("options個別解析: " + command); ret = cs.ScrapeBy(command); break;
                case "merge-one-file": Console.WriteLine("options個別解析: " + command); ret = cs.ScrapeBy(command); break;
                case "patch-id": Console.WriteLine("options個別解析: " + command); ret = cs.ScrapeBy(command); break;
                case "column": Console.WriteLine("options個別解析: " + command); ret = cs.ScrapeBy(command); break;
                case "mailsplit": Console.WriteLine("options個別解析: " + command); ret = cs.ScrapeBy(command); break;
                case "check-attr": Console.WriteLine("options個別解析: " + command); ret = cs.ScrapeBy(command); break;
                case "check-ignore": Console.WriteLine("options個別解析: " + command); ret = cs.ScrapeBy(command); break;
                case "check-mailmap": Console.WriteLine("options個別解析: " + command); ret = cs.ScrapeBy(command); break;
                case "credential": Console.WriteLine("options個別解析: " + command); ret = cs.ScrapeBy(command); break;
                case "fmt-merge-msg": Console.WriteLine("options個別解析: " + command); ret = cs.ScrapeBy(command); break;
                case "interpret-trailers": Console.WriteLine("options個別解析: " + command); ret = cs.ScrapeBy(command); break;
                case "mailinfo": Console.WriteLine("options個別解析: " + command); ret = cs.ScrapeBy(command); break;
                case "stripspace": Console.WriteLine("options個別解析: " + command); ret = cs.ScrapeBy(command); break;
                case "receive-pack": Console.WriteLine("options個別解析: " + command); ret = cs.ScrapeBy(command); break;
                case "http-fetch": Console.WriteLine("options個別解析: " + command); ret = cs.ScrapeBy(command); break;
                case "http-push": Console.WriteLine("options個別解析: " + command); ret = cs.ScrapeBy(command); break;
                case "upload-archive": Console.WriteLine("options個別解析: " + command); ret = cs.ScrapeBy(command); break;
                case "upload-pack": Console.WriteLine("options個別解析: " + command); ret = cs.ScrapeBy(command); break;
                case "daemon": Console.WriteLine("options個別解析: " + command); ret = cs.ScrapeBy(command); break;
                case "fetch-pack": Console.WriteLine("options個別解析: " + command); ret = cs.ScrapeBy(command); break;
                case "http-backend": Console.WriteLine("options個別解析: " + command); ret = cs.ScrapeBy(command); break;
                case "send-pack": Console.WriteLine("options個別解析: " + command); ret = cs.ScrapeBy(command); break;
                case "update-server-info": Console.WriteLine("options個別解析: " + command); ret = cs.ScrapeBy(command); break;
                case "stage": Console.WriteLine("options個別解析: " + command); ret = cs.ScrapeBy(command); break;

                default:
                    break;
            }
            return ret;
        }

        /// <inheritdoc/>
        public override ECommandKeyScrape ScrapeBy(ECommandKeyScrape _in)
        {
            if (CommonProps.OPTIONS_INDEVIDUAL_SCRAPE_COMMAND.Contains(_in.command))
            {
                var ret = new ECommandKeyScrape(_in);
                ret.options = ScrapeBy(ret.command);
                return ret;
            }
            return _in;

        }
    }
}
