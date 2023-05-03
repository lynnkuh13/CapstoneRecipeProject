using System;
using System.Globalization;
using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.VisualBasic;
using System.Reflection;
using System.Drawing;
using System.Net.NetworkInformation;
using System.Text;
using System.Numerics;
using System.Globalization;
using System.Runtime.Intrinsics.X86;
using CapstoneRecipeProject;
using System.Runtime;


namespace CapstoneRecipeProject
{
    public class RecipeOperations
    {
        private Recipe recipe;
        private List<Recipe> recipes;


    public RecipeOperations()
    {
            recipe = new Recipe();
            recipes = new List<Recipe>();
    }


    public void AddRecipe(List<Recipe> recipeList)
        {
            Console.WriteLine("");
            Console.WriteLine("Please add a recipe title");
            string userInput = Console.ReadLine().Trim();
            string[] words = userInput.Split(' ');
            for (int i = 0; i < words.Length; i++)
            {
                words[i] = char.ToUpper(words[i][0]) + words[i].Substring(1);
            }
            string output = string.Join(" ", words);


            while (String.IsNullOrWhiteSpace(output))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Please add a recipe title");
                userInput = Console.ReadLine().Trim();
                string[] wrds = userInput.Split(' ');
                for (int i = 0; i < wrds.Length; i++)
                {
                    wrds[i] = char.ToUpper(wrds[i][0]) + wrds[i].Substring(1);
                }
                string join = string.Join(" ", wrds);


            }

            recipe.Title = output;

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

            while (ingred.ToUpper().Trim() != "END")
            {
                recipe.ingredients.Add(ingred);
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine("Add another ingredient?");
                ingred = Console.ReadLine().Trim();
            }

            Console.WriteLine("");
            Console.WriteLine("Please add the recipe instructions");
            string instruct = Console.ReadLine().Trim();
            TextInfo myCap = CultureInfo.CurrentCulture.TextInfo;
            string capString = myCap.ToTitleCase(instruct);
            instruct = capString;

            while (String.IsNullOrWhiteSpace(instruct))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Please add the recipe instructions");
                userInput = Console.ReadLine().Trim();
                TextInfo cap = CultureInfo.CurrentCulture.TextInfo;
                string cpString = cap.ToTitleCase(instruct);
                instruct = capString;

            }

