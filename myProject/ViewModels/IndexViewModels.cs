using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace myProject.ViewModels
{
    public class IndexViewModels
    {
        
        [Required(ErrorMessage = "A description of the activity or trip must be given.")]
        [StringLength(255)]
        public String Activity { get; set; }

        [Required]
        public String Location { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

    }
}
