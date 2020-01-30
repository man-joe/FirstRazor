using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazorApp.Models.RestaurantViewModels
{
    public class AssignedDrinkData
    { 
        public int DrinkID { get; set; }
        public string Name { get; set; }
        public bool Assigned { get; set; }
    }
}
