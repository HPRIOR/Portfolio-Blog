using System;
using System.Collections.Generic;
using System.Text;

namespace PortfolioBlogLibrary.GitScraper
{
    public interface IGitHubScraper
    {
        IList<string> GetReadMeStrings();
    }
}

