using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazorApp.Models.RestaurantViewModels
{
    #region snippet
    public class DrinkViewModel
    {
        public int DrinkID { get; set; }
        public string Name { get; set; }
        public double Size { get; set; }
        public string DrinkCategoryName { get; set; }
    }
    #endregion
}
