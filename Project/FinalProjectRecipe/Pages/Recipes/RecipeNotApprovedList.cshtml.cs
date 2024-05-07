using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RecipeModels;
using Services;
using Services.InterfacesServices;

namespace FinalProjectRecipe.Pages.Recipes
{
    public class RecipeNotApprovedModel : PageModel
    {
        private static IRecipeServices _services = new RecipeServices();

        public List<Recipe> Recipes { get; set; }
        
        
        public void OnGet()
        {
            Recipes = _services.GetAllRecipesNotApproved();
           
        }

        public IActionResult OnPostGetRecipeDetails(int id)
        {

            return new RedirectToPageResult("/Recipes/RecipeForApproved", new { recipeId = id.ToString() });
        }

    }
}
