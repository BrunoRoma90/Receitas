using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RecipeModels;
using Services;
using Services.InterfacesServices;

namespace FinalProjectRecipe.Pages.Users
{
    public class UserPersonalInformationUpdateModel : PageModel
    {
        private IUserServices services = new UserServices();
        public User User { get; set; }
        public void OnGet(int userId)
        {
            if (userId == null) { throw new ArgumentNullException("Invalid userId"); }

            User = services.GetUserById(userId);
        }

        public IActionResult OnPost()
        {
            User user = new User();

            user.Id = Convert.ToInt32(Request.Form["User.Id"]);
            user.UserName = Convert.ToString(Request.Form["User.Username"]);
            user.Email = Convert.ToString(Request.Form["User.Email"]);
            user.Password = Convert.ToString(Request.Form["User.Password"]);

            services.UpdateUser(user);

            
            return new RedirectToPageResult("/Users/User", new { userId = user.Id.ToString() });
        }
    }
}
