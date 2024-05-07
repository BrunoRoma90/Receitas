using RecipeModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.InterfacesServices
{
    public interface IIngredientServices
    {
        public List<Ingredient> GetAllIngredients();
        public Ingredient GetIngredientById(int id);
        public Boolean InsertNewIngredient(Ingredient newIngredient);
        public Boolean UpdateIngredient(Ingredient updatedIngredient);
        public Ingredient GetIngredientByName(string name);
    }
}
