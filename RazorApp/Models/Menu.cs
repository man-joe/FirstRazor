using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazorApp.Models
{

    public enum HealthGrade
    {
        A, B, C, D, F
    }
    public class Menu
    {
        public int MenuID { get; set; }
        public int FoodID { get; set; }
        public int DrinkID { get; set; }
        public HealthGrade? HealthGrade { get; set; }

        public Food Food { get; set; }
        public Drink Drink { get; set; }
    }
}
