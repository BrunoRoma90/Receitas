using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RecipeModels;
using Services;
using Services.InterfacesServices;

namespace FinalProjectRecipe.Pages.Difficulties
{
    public class InsertDifficultyModel : PageModel
    {
        private IDifficultyServices _difficultyServices = new DifficultyServices();

        public Difficulty Difficulty { get; set; }
        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            bool isAnyFieldEmpty = false;
            Difficulty difficulty = new Difficulty();
            difficulty.Id = Convert.ToInt32(Request.Form["Difficulty.Id"]);
            if (!string.IsNullOrEmpty(Request.Form["Difficulty.Name"]))
            {
                difficulty.Name = Convert.ToString(Request.Form["Difficulty.Name"]);
            }
            else
            {
                isAnyFieldEmpty = true;
            }
            if (isAnyFieldEmpty)
            {
                TempData["ErrorMessageNullOrEmpty"] = "Choose the Difficulty!";
                return RedirectToPage();
            }
            //difficulty.Name = Convert.ToString(Request.Form["Difficulty.Name"]);
            Difficulty existingDifficulty = _difficultyServices.GetDifficultyByName(difficulty.Name);
            if (existingDifficulty != null)
            {
                TempData["ErrorMessage"] = "This Difficulty already exists.";
                return RedirectToPage();
            }

            _difficultyServices.InsertNewDifficulty(difficulty);

            return Redirect("/Difficulties/DifficultyList");
        }
    }
}
