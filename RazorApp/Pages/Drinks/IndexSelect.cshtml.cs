using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorApp.Models.RestaurantViewModels;
using Microsoft.EntityFrameworkCore;

namespace RazorApp.Pages.Drinks
{
    public class IndexSelectModel : PageModel
    {
        private readonly RazorApp.Data.RestaurantContext _context;

        public IndexSelectModel(RazorApp.Data.RestaurantContext context)
        {
            _context = context;
        }

        public IList<DrinkViewModel> DrinkVM { get; set; }

        public async Task OnGetAsync()
        {
            DrinkVM = await _context.Drinks
                .Select(p => new DrinkViewModel
                {
                    DrinkID = p.DrinkID,
                    Name = p.Name,
                    Size = p.Size,
                    DrinkCategoryName = p.DrinkCategory.Name
                }).ToListAsync();
            
            
        }
    }
}