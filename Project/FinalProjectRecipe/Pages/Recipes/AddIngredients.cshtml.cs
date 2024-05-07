using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RecipeModels;
using Services;
using Services.InterfacesServices;
using System;
using System.ComponentModel.DataAnnotations;

namespace FinalProjectRecipe.Pages.Recipes
{
    public class AddIngredientsModel : PageModel
    {
        private IRecipeServices _recipeServices = new RecipeServices();
        
        private IIngredientServices _ingredientServices = new IngredientServices();
        private IUnitServices _unitServices = new UnitServices();
        public List<RecipeIngredients> RecipeIngredients { get; set; }
        [BindProperty]
        public RecipeIngredients RecipeIngredient { get; set; }
        public List<Unit> Unit { get; set; }
        public Recipe Recipe { get; set; }
        public Ingredient Ingredient { get; set; }

        public List<Ingredient> Ingredients { get; set; }

        public void OnGet()
        {
            int recipeId = _recipeServices.LastRecipeId();
            RecipeIngredients = _recipeServices.GetIngredientsByRecipeId(recipeId);
            Recipe = _recipeServices.GetRecipeById(recipeId);
            Ingredients = _ingredientServices.GetAllIngredients();
            Unit = _unitServices.GetAllUnits();
        }

        public IActionResult OnPost()
        {
            

            Recipe recipe = new Recipe();
            recipe.RecipeIngredients = new List<RecipeIngredients>();
            recipe.Id = _recipeServices.LastRecipeId();
            int selectedIngredientId;
            double quantity;
            int selectedUnitId;

            if (!string.IsNullOrEmpty(Request.Form["RecipeIngredient.Ingredient.Id"]))
            {
                selectedIngredientId = Convert.ToInt32(Request.Form["RecipeIngredient.Ingredient.Id"]);
            }
            else
            {
                selectedIngredientId = 0;
            }
            if (!string.IsNullOrEmpty(Request.Form["RecipeIngredient.Quantity"]))
            {
                if (double.TryParse(Request.Form["RecipeIngredient.Quantity"], out quantity))
                {
                    quantity = Convert.ToDouble(Request.Form["RecipeIngredient.Quantity"]);
                }
                else 
                {
                    TempData["ErrorMessageAddValidQuantity"] = "Please enter a valid quantity.";
                    return RedirectToPage();
                }
               
            }
            else
            {
                quantity = 0;
            }
            if (!string.IsNullOrEmpty(Request.Form["RecipeIngredient.Unit.Id"]))
            {
                selectedUnitId = Convert.ToInt32(Request.Form["RecipeIngredient.Unit.Id"]);
            }
            else 
            { 
                selectedUnitId = 0;
            }
            //int selectedIngredientId = Convert.ToInt32(Request.Form["RecipeIngredient.Ingredient.Id"]);
            //double quantity = Convert.ToDouble(Request.Form["RecipeIngredient.Quantity"]);
            //int selectedUnitId = Convert.ToInt32(Request.Form["RecipeIngredient.Unit.Id"]);

            if (selectedIngredientId == 0 || quantity <= 0 || selectedUnitId == 0)
            {
                
                TempData["ErrorMessageAddIngredientNullorEmpty"] = "Please fill in all fields before submitting the form.";
                return RedirectToPage();
            }

            Ingredient selectedIngredient = _ingredientServices.GetIngredientById(selectedIngredientId);
            Unit selectedUnit = _unitServices.GetUnitById(selectedUnitId);

            RecipeIngredients newRecipeIngredient = new RecipeIngredients
            {
                Recipe = new Recipe
                {
                    Id = recipe.Id,
                },
                Ingredient = selectedIngredient,
                Quantity = quantity,
                Unit = selectedUnit
            };

            recipe.RecipeIngredients.Add(newRecipeIngredient);
            bool inserted = _recipeServices.InsertNewRecipeIngredients(newRecipeIngredient);
            if (inserted)
            {
                TempData["SuccessMessageAddIngredient"] = "Ingredient added successfully!";
            }
            else
            {
                TempData["ErrorMessageAddIngredient"] = "Failed to add Ingredient. Try again!";
            }

            return RedirectToPage();

        }

        public IActionResult OnPostRemoveRecipeIngredients(int id, int recipeId)
        {
            RecipeIngredients recipeIngredients = new RecipeIngredients();

            recipeIngredients.Id = id;
            recipeIngredients.Recipe = new Recipe();
            recipeIngredients.Recipe.Id = recipeId;
            
            _recipeServices.DeleteRecipeIngredients(id);
            
            return RedirectToPage("/Recipes/AddIngredients", new { recipeId = recipeIngredients.Recipe.Id.ToString() });

        }

        public IActionResult OnPostInsertNewRecipe()
        {
            
            return RedirectToPage("/Index");
        }

    }
}
