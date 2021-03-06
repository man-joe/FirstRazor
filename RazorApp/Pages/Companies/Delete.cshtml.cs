﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorApp.Data;
using RazorApp.Models;

namespace RazorApp.Pages.Companies
{
    public class DeleteModel : PageModel
    {
        private readonly RazorApp.Data.RestaurantContext _context;

        public DeleteModel(RazorApp.Data.RestaurantContext context)
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

            Company = await _context.Companies.FirstOrDefaultAsync(m => m.CompanyID == id);

            if (Company == null)
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

            Company company = await _context.Companies
                .Include(i => i.DrinkAssignments)
                .SingleAsync(i => i.CompanyID == id);

            if(company == null)
            {
                return RedirectToPage("./Index");
            }

            var drinkCategories = await _context.DrinkCategories
                .Where(d => d.CompanyID == id)
                .ToListAsync();
            drinkCategories.ForEach(d => d.CompanyID = null);
            _context.Companies.Remove(company);
            await _context.SaveChangesAsync();
            /*Company = await _context.Companies.FindAsync(id);

            if (Company != null)
            {
                _context.Companies.Remove(Company);
                await _context.SaveChangesAsync();
            }*/

            return RedirectToPage("./Index");
        }
    }
}
