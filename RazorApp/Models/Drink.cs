using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazorApp.Models
{
    public class Drink
    {
        public int DrinkID { get; set; }

        public string Name { get; set; }
        public double Size { get; set; }

        public ICollection<Menu> Menus { get; set; }
    }
}
