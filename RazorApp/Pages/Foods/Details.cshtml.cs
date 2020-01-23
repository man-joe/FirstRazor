using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorApp.Data;
using RazorApp.Models;


namespace RazorApp.Pages.Foods
{
    public class DetailsModel : PageModel
    {
        private readonly RazorApp.Data.RestaurantContext _context;

        public DetailsModel(RazorApp.Data.RestaurantContext context)
        {
            _context = context;
        }

        public Food Food { get; set; }

        #region snippet_OngetAsync
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            /*Food = await _context.Foods.FirstOrDefaultAsync(m => m.FoodID == id);*/
            Food = await _context.Foods
                .Include(f => f.Menus)
                .ThenInclude(m => m.Drink)
                .AsNoTracking()
                .FirstOrDefaultAsync(s => s.FoodID == id);

            if (Food == null)
            {
                return NotFound();
            }
            return Page();
        }
        #endregion
    }
}
