using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RecipeModels;
using Services;
using Services.InterfacesServices;

namespace FinalProjectRecipe.Pages.Categories
{
    public class CategoryListModel : PageModel
    {
        private static ICategoryServices _services = new CategoryServices();
        [BindProperty]

        public List<Category> Categories { get; set; }
        public void OnGet()
        {
            Categories = _services.GetAllCategories();
        }
        public IActionResult OnPostInsertCategory()
        {

            return new RedirectToPageResult("/Categories/InsertCategory");
        }
    }
}
