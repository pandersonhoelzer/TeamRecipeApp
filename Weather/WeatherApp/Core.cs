using Newtonsoft.Json.Linq;
using System;
using System.Threading.Tasks;

namespace WeatherApp
{
    public class Core
    {
        public static async Task<Recipe> GetRecipe(string searchTerm)
        {

            // **START recipe search API
            // documentation https://developer.edamam.com/edamam-docs-recipe-api

            string key = "4f9099da52f998eb02261e0714715495";
            string id = "cfafedc8";
            string queryString = "https://api.edamam.com/search?q=" + System.Uri.EscapeUriString(searchTerm) + "&app_id=" + id + "&app_key=" + key;
            // **END recipe search API

            dynamic results = await DataService.GetDataFromService(queryString).ConfigureAwait(true);

            Recipe recipe = new Recipe();
            // recipe name
            recipe.RecipeLabelContent = (string)results["hits"][0]["recipe"]["label"];
            // recipe ingredients
                // count all ingredients in array
            int NumberofIngredients = results["hits"][0]["recipe"]["ingredients"].Count;
                // loop to put all ingredients in ingredient array in 1 string
                for (int i = 0; i < NumberofIngredients; i++)
                {
                    recipe.IngredientsContent += ((string)results["hits"][i]["recipe"]["ingredients"][1]["text"] + "\n");
                }
            // recipe URL
            recipe.RecipeURL = (string)results["hits"][0]["recipe"]["url"];
            // recipe image URL
            recipe.RecipeImageURL = (string)results["hits"][0]["recipe"]["image"];



            return recipe;

        }

    }
}