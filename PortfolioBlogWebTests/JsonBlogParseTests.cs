using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using System.IO;
using PortfolioBlog.Models;
using PortfolioBlog.Models.JsonBlogParse;

namespace PortfolioBlogLibraryTests
{

    class JsonBlogParseTests
    {
        private BlogParser blogParser;
        private Blog blog1;
        private Blog blog2;

        [SetUp]
        public void SetUpTest()
        {
            blogParser = new BlogParser();
            string blog1_json_string = File.ReadAllText(@"C:\Users\User\Documents\Code\PortfolioBlog\PortfolioWebTests\JsonTestBlogs\test_blog_1.json");
            string blog2_json_string = File.ReadAllText(@"C:\Users\User\Documents\Code\PortfolioBlog\PortfolioWebTests\JsonTestBlogs\test_blog_2.json");
            blog1 = blogParser.GetBlog(blog1_json_string);
            blog2 = blogParser.GetBlog(blog2_json_string);
        }
        [Test]
        public void TestCorrectId()
        {
            Assert.AreEqual(blog1.Id, 1);
            Assert.AreEqual(blog2.Id, 2);

        }
        
        [Test]
        public void TestCorrectTitle()
        {
            Assert.AreEqual(blog1.Title, "test blog 1");
            Assert.AreEqual(blog2.Title, "test blog 2");
        }

        [Test]
        public void TestCorrectContent()
        {
            Assert.AreEqual(blog1.Content,"this is the content of test blog 1 with 1 new line \n this is the content of test blog 1 with 1 new line " );
            Assert.AreEqual(blog1.Content, "this is the content of test blog 2 with 2 new line \n this is the content of test blog 2 with 2 new line ");
        }




    }
}
