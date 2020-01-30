using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorApp.Data;
using RazorApp.Models;

namespace RazorApp.Pages.Drinks
{
    public class IndexModel : PageModel
    {
        private readonly RazorApp.Data.RestaurantContext _context;

        public IndexModel(RazorApp.Data.RestaurantContext context)
        {
            _context = context;
        }

        public IList<Drink> Drinks { get;set; }

        public async Task OnGetAsync()
        {
            Drinks = await _context.Drinks
                .Include(d => d.DrinkCategory)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
