﻿using System;
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

        public IList<Food> Foods { get; set; }

        public async Task OnGetAsync(string sortOrder)
        {
            NameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : ""; // If string is empty, default to names to descending order
            DateSort = sortOrder == "Date" ? "date_desc" : "Date";

            IQueryable<Food> foodIQ = from f in _context.Foods
                                      select f;

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

            Foods = await foodIQ.AsNoTracking().ToListAsync();
        }


      /*  public IList<Food> Food { get;set; }

        public async Task OnGetAsync()
        {
            Food = await _context.Foods.ToListAsync();
        }*/
    }
}
