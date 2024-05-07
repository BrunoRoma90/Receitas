using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RecipeModels;
using Services;
using Services.InterfacesServices;

namespace FinalProjectRecipe.Pages.Users
{
    public class UserListModel : PageModel
    {
        private static IUserServices _services = new UserServices();
        [BindProperty]

        public List<User> Users { get; set; }
        public void OnGet()
        {
            Users = _services.GetAllUsers();
        }

        public IActionResult OnPostGetUserDetails(int id)
        {

            return new RedirectToPageResult("/Users/User", new { userId = id.ToString() });
        }
    }
}
