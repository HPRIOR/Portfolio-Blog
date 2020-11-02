using System;
using System.Collections.Generic;
using System.Text;

namespace PortfolioBlogLibrary.GitScraper
{
    interface IGitHubScraper
    {
        IList<string> GetReadMeStrings();
    }
}

