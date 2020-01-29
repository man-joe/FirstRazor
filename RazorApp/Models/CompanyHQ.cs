using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RazorApp.Models
{
    public class CompanyHQ
    {
        [Key]
        public int CompanyID { get; set; }
        
        [StringLength(50)]
        [Display(Name = "Company HQ Location")]
        public string Location { get; set; }

        public Company Company { get; set; }
    }
}