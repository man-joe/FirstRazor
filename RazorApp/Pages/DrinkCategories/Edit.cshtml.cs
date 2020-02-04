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

namespace RazorApp.Pages.DrinkCategories
{
    public class EditModel : PageModel
    {
        private readonly RazorApp.Data.RestaurantContext _context;

        public EditModel(RazorApp.Data.RestaurantContext context)
        {
            _context = context;
        }

        [BindProperty]
        public DrinkCategory DrinkCategory { get; set; }
        // Replace ViewData["CompanyID"]
        public SelectList CompanyNameSL { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            DrinkCategory = await _context.DrinkCategories
                .Include(d => d.CompanyHead) // eager loading
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.DrinkCategoryID == id);

            if (id == null)
            {
                return NotFound();
            }

            // Using strongly typed data rather than ViewData.
            CompanyNameSL = new SelectList(_context.Companies, "ID", "Name");

            return Page();

            /*if (DrinkCategory == null)  ----------> Replaced!!!
            {
                return NotFound();
            }
           ViewData["CompanyID"] = new SelectList(_context.Companies, "CompanyID", "Name");
            return Page();*/
        }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var drinkCategoryToUpdate = await _context.DrinkCategories
                .Include(i => i.CompanyHead)
                .FirstOrDefaultAsync(m => m.DrinkCategoryID == id);

            if(drinkCategoryToUpdate == null)
            {
                return HandleDeletedDrinkCategory();
            }

            _context.Entry(drinkCategoryToUpdate)
                .Property("RowVersion")
                .OriginalValue = DrinkCategory.RowVersion;

            if(await TryUpdateModelAsync<DrinkCategory>(
                drinkCategoryToUpdate,
                "Drink Category", 
                s => s.Name, s => s.Alcoholic, s => s.MinProductionCost, s => s.CompanyID))
            {
                try
                {
                    await _context.SaveChangesAsync();
                    return RedirectToPage("./Index");
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    var exceptionEntry = ex.Entries.Single();
                    var clientValues = (DrinkCategory)exceptionEntry.Entity;
                    var databaseEntry = exceptionEntry.GetDatabaseValues();

                    if(databaseEntry == null)
                    {
                        ModelState.AddModelError(string.Empty, "Unable to save. " +
                            "The department was deleted by another user.");
                        return Page();
                    }

                    var dbValues = (DrinkCategory)databaseEntry.ToObject();
                    await setDbErrorMessage(dbValues, clientValues, _context);

                    //Save the current RowVersion so next postback matched unless an new concurrency issue happens.
                    DrinkCategory.RowVersion = (byte[])dbValues.RowVersion;
                    //Clear the model error for the next postback.
                    ModelState.Remove("Department.RowVersion");
                }
            }

            CompanyNameSL = new SelectList(_context.Companies,
                "ID", "Name", drinkCategoryToUpdate.CompanyID);

            return Page();


            /*_context.Attach(DrinkCategory).State = EntityState.Modified; // before Concurrency implementation

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DrinkCategoryExists(DrinkCategory.DrinkCategoryID))
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

        private IActionResult HandleDeletedDrinkCategory()
        {
            var deletedDrinkCategory = new DrinkCategory();
            // ModelStat contains the posted data because of the deletion error
            // and will overide the Drink Category instance values when displaying page()
            ModelState.AddModelError(string.Empty,
                "Unable to save. The drink category was deleted by another user.");
            CompanyNameSL = new SelectList(_context.Companies, "ID", "Name", DrinkCategory.CompanyID);
            return Page();
        }

        private async Task setDbErrorMessage(DrinkCategory dbValues,
            DrinkCategory clientValues, RestaurantContext context)
        {
            if(dbValues.Name != clientValues.Name)
            {
                ModelState.AddModelError("DrinkCategory.Name",
                    $"Current value: { dbValues.Name}");
            }
            if(dbValues.MinProductionCost != clientValues.MinProductionCost)
            {
                ModelState.AddModelError("DrinkCategory.MinProductionCost",
                    $"Current value: {dbValues.MinProductionCost:c}");
            }
            if(dbValues.Alcoholic != clientValues.Alcoholic)
            {
                ModelState.AddModelError("DrinkCategory.Alcoholic",
                    $"Current value: {dbValues.Alcoholic}");
            }
            if(dbValues.CompanyID != clientValues.CompanyID)
            {
                Company dbCompany = await _context.Companies
                    .FindAsync(dbValues.CompanyID);
                ModelState.AddModelError("DrinkCategory.CompanyID",
                    $"Current value: {dbCompany?.Name}");
            }

            ModelState.AddModelError(string.Empty,
                "The record you attempted to edit was modifed by another user after you. "
                + "The edit operation was canceled and the current values in the database "
                + "have been displayed. If you still want to edit this record, click "
                + "the Save button again.");
        }


       /* private bool DrinkCategoryExists(int id)
        {
            return _context.DrinkCategories.Any(e => e.DrinkCategoryID == id);
        }*/
    }
}
