using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RecipeModels;
using Services;
using System.Xml.Linq;
using Services.InterfacesServices;

namespace FinalProjectRecipe.Pages.Recipes
{
    public class RecipeForApprovedModel : PageModel
    {
        private IRecipeServices services = new RecipeServices();
        public Recipe Recipe { get; set; }
        public List<RecipeIngredients> RecipeIngredients { get; set; }
        public void OnGet(int recipeId)
        {
            if (recipeId == null) { throw new ArgumentNullException("Invalid recipeId"); }
            Recipe = services.GetRecipeById(recipeId);
            RecipeIngredients = services.GetIngredientsByRecipeId(recipeId);
        }

        public IActionResult OnPostGetRecipeApproved(int id)
        {
            Recipe recipe = new Recipe();
            recipe.Id = id;
            services.UpdateRecipeForApproved(id);
            return new RedirectToPageResult("/Recipes/RecipeNotApprovedList");
        }


    }
}
