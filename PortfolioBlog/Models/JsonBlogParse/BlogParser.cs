using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using Newtonsoft.Json;

namespace PortfolioBlog.Models.JsonBlogParse
{
    public class BlogParser : IBlogParser
    {
        public Blog GetBlog(string json) 
            => JsonConvert.DeserializeObject<Blog>(json);


    }
}

