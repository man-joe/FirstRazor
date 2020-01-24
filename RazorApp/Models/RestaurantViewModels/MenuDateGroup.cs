using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RazorApp.Models.RestaurantViewModels
{
    public class MenuDateGroup
    {
        [DataType(DataType.Date)]
        public DateTime? MenuDate { get; set; }
        
        public int FoodCount { get; set; }

    }
}
