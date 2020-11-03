using System;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Xml.Linq;
using PortfolioBlogLibrary.GitScraper;

namespace ConsoleTester
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            using var client = new HttpClient();
            GitHubScraper gitHubScraper = new GitHubScraper(client);
            var result = await gitHubScraper.GetHtmlString(gitHubScraper.GetUserUrl("HPRIOR"));
            var repoList = gitHubScraper.ProcessHtmlToList(result, "//*[@id='user-repositories-list']/ul/li/div/div/h3/a",  node => node.GetAttributeValue("href", "default"));
            /*repoList.ToList().ForEach(async repo =>
            {
                var repoURL = gitHubScraper.GetReadmeUrl(repo);
                Console.WriteLine(repoURL);
                var repoHtml = await gitHubScraper.GetHtmlString(repoURL);
                Console.Write(repoHtml);
                Console.WriteLine(gitHubScraper.ProcessHtmlToString(repoHtml, "//*[@id='readme']"));
            });*/
            try
            {
                var repoUrl = gitHubScraper.GetReadmeUrl(repoList[2]);
                Console.WriteLine(repoUrl);
                var repoHtml = await gitHubScraper.GetHtmlString(repoUrl);
                var readme = gitHubScraper.ProcessHtmlToString(repoHtml, "//*[@id='readme']");
                Console.WriteLine(readme);

            }
            catch(HttpRequestException)
            {
                Console.WriteLine("Uh OH");
            }
            
        }

    }
}
