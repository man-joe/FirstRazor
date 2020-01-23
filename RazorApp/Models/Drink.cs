using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace RazorApp.Models
{
    public class Drink
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int DrinkID { get; set; }

        public string Name { get; set; }
        public double Size { get; set; }

        public ICollection<Menu> Menus { get; set; }
    }
}
