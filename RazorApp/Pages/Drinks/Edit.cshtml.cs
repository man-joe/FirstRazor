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

namespace RazorApp.Pages.Drinks
{
    public class EditModel : DrinkCategoryNamePageModel
    {
        private readonly RazorApp.Data.RestaurantContext _context;

        public EditModel(RazorApp.Data.RestaurantContext context)
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
                .Include(d => d.DrinkCategory).FirstOrDefaultAsync(m => m.DrinkID == id);

            if (Drink == null)
            {
                return NotFound();
            }
            /*ViewData["DrinkCategoryID"] = new SelectList(_context.DrinkCategories, "DrinkCategoryID", "Alcoholic");*/
            //Select Current DrinkCategoryID
            PopulateDrinksDropDownList(_context, Drink.DrinkCategoryID);
            return Page();
        }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int? id)
        {
            /*if (!ModelState.IsValid) // Before using updated related DATA
            {
                return Page();
            }

            _context.Attach(Drink).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DrinkExists(Drink.DrinkID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");*/
            
            if(id == null)
            {
                return NotFound();
            }

            var drinkToUpdate = await _context.Drinks.FindAsync(id);

            if(drinkToUpdate == null)
            {
                return NotFound();
            }

            if(await TryUpdateModelAsync<Drink> (
                drinkToUpdate,
                "drink",
                d => d.Size, d => d.DrinkCategoryID, d => d.Name))
            {
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            //Select DrinkCategoryID if TryUpdateModelAsync fails.
            PopulateDrinksDropDownList(_context, drinkToUpdate.DrinkCategoryID);
            return Page();
        }

        private bool DrinkExists(int id)
        {
            return _context.Drinks.Any(e => e.DrinkID == id);
        }
    }
}
