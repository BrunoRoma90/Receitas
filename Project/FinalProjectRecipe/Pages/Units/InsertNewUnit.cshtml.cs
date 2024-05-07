using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RecipeModels;
using Services;
using Services.InterfacesServices;

namespace FinalProjectRecipe.Pages.Units
{
    public class InsertNewUnitModel : PageModel
    {
        private IUnitServices _unitServices = new UnitServices();
        public Unit Unit { get; set; }
        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            bool isAnyFieldEmpty = false;
            Unit unit = new Unit();
            
            unit.Id = Convert.ToInt32(Request.Form["Unit.Id"]);
            if (!string.IsNullOrEmpty(Request.Form["Unit.Name"]))
            {
                unit.Name = Convert.ToString(Request.Form["Unit.Name"]);
            }
            else
            {
                isAnyFieldEmpty = true;
            }
            //unit.Name = Convert.ToString(Request.Form["Unit.Name"]);

            if (isAnyFieldEmpty)
            {
                TempData["ErrorMessageNullOrEmpty"] = "Choose the Unit!";
                return RedirectToPage();
            }

            Unit existingUnit = _unitServices.GetUnitByName(unit.Name);
            if (existingUnit != null)
            {
                TempData["ErrorMessage"] = "This Unit already exists.";
                return RedirectToPage();
            }           

            _unitServices.InsertNewUnit(unit);

            return Redirect("/Units/UnitList");
        }
    }
}
