using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazorApp.Models.RestaurantViewModels
{
    public class CompanyIndexData
    {
        public IEnumerable<Company> Companies { get; set; }
        public IEnumerable<Drink> Drinks { get; set; }
        public IEnumerable<Menu> Menus { get; set; }
    }
}
