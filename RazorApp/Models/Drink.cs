using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RazorApp.Models
{
    public class Drink
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "DrinkID")]
        public int DrinkID { get; set; }
        
        [StringLength(50, MinimumLength = 3)]
        public string Name { get; set; }
        
        [Range(0,120)]
        public double Size { get; set; }

        public int DrinkCategoryID { get; set; }

        public DrinkCategory DrinkCategory { get; set; }
        public ICollection<Menu> Menus { get; set; }
        public ICollection<DrinkAssignment> DrinkAssignments { get; set; }
    }
}
