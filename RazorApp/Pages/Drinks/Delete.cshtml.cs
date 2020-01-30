using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorApp.Data;
using RazorApp.Models;

namespace RazorApp.Pages.Drinks
{
    public class DeleteModel : PageModel
    {
        private readonly RazorApp.Data.RestaurantContext _context;

        public DeleteModel(RazorApp.Data.RestaurantContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Drink Drink { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Drink = await _context.Drinks
                .AsNoTracking()
                .Include(d => d.DrinkCategory)
                .FirstOrDefaultAsync(m => m.DrinkID == id);

            if (Drink == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Drink = await _context.Drinks.FindAsync(id);

            if (Drink != null)
            {
                _context.Drinks.Remove(Drink);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
