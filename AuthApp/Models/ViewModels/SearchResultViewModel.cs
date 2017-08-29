using System.Collections.Generic;

namespace AuthApp.Models.ViewModels
{
    public class SearchResultViewModel
    {
		public IEnumerable<HintViewModel> Hints { get; set; }
		public int TotalCount { get; set; }
        public string SearchString { get; set; }
    }
}