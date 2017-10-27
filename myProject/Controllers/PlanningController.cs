using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using myProject.Data;
using myProject.Models;
using myProject.Models.ManageViewModels;
using myProject.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace myProject.Controllers
{
    [Authorize]
    public class PlanningController : Controller
    {

        private ApplicationDbContext context;

        public PlanningController(ApplicationDbContext dbContext)
        {
            context = dbContext;
        }


        // GET: /<controller>/
        // takes you to the form where you can plan your trip
        public IActionResult Index()
        {
            return View();
        }


        public IActionResult Add()
        {
            IndexViewModel aplanningViewModel = new IndexViewModel();
            return View(aplanningViewModel);
        }

        [HttpPost]
        public IActionResult Add(IndexViewModels plans)
        {
            ApplicationUser currentUser = context.Users.Single(finduser => finduser.UserName.Equals(User.Identity.Name));


            if (ModelState.IsValid)
            {
                // Add the new cheese to my existing cheeses
                Planning newAdventure = new Planning
                {   //take form input and store into database
                    Activity = plans.Activity,
                    Location = plans.Location,//theLocation.ToString(),
                    Date = plans.Date,
                    User= currentUser // both are objects

                };

                context.Plans.Add(newAdventure);
                context.SaveChanges();

                //return Redirect(string.Format("/AllTrips?id={0}", newAdventure.ID));
                return Redirect("AllTrips");
            }
            return View(plans);
        }


        public IActionResult AllTrips()
        {//query results of all planned activity for that user.

            // finds the current logged in user name
            ApplicationUser currentUser = context.Users.Single(finduser=> finduser.UserName.Equals(User.Identity.Name));

            ViewBag.name = currentUser;

            //FInd all every instances where that user shows up. Gather all the rows and column for that user(that user's activity plans, location, date)
            IList<Planning> Userplans = context.Plans.Where(p => p.User.Equals(currentUser.Id)).ToList();
            //currentUser.Id is an instance

            ViewBag.yourPlans = Userplans;


            return View();

        }

        public IActionResult FindMatch(String TripID) // The current user planID was generated when she/he user created that activity and was then passed in the url
        {
            // find the current user
            ApplicationUser currentUser = context.Users.Single(finduser => finduser.UserName.Equals(User.Identity.Name));

            ViewBag.name = currentUser;

            //find the current user planning ID
            Planning currentplan = context.Plans.Single(p => p.ID == int.Parse(TripID));

            // Finds and creates a list of activities/trips that may match the current user date, location, and activity with the same criteria as the current signed in user, planID.
            // It is a list of objects, each object is a unique match in a different row in the Database Plans
            IList<Planning> match_plans = context.Plans.Where(mp => mp.Location == currentplan.Location)
                                                       .Where(mp => mp.Activity == currentplan.Activity)
                                                       .Where(mp => mp.Date == currentplan.Date).ToList();

            IList<Planning> unapprovedMatches = new List<Planning>();// creates an empty list that will later be filled by activities that matches and do not already exist (and not associated properties tripA=tripB, tripB=tripA)


            //tp would be each individual object( a row) in the list with a unique planID
            foreach (var tp in match_plans)
            { //finding associate property of the current user is in the database 


                //check to see if the planid # in the plans Database already exist
                // verifies if inside column TripA_ID has the value of tp(the planID from the list of matched plans), and column TripB(the user planID pass thru the url)  has the same value
                IList <ApprovedMatch> matchAlready = context.ApprovedMatches.Where(ma => ma.TripA == tp)
                    .Where(ma => ma.TripB == int.Parse(TripID)).ToList();
                //check for same match but backwards
                IList<ApprovedMatch> matchAlready2 = context.ApprovedMatches.Where(ma => ma.TripB == tp.ID)
                  .Where(ma => ma.TripA == currentplan).ToList();

                if (matchAlready.Count<1 && matchAlready2.Count <1)
                {
                    unapprovedMatches.Add(tp);
                }
            }
            ViewBag.Matches = unapprovedMatches;

            return View();
        }

    }
}
