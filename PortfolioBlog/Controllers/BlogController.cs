using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting.Server.Features;
using Microsoft.AspNetCore.Mvc;
using PortfolioBlog.Models;
using Microsoft.AspNetCore.Hosting;
using PortfolioBlog.Models.JsonBlogParse;
using PortfolioBlogLibrary;
using System.Diagnostics;

namespace PortfolioBlog.Controllers
{
    public class BlogController : Controller
    {
        private readonly IWebHostEnvironment _hostingEnvironment;
        private IBlogParser _blogParser;
        public BlogController(IWebHostEnvironment hostEnv, IBlogParser blogParser)
        {
            _hostingEnvironment = hostEnv;
            _blogParser = blogParser;
        }
        public IActionResult DiplayBlog(Blog blog)
        {
            return View(blog);
        }

        public IActionResult Index()
        {
            var filePaths = Directory.GetFiles(_hostingEnvironment.ContentRootPath + @"\BlogPosts");
            filePaths.ForEach(x => Debug.WriteLine(x));
            // need to convert blog path to actuall json string
            IEnumerable<Blog> blogs = filePaths.Select(path => _blogParser.GetBlog(path));
            return View(blogs);
        }
    }
}
