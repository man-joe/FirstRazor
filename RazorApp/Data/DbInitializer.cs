using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RazorApp.Data;
using RazorApp.Models;


namespace RazorApp.Data
{
    public static class DbInitializer
    {
        public static void Initialize(RestaurantContext context)
        {
            context.Database.EnsureCreated();

            // Looks for any Food
            if (context.Foods.Any())
            {
                return; //DB has been seeded aka has foods
            }


            //Initialize Foods
            var foods = new Food[]
            {
                new Food{Name="Taco",ExpirationDate=DateTime.Parse("2020-01-25")},
                new Food{Name="Burger",ExpirationDate=DateTime.Parse("2020-02-01")},
                new Food{Name="Sandwich",ExpirationDate=DateTime.Parse("2020-01-01")}
            };

            foreach (Food f in foods)
            {
                context.Foods.Add(f);
            }
            context.SaveChanges();

            
            //Initialize Drinks
            var drinks = new Drink[]
            {
                new Drink{DrinkID=1001,Name="Coke",Size=20.0},
                new Drink{DrinkID=1002,Name="Water",Size=32.0},
                new Drink{DrinkID=1003,Name="Sprite",Size=16.0}
            };

            foreach(Drink d in drinks)
            {
                context.Drinks.Add(d);
            }
            context.SaveChanges();


            //Initialize Menus
            var menus = new Menu[]
            {
                new Menu{FoodID=2,DrinkID=1001,HealthGrade=HealthGrade.F},
                new Menu{FoodID=2,DrinkID=1002,HealthGrade=HealthGrade.C},
                new Menu{FoodID=3,DrinkID=1003,HealthGrade=HealthGrade.D},
                new Menu{FoodID=3,DrinkID=1002,HealthGrade=HealthGrade.B},
                new Menu{FoodID=4,DrinkID=1002,HealthGrade=HealthGrade.A},
                new Menu{FoodID=4,DrinkID=1003,HealthGrade=HealthGrade.D}
            };
            foreach(Menu m in menus)
            {
                context.Menus.Add(m);
            }
            context.SaveChanges();
        }
    }
}
