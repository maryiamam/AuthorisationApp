using AuthApp.Filters;
using AuthApp.Models;
using AuthApp.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AuthApp.Controllers
{
    [RequireHttps]
    [CustomAuthentication]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var currUser = HttpContext.User.Identity.Name;
            ApplicationDbContext db = new ApplicationDbContext(); //open connection to the DB
            var users = db.Users.ToList();
            var viewModels = users.Where(user => user.UserName != currUser).Select(user => new UserViewModel(user));
            return View(viewModels);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}