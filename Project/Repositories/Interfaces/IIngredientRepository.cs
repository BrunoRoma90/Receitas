using RecipeModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Interfaces
{
    public interface IIngredientRepository
    {
        public DataTable GetAllIngredients();
        public DataTable GetIngredientById(int id);
        public void InsertNewIngredient(Ingredient ingredient);
        public void UpdateIngredient(Ingredient ingredient);

        public DataTable GetIngredientByName(string name);

    }
}
