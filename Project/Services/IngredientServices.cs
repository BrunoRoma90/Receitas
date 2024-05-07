using RecipeModels;
using Repositories;
using Repositories.Interfaces;
using Services.InterfacesServices;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class IngredientServices : IIngredientServices
    {
        
        private IIngredientRepository _repository = new IngredientRepository();

        public List<Ingredient> GetAllIngredients()
        {

            List<Ingredient> lIngredients = new List<Ingredient>();
            DataTable dt = _repository.GetAllIngredients();

            foreach (DataRow row in dt.Rows)
            {
                Ingredient ingredient = new Ingredient
                {
                    Id = Convert.ToInt32(row["id"]),
                    Name = row["name"].ToString(),

                };

                lIngredients.Add(ingredient);
            }

            return lIngredients;
        }


        public Ingredient GetIngredientById(int id)
        {


            DataTable dt = _repository.GetIngredientById(id);
            DataRow dr = dt.Rows[0];
            Ingredient ingredient = new Ingredient(Convert.ToInt32(dr["id"].ToString()), dr["name"].ToString());

            return ingredient;
        }


        public Boolean InsertNewIngredient(Ingredient newIngredient)
        {
            bool inserted = false;

            try
            {

                _repository.InsertNewIngredient(newIngredient);
                inserted = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("This is not working");
            }
            return inserted;
        }


        public Boolean UpdateIngredient(Ingredient updatedIngredient)
        {
            bool updated = false;

            try
            {
                _repository.UpdateIngredient(updatedIngredient);
                updated = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("This is not working");
            }
            return updated;
        }


        public Ingredient GetIngredientByName(string name)
        {
            DataTable dt = _repository.GetIngredientByName(name);

            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];
                return new Ingredient(
                    Convert.ToInt32(dr["id"]),
                    dr["name"].ToString()
                    );
            }

            return null;
        }

    }
}
