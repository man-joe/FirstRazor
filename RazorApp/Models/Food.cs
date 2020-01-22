using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazorApp.Models
{
    public class Food
    {
        public int FoodID { get; set; }
        public string Name { get; set; }
        public DateTime ExpirationDate { get; set; }

        public ICollection<Menu> Menus { get; set; }
    }
}
