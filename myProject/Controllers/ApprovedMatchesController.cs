using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using myProject.Data;
using myProject.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace myProject.Controllers
{
    [Authorize]
    public class ApprovedMatchesController : Controller
    {

        private ApplicationDbContext context;

        public ApprovedMatchesController(ApplicationDbContext dbContext)
        {
            context = dbContext;
        }

        // GET: /<controller>/
        public IActionResult Index(Planning id)
        { // Logic to determine ....
            
            return View();
        }

        public IActionResult Decline()
        {
            return View();
        }
    }
}
