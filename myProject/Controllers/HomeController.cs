using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using myProject.Data;
using myProject.Models;

namespace myProject.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private ApplicationDbContext context;

        public HomeController(ApplicationDbContext dbContext)
        {
            context = dbContext;
        }

        public IActionResult Index()
        {
            ApplicationUser currentUser = context.Users.Single(finduser => finduser.UserName.Equals(User.Identity.Name));

            ViewBag.name = currentUser;
            //string[] saidList = {"ball","hat","shoe"};
            //ViewBag.Test = saidList;
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
