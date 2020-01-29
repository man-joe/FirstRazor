using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RazorApp.Models
{
    public class Food
    {
        public int FoodID { get; set; }
        
        [Required(ErrorMessage = "Please Enter Name of Food")]
        [StringLength(50, ErrorMessage = "Food Name cannot be longer than 50 characters")]
        [Column("FoodName")]
        [Display(Name = "Food Name")]
        public string Name { get; set; }
        
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Expiration Date")]
        public DateTime ExpirationDate { get; set; }

        // May remove, Not being used yet... Return later. 
        [Range(0,100, ErrorMessage ="Must be between 0-100")]
        public int Quantity { get; set; }

        public ICollection<Menu> Menus { get; set; }
    }
}
