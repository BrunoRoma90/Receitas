using RecipeModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.InterfacesServices
{
    public interface IRecipeServices
    {
        public List<Recipe> GetAllRecipes();
        public List<Recipe> SearchRecipes(string searchTerm);
        public List<Recipe> GetAllRecipesApproved();
        public List<Recipe> GetAllRecipesNotApproved();
        public Recipe GetRecipeById(int id);

        public List<Recipe> GetRecipesByUserId(int userId);
        public List<Comment> GetCommentByRecipeId(int recipeId);
        public List<Comment> GetCommentByUserId(int userId);
        public Boolean InsertNewComment(Comment newComment);
        public Boolean InsertNewRating(Rating newRating);
        public List<RecipeIngredients> GetIngredientsByRecipeId(int recipeId);
        public List<UserFavorites> GetFavoritesRecipesByUserId(int userId);
        public List<UserFavorites> GetFavoritesRecipesByRecipeId(int recipeId);
        public List<Rating> GetRatingsByUserId(int userId);
        public List<Rating> GetRatingsByRecipeId(int recipeId);
        public Boolean InsertNewRecipe(Recipe newRecipe);
        public int LastRecipeId();
        public Boolean InsertNewUserFavorites(UserFavorites newUserFavorites);
        public Boolean InsertNewRecipeIngredients(RecipeIngredients newRecipeIngredients);
        public Boolean UpdateRecipe(Recipe updatedRecipe);
        public Boolean UpdateRecipeForApproved(int id);
        public bool UpdateRecipeApprovalStatus(int recipeId, bool approved);
        public Boolean UpdateRecipeIngredients(RecipeIngredients updatedRecipeIngredients);
        public Boolean DeleteRecipeIngredients(int deletedRecipeIngredientsId);
        public Boolean UpdateUserFavorites(UserFavorites updatedUserFavorites);
        public Boolean DeleteUserFavorites(int deletedUserFavoritesId);
        public double GetAverageRatingForRecipe(int recipeId);
        public void ViewRecipeDetails();
        public void InsertNewRecipeMenu(User authenticatedUser);
        public void InsertCommentRecipeMenu(User authenticatedUser);
        public void InsertNewUserFavoritesMenu(User authenticatedUser);
        public void ViewAllFavoriteRecipes(User authenticatedUser);
        public void DeleteUserFavoritesMenu(User authenticatedUser);
        public void InsertRatingRecipeMenu(User authenticatedUser);
        public void ApproveRecipesMenu();
        public void SearchRecipesMenu();

    }
}
