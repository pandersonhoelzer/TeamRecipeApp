// this .cs file brings stuff from the Core.cs file to the MainActivity.cs file

namespace WeatherApp
{
    public class Recipe
    {
        // Because labels bind to these values, set them to an empty string to
        // ensure that the label appears on all platforms by default.

        //** Daniel: these variable names are what will need to be called in the MainActivity.cs file

        public string RecipeLabelContent    { get; set; } = " ";
        public string IngredientsContent    { get; set; } = " ";
        public string RecipeURL             { get; set; } = " ";
        public string RecipeImageURL        { get; set; } = " ";
        public string CookingInstructions   { get; set; } = " ";
    }
}
