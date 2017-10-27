using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace myProject.Models
{
    public class Chat
    {
        public int ID { get; set; }
        public ApprovedMatch ApprovedTrip { get; set; }
        public ApplicationUser user { get; set; }
        public String Messages { get; set; }
    }
}
