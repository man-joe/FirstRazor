using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RazorApp.Data;
using RazorApp.Models;

namespace RazorApp
{
    public class EditModel : PageModel
    {
        private readonly RazorApp.Data.RestaurantContext _context;

        public EditModel(RazorApp.Data.RestaurantContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Food Food { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            /*Food = await _context.Foods.FirstOrDefaultAsync(m => m.FoodID == id);*/
            Food = await _context.Foods.FindAsync(id);

            if (Food == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int id)
        {
            var foodToUpdate = await _context.Foods.FindAsync(id);

            if(foodToUpdate == null)
            {
                return NotFound();
            }

            if(await TryUpdateModelAsync<Food> (
                foodToUpdate,
                "food",
                f => f.Name, f => f.ExpirationDate))
            {
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            return Page();

            /*
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Food).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FoodExists(Food.FoodID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
            */
        }

        private bool FoodExists(int id)
        {
            return _context.Foods.Any(e => e.FoodID == id);
        }
    }
}
