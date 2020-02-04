using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RazorApp.Data;
using RazorApp.Models;

namespace RazorApp.Pages.DrinkCategories
{
    public class CreateModel : PageModel
    {
        private readonly RazorApp.Data.RestaurantContext _context;

        public CreateModel(RazorApp.Data.RestaurantContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["CompanyID"] = new SelectList(_context.Companies, "CompanyID", "Name");
            return Page();
        }

        [BindProperty]
        public DrinkCategory DrinkCategory { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.DrinkCategories.Add(DrinkCategory);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
