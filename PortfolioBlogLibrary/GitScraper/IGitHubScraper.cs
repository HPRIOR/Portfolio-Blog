using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PortfolioBlogLibrary.GitScraper
{
    public interface IGitHubScraper
    {   
        Task<string> GetHtmlString(string href);
        IList<string> ProcessHtmlToList(string html, string xpath, Func<HtmlNode, string> whichNodes);
        string ProcessHtmlToString(string html, string xpath);
        string GetUserUrl(string user);
        string GetReadmeUrl(string repoName);
        


    }
}

