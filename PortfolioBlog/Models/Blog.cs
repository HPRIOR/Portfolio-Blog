using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PortfolioBlogLibrary.JsonBlogParse;

namespace PortfolioBlog.Models
{
    public class Blog : IBlog
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
    }
}
