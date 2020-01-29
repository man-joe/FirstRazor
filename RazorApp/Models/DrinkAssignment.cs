namespace RazorApp.Models
{
    public class DrinkAssignment
    {
        public int CompanyID { get; set; }
        public int DrinkID { get; set; }
        public Company Company { get; set; }
        public Drink Drink { get; set; }
    }
}