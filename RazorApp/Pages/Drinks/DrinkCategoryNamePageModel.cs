using RazorApp.Data;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazorApp.Pages.Drinks
{
    public class DrinkCategoryNamePageModel : PageModel // base PageModel for create and edit
    {
        public SelectList DrinkCategoryNameSL { get; set; }

        public void PopulateDrinksDropDownList(RestaurantContext _context,
            object selectedDrinkCategory = null)
        {
            var drinkCategoryQuery = from d in _context.DrinkCategories
                                     orderby d.Name
                                     select d;

            DrinkCategoryNameSL = new SelectList(drinkCategoryQuery.AsNoTracking(),
                "DrinkCategoryID", "Name", selectedDrinkCategory);
        }
    }
}
