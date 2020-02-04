using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RazorApp.Models
{
    public class DrinkCategory
    {
        public int DrinkCategoryID { get; set; }
        
        [StringLength(50, MinimumLength =3)]
        public string Name { get; set; }

        [DataType(DataType.Currency)]
        [Column(TypeName = "money")]
        [Display(Name = "Minimum Production Cost")]
        public decimal MinProductionCost { get; set; }

        [Required]
        public string Alcoholic { get; set; }

        public int? CompanyID { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }

        public Company CompanyHead { get; set; }
        public ICollection<Drink> Drinks { get; set; }
    }
}