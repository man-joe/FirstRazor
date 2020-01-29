using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RazorApp.Models
{
    public class Company
    {
        public int CompanyID { get; set; }
        
        [Required]
        [Display(Name = "Company Name")]
        [StringLength(50, ErrorMessage = "Company Name cannot be larger than 50 characters")]
        public string Name { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Founded Date")]
        public DateTime FoundedDate { get; set; }

        public ICollection<DrinkAssignment> DrinkAssignments { get; set; }
        public CompanyHQ CompanyHQ { get; set; }
    }
}
