using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RecipeModels;
using Services;
using Services.InterfacesServices;

namespace FinalProjectRecipe.Pages.Users
{
    public class UserRegistModel : PageModel
    {
        private IUserServices _services = new UserServices();
        public User User { get; set; }
        public void OnGet()
        {           
        }

        public IActionResult OnPost()
        {
            User user = new User();
            bool userEmptyOrNull = false;
            if (!string.IsNullOrEmpty(Request.Form["User.Username"]))
            {
                user.UserName = Convert.ToString(Request.Form["User.UserName"]);
            }
            else
            {
                userEmptyOrNull = true;
            }
            //user.UserName = Convert.ToString(Request.Form["User.UserName"]);
            if (!string.IsNullOrEmpty(Request.Form["User.Email"]))
            {
                user.Email = Convert.ToString(Request.Form["User.Email"]);
            }
            else
            {
                userEmptyOrNull = true;
            }
            //user.Email = Request.Form["User.Email"];
            if (!string.IsNullOrEmpty(Request.Form["User.Password"]))
            {
                user.Password = Convert.ToString(Request.Form["User.Password"]);
            }
            else
            {
                userEmptyOrNull = true;
            }
            //user.Password = Request.Form["User.Password"];
            if (userEmptyOrNull)
            {
                TempData["ErrorMessage"] = "Please fill in all fields before submitting the form.";
                return RedirectToPage();
            }

            User existingUserWithEmail = _services.GetUserByEmail(user.Email);
            if (existingUserWithEmail != null)
            {
                TempData["ErrorMessageEmail"] = "An account with this email already exists.";
                return RedirectToPage();
            }
            User existingUserWithUsername = _services.GetUserByUsername(user.UserName);
            if (existingUserWithUsername != null)
            {
                TempData["ErrorMessageUsername"] = "An account with this Username already exists.";
                return RedirectToPage();
            }
            _services.InsertNewUser(user);
            return Redirect("/Users/Login");

        }

    }
}
