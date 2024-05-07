using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RecipeModels;
using Services;
using Services.InterfacesServices;

namespace FinalProjectRecipe.Pages.Ingredients
{
    public class IngredientListModel : PageModel
    {
        private static IIngredientServices _services = new IngredientServices();
        [BindProperty]

        public List<Ingredient> Ingredients { get; set; }
        public void OnGet()
        {
            Ingredients = _services.GetAllIngredients();
        }

        public IActionResult OnPostInsertIngredient()
        {

            return new RedirectToPageResult("/Ingredients/InsertIngredient");
        }

    }
}
