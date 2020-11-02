using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PortfolioBlog.Models;
using Newtonsoft.Json;
using System.IO;
using Newtonsoft.Json.Linq;
using System.Security.Cryptography.X509Certificates;

namespace PortfolioBlog.Controllers
{
    internal class JsonTitle
    {
        public string title { get; set; }
    }
    public class ProjectsController : Controller
    {

        public string GetUrl(string title)
            =>  $"https://github.com/HPRIOR/{title}/blob/master/README.md";
        
        private IList<string> GetTitles()
        {
            string jsonString = System.IO.File.ReadAllText(@"..\Json\git-titles.json");
            JObject jObject = JObject.Parse(jsonString);
            JArray jArray = (JArray)jObject["projects"];
            return jArray.ToObject<IList<JsonTitle>>().Select(x => x.title).ToList();             
        }
            
        public IActionResult Index()
        {

            var readMe = HtmlHelper.GetHtmlSection( "https://github.com/HPRIOR/PHP-XML-Translation/blob/master/README.md", "//*[@id='readme']/article");
            var projectModel = new Project();
            projectModel.ReadMe = readMe;
            return View(projectModel);
        }

        public IActionResult ProjectReadMe()
        {
            return View();
        }
    }
}
