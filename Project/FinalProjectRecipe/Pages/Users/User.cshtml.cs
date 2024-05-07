using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Caching.Memory;
using RecipeModels;
using Services;
using Services.InterfacesServices;
using System.Xml.Linq;

namespace FinalProjectRecipe.Pages.Users
{
    public class UserModel : PageModel
    {
        private readonly IMemoryCache _memoryCache;
        public UserModel(IMemoryCache memoryCache) => _memoryCache = memoryCache;

        private IUserServices services = new UserServices();

        private IRecipeServices recipeServices = new RecipeServices();
        public User User { get; set; }

        public List<Recipe> Recipes { get; set; }
        public List<UserFavorites> UserFavorites { get; set; }
        public void OnGet(int userId)
        {
            if (userId == null) { throw new ArgumentNullException("Invalid userId"); }

            User = services.GetUserById(userId);
            UserFavorites = recipeServices.GetFavoritesRecipesByUserId(userId);
            Recipes = recipeServices.GetRecipesByUserId(userId);

        }
        public IActionResult OnPostRemoveRecipe(int id, int user)
        {
            UserFavorites userFavorites = new UserFavorites();
           
            userFavorites.Id = id;
            userFavorites.User = new User();
            userFavorites.User.Id = user;
            recipeServices.DeleteUserFavorites(id);
            //return new RedirectToPageResult("/Users/UserList");
            return RedirectToPage("/Users/User", new { userId = userFavorites.User.Id.ToString()});
        }

        public IActionResult OnPostGetUserPersonalInformationUpdate(int id)
        {

            return new RedirectToPageResult("UserPersonalInformationUpdate", new { userId = id.ToString() });
        }

        public IActionResult OnPostGetRecipeDetails(int id)
        {

            return new RedirectToPageResult("/Recipes/Recipe", new { recipeId = id.ToString() });
        }

    }
}
