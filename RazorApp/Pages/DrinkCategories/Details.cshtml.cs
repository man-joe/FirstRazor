using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorApp.Data;
using RazorApp.Models;

namespace RazorApp.Pages.DrinkCategories
{
    public class DetailsModel : PageModel
    {
        private readonly RazorApp.Data.RestaurantContext _context;

        public DetailsModel(RazorApp.Data.RestaurantContext context)
        {
            _context = context;
        }

        public DrinkCategory DrinkCategory { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            DrinkCategory = await _context.DrinkCategories
                .Include(d => d.CompanyHead).FirstOrDefaultAsync(m => m.DrinkCategoryID == id);

            if (DrinkCategory == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
