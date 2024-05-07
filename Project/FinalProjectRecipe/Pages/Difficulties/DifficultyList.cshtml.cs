using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RecipeModels;
using Services;
using Services.InterfacesServices;

namespace FinalProjectRecipe.Pages.Difficulties
{
    public class DifficultyListModel : PageModel
    {
        private static IDifficultyServices _services = new DifficultyServices();
        [BindProperty]

        public List<Difficulty> Difficulties { get; set; }
        public void OnGet()
        {
            Difficulties = _services.GetAllDifficulties();
        }

        public IActionResult OnPostInsertDifficulty()
        {

            return new RedirectToPageResult("/Difficulties/InsertDifficulty");
        }
    }
}
