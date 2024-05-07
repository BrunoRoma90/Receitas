using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Services;
using RecipeModels;
using Services.InterfacesServices;

namespace FinalProjectRecipe.Pages.Recipes
{
    public class RecipeListModel : PageModel
    {
        private static IRecipeServices _services = new RecipeServices();
        [BindProperty]
        
        
        public List<Recipe> Recipes { get; set; }
        public void OnGet()
        {

            Recipes = _services.GetAllRecipesApproved();
           
        }
        public IActionResult OnPostGetRecipeDetails(int id)
        {

            return new RedirectToPageResult("/Recipes/Recipe", new { recipeId = id.ToString() });
        }
    }
}
