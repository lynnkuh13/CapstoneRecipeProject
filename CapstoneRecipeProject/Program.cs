using System;
using System.Drawing.Printing;
using System.Collections;
using System.Collections.Generic;
using Microsoft.VisualBasic;
using System.Reflection;
using System.Drawing;
using System.Net.NetworkInformation;
using System.Text;
using System.Numerics;
using CapstoneRecipeProject;
using System.Globalization;
using System.Runtime.Intrinsics.X86;


namespace CapstoneRecipeProject
{
    class Program
    {
        static void Main(String[] args)
        {


            Recipe recipe = new Recipe();
            List<Recipe> recipeList = new List<Recipe>();
            RecipeOperations ro = new RecipeOperations();

            ro.LoadDummyData(recipeList);

         //   recipe.LoadDummyData(recipeList);

        //    ro.DisplayRecipes(recipeList);


            string userInput = recipe.Intro();

            while (userInput != "QUIT")
            {
                if (!String.IsNullOrWhiteSpace(userInput))
                {
                    switch (userInput)
                    {
                        case "ADD":
                            ro.AddRecipe(recipeList);
                            Console.WriteLine();
                            Console.WriteLine("What would you like to do?");
                            Console.WriteLine();
                            userInput = Console.ReadLine().ToUpper().Trim();
                            break;
                        case "UPDATE TITLE":
                            ro.UpdateRecipeTitle(recipeList);
                            Console.WriteLine();
                            Console.WriteLine("What would you like to do?");
                            Console.WriteLine();
                            userInput = Console.ReadLine().ToUpper().Trim();
                            break;
                        case "UPDATE INGRED":
                            ro.UpdateRecipeIngredient(recipeList);
                            Console.WriteLine();
                            Console.WriteLine("What would you like to do?");
                            Console.WriteLine();
                            userInput = Console.ReadLine().ToUpper().Trim();
                            break;
                        case "UPDATE INS":
                            ro.UpdateRecipeInstructions(recipeList);
                            Console.WriteLine();
                            Console.WriteLine("What would you like to do?");
                            Console.WriteLine();
                            userInput = Console.ReadLine().ToUpper().Trim();
                            break;
                        case "DELETE RECIPE":
                            ro.DeleteRecipe(recipeList);
                            Console.WriteLine();
                            Console.WriteLine("What would you like to do?");
                            Console.WriteLine();
                            userInput = Console.ReadLine().ToUpper().Trim();
                            break;
                        case "PRINT RECIPE":
                            ro.PrintRecipe();
                            Console.WriteLine();
                            Console.WriteLine("What would you like to do?");
                            Console.WriteLine();
                            userInput = Console.ReadLine().ToUpper().Trim();
                            break;
                        case "PRINT RECIPE TITLES":
                            ro.PrintRecipeTitles(recipeList);
                            Console.WriteLine();
                            Console.WriteLine("What would you like to do?");
                            Console.WriteLine();
                            userInput = Console.ReadLine().ToUpper().Trim();
                            break;
                        case "CATEGORY":
                            ro.AddCategory();
                            Console.WriteLine();
                            Console.WriteLine("What would you like to do?");
                            Console.WriteLine();
                            userInput = Console.ReadLine().ToUpper().Trim();
                            break;
                        case "DISPLAY CATEGORIES":
                            ro.DisplayCategories();
                            Console.WriteLine();
                            Console.WriteLine("What would you like to do?");
                            Console.WriteLine();
                            userInput = Console.ReadLine().ToUpper().Trim();
                            break;
                        case "FIND BY INGRED":
                            ro.DesiredRecipes(recipeList);
                            Console.WriteLine();
                            Console.WriteLine("What would you like to do?");
                            Console.WriteLine();
                            userInput = Console.ReadLine().ToUpper().Trim();
                            break;
                        case "SORT BY 5":
                            ro.Top5Ingredients(recipeList);
                            Console.WriteLine();
                            Console.WriteLine("What would you like to do?");
                            Console.WriteLine();
                            userInput = Console.ReadLine().ToUpper().Trim();
                            break;
                        case "DISPLAY":
                            ro.DisplayRecipes(recipeList);
                            Console.WriteLine();
                            Console.WriteLine("What would you like to do?");
                            Console.WriteLine();
                            userInput = Console.ReadLine().ToUpper().Trim();
                            break;
                        case "DISPLAY ALL RECIPES":
                            ro.DisplayAllRecipes(recipeList);
                            Console.WriteLine();
                            Console.WriteLine("What would you like to do?");
                            Console.WriteLine();
                            userInput = Console.ReadLine().ToUpper().Trim();
                            break;
                        case "COST":
                            ro.CostOfRecipe();
                            Console.WriteLine();
                            Console.WriteLine("What would you like to do?");
                            Console.WriteLine();
                            userInput = Console.ReadLine().ToUpper().Trim();
                            break;
                        case "MENU":
                            recipe.Intro();
                            Console.WriteLine();
                            Console.WriteLine("What would you like to do?");
                            Console.WriteLine();
                            userInput = Console.ReadLine().ToUpper().Trim();
                            break;
                        case "QUIT":
                            break;
                        default:
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine();
                            Console.WriteLine("Please choose a valid menu item");
                            Console.WriteLine();
                            Console.ForegroundColor = ConsoleColor.Black;
                            userInput = Console.ReadLine().ToUpper().Trim();
                            break;
                    }

                    Console.ForegroundColor = ConsoleColor.Black;
                }
                else
                {
                    
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine();
                    Console.WriteLine("Please choose a valid menu item");
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Black;
                    userInput = Console.ReadLine().ToUpper().Trim();
                }
            }
        }
    }

