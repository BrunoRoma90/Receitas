using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeModels
{
    public class RecipeIngredients
    {
        public int Id { get; set; }    
        public Ingredient Ingredient { get; set; }
        public double Quantity { get; set; }
        public Unit Unit { get; set; }
        
        public Recipe Recipe { get; set; }

        public RecipeIngredients() { }

        public RecipeIngredients(int id, Ingredient ingredient, double quantity, Unit unit)
        {
            Id = id;
            Ingredient = ingredient;
            Quantity = quantity;
            Unit = unit;
        }

        public RecipeIngredients(int id, Ingredient ingredient, double quantity, Unit unit , Recipe recipe)
        {
            Id = id;
            Ingredient = ingredient;
            Quantity = quantity;
            Unit = unit;
            Recipe = recipe;
        }

    }
}