            recipe.Instructions = instruct;

            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("");
            Console.WriteLine("Recipe added");
            recipeList.Add(recipe);
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.Black;
        }

        public void UpdateRecipeTitle(List<Recipe> recipeList)
        {
            Console.WriteLine("");
            Console.WriteLine("Please enter the recipe title");
            string userInput = Console.ReadLine().Trim();
            string[] words = userInput.Split(' ');
            for (int i = 0; i < words.Length; i++)
            {
                words[i] = char.ToUpper(words[i][0]) + words[i].Substring(1);
            }
            string output = string.Join(" ", words);

            while (String.IsNullOrWhiteSpace(output))
            {
                Console.WriteLine("");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Please enter the recipe title");
                userInput = Console.ReadLine().Trim();
                string[] wrds = userInput.Split(' ');
                for (int i = 0; i < wrds.Length; i++)
                {
                    wrds[i] = char.ToUpper(wrds[i][0]) + wrds[i].Substring(1);
                }
                string outputString = string.Join(" ", wrds);

            }

            Recipe recipeToUpdate = recipeList.FirstOrDefault(r => r.Title == output);


            if (recipeToUpdate != null)
            {
                Console.ForegroundColor = ConsoleColor.Black;

                Console.WriteLine();
                Console.WriteLine("Enter new recipe title");
                string input = Console.ReadLine().Trim();
                string[] wrds = input.Split(' ');
                for (int i = 0; i < wrds.Length; i++)
                {
                    wrds[i] = char.ToUpper(wrds[i][0]) + wrds[i].Substring(1);
                }
                string join = string.Join(" ", wrds);

                recipeToUpdate.Title = join;
                Console.WriteLine();


                Console.WriteLine();
                Console.WriteLine("The recipe title is updated");
                Console.WriteLine();

            }
            else
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("The recipe does not exist");
                Console.WriteLine();
            }

            Console.ForegroundColor = ConsoleColor.Black;

        }

        public void UpdateRecipeIngredient(List<Recipe> recipeList)
        {
            Console.WriteLine("");
            Console.WriteLine("Please enter the recipe title");
            string recipeTitle = Console.ReadLine().Trim();
            string[] words = recipeTitle.Split(' ');
            for (int i = 0; i < words.Length; i++)
            {
                words[i] = char.ToUpper(words[i][0]) + words[i].Substring(1);
            }
            string output = string.Join(" ", words);


            while (String.IsNullOrWhiteSpace(output))
            {
                Console.WriteLine("");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Please enter the recipe title");
                recipeTitle = Console.ReadLine().Trim();
                string[] wrds = recipeTitle.Split(' ');
                for (int i = 0; i < wrds.Length; i++)
                {
                    wrds[i] = char.ToUpper(wrds[i][0]) + wrds[i].Substring(1);
                }
                string outputString = string.Join(" ", wrds);
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
                newIngredient = Console.ReadLine().Trim();
            }

            bool recipeFound = false;

            foreach (Recipe recipe in recipeList)
            {
                if (recipe.Title == output)
                {
                    recipeFound = true;

                    for (int i = 0; i < recipe.ingredients.Count; i++)
                    {
                        if (recipe.ingredients[i].IndexOf(oldIngredient, StringComparison.OrdinalIgnoreCase) >= 0)
                        {
                            recipe.ingredients[i] = newIngredient;

                            Console.WriteLine();
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Ingredient updated successfully");
                            recipeList.Add(recipe);
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.WriteLine();
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
                Console.WriteLine();
                userInput = Console.ReadLine().Trim();
                TextInfo ti = CultureInfo.CurrentCulture.TextInfo;
                string capString = ti.ToTitleCase(userInput);
                userInput = capString;
                recipeToUpdate.Instructions = userInput;
                Console.WriteLine();
                Console.WriteLine("The recipe instructions are updated");
                Console.WriteLine();
                recipeList.Add(recipeToUpdate);

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

        public void DeleteRecipe(List<Recipe> recipeList)
        {
            Console.WriteLine("");
            Console.WriteLine("Please enter the recipe title to delete recipe");
            string userInput = Console.ReadLine().Trim();

            //capitalize the userInput words

            string[] words = userInput.Split(' ');
            for (int i = 0; i < words.Length; i++)
            {
                words[i] = char.ToUpper(words[i][0]) + words[i].Substring(1);
            }
            string output = string.Join(" ", words);

            Boolean found = false;


            while (String.IsNullOrWhiteSpace(output))
            {
                Console.WriteLine("");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Please enter the recipe title to delete recipe");
                userInput = Console.ReadLine().Trim();
                string[] wrds = userInput.Split(' ');
                for (int i = 0; i < wrds.Length; i++)
                {
                    wrds[i] = char.ToUpper(wrds[i][0]) + wrds[i].Substring(1);
                }
                string join = string.Join(" ", wrds);


            }



            foreach (Recipe recipe in recipeList)
            {
                
                if (recipe.Title == output)
                {
                    Console.WriteLine();
                    Console.WriteLine("Recipe is deleted");
                    Console.WriteLine();
                    recipeList.Remove(recipe);
                    found = true;
                    break;
                }
                
            }

            if (!found)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine();
                Console.WriteLine("The recipe is not found");
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Black;

            }


            Console.ForegroundColor = ConsoleColor.Black;

        }


        public void DisplayRecipes(List<Recipe> recipeList)
        {
         
            Console.WriteLine("");
            Console.WriteLine("Please enter the recipe title");
            string userInput = Console.ReadLine().Trim();
            string[] words = userInput.Split(' ');
            for (int i = 0; i < words.Length; i++)
            {
                words[i] = char.ToUpper(words[i][0]) + words[i].Substring(1);
            }
            string output = string.Join(" ", words);


            while (String.IsNullOrWhiteSpace(output))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Please add a recipe title");
                userInput = Console.ReadLine().Trim();
                string[] wrds = userInput.Split(' ');
                for (int i = 0; i < wrds.Length; i++)
                {
                    wrds[i] = char.ToUpper(wrds[i][0]) + wrds[i].Substring(1);
                }
                string outString = string.Join(" ", wrds);
            }

                int index = recipeList.FindIndex(item => item.Title == output);
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
                    Console.WriteLine("Recipe not found");
                    Console.WriteLine("");
                }

                Console.ForegroundColor = ConsoleColor.Black;
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

            Recipe recipe2 = new Recipe();
            recipe2.Title = "Chicken Salad";
            recipe2.ingredients.Add("chicken");
            recipe2.ingredients.Add("lettuce");
            recipe2.ingredients.Add("tomatoes");
            recipe2.ingredients.Add("paprika");
            recipe2.Instructions = "Put chicken on salad";

            recipeList.Add(recipe2);

            foreach (Recipe rc in recipeList)
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

        public void DisplayAllRecipes(List<Recipe> recipeList)
        {

            foreach (Recipe rc in recipeList)
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

        public void PrintRecipe()
        {
            Console.WriteLine("");
            Console.WriteLine("Please enter the recipe title");
            string userInput = Console.ReadLine().Trim();
            TextInfo myTI = CultureInfo.CurrentCulture.TextInfo;
            string capitalizedString = myTI.ToTitleCase(userInput);
            userInput = capitalizedString;

            while (String.IsNullOrWhiteSpace(userInput))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Please add a recipe title");
                userInput = Console.ReadLine().Trim();
                TextInfo myCap = CultureInfo.CurrentCulture.TextInfo;
                string capString = myCap.ToTitleCase(userInput);
                userInput = capString;
            }

            Console.ForegroundColor = ConsoleColor.Black;
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

            if (recipe.category.categories.Contains(userInput))
            {
                Console.WriteLine("");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("You entered a category that already exists");
                Console.WriteLine("");
            }
            else
            {
                recipe.category.categories.Add(userInput);
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

            if (recipe.category.categories.Count() > 0)
            {
                foreach (var item in recipe.category.categories)
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

        public void DesiredRecipes(List<Recipe> recipeList)
        {
            
           Console.WriteLine();
           Console.WriteLine("Enter desired ingredients (separated by comma) which will give you recipes");
           Console.WriteLine();
           string input = Console.ReadLine().TrimEnd(',');


            List<string> desiredIngredients = input.Split(',').Select(x => x.Trim()).ToList();

           var filteredRecipes = recipeList.Where(recipe => desiredIngredients.All(ingredient => recipe.ingredients.Contains(ingredient)));

           Console.WriteLine();
           Console.WriteLine("Recipes that contain all of the desired ingredients:");
           Console.WriteLine();

            foreach (var recipe in filteredRecipes)
            {
                Console.WriteLine($"* {recipe.Title}");
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

            Console.WriteLine();
            Console.WriteLine("Top 5 ingredients");
            Console.WriteLine();

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

        public void CostOfRecipe()
        {

        }



    }

        
}

