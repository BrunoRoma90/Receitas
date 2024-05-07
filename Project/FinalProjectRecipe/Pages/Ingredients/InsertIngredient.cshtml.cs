using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RecipeModels;
using Services;
using Services.InterfacesServices;

namespace FinalProjectRecipe.Pages.Ingredients
{
    public class InsertIngredientModel : PageModel
    {
        private IIngredientServices _ingredientServices = new IngredientServices();
        public Ingredient Ingredient { get; set; }
        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            bool isAnyFieldEmpty = false;
            Ingredient ingredient = new Ingredient();
            ingredient.Id = Convert.ToInt32(Request.Form["Ingredient.Id"]);
            if (!string.IsNullOrEmpty(Request.Form["Ingredient.Name"]))
            {
                ingredient.Name = Convert.ToString(Request.Form["Ingredient.Name"]);
            }
            else
            {
                isAnyFieldEmpty = true;
            }
            //ingredient.Name = Convert.ToString(Request.Form["Ingredient.Name"]);
            if (isAnyFieldEmpty)
            {
                TempData["ErrorMessageNullOrEmpty"] = "Choose the Ingredient!";
                return RedirectToPage();
            }

            Ingredient existingIngredient = _ingredientServices.GetIngredientByName(ingredient.Name);
            if (existingIngredient != null)
            {
                TempData["ErrorMessage"] = "This Ingredient already exists.";
                return RedirectToPage();
            }

            _ingredientServices.InsertNewIngredient(ingredient);

            return Redirect("/Ingredients/IngredientList");
        }

    }
}
