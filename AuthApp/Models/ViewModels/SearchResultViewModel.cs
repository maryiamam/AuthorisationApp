using System.Collections.Generic;

namespace AuthApp.Models.ViewModels
{
    public class SearchResultViewModel
    {
		public IEnumerable<HintViewModel> Hints { get; set; }

		public long TotalCount { get; set; }
    }
}