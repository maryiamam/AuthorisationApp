using AuthApp.Models.ViewModels;
using System.Web.Mvc;

namespace AuthApp.Controllers
{
    public class SearchController : Controller
    {
        [HttpPost]
        public ActionResult SearchResult(SearchViewModel searchModel)
        {
            return View("SearchResult", searchModel);
        }
    }
}