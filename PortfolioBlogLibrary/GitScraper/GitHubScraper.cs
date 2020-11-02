using System;
using System.Collections.Generic;
using System.Text;

namespace PortfolioBlogLibrary.GitScraper
{
    public class GitHubScraper : IGitHubScraper
    {

        public IList<string> GetReadMeStrings()
        {
            return new List<string>() { "Hello world" };
        }
    }
}
