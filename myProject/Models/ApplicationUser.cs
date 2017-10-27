using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace myProject.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        public IList<Planning> Plans { get; set; }
        public IList<ApprovedMatch> ApprovedMatches { get; set; }
        public IList<Chat> Chats { get; set; }
    }
}
