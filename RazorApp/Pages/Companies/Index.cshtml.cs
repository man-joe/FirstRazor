using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorApp.Data;
using RazorApp.Models;
using RazorApp.Models.RestaurantViewModels;

namespace RazorApp.Pages.Companies
{
    public class IndexModel : PageModel
    {
        private readonly RazorApp.Data.RestaurantContext _context;

        public IndexModel(RazorApp.Data.RestaurantContext context)
        {
            _context = context;
        }

        public CompanyIndexData CompanyData { get; set; }
        public int CompanyID { get; set; }
        public int DrinkID { get; set; }

        public IList<Company> Company { get;set; }

        public async Task OnGetAsync(int? id, int? drinkID)
        {
            CompanyData = new CompanyIndexData();
            // Eager Loading of Company Data
            CompanyData.Companies = await _context.Companies
                .Include(i => i.CompanyHQ)
                .Include(i => i.DrinkAssignments)
                    .ThenInclude(i => i.Drink)
                        .ThenInclude(i => i.DrinkCategory)
                /*.Include(i => i.DrinkAssignments)
                    .ThenInclude(i => i.Drink)
                        .ThenInclude(i => i.Menus)
                            .ThenInclude(i => i.Food)
                .AsNoTracking()*/
                .OrderBy(i => i.Name)
                .ToListAsync();

            if(id != null)
            {
                CompanyID = id.Value;
                Company company = CompanyData.Companies
                    .Where(i => i.CompanyID == id.Value).Single();
                CompanyData.Drinks = company.DrinkAssignments.Select(s => s.Drink);
            }

            if(drinkID != null)
            {
                DrinkID = drinkID.Value;
                /*CompanyData.Menus = CompanyData.Drinks.Single(
                    x => x.DrinkID == drinkID).Menus;*/
                var selectedDrink = CompanyData.Drinks
                    .Where(x => x.DrinkID == drinkID).Single();
                
                //Explicit Loading of Menu Data
                await _context.Entry(selectedDrink).Collection(x => x.Menus).LoadAsync();
                foreach (Menu menu in selectedDrink.Menus)
                {
                    await _context.Entry(menu).Reference(x => x.Food).LoadAsync();
                }
                //End of Explicit Loading
                CompanyData.Menus = selectedDrink.Menus;
            }

            /*Company = await _context.Companies.ToListAsync();*/
        }
    }
}
