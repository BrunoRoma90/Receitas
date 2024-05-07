using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RecipeModels;
using Services;
using Services.InterfacesServices;

namespace FinalProjectRecipe.Pages.Recipes
{
    public class SearchRecipeModel : PageModel
    {
        private IRecipeServices recipeServices = new RecipeServices();
        public List<Recipe> Recipes { get; set; }
        public void OnGet(string searchTerm)
        {
            Recipes = recipeServices.SearchRecipes(searchTerm);
        }
        public IActionResult OnPostGetRecipeDetails(int id)
        {

            return new RedirectToPageResult("/Recipes/Recipe", new { recipeId = id.ToString() });
        }
    }
}
