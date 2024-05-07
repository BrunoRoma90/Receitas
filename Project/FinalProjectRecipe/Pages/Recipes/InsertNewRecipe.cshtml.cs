using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RecipeModels;
using Services;
using System.Reflection;
using Services.InterfacesServices;
using Microsoft.Extensions.Caching.Memory;

namespace FinalProjectRecipe.Pages.Recipes
{
    public class InsertNewRecipeModel : PageModel
    {

        private readonly IMemoryCache _memoryCache;

        public InsertNewRecipeModel(IMemoryCache memoryCache) => _memoryCache = memoryCache;


        private IRecipeServices _recipeServices = new RecipeServices();
        private ICategoryServices _categoryServices = new CategoryServices();
        private IDifficultyServices _difficultyServices = new DifficultyServices();
        
       
        
        [BindProperty]
        public Recipe Recipe { get; set; }

        public User User { get; set; }
        public List<Category> Categories { get; set; }

        [BindProperty]
        public List<Difficulty> Difficulties { get; set; }

        
        public void OnGet()
        {           
            Categories = _categoryServices.GetAllCategories();
            Difficulties = _difficultyServices.GetAllDifficulties();
                      
        }

        public IActionResult OnPost(int id)
        {
            Recipe recipe = new Recipe();
            recipe.User = new User();
            recipe.Category = new Category();
            recipe.Difficulty = new Difficulty();

            bool isAnyFieldEmpty = false;

            recipe.User.Id = Convert.ToInt32(_memoryCache.Get("Id"));
            if (!string.IsNullOrEmpty(Recipe.Name))
            {
                recipe.Name = Recipe.Name;
            }
            else
            {
                isAnyFieldEmpty = true;
            }
            //recipe.Name = Recipe.Name;//Convert.ToString(Request.Form["Recipe.Name"]);
            if (!string.IsNullOrEmpty(Request.Form["Recipe.PreparationMethod"]))
            {
                recipe.PreparationMethod = Convert.ToString(Request.Form["Recipe.PreparationMethod"]);
            }
            else
            {
                isAnyFieldEmpty = true;
            }
            //recipe.PreparationMethod = Convert.ToString(Request.Form["Recipe.PreparationMethod"]);
            if (!string.IsNullOrEmpty(Request.Form["Recipe.PreparationTime"]))
            {
                recipe.PreparationTime = Convert.ToString(Request.Form["Recipe.PreparationTime"]);
            }
            else
            {
                isAnyFieldEmpty = true;
            }
            //recipe.PreparationTime = Convert.ToString(Request.Form["Recipe.PreparationTime"]);
            if (Recipe.Category != null && Recipe.Category.Id != 0)
            {
                recipe.Category = Recipe.Category;
            }
            else
            {
                isAnyFieldEmpty = true;
            }
            //recipe.Category = Recipe.Category;//new Category{Id = Convert.ToInt32(Request.Form["Recipe.Category.Id"]),};
            if (Recipe.Difficulty != null && Recipe.Difficulty.Id != 0)
            {
                recipe.Difficulty = new Difficulty
                {
                    Id = Convert.ToInt32(Request.Form["Recipe.Difficulty.Id"])
                };
            }
            else
            {
                isAnyFieldEmpty = true;
            }
            //recipe.Difficulty = new Difficulty
            //{
            //    Id = Convert.ToInt32(Request.Form["Recipe.Difficulty.Id"]),

            //};

            if (isAnyFieldEmpty)
            {
                TempData["ErrorMessage"] = "Please fill in all fields before submitting the form.";
                return RedirectToPage();
            }

            _recipeServices.InsertNewRecipe(recipe);

            return new RedirectToPageResult("/Recipes/AddIngredients", new { recipeId = id.ToString() });
            
        }
    }
}
