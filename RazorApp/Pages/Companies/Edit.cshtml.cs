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

namespace RazorApp.Pages.Companies
{
    public class EditModel : CompanyDrinksPageModel
    {
        private readonly RazorApp.Data.RestaurantContext _context;

        public EditModel(RazorApp.Data.RestaurantContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Company Company { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //Eager Query
            Company = await _context.Companies
                .Include(i => i.CompanyHQ)
                .Include(i => i.DrinkAssignments)
                    .ThenInclude(i => i.Drink)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.CompanyID == id);

            /*Company = await _context.Companies.FirstOrDefaultAsync(m => m.CompanyID == id);*/

            if (Company == null)
            {
                return NotFound();
            }

            PopulateAssignedDrinkData(_context, Company);
            return Page();
        }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int? id, string[] selectedDrinks)
        {
            if(id ==null)
            {
                return NotFound();
            }

            var companyToUpdate = await _context.Companies
                .Include(i => i.CompanyHQ)
                .Include(i => i.DrinkAssignments)
                    .ThenInclude(i => i.Drink)
                .FirstOrDefaultAsync(s => s.CompanyID == id);

            if(companyToUpdate == null)
            { 
                return NotFound();
            }

            if(await TryUpdateModelAsync<Company> (
                companyToUpdate,
                "Company",
                i => i.Name, 
                i => i.FoundedDate, 
                i => i.CompanyHQ))
            {
                if(String.IsNullOrWhiteSpace(
                    companyToUpdate.CompanyHQ?.Location))
                {
                    companyToUpdate.CompanyHQ = null;
                }
            }
            UpdateCompanyDrinks(_context, selectedDrinks, companyToUpdate);
            PopulateAssignedDrinkData(_context, companyToUpdate);
            return Page();
           /* if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Company).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CompanyExists(Company.CompanyID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");*/
        }

       /* private bool CompanyExists(int id)
        {
            return _context.Companies.Any(e => e.CompanyID == id);
        }*/
    }
}
