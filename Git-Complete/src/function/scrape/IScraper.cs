using Git_Complete.src.entity;
using System.Collections.Generic;

namespace Git_Complete.src.function.scrape
{
    public interface IScraper
    {
        public List<string> ScrapeBy(string command);

        public EGitCommand ScrapeBy(EGitCommand _in);

        public void ScrapeBy(EGitCommandList<EGitCommand> _in);
    }
}
