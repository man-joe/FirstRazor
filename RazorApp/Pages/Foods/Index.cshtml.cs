using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorApp.Data;
using RazorApp.Models;

namespace RazorApp.Pages.Foods
{
    public class IndexModel : PageModel
    {
        private readonly RazorApp.Data.RestaurantContext _context;

        public IndexModel(RazorApp.Data.RestaurantContext context)
        {
            _context = context;
        }


        /// <summary>
        /// Adds Sorting to Foods
        /// </summary>
        public string NameSort { get; set; }
        public string DateSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }

        public PaginatedList<Food> Foods { get; set; }

       /* public IList<Food> Foods { get; set; }*/

        public async Task OnGetAsync(string sortOrder,
            string currentFilter, string searchString, int? pageIndex)
        {
            CurrentSort = sortOrder;
            NameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : ""; // If string is empty, default to names to descending order
            DateSort = sortOrder == "Date" ? "date_desc" : "Date";
            if(searchString != null)
            {
                pageIndex = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            CurrentFilter = searchString;

            IQueryable<Food> foodIQ = from f in _context.Foods
                                      select f;

            if(!String.IsNullOrEmpty(searchString))
            {
                foodIQ = foodIQ.Where(f => f.Name.Contains(searchString));
            }


            switch(sortOrder)
            {
                case "name_desc":
                    foodIQ = foodIQ.OrderByDescending(f => f.Name);
                    break;
                case "Date":
                    foodIQ = foodIQ.OrderBy(f => f.ExpirationDate);
                    break;
                case "date_desc":
                    foodIQ = foodIQ.OrderByDescending(f => f.ExpirationDate);
                    break;
                default:
                    foodIQ = foodIQ.OrderBy(f => f.Name);
                    break;
            }

            int pageSize = 3;

            Foods = await PaginatedList<Food>.CreateAsync(
                foodIQ.AsNoTracking(), pageIndex ?? 1, pageSize); // resets page index to 1 when there's a new string search string
        }


      /*  public IList<Food> Food { get;set; }

        public async Task OnGetAsync()
        {
            Food = await _context.Foods.ToListAsync();
        }*/
    }
}
