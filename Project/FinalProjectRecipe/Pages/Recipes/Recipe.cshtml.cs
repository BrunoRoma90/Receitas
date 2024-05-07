using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Server.Kestrel.Core.Features;
using RecipeModels;
using Services;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Xml.Linq;
using Services.InterfacesServices;
using Microsoft.Extensions.Caching.Memory;

namespace FinalProjectRecipe.Pages.Recipes
{
    public class RecipeModel : PageModel
    {

        private readonly IMemoryCache _memoryCache;

        public RecipeModel(IMemoryCache memoryCache) => _memoryCache = memoryCache;
        private IRecipeServices services = new RecipeServices();

        public Recipe Recipe { get; set; }

        public List<RecipeIngredients> RecipeIngredients { get; set; }

        public List<Comment> Comments { get; set; }

        public Comment Comment { get; set; }
      
        public Rating Rating { get; set; }

        public UserFavorites UserFavorites { get; set; }

        public void OnGet(int recipeId)
        {
            
            if (recipeId == null) { throw new ArgumentNullException("Invalid recipeId"); }
            Recipe = services.GetRecipeById(recipeId);
            RecipeIngredients = services.GetIngredientsByRecipeId(recipeId);
            Comments = services.GetCommentByRecipeId(recipeId);
            

        }


        public IActionResult OnPostAddRating(int Id)
        {
            Rating rating = new Rating();
            rating.Recipe = new Recipe();
            rating.User = new User();
            rating.Value = Convert.ToDouble(Request.Form["Rating.Value"]);
            rating.Recipe.Id = Id;
            rating.User.Id = Convert.ToInt32(_memoryCache.Get("Id"));
            bool inserted = services.InsertNewRating(rating);
            if (inserted)
            {
                TempData["SuccessMessageRating"] = "Rating added successfully!";
            }
            else
            {
                TempData["ErrorMessageRating"] = "Failed to add rating. You already rating this recipe";
            }
            return RedirectToPage("/Recipes/Recipe", new { recipeId = rating.Recipe.Id.ToString() });

        }

        public IActionResult OnPostAddComment(int Id)
        {
            Comment comment = new Comment();
            comment.Recipe = new Recipe();
            comment.User = new User();
            comment.Text = Convert.ToString(Request.Form["Comment.Text"]);
            comment.Recipe.Id = Id;
            comment.User.Id = Convert.ToInt32(_memoryCache.Get("Id"));

            bool inserted = services.InsertNewComment(comment);
            if (inserted)
            {
                TempData["SuccessMessageComment"] = "Comment added successfully!";
            }
            else
            {
                TempData["ErrorMessageComment"] = "Failed to add comment. You already comment this recipe";
            }
            return RedirectToPage("/Recipes/Recipe", new { recipeId = comment.Recipe.Id.ToString() });

        }

        public IActionResult OnPostAddRecipeToFavorites(int Id)
        {
            UserFavorites userFavorites = new UserFavorites();
            userFavorites.Recipe = new Recipe();
            userFavorites.User = new User();
            userFavorites.Recipe.Id = Id;
            userFavorites.User.Id = Convert.ToInt32(_memoryCache.Get("Id"));
            bool inserted = services.InsertNewUserFavorites(userFavorites);
            if (inserted)
            {
                TempData["SuccessMessage"] = "Recipe added to favorites successfully.";
            }
            else
            {
                TempData["ErrorMessage"] = "Recipe is already in favorites.";
            }

            return RedirectToPage("/Recipes/Recipe", new { recipeId = userFavorites.Recipe.Id.ToString() });
        }





    }
}
