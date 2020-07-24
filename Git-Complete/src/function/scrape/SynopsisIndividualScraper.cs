using Git_Complete.src.entity;
using System.Collections.Generic;

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
                case "annotate": ret = cs.ScrapeBy(command); break;
                case "blame": ret = cs.ScrapeBy(command); break;
                case "rerere": ret = cs.ScrapeBy(command); break;
                case "bugreport": ret = cs.ScrapeBy(command); break;
                case "count-objects": ret = cs.ScrapeBy(command); break;
                case "difftool": ret = cs.ScrapeBy(command); break;
                case "fsck": ret = cs.ScrapeBy(command); break;
                case "help": ret = cs.ScrapeBy(command); break;
                case "instaweb": ret = cs.ScrapeBy(command); break;
                case "merge-tree": ret = cs.ScrapeBy(command); break;
                case "show-branch": ret = cs.ScrapeBy(command); break;
                case "verify-commit": ret = cs.ScrapeBy(command); break;
                case "verify-tag": ret = cs.ScrapeBy(command); break;
                case "whatchanged": ret = cs.ScrapeBy(command); break;
                case "reflog": ret = cs.ScrapeBy(command); break;
                case "remote": ret = cs.ScrapeBy(command); break;
                case "repack": ret = cs.ScrapeBy(command); break;
                case "replace": ret = cs.ScrapeBy(command); break;
                case "config": ret = cs.ScrapeBy(command); break;
                case "filter-branch": ret = cs.ScrapeBy(command); break;
                case "mergetool": ret = cs.ScrapeBy(command); break;
                case "pack-refs": ret = cs.ScrapeBy(command); break;
                case "prune": ret = cs.ScrapeBy(command); break;
                case "svn": ret = cs.ScrapeBy(command); break;
                case "archimport": ret = cs.ScrapeBy(command); break;
                case "cvsexportcommit": ret = cs.ScrapeBy(command); break;
                case "cvsimport": ret = cs.ScrapeBy(command); break;
                case "imap-send": ret = cs.ScrapeBy(command); break;
                case "p4": ret = cs.ScrapeBy(command); break;
                case "quiltimport": ret = cs.ScrapeBy(command); break;
                case "request-pull": ret = cs.ScrapeBy(command); break;
                case "send-email": ret = cs.ScrapeBy(command); break;
                case "bisect": ret = cs.ScrapeBy(command); break;
                case "format-patch": ret = cs.ScrapeBy(command); break;
                case "init": ret = cs.ScrapeBy(command); break;
                case "rm": ret = cs.ScrapeBy(command); break;
                case "show": ret = cs.ScrapeBy(command); break;
                case "stash": ret = cs.ScrapeBy(command); break;
                case "archive": ret = cs.ScrapeBy(command); break;
                case "describe": ret = cs.ScrapeBy(command); break;
                case "shortlog": ret = cs.ScrapeBy(command); break;
                case "clean": ret = cs.ScrapeBy(command); break;
                case "pull": ret = cs.ScrapeBy(command); break;
                case "reset": ret = cs.ScrapeBy(command); break;
                case "add": ret = cs.ScrapeBy(command); break;
                case "am": ret = cs.ScrapeBy(command); break;
                case "branch": ret = cs.ScrapeBy(command); break;
                case "bundle": ret = cs.ScrapeBy(command); break;
                case "checkout": ret = cs.ScrapeBy(command); break;
                case "cherry-pick": ret = cs.ScrapeBy(command); break;
                case "citool": ret = cs.ScrapeBy(command); break;
                case "clone": ret = cs.ScrapeBy(command); break;
                case "commit": ret = cs.ScrapeBy(command); break;
                case "diff": ret = cs.ScrapeBy(command); break;
                case "fetch": ret = cs.ScrapeBy(command); break;
                case "gc": ret = cs.ScrapeBy(command); break;
                case "grep": ret = cs.ScrapeBy(command); break;
                case "gui": ret = cs.ScrapeBy(command); break;
                case "log": ret = cs.ScrapeBy(command); break;
                case "merge": ret = cs.ScrapeBy(command); break;
                case "mv": ret = cs.ScrapeBy(command); break;
                case "notes": ret = cs.ScrapeBy(command); break;
                case "push": ret = cs.ScrapeBy(command); break;
                case "range-diff": ret = cs.ScrapeBy(command); break;
                case "rebase": ret = cs.ScrapeBy(command); break;
                case "restore": ret = cs.ScrapeBy(command); break;
                case "revert": ret = cs.ScrapeBy(command); break;
                case "sparse-checkout": ret = cs.ScrapeBy(command); break;
                case "status": ret = cs.ScrapeBy(command); break;
                case "submodule": ret = cs.ScrapeBy(command); break;
                case "switch": ret = cs.ScrapeBy(command); break;
                case "tag": ret = cs.ScrapeBy(command); break;
                case "worktree": ret = cs.ScrapeBy(command); break;
                case "diff-tree": ret = cs.ScrapeBy(command); break;
                case "get-tar-commit-id": ret = cs.ScrapeBy(command); break;
                case "rev-parse": ret = cs.ScrapeBy(command); break;
                case "cat-file": ret = cs.ScrapeBy(command); break;
                case "cherry": ret = cs.ScrapeBy(command); break;
                case "diff-files": ret = cs.ScrapeBy(command); break;
                case "diff-index": ret = cs.ScrapeBy(command); break;
                case "for-each-ref": ret = cs.ScrapeBy(command); break;
                case "ls-files": ret = cs.ScrapeBy(command); break;
                case "ls-remote": ret = cs.ScrapeBy(command); break;
                case "ls-tree": ret = cs.ScrapeBy(command); break;
                case "merge-base": ret = cs.ScrapeBy(command); break;
                case "name-rev": ret = cs.ScrapeBy(command); break;
                case "pack-redundant": ret = cs.ScrapeBy(command); break;
                case "rev-list": ret = cs.ScrapeBy(command); break;
                case "show-index": ret = cs.ScrapeBy(command); break;
                case "show-ref": ret = cs.ScrapeBy(command); break;
                case "unpack-file": ret = cs.ScrapeBy(command); break;
                case "var": ret = cs.ScrapeBy(command); break;
                case "verify-pack": ret = cs.ScrapeBy(command); break;
                case "commit-tree": ret = cs.ScrapeBy(command); break;
                case "hash-object": ret = cs.ScrapeBy(command); break;
                case "read-tree": ret = cs.ScrapeBy(command); break;
                case "symbolic-ref": ret = cs.ScrapeBy(command); break;
                case "index-pack": ret = cs.ScrapeBy(command); break;
                case "prune-packed": ret = cs.ScrapeBy(command); break;
                case "mktree": ret = cs.ScrapeBy(command); break;
                case "apply": ret = cs.ScrapeBy(command); break;
                case "checkout-index": ret = cs.ScrapeBy(command); break;
                case "commit-graph": ret = cs.ScrapeBy(command); break;
                case "merge-file": ret = cs.ScrapeBy(command); break;
                case "merge-index": ret = cs.ScrapeBy(command); break;
                case "mktag": ret = cs.ScrapeBy(command); break;
                case "multi-pack-index": ret = cs.ScrapeBy(command); break;
                case "pack-objects": ret = cs.ScrapeBy(command); break;
                case "unpack-objects": ret = cs.ScrapeBy(command); break;
                case "update-index": ret = cs.ScrapeBy(command); break;
                case "update-ref": ret = cs.ScrapeBy(command); break;
                case "write-tree": ret = cs.ScrapeBy(command); break;
                case "check-ref-format": ret = cs.ScrapeBy(command); break;
                case "merge-one-file": ret = cs.ScrapeBy(command); break;
                case "patch-id": ret = cs.ScrapeBy(command); break;
                case "column": ret = cs.ScrapeBy(command); break;
                case "mailsplit": ret = cs.ScrapeBy(command); break;
                case "check-attr": ret = cs.ScrapeBy(command); break;
                case "check-ignore": ret = cs.ScrapeBy(command); break;
                case "check-mailmap": ret = cs.ScrapeBy(command); break;
                case "credential": ret = cs.ScrapeBy(command); break;
                case "fmt-merge-msg": ret = cs.ScrapeBy(command); break;
                case "interpret-trailers": ret = cs.ScrapeBy(command); break;
                case "mailinfo": ret = cs.ScrapeBy(command); break;
                case "stripspace": ret = cs.ScrapeBy(command); break;
                case "receive-pack": ret = cs.ScrapeBy(command); break;
                case "http-fetch": ret = cs.ScrapeBy(command); break;
                case "http-push": ret = cs.ScrapeBy(command); break;
                case "upload-archive": ret = cs.ScrapeBy(command); break;
                case "upload-pack": ret = cs.ScrapeBy(command); break;
                case "daemon": ret = cs.ScrapeBy(command); break;
                case "fetch-pack": ret = cs.ScrapeBy(command); break;
                case "http-backend": ret = cs.ScrapeBy(command); break;
                case "send-pack": ret = cs.ScrapeBy(command); break;
                case "update-server-info": ret = cs.ScrapeBy(command); break;
                case "stage": ret = cs.ScrapeBy(command); break;

                default:
                    break;
            }
            return ret;

        }

        public override ECommandKeyScrape ScrapeBy(ECommandKeyScrape _in)
        {
            var ret = new ECommandKeyScrape(_in);
            ret.synopsis = ScrapeBy(ret.command);
            return ret;
        }

    }
}
