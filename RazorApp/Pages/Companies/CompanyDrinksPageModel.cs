using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RazorApp.Data;
using RazorApp.Models;
using RazorApp.Models.RestaurantViewModels;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorApp.Pages.Companies
{
    public class CompanyDrinksPageModel : PageModel
    {
        public List<AssignedDrinkData> AssignedDrinkDataList;

        public void PopulateAssignedDrinkData(RestaurantContext context,
                                              Company company)
        {
            var allDrinks = context.Drinks;
            var companyDrinks = new HashSet<int>(
                company.DrinkAssignments.Select(c => c.DrinkID));
            AssignedDrinkDataList = new List<AssignedDrinkData>();

            foreach (var drink in allDrinks)
            {
                AssignedDrinkDataList.Add(new AssignedDrinkData
                {
                    DrinkID = drink.DrinkID,
                    Name = drink.Name,
                    Assigned = companyDrinks.Contains(drink.DrinkID)
                });
            }
        }

        public void UpdateCompanyDrinks(RestaurantContext context,
            string[] selectedDrinks, Company companyToUpdate)
        {
            if(selectedDrinks == null)
            {
                companyToUpdate.DrinkAssignments = new List<DrinkAssignment>();
                return;
            }

            var selectedDrinkHS = new HashSet<string>(selectedDrinks);
            var companyDrinks = new HashSet<int>
                (companyToUpdate.DrinkAssignments.Select(c => c.Drink.DrinkID));

            foreach (var drink in context.Drinks)
            {
                if(selectedDrinkHS.Contains(drink.DrinkID.ToString()))
                {
                    if(!companyDrinks.Contains(drink.DrinkID))
                    {
                        companyToUpdate.DrinkAssignments.Add(
                            new DrinkAssignment
                            {
                                CompanyID = companyToUpdate.CompanyID,
                                DrinkID = drink.DrinkID
                            });
                    }
                }
                else
                {
                    if(companyDrinks.Contains(drink.DrinkID))
                    {
                        DrinkAssignment drinkToRemove =
                            companyToUpdate
                            .DrinkAssignments
                            .SingleOrDefault(i => i.DrinkID == drink.DrinkID);
                        context.Remove(drinkToRemove);
                    }
                }

            }
        }
    }
}
