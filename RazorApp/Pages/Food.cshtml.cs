using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorApp
{
    public class FoodModel : PageModel
    {

        public string Blueberries { get; set; }
        public void OnGet()
        {

        }
    }
}