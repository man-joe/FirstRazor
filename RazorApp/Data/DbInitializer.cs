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
            //context.Database.EnsureDeleted(); // makes sure the database starts fresh by deleting any old databases
            // Migrations added -- 01/27/2020 -- 
            // context.Database.EnsureCreated(); // creates new database if there isn't one already. 
            
            // Looks for any Food
            // Change conditional to check for all models 
            if (context.Foods.Any())
            {
                return; //DB has been seeded aka has foods
            }


            //Initialize Foods
            var foods = new Food[]
            {
                new Food
                {
                    Name="Taco",
                    ExpirationDate=DateTime.Parse("2020-01-25"),
                    Quantity=20},
                new Food
                {
                    Name="Burger",
                    ExpirationDate=DateTime.Parse("2020-02-01"),
                    Quantity=30
                },
                new Food
                {
                    Name="Sandwich",
                    ExpirationDate=DateTime.Parse("2020-01-01"),
                    Quantity=50
                },
                new Food
                {
                    Name="Ramen",
                    ExpirationDate=DateTime.Parse("2020-03-05"),
                    Quantity=100
                },
                new Food
                {
                    Name="Pizza",
                    ExpirationDate=DateTime.Parse("2020-04-01"),
                    Quantity=25
                },
                new Food
                {
                    Name="Hot Dog",
                    ExpirationDate=DateTime.Parse("2020-12-31"),
                    Quantity=15
                }
            };

            foreach (Food f in foods)
            {
                context.Foods.Add(f);
            }
            context.SaveChanges();

            //Initialize Beverage Companies
            var companys = new Company[]
            {
                new Company
                {
                    Name="Coca-Cola",
                    FoundedDate=DateTime.Parse("1920-01-15")
                },
                new Company
                {
                    Name="Nestle",
                    FoundedDate=DateTime.Parse("1845-05-24")
                },
                new Company
                {
                    Name="Heineken",
                    FoundedDate=DateTime.Parse("1953-03-24")
                } 
            };

            foreach (Company c in companys)
            {
                context.Companies.Add(c);
            }
            context.SaveChanges();

            //Initialize Drink Categories

            var drinkCats = new DrinkCategory[]
            {
                //Single will look for 1 instance, it throws an exception if 0 or more than 1 is found. 
                new DrinkCategory
                {
                    Name="Soft Drink",
                    MinProductionCost=1000.00m,
                    Alcoholic="no",
                    CompanyID=companys.Single(c => c.Name == "Coca-Cola").CompanyID
                },
                new DrinkCategory
                {
                    Name="Bottled Water",
                    MinProductionCost=2020.20m,
                    Alcoholic="no",
                    CompanyID=companys.Single(c => c.Name == "Nestle").CompanyID
                },
                new DrinkCategory
                {
                    Name="Beer",
                    MinProductionCost=150.00m,
                    Alcoholic="yes",
                    CompanyID=companys.Single(c => c.Name == "Heineken").CompanyID
                }
            };

            foreach(DrinkCategory d in drinkCats)
            {
                context.DrinkCategories.Add(d);
            }
            context.SaveChanges();

            //Initialize Drinks
            var drinks = new Drink[]
            {
                new Drink
                {
                    DrinkID=1001,
                    Name="Coke",
                    Size=20.0,
                    DrinkCategoryID = drinkCats.Single(d => d.Name == "Soft Drink").DrinkCategoryID
                },
                new Drink
                {
                    DrinkID=1002,
                    Name="Water",
                    Size=32.0,
                    DrinkCategoryID = drinkCats.Single(d => d.Name == "Bottled Water").DrinkCategoryID
                },
                new Drink
                {
                    DrinkID=1003,
                    Name="Sprite",
                    Size=16.0,
                    DrinkCategoryID = drinkCats.Single(d => d.Name == "Soft Drink").DrinkCategoryID
                },
                new Drink
                {
                    DrinkID=1004,
                    Name="Lager",
                    Size=12.0,
                    DrinkCategoryID = drinkCats.Single(d => d.Name == "Beer").DrinkCategoryID
                }
            };

            foreach(Drink d in drinks)
            {
                context.Drinks.Add(d);
            }
            context.SaveChanges();

            //Initalize CompanyHQs

            var companyHQs = new CompanyHQ[]
            {
                new CompanyHQ
                {
                    CompanyID = companys.Single(c => c.Name == "Coca-Cola").CompanyID,
                    Location = "Atlanta, Georgia"
                },
                new CompanyHQ
                {
                    CompanyID = companys.Single(c => c.Name == "Nestle").CompanyID,
                    Location = "Vevey, Switzerland"
                },
                new CompanyHQ
                {
                    CompanyID = companys.Single(c => c.Name == "Heineken").CompanyID,
                    Location = "Amsterdam, Netherlands"
                }
            };

            foreach (CompanyHQ c in companyHQs)
            {
                context.CompanyHQs.Add(c);
            }
            context.SaveChanges();

            //Initialize CompanyAssignments

            var drinkAssigns = new DrinkAssignment[]
            {
                new DrinkAssignment
                {
                    DrinkID = drinks.Single(d => d.Name == "Coke").DrinkID,
                    CompanyID = companys.Single(c => c.Name == "Coca-Cola").CompanyID
                },
                new DrinkAssignment
                {
                    DrinkID = drinks.Single(d => d.Name == "Water").DrinkID,
                    CompanyID = companys.Single(c => c.Name == "Nestle").CompanyID
                },
                new DrinkAssignment
                {
                    DrinkID = drinks.Single(d => d.Name == "Sprite").DrinkID,
                    CompanyID = companys.Single(c => c.Name == "Coca-Cola").CompanyID
                },
                new DrinkAssignment
                {
                    DrinkID = drinks.Single(d => d.Name == "Lager").DrinkID,
                    CompanyID = companys.Single(c => c.Name == "Heineken").CompanyID
                }
            };

            foreach (DrinkAssignment d in drinkAssigns)
            {
                context.DrinkAssignments.Add(d);
            }
            context.SaveChanges();


            //Initialize Menus
            var menus = new Menu[]
            {
                new Menu
                {
                    FoodID=foods.Single(f => f.Name == "Taco").FoodID,
                    DrinkID=drinks.Single(d => d.Name == "Sprite").DrinkID,
                    HealthGrade=HealthGrade.F
                },
                new Menu
                {
                    FoodID=foods.Single(f => f.Name == "Pizza").FoodID,
                    DrinkID=drinks.Single(d => d.Name == "Water").DrinkID,
                    HealthGrade=HealthGrade.C
                },
                new Menu
                {
                    FoodID=foods.Single(f => f.Name == "Burger").FoodID,
                    DrinkID=drinks.Single(d => d.Name == "Water").DrinkID,
                    HealthGrade=HealthGrade.D
                },
                new Menu
                {
                    FoodID=foods.Single(f => f.Name == "Hot Dog").FoodID,
                    DrinkID=drinks.Single(d => d.Name == "Lager").DrinkID,
                    HealthGrade=HealthGrade.B
                },
                new Menu
                {
                    FoodID=foods.Single(f => f.Name == "Ramen").FoodID,
                    DrinkID=drinks.Single(d => d.Name == "Water").DrinkID,
                    HealthGrade=HealthGrade.A
                },
                new Menu
                {
                    FoodID=foods.Single(f => f.Name == "Sandwich").FoodID,
                    DrinkID=drinks.Single(d => d.Name == "Lager").DrinkID,
                    HealthGrade=HealthGrade.D
                }
            };

            foreach(Menu m in menus)
            {
                //
                var menuInDatabase = context.Menus.Where(
                    f =>
                        f.Food.FoodID == m.FoodID &&
                        f.Drink.DrinkID == m.DrinkID).SingleOrDefault();

                if(menuInDatabase == null)
                {
                    context.Menus.Add(m);
                }
            }
            context.SaveChanges();
        }
    }
}
