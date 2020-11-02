using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace PortfolioBlog.Models
{
    public static class HtmlHelper
    {
        public static async Task<string> GetHtmlString(string url)
        {
            using var client = new HttpClient();

            var HtmlString = await client.GetStringAsync(url);
            return HtmlString;
        }

        public static string GetHtmlSection(string url, string xpath)
        {
            var htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(GetHtmlString(url).Result);

            return htmlDoc.DocumentNode.SelectSingleNode(xpath).OuterHtml;



        }
    }
}
