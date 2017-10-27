using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace myProject.Models
{
    public class Planning
    {
        public int ID { get; set; }
        public ApplicationUser User { get; set; }

        public String Activity { get; set; }

        public String Location { get; set; }

        public DateTime Date { get; set; }

        public IList<ApprovedMatch> ApprovedMatches { get; set; }
    }
}
