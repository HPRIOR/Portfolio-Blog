using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc;
using PortfolioBlog.Models;
using PortfolioBlogLibrary.GitScraper;

namespace PortfolioBlog.Controllers
{
    public class ProjectsController : Controller
    {
        HttpClient _client;
        IGitHubScraper _gitHubScraper;
        public ProjectsController(HttpClient client, IGitHubScraper gitHubScraper)
        {
            _gitHubScraper = gitHubScraper;
            _client = client;
        }
        
            
        public async Task<IActionResult> Index()
        {
            var htmlString = await _gitHubScraper.GetHtmlString(_gitHubScraper.GetUserUrl("HPRIOR"));
            var repoList = _gitHubScraper
                .ProcessHtmlToList(
                htmlString, 
                "//*[@id='user-repositories-list']/ul/li/div/div/h3/a", 
                node => node.GetAttributeValue("href", "default")
                );

            var models = repoList.ToList().Select(title => new Project { Title = title });

            return View(models);
        }

        public async Task<IActionResult> ProjectReadMe(Project project)
        {
            try
            {
                var readMeUrl = _gitHubScraper.GetReadmeUrl(project.Title);
                var htmlString = await _gitHubScraper.GetHtmlString(readMeUrl);
                project.ReadMe = _gitHubScraper.ProcessHtmlToString(htmlString, "//*[@id='readme']");

            }
            catch(HttpRequestException)
            {
                project.ReadMe = "This project repository does not contain a readme";
            }
                       
            return View(project);
        }
    }
}
