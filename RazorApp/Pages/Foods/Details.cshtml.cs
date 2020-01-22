using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorApp.Data;
using RazorApp.Models;

namespace RazorApp
{
    public class DetailsModel : PageModel
    {
        private readonly RazorApp.Data.FoodContext _context;

        public DetailsModel(RazorApp.Data.FoodContext context)
        {
            _context = context;
        }

        public Food Food { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Food = await _context.Food.FirstOrDefaultAsync(m => m.FoodID == id);

            if (Food == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
