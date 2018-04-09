using System;
using Android.App;
using Android.Widget;
using Android.OS;

namespace WeatherApp.Android
{
    [Activity(Label = "WeatherApp.Android", 
              Theme = "@android:style/Theme.Material.Light", 
              MainLauncher = true)]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            Button button = FindViewById<Button>(Resource.Id.SearchBtn);

            button.Click += Button_Click;
        }

        private async void Button_Click(object sender, EventArgs e)
        {
            EditText SearchTermTextEntry = FindViewById<EditText>(Resource.Id.SearchTermTextEntry);

            if (!String.IsNullOrEmpty(SearchTermTextEntry.Text))
            {
                Recipe recipe = await Core.GetRecipe(SearchTermTextEntry.Text);
                if (recipe != null)
                {
                    /** START: EXAMPLE **/
                    /**
                    FindViewById<TextView>(Resource.Id.{name_of_element_in_Main.axml}).Text = recipe.{name_of_variable_in_Weather.cs};
                    **/
                    /** END: EXAMPLE **/

                    FindViewById<TextView>(Resource.Id.RecipeLabelContent).Text = recipe.RecipeLabelContent;
                    FindViewById<TextView>(Resource.Id.IngredientsContent).Text = recipe.IngredientsContent;

                }
            }
        }
    }
}