using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Caching.Memory;
using RecipeModels;
using Services;
using Services.InterfacesServices;
using System.Security.Authentication;

namespace FinalProjectRecipe.Pages.Users
{
    public class LoginModel : PageModel
    {
        private readonly IMemoryCache _memoryCache;

        public LoginModel(IMemoryCache memoryCache) => _memoryCache = memoryCache;

        private IUserServices _userServices = new UserServices();
        
        [BindProperty]
        public User User { get; set; }

        
        public void OnGet()
        {
            if (_memoryCache.Get("Id") != null)
                this.User.Id = Convert.ToInt32(_memoryCache.Get("Id"));
        }
        public IActionResult OnPostLogin(string username, string password)
        {
           if(string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
           {
                TempData["ErrorMessageNullOrEmpty"] = "Please fill in all fields before submitting the form.";
                return RedirectToPage("/Users/Login");
            }
           User = _userServices.AuthenticateUser(username, password);
           if (User != null)
           {
                _memoryCache.Set("Id", User.Id);
                _memoryCache.Set("Admin", User.IsAdmin);
                _memoryCache.Set("UserName", User.UserName);
                return RedirectToPage("/Index");
           }
           else
           {
                TempData["ErrorMessage"] = "Incorrect login. Please try again.";
                return RedirectToPage("/Users/Login");
           }

        }

        public IActionResult OnPostLogout()
        {
            _memoryCache.Remove("Id");
            _memoryCache.Remove("Admin");
            _memoryCache.Remove("UserName");

            return RedirectToPage("/Index");

        }

    }
}
