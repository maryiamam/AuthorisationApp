using System.Collections.Generic;
using System.Linq;
using AngleSharp.Dom.Html;
using AuthApp.Core.Interfaces;
using AuthApp.Models.ViewModels;

namespace AuthApp.Core.BelChip
{
    public class BelChipParser : IParser<SearchResultViewModel>
    {
        private readonly string _baseUrl;
        private readonly int _page;
        private const int CountPerPage = 20;

        public BelChipParser(string baseUrl, int? page)
        {
            _baseUrl = baseUrl;
            _page = page ?? 0;
        }

        public SearchResultViewModel Parse(IHtmlDocument document)
        {
            SearchResultViewModel result = new SearchResultViewModel();
            List<HintViewModel> hints = new List<HintViewModel>();
            var searchTable = document.QuerySelectorAll("table")
                                .FirstOrDefault(table => table.ClassName != null && table.ClassName.Contains("table-list"));
            var totalItems = searchTable?.QuerySelectorAll("tr").Skip(1).ToList();
            var items = totalItems?.Skip(_page * CountPerPage).Take(CountPerPage);
            if (items != null)
            {
                foreach (var item in items)
                {
                    var linkElem = item.QuerySelectorAll("td")
                            .FirstOrDefault(td => td.ClassName != null && td.ClassName.Contains("t-d1"));
                    var link = linkElem?.QuerySelector("a");
                    var imageElem = item.QuerySelectorAll("td")
                            .FirstOrDefault(td => td.ClassName != null && td.ClassName.Contains("t-d2"));
                    var image = imageElem?.QuerySelector("img") as IHtmlImageElement;
                    var priceElem = item.QuerySelectorAll("td")
                            .FirstOrDefault(td => td.ClassName != null && td.ClassName.Contains("t-d3"));
                    var hint = new HintViewModel
                    {
                        Link = $"{_baseUrl}/{link?.GetAttribute("href")}",
                        Text = link?.InnerHtml,
                        Price = priceElem?.InnerHtml,
                        ImageSrc = image?.Source
                    };
                    hints.Add(hint);
                }
            }
            result.TotalCount = totalItems?.Count ?? 0;
            result.Hints = hints;

            return result;
        }
    }
}