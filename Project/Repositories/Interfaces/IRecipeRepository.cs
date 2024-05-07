using RecipeModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Interfaces
{
    public interface IRecipeRepository
    {
        public DataTable GetAllRecipes();
        public DataTable GetAllRecipesApproved();
        public DataTable GetAllRecipesNotApproved();
        public DataTable GetRecipeById(int id);

        public DataTable GetRecipeByUserId(int userId);
        public DataTable GetIngredientsByRecipeId(int recipeId);
        public DataTable GetFavoritesRecipesByUserId(int userId);
        public DataTable GetFavoritesRecipesByRecipeId(int recipeId);
        public void InsertNewRecipe(Recipe recipe);
        public void InsertNewUserFavorites(UserFavorites userFavorites);
        public void InsertNewRecipeIngredients(RecipeIngredients recipeIngredients);
        public void DeleteRecipeIngredients(int recipeIngredientsId);
        public void UpdateRecipe(Recipe recipe);
        public void UpdateRecipeForApproved(int id);
        public void UpdateRecipeIngredients(RecipeIngredients recipeIngredients);
        public void UpdateUserFavorites(UserFavorites userFavorites);
        public void DeleteUserFavorites(int userFavoritesId);
        public int LastRecipeId();
        public void UpdateRecipeApprovalStatus(int recipeId, bool approved);
        public DataTable SearchRecipes(string searchTerm);

    }
}
