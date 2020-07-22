using Git_Complete.src.entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Git_Complete.src.function.scrape
{
    interface IScraper
    {

        public List<string> ScrapeBy(string command);

        public EGitCommand ScrapeBy(EGitCommand _in);

        public EGitCommandList<EGitCommand> ScrapeBy(EGitCommandList<EGitCommand> _in);
    }
}