    public class Recipe
    {
        public string Title { get; set; }
        public string Instructions { get; set; }
        string currentTime = DateTime.Now.ToString();
        string userInput = "";
        public Category category = new Category();


        public List<string> ingredients = new List<string>();


        public string Intro()
        {
            Console.WriteLine(currentTime);
            Console.WriteLine("");
            Console.WriteLine("Welcome to Lynn's recipes! In this application you can do a series of things.");
            Console.WriteLine("Please choose from a following menu item");
            Console.WriteLine("");
            Console.WriteLine("• ADD a recipe");
            Console.WriteLine("• Revise / UPDATE TITLE recipe title");
            Console.WriteLine("• Revise / UPDATE INGRED recipe ingredient");
            Console.WriteLine("• Revise / UPDATE INS recipe instructions");
            Console.WriteLine("• Delete a recipe - DELETE RECIPE");
            Console.WriteLine("• Print a recipe – PRINT RECIPE");
            Console.WriteLine("• Display all recipe titles – PRINT RECIPE TITLES");
            Console.WriteLine("• Add a CATEGORY – lunch, dinner, desert, etc.");
            Console.WriteLine("• Display all categories – DISPLAY CATEGORIES");
            Console.WriteLine("• Display by 5 ingredients – FIND BY INGRED");
            Console.WriteLine("• Sort by top 5 ingredients in recipes(up to 5 things) – TOP 5");
            Console.WriteLine("• DISPLAY a recipe");
            Console.WriteLine("• DISPLAY ALL RECIPES");
            Console.WriteLine("• Keep track of what the recipe costs - COST");
            Console.WriteLine("• MENU - see this menu displayed");
            Console.WriteLine("• QUIT recipes");
            Console.WriteLine("");

            Console.WriteLine("What would you like to do?");

            userInput = Console.ReadLine().ToUpper().Trim();
            return userInput;

        }

        public void AddRecipe()
        {
            Console.WriteLine("");
            Console.WriteLine("Please add a recipe title");
            string userInput = Console.ReadLine().Trim();

            while (String.IsNullOrWhiteSpace(userInput))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Please add a recipe title");
                userInput = Console.ReadLine().ToUpper().Trim();
            }

