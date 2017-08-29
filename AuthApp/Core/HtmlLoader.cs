using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using AuthApp.Core.Interfaces;

namespace AuthApp.Core
{
    public class HtmlLoader
    {
        private readonly string _url;
        private readonly HttpClient _client;

        public HtmlLoader(IParserSettings parserSettings)
        {
            _client = new HttpClient();
            _url = $"{parserSettings.BaseUrl}/{parserSettings.Prefix}";
        }

        public async Task<string> GetSource(string searchWord, int? page = null)
        {
            var pagePrefix = page.HasValue && page.Value != 0 ? $"&page={page.Value}" : string.Empty;
            var url = $"{_url}={searchWord}{pagePrefix}";
            var response = await _client.GetAsync(url);
            string source = null;
            if (response != null && response.StatusCode == HttpStatusCode.OK)
            {
                source = await response.Content.ReadAsStringAsync();
            }

            return source;
        }
    }
}