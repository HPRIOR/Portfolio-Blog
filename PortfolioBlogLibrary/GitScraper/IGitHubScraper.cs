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
        public IList<string> ProcessHtmlToList(string html, string xpath, Func<HtmlNode, string> whichNodes);
        string GetUserUrl(string user);
        string GetReadmeUrl(string repoName);
        string ProcessHtmlToString(string html, string xpath);



    }
}

