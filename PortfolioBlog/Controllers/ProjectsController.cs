using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.AspNetCore.Mvc;
using PortfolioBlog.Models;
using PortfolioBlogLibrary.GitScraper;

namespace PortfolioBlog.Controllers
{
    public class ProjectsController : Controller
    {

        
            
        public IActionResult Index()
        {



            return View();
        }

        public IActionResult ProjectReadMe()
        {
            return View();
        }
    }
}
