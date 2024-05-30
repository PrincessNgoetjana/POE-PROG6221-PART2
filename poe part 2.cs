// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
using System;
using System.Collections.Generic;

namespace RecipeApp
{
    class Ingredient
    {
        public string Name { get; set; }
        public double Quantity { get; set; }
        public string Unit { get; set; }
        public double Calories { get; set; }
        public string FoodGroup { get; set; }
    }

    class RecipeStep
    {
        public string Description { get; set; }
    }

    class Recipe
    {
        private List<Ingredient> ingredients;
        private List<RecipeStep> steps;

        public Recipe()
        {
            ingredients = new List<Ingredient>();
            steps = new List<RecipeStep>();
        }

        public void AddIngredient(Ingredient ingredient)
        {
            ingredients.Add(ingredient);
        }

        public void AddStep(RecipeStep step)
        {
            steps.Add(step);
        }

        public void Clear()
        {
            ingredients.Clear();
            steps.Clear();
        }

        public void Scale(double factor)
        {
            foreach (var ingredient in ingredients)
            {
                ingredient.Quantity *= factor;
            }
        }

        public void Reset()
        {
            // Reset quantities to original values
            // Assuming original quantities are stored somewhere
        }

        public void DisplayRecipe()
        {
            Console.WriteLine("Recipe:");

            Console.WriteLine("Ingredients:");
            foreach (var ingredient in ingredients)
            {
                Console.WriteLine($"{ingredient.Quantity} {ingredient.Unit} of {ingredient.Name}");
            }

            Console.WriteLine("Steps:");
            for (int i = 0; i < steps.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {steps[i].Description}");
            }
        }

        public double CalculateTotalCalories()
        {
            double totalCalories = 0;
            foreach (var ingredient in ingredients)
            {
                totalCalories += ingredient.Calories;
            }
            return totalCalories;
        }

        public void NotifyCalorieExceeded()
        {
            if (CalculateTotalCalories() > 300)
            {
                Console.WriteLine("Total calories exceed 300!");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Recipe> recipes = new List<Recipe>();

            while (true)
            {
                Console.WriteLine("Enter recipe name (or 'exit' to quit):");
                string recipeName = Console.ReadLine();

                if (recipeName == "exit")
                    break;

                Recipe recipe = new Recipe();

                Console.WriteLine("Enter the number of ingredients:");
                int ingredientCount = int.Parse(Console.ReadLine());

                for (int i = 0; i < ingredientCount; i++)
                {
                    Console.WriteLine("Enter ingredient name:");
                    string name = Console.ReadLine();

                    Console.WriteLine("Enter ingredient quantity:");
                    double quantity = double.Parse(Console.ReadLine());

                    Console.WriteLine("Enter ingredient unit of measurement:");
                    string unit = Console.ReadLine();

                    Console.WriteLine("Enter ingredient calories:");
                    double calories = double.Parse(Console.ReadLine());

                    Console.WriteLine("Enter ingredient food group:");
                    string foodGroup = Console.ReadLine();

                    recipe.AddIngredient(new Ingredient
                    {
                        Name = name,
                        Quantity = quantity,
                        Unit = unit,
                        Calories = calories,
                        FoodGroup = foodGroup
                    });
                }

                Console.WriteLine("Enter the number of steps:");
                int stepCount = int.Parse(Console.ReadLine());

                for (int i = 0; i < stepCount; i++)
                {
                    Console.WriteLine($"Enter step {i + 1} description:");
                    string description = Console.ReadLine();
                    recipe.AddStep(new RecipeStep
                    {
                        Description = description
                    });
                }

                recipes.Add(recipe);
            }

            Console.WriteLine("Recipes:");

            foreach (var recipe in recipes)
            {
                Console.WriteLine(recipe.Name);
            }

            Console.WriteLine("Enter the name of the recipe to display:");
            string recipeToDisplay = Console.ReadLine();

            Recipe selectedRecipe = recipes.Find(r => r.Name == recipeToDisplay);

            if (selectedRecipe != null)
            {
                selectedRecipe.DisplayRecipe();

                double totalCalories = selectedRecipe.CalculateTotalCalories();
                Console.WriteLine($"Total Calories: {totalCalories}");

                selectedRecipe.NotifyCalorieExceeded();
            }
            else
            {
                Console.WriteLine("Recipe not found!");
            }
        }
    }

}