            Title = userInput;

            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("Please add ingredients. When done entering please type in END");
            string ingred = Console.ReadLine().ToLower().Trim();


            while (String.IsNullOrWhiteSpace(ingred))
            {
                Console.WriteLine("");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Please add an ingredient");
                ingred = Console.ReadLine().Trim();
            }

            Console.ForegroundColor = ConsoleColor.Black;

            while (ingred.ToUpper().Trim() != "END")
            {
                ingredients.Add(ingred);
                Console.WriteLine("Add another ingredient?");
                ingred = Console.ReadLine().Trim();
            }

            Console.WriteLine("");
            Console.WriteLine("Please add the recipe instructions");
            string instruct = Console.ReadLine().Trim();

            while (String.IsNullOrWhiteSpace(instruct))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Please add the recipe instructions");
                userInput = Console.ReadLine().Trim();
            }

            Console.ForegroundColor = ConsoleColor.Black;
            Instructions = instruct;

            Console.WriteLine("");
            Console.WriteLine("Recipe added");
            Console.WriteLine("");
        }

        public void UpdateRecipeTitle(List<Recipe> recipeList)
        {
            Console.WriteLine("");
            Console.WriteLine("Please enter the recipe title");
            userInput = Console.ReadLine().Trim();
            TextInfo myTI = CultureInfo.CurrentCulture.TextInfo;
            string capitalizedString = myTI.ToTitleCase(userInput);
            userInput = capitalizedString;

            while (String.IsNullOrWhiteSpace(userInput))
            {
                Console.WriteLine("");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Please enter the recipe title");
                userInput = Console.ReadLine().Trim();
            }

            Recipe recipeToUpdate = recipeList.FirstOrDefault(r => r.Title == userInput);

            if (recipeToUpdate != null)
            {
                Console.ForegroundColor = ConsoleColor.Black;
                recipeToUpdate.Title = userInput;

                Console.WriteLine("");
                Console.WriteLine("The recipe title is updated");
                Console.WriteLine("");

            }
            else
            {
                Console.WriteLine("");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("The recipe does not exist");
                Console.WriteLine("");
            }

            Console.ForegroundColor = ConsoleColor.Black;

        }

        public void UpdateRecipeIngredient(List<Recipe> recipeList)
        {
            Console.WriteLine("");
            Console.WriteLine("Please enter the recipe title");
            string recipeTitle = Console.ReadLine().Trim();

            while (String.IsNullOrWhiteSpace(recipeTitle))
            {
                Console.WriteLine("");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Please enter the recipe title");
                recipeTitle = Console.ReadLine().Trim();
            }

            
            Console.WriteLine("");
            Console.WriteLine("Please enter the recipe ingredient");
            string oldIngredient = Console.ReadLine().Trim();

            while (String.IsNullOrWhiteSpace(oldIngredient))
            {
                Console.WriteLine("");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Please enter the recipe ingredient");
                oldIngredient = Console.ReadLine().Trim();
            }

            Console.WriteLine("");
            Console.WriteLine("Please enter the new recipe ingredient");
            string newIngredient = Console.ReadLine().Trim();

            while (String.IsNullOrWhiteSpace(newIngredient))
            {
                Console.WriteLine("");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Please enter the new recipe ingredient");
                recipeTitle = Console.ReadLine().Trim();
            }

            bool recipeFound = false;

            foreach (Recipe recipe in recipeList)
            {
                if (recipe.Title == recipeTitle)
                {
                    recipeFound = true;

                    for (int i = 0; i < recipe.ingredients.Count; i++)
                    {
                        if (recipe.ingredients[i].IndexOf(oldIngredient, StringComparison.OrdinalIgnoreCase) >= 0)
                        {
                            recipe.ingredients[i] = newIngredient;

                            Console.WriteLine("");
                            Console.WriteLine("Ingredient updated successfully");
                            Console.WriteLine("");
                            break;
                        }
                    }

                    if (!recipeFound)
                    {
                        Console.WriteLine("");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Ingredient not found in recipe");
                        Console.WriteLine("");

                    }

                    break;
                }
            }

            if (!recipeFound)
            {
                Console.WriteLine("");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Recipe title not found in list");
                Console.WriteLine("");
            }

            Console.ForegroundColor = ConsoleColor.Black;
        }



        public void UpdateRecipeInstructions(List<Recipe> recipeList)
        {
            Console.WriteLine("");
            Console.WriteLine("Please enter the recipe title");
            string userInput = Console.ReadLine().Trim();
            TextInfo myTI = CultureInfo.CurrentCulture.TextInfo;
            string capitalizedString = myTI.ToTitleCase(userInput);
            userInput = capitalizedString;
            


            while (String.IsNullOrWhiteSpace(userInput))
            {
                Console.WriteLine("");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Please enter the recipe title");
                userInput = Console.ReadLine().Trim();
                TextInfo ti = CultureInfo.CurrentCulture.TextInfo;
                string capString = ti.ToTitleCase(userInput);
                userInput = capString;

            }

            Recipe recipeToUpdate = recipeList.FirstOrDefault(r => r.Title == userInput);

            if (recipeToUpdate != null)
            {
                Console.WriteLine();
                Console.WriteLine("Please enter the new instructions");
                recipeToUpdate.Instructions = userInput;
                Console.WriteLine();

                Console.WriteLine();
                Console.WriteLine("The recipe instructions are updated");
                Console.WriteLine();
                

            }
            else
            {
                Console.WriteLine("");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("The recipe does not exist");
                Console.WriteLine("");
            }

            Console.ForegroundColor = ConsoleColor.Black;

        }

        public void PrintRecipe()
        {
            Console.WriteLine("");
            Console.WriteLine("Please enter the recipe title");
            userInput = Console.ReadLine().Trim();
        }

        public void PrintRecipeTitles(List<Recipe> recipeList)
        {
            Console.WriteLine("");
            Console.WriteLine("The Recipe List:");
            Console.WriteLine("");


            foreach (Recipe recipe in recipeList)
            {
                if (recipe.Title != "null")
                {
                    Console.WriteLine($"* {recipe.Title}");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("There are no recipes");
                    Console.WriteLine("");
                    break;
                }
            }

            Console.ForegroundColor = ConsoleColor.Black;
        }

        public void AddCategory()
        {
            Console.WriteLine("");
            Console.WriteLine("Please enter a recipe category");
            string userInput = Console.ReadLine().ToUpper().Trim();

            while (String.IsNullOrWhiteSpace(userInput))
            {
                Console.WriteLine("Please enter a recipe category");
                userInput = Console.ReadLine().ToUpper().Trim();
            }

            if (category.categories.Contains(userInput))
            {
                Console.WriteLine("");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("You entered a category that already exists");
                Console.WriteLine("");
            }
            else
            {
                category.categories.Add(userInput);
                Console.WriteLine("");
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine($"The recipe category {userInput} is added");
                Console.WriteLine("");
            }

            Console.ForegroundColor = ConsoleColor.Black;

        }

        public void DisplayCategories()
        {
            Console.WriteLine("");
            Console.WriteLine("Recipe Categories");
            Console.WriteLine("");

            if (category.categories.Count() > 0)
            {
                foreach (var item in category.categories)
                {
                    Console.WriteLine($"* {item}");
                }
                Console.WriteLine("");
            }
            else
            {
                Console.WriteLine("");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No categories have been added to recipes.");
                Console.WriteLine("");
            }

            Console.ForegroundColor = ConsoleColor.Black;

        }

        public void SortBy5(List<Recipe> recipeList)
        {
            Console.WriteLine("");


            while (true)
            {
                Console.WriteLine("Enter desired ingredients (separated by comma) or type QUIT to exit");
                string input = Console.ReadLine().Trim();
                Console.WriteLine($"Ingredients {input}");
                Console.ReadKey();


                if (input == "QUIT")
                {
                    break;
                }

                List<string> desiredIngredients = input.Split(',').Select(x => x.Trim()).ToList();

                var filteredRecipes = recipeList.Where(recipe => desiredIngredients.All(ingredient => recipe.ingredients.Contains(ingredient)));

                Console.WriteLine("Recipes that contain all of the desired ingredients:");
                Console.WriteLine("");

                foreach (var recipe in filteredRecipes)
                {
                    Console.WriteLine($"* {recipe.Title}");
                }
            }


        }


        public void Top5Ingredients(List<Recipe> recipeList)
        {
            // Assuming we have a List<Recipe> called "recipes"
            List<string> ingredients = recipeList.SelectMany(recipe => recipe.ingredients)
                                                .GroupBy(ingredient => ingredient)
                                                .OrderByDescending(group => group.Count())
                                                .Take(5)
                                                .Select(group => group.Key)
                                                .ToList();

            Console.WriteLine("");
            Console.WriteLine("Top 5 ingredients");

            if (ingredients.Count > 0)
            {
                foreach (var ingredient in ingredients)
                {
                    Console.WriteLine($"* {ingredient}");
                }

                Console.WriteLine("");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("There are no ingredients");
            }

            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("");

        }


        public void DisplayRecipe(List<Recipe> recipeList)
        {
            Console.WriteLine("");
            Console.WriteLine("Please enter the recipe title");
            string userInput = Console.ReadLine().Trim();

            while (String.IsNullOrWhiteSpace(userInput))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Please add a recipe title");
                userInput = Console.ReadLine().Trim();
            }

            int index = recipeList.FindIndex(item => item.Title == userInput);
            // If index = -1 then the title is not found

            if (index >= 0)
            {
                var Title = recipeList[index].Title;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine("");
                Console.WriteLine("Recipe Title");
                Console.WriteLine("");
                Console.WriteLine(Title);
                Console.WriteLine("");

                Console.WriteLine("");
                Console.WriteLine("Recipe Ingredients");
                Console.WriteLine("");

                foreach (string item in recipeList[index].ingredients)
                {
                    Console.WriteLine($"* {item}");
                }

                Console.WriteLine("");
                Console.WriteLine("Recipe Instructions");
                Console.WriteLine("");

                var Instructions = recipeList[index].Instructions;
                Console.WriteLine(Instructions);
                Console.WriteLine("");


            }
            else
            {

                Console.WriteLine("");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No recipes are found");
                Console.WriteLine("");
            }

            Console.ForegroundColor = ConsoleColor.Black;
        }

        public void CostOfRecipe()
        {

        }

        public void LoadDummyData(List<Recipe> recipeList)
        {
            Recipe recipe = new Recipe();
            recipe.Title = "Beef Stroganoff";
            recipe.ingredients.Add("beef");
            recipe.ingredients.Add("onions");
            recipe.ingredients.Add("garlic");
            recipe.ingredients.Add("worchester sauce");
            recipe.ingredients.Add("sour cream");
            recipe.Instructions = "Put beef in pan";

            recipeList.Add(recipe);


            Recipe recipe1 = new Recipe();
            recipe1.Title = "Fried Chicken";
            recipe1.ingredients.Add("chicken");
            recipe1.ingredients.Add("flour");
            recipe1.ingredients.Add("oil spray");
            recipe1.ingredients.Add("paprika");
            recipe1.Instructions = "Put chicken in pan";

            recipeList.Add(recipe1);

            foreach(Recipe rc in recipeList)
            {
                Console.WriteLine("Recipe title");
                Console.WriteLine();
                Console.WriteLine($"{rc.Title}");
                Console.WriteLine();
                Console.WriteLine("Ingredients");
                Console.WriteLine();
                foreach (string ingred in rc.ingredients)
                {
                       Console.WriteLine($"* {ingred}");
                       
                 }
                    Console.WriteLine();
                    Console.WriteLine("Recipe instructions");
                    Console.WriteLine();
                    Console.WriteLine($"{rc.Instructions}");
                    Console.WriteLine();
                }

            }

    }

}


