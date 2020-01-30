using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RazorApp.Data;
using RazorApp.Models;

namespace RazorApp.Pages.Drinks
{
    public class CreateModel : DrinkCategoryNamePageModel
    {
        private readonly RazorApp.Data.RestaurantContext _context;

        public CreateModel(RazorApp.Data.RestaurantContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            /*ViewData["DrinkCategoryID"] = new SelectList(_context.DrinkCategories, "DrinkCategoryID", "Alcoholic");*/
            PopulateDrinksDropDownList(_context);
            return Page();
        }

        [BindProperty]
        public Drink Drink { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            var emptyDrink = new Drink();

            if(await TryUpdateModelAsync<Drink>(
                emptyDrink,
                "drink",
                s => s.DrinkID, s => s.DrinkCategoryID, s => s.Name, s => s.Size))
            {
                _context.Drinks.Add(emptyDrink);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            // Select DrinkCategoryID if TryUpdateModelAsync fails...
            PopulateDrinksDropDownList(_context, emptyDrink.DrinkCategoryID);
            return Page();


          /*  if (!ModelState.IsValid) //Before updating related Data....
            {
                return Page();
            }

            _context.Drinks.Add(Drink);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");*/
        }
    }
}
