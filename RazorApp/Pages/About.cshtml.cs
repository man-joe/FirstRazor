using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorApp.Models;
using RazorApp.Data;
using RazorApp.Models.RestaurantViewModels;
using Microsoft.EntityFrameworkCore;

namespace RazorApp.Pages
{
    public class AboutModel : PageModel
    {
        private readonly RestaurantContext _context;
        public AboutModel(RestaurantContext context)
        {
            _context = context;
        }

        public IList<MenuDateGroup> Foods { get; set; }

        public async Task OnGetAsync()
        {
            IQueryable<MenuDateGroup> data =
                from food in _context.Foods
                group food by food.ExpirationDate into dateGroup
                select new MenuDateGroup()
                {
                    MenuDate = dateGroup.Key,
                    FoodCount = dateGroup.Count()
                };

            Foods = await data.AsNoTracking().ToListAsync();
        }
    }
}