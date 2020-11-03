using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Cache;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace PortfolioBlogLibrary.GitScraper
{
    public class GitHubScraper : IGitHubScraper
    {
        private HttpClient _httpClient;
     
        public GitHubScraper(HttpClient httpClient)
        {
            _httpClient = httpClient;

        }

        public string GetUserUrl(string userName) => "https://github.com" + "/" + userName + "?tab=repositories";
        public string GetReadmeUrl(string repoName) => "https://github.com" +  repoName + "/blob/master/README.md";

        public IList<string> ProcessHtmlToList(string html, string xpath, Func<HtmlNode, string> whichNodes)
        {
            HtmlDocument htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(html);
            return htmlDocument
                .DocumentNode
                .SelectNodes(xpath)
                .Select(whichNodes)
                .ToList();
        }

        public string ProcessHtmlToString(string html, string xpath)
        {
            HtmlDocument htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(html);
            return htmlDocument
                .DocumentNode
                .SelectSingleNode(xpath)
                .OuterHtml;        
        }
       
        public async Task<string> GetHtmlString(string url)
        {
            try
            {
                return await _httpClient.GetStringAsync(url);
               
            }
            catch(HttpRequestException e)
            {
                throw e;
            }
                                   
        }


     
    }
}

