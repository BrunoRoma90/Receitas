using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RecipeModels;
using Services;
using Services.InterfacesServices;

namespace FinalProjectRecipe.Pages.Categories
{
    public class InsertCategoryModel : PageModel
    {
        private ICategoryServices _categoryServices = new CategoryServices();
        

        public Category Category { get; set; }
        public void OnGet()
        {
        }
        public IActionResult OnPost()
        {
            bool isAnyFieldEmpty = false;
            Category category = new Category();
            category.Id = Convert.ToInt32(Request.Form["Category.Id"]);
            if (!string.IsNullOrEmpty(Request.Form["Category.Name"]))
            {
                category.Name = Convert.ToString(Request.Form["Category.Name"]);
            }
            else
            {
                isAnyFieldEmpty = true;
            }
            //category.Name = Convert.ToString(Request.Form["Category.Name"]);
            if (isAnyFieldEmpty)
            {
                TempData["ErrorMessageNullOrEmpty"] = "Choose the Category!";
                return RedirectToPage();
            }

            Category existingCategory = _categoryServices.GetCategoryByName(category.Name);
            if (existingCategory != null)
            {
                TempData["ErrorMessage"] = "This Category already exists.";
                return RedirectToPage();
            }

            _categoryServices.InsertNewCategory(category);

            return Redirect("/Categories/CategoryList");
        }
    }
}
