using AuthApp.Filters;
using AuthApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AuthApp.Controllers
{
    [CustomAuthentication]
    public class UserController : Controller
    {
        public ActionResult BlockUser(string userId)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            var user = db.Users.FirstOrDefault(x => x.Id == userId);
            if (user != null)
            {
                user.IsBlocked = !user.IsBlocked;
                db.SaveChanges();
            }
            return RedirectToAction("Index", "Home");
        }

        public ActionResult DeleteUser(string userId)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            var user = db.Users.FirstOrDefault(x => x.Id == userId);
            if (user != null)
            {
                db.Users.Remove(user);
                db.SaveChanges();
            }
            return RedirectToAction("Index", "Home");
        }

        [AllowAnonymous]
        [HttpGet]
        public void UpdateUserStatus()
        {
            if (HttpContext.User != null && HttpContext.User.Identity.IsAuthenticated) {
                ApplicationDbContext db = new ApplicationDbContext();
                var currUserName = HttpContext.User.Identity.Name;
                var user = db.Users.FirstOrDefault(x => x.UserName == currUserName);
                if (user != null)
                {
                    user.LastVisited = DateTime.Now;
                    db.SaveChanges();
                }
            }
        }
    }
}