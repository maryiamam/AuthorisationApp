using System.Linq;
using System.Threading.Tasks;
using AuthApp.Models.ViewModels;
using System.Web.Mvc;
using AngleSharp.Dom.Html;
using AngleSharp.Parser.Html;
using AuthApp.Core;
using AuthApp.Core.BelChip;
using AuthApp.Core.Interfaces;
using AuthApp.Core.RuChildip;

namespace AuthApp.Controllers
{
    public class SearchController : Controller
    {
        [HttpPost]
        public async Task<ActionResult> SearchResult(SearchViewModel searchModel)
        {
            var data = await GetResults(searchModel);
            return View("SearchResult", data);
        }

        [HttpPost]
        public async Task<JsonResult> GetSearchResults(SearchViewModel searchModel)
        {
            var data = await GetResults(searchModel);
            return Json(data);
        }

        #region Private Methods

        private async Task<SearchResultViewModel> GetResults(SearchViewModel searchModel)
        {
            var ruChildipData = await GetRuChildipResults(searchModel);
            var belChipData = await GetBelchipResults(searchModel);
            var result = new SearchResultViewModel
            {
                Hints = ruChildipData.Hints.Concat(belChipData.Hints),
                SearchString = searchModel.Phrase,
                TotalCount = ruChildipData.TotalCount + belChipData.TotalCount
            };

            return result;
        }

        private async Task<SearchResultViewModel> GetRuChildipResults(SearchViewModel searchModel)
        {
            var parserSettings = new RuChildipParserSettings();
            var document = await GetDocument(parserSettings, searchModel);
            var parser = new RuChipdipParser(parserSettings.BaseUrl);
            SearchResultViewModel data = parser.Parse(document);
            return data;
        }

        private async Task<SearchResultViewModel> GetBelchipResults(SearchViewModel searchModel)
        {
            var parserSettings = new BelChipParserSettings();
            var document = await GetDocument(parserSettings, searchModel);
            var parser = new BelChipParser(parserSettings.BaseUrl, searchModel.Page);
            SearchResultViewModel data = parser.Parse(document);
            return data;
        }

        private async Task<IHtmlDocument> GetDocument(IParserSettings parserSettings, SearchViewModel searchModel)
        {
            var htmlLoader = new HtmlLoader(parserSettings);
            var source = await htmlLoader.GetSource(searchModel.Phrase);
            var domParser = new HtmlParser();
            var document = await domParser.ParseAsync(source);
            return document;
        }

        #endregion

    }
}