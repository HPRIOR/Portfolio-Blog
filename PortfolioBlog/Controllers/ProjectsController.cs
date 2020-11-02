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
