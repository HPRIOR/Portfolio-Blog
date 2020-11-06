using System.Text.Json;

namespace PortfolioBlog.Models.JsonBlogParse
{
    public interface IBlogParser
    {
        Blog GetBlog(string json);

    }
}
