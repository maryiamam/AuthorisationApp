using System.Collections.Generic;
using System.Linq;
using AngleSharp.Dom.Html;
using AuthApp.Core.Interfaces;
using AuthApp.Models.ViewModels;

namespace AuthApp.Core.RuChildip
{
    public class RuChipdipParser : IParser<SearchResultViewModel>
    {

        private readonly string _baseUrl;

        public RuChipdipParser(string baseUrl)
        {
            _baseUrl = baseUrl;
        }

        public SearchResultViewModel Parse(IHtmlDocument document)
        {
            SearchResultViewModel result = new SearchResultViewModel();
            List<HintViewModel> hints = new List<HintViewModel>();
            var totalCountTag = document.QuerySelectorAll("sub").FirstOrDefault(sub => sub.ClassName != null && sub.ClassName.Contains("count1"));
            int totalCount;
            int.TryParse(totalCountTag?.TextContent, out totalCount);
            result.TotalCount = totalCount;
            var searchTable = document.QuerySelectorAll("table").FirstOrDefault(table => table.Id != null && table.Id == "search_items");
            var items = searchTable?.QuerySelectorAll("tr")
                .Where(tr => tr.ClassName != null && tr.ClassName.Contains("with-hover"));
            if (items != null)
            {
                foreach (var item in items)
                {
                    var link = item.QuerySelectorAll("a")
                                    .FirstOrDefault(a => a.ClassName != null && a.ClassName.Contains("link"));
                    var image = item.QuerySelectorAll("img").OfType<IHtmlImageElement>().FirstOrDefault();
                    var price = item.QuerySelectorAll("span")
                            .FirstOrDefault(span => span.ClassName != null && span.ClassName.Contains("price_mr"));
                    var hint = new HintViewModel
                    {
                        Link = $"{_baseUrl}{link?.GetAttribute("href")}",
                        Text = link?.InnerHtml,
                        Price = price?.InnerHtml,
                        ImageSrc = image?.Source
                    };
                    hints.Add(hint);
                }
            }

            result.Hints = hints;

            return result;
        }
    }
}