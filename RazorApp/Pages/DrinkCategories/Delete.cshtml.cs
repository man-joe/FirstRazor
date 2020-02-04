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
    public class DeleteModel : PageModel
    {
        private readonly RazorApp.Data.RestaurantContext _context;

        public DeleteModel(RazorApp.Data.RestaurantContext context)
        {
            _context = context;
        }

        [BindProperty]
        public DrinkCategory DrinkCategory { get; set; }
        public string ConcurrencyErrorMesage { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id, bool? concurrencyError)
        {
            DrinkCategory = await _context.DrinkCategories
                .Include(d => d.CompanyHead)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.DrinkCategoryID == id);

/*            if (id == null)
            {
                return NotFound();
            }*/
     
            if (DrinkCategory == null)
            {
                return NotFound();
            }

            if(concurrencyError.GetValueOrDefault())
            {
                ConcurrencyErrorMesage = "The record you attempted to delete "
                  + "was modified by another user after you selected delete. "
                  + "The delete operation was canceled and the current values in the "
                  + "database have been displayed. If you still want to delete this "
                  + "record, click the Delete button again.";
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            try
            {
                if(await _context.DrinkCategories.AnyAsync (
                    m => m.DrinkCategoryID == id))
                {
                    // DrinkCategory.rowVersion value is from when the entity was fetched.
                    // If it doesn't match the DB, a DbUpdateConcurrencyException is thrown.
                    _context.DrinkCategories.Remove(DrinkCategory);
                    await _context.SaveChangesAsync();
                }
                return RedirectToPage("./Index");
            }
            catch(DbUpdateConcurrencyException)
            {
                return RedirectToPage("./Delete",
                    new { concurrencyError = true, id = id });
            }
           /* if (id == null)
            {
                return NotFound();
            }

            DrinkCategory = await _context.DrinkCategories.FindAsync(id);

            if (DrinkCategory != null)
            {
                _context.DrinkCategories.Remove(DrinkCategory);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");*/
        }
    }
}
