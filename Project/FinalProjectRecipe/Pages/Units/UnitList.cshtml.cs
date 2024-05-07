using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RecipeModels;
using Services;
using Services.InterfacesServices;
namespace FinalProjectRecipe.Pages.Units
{
    public class UnitListModel : PageModel
    {
        private static IUnitServices _services = new UnitServices();
        [BindProperty]

        public List<Unit> Units { get; set; }

        public void OnGet()
        {
            Units = _services.GetAllUnits();
        }

        public IActionResult OnPostInsertNewUnit()
        {

            return new RedirectToPageResult("/Units/InsertNewUnit");
        }
    }
}
