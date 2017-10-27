using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace myProject.Models
{
    public class ApprovedMatch
    {
        public int ID { get; set; }
        //public Planning Plan { get; set; }
        //public ApplicationUser userchoice { get; set; }
        public Planning TripA { get; set; }
        public int TripB { get; set; }
        public Boolean AcceptA { get; set; }
        public Boolean AcceptB { get; set; }
        public Boolean IgnoreMatch { get; set; }
        public IList<Chat> Chats { get; set; }

    }
}
