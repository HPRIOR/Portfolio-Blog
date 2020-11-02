using NUnit.Framework;
using PortfolioBlogLibrary.GitScraper;
using System.Collections.Generic;

namespace PortfolioBlogLibraryTests
{
    public class GitHubScraperTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            GitHubScraper git = new GitHubScraper();
            Assert.AreEqual(git.GetReadMeStrings(), new List<string>() { "Hello world" });
        }
    }
}