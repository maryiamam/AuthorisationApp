namespace AuthApp.Models.ViewModels
{
    public class SearchViewModel
    {
        public int Page { get; set; }

        public int ItemsPerPage { get; set; }

        public string Phrase { get; set; }
    }
}