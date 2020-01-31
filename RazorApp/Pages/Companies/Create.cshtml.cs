using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RazorApp.Data;
using RazorApp.Models;

namespace RazorApp.Pages.Companies
{
    public class CreateModel : CompanyDrinksPageModel
    {
        private readonly RazorApp.Data.RestaurantContext _context;

        public CreateModel(RazorApp.Data.RestaurantContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            var company = new Company();
            company.DrinkAssignments = new List<DrinkAssignment>();
            // Provides an empty collection for the foreach loop
            // foreach (var course in Model.AssignedCourseDataList)
            // in the Create Razor page.
            PopulateAssignedDrinkData(_context, company);
            return Page();
        }

        [BindProperty]
        public Company Company { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(string[] selectedDrinks)
        {
            var newCompany = new Company();
            if(selectedDrinks != null)
            {
                newCompany.DrinkAssignments = new List<DrinkAssignment>();
                foreach (var drink in selectedDrinks)
                {
                    var drinkToAdd = new DrinkAssignment
                    {
                        DrinkID = int.Parse(drink)
                    };
                    newCompany.DrinkAssignments.Add(drinkToAdd);
                }
            }

            if(await TryUpdateModelAsync<Company> (
                newCompany,
                "Company",
                i => i.Name,
                i => i.FoundedDate,
                i => i.CompanyHQ))
            {
                _context.Companies.Add(newCompany);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            PopulateAssignedDrinkData(_context, newCompany);
            return Page();

           /* if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Companies.Add(Company);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");*/
        }
    }
}
