using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AuthApp.Models.ViewModels
{
    public class UserViewModel
    {
        public string Name { get; set; }
        public string Status { get; set; }
        public bool IsBlocked { get; set; }
        public string Id { get; set; }
        public UserViewModel(ApplicationUser user)
        {
            Name = user.UserName;
            IsBlocked = user.IsBlocked;
            Status = "Offline";
            Id = user.Id;
            if (user.LastVisited.HasValue)
            {
                TimeSpan diff = DateTime.Now - user.LastVisited.Value;
                TimeSpan minute = new TimeSpan(0, 1, 0);
                if (diff <= minute)
                {
                    Status = "Online";
                }
            }
        }
    }
}