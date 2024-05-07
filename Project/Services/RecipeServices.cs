using RecipeModels;
using Repositories;
using Repositories.Interfaces;
using Services.InterfacesServices;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Services
{
    public class RecipeServices : IRecipeServices
    {
        private IRecipeRepository _repository = new RecipeRepository();
        private ICommentRepository _commentRepository = new CommentRepository();
        private IRatingRepository _ratingRepository = new RatingRepository();
        private IUserServices _userServices = new UserServices();
        private ICategoryServices _categoryServices = new CategoryServices();
        private IDifficultyServices _difficultyServices = new DifficultyServices();
        private IUnitServices _unitServices = new UnitServices();        
        private IIngredientServices _ingredientServices = new IngredientServices();
        

        public List<Recipe> GetAllRecipes()
        {
            List<Recipe> lRecipes = new List<Recipe>();

            try
            {
                int userId;
                int categoryId;
                int difficultyId;
                DataTable dt = new DataTable();
                dt = _repository.GetAllRecipes();
                foreach (DataRow dr in dt.Rows)
                {

                    User user = new User();
                    if (dr["userId"] != DBNull.Value)
                    {
                        userId = Convert.ToInt32(dr["userId"]);
                        user = _userServices.GetUserById(userId);
                    }
                    Difficulty difficulty = new Difficulty();
                    if (dr["difficultyId"] != DBNull.Value)
                    {
                        difficultyId = Convert.ToInt32(dr["difficultyId"]);
                        difficulty = _difficultyServices.GetDifficultyById(difficultyId);
                    }
                    Category category = new Category();
                    if (dr["categoryId"] != DBNull.Value)
                    {
                        categoryId = Convert.ToInt32(dr["categoryId"]);
                        category = _categoryServices.GetCategoryById(categoryId);
                    }
                    int recipeId = Convert.ToInt32(dr["id"].ToString());
                    double rating = GetAverageRatingForRecipe(recipeId);

                    Recipe recipe = new Recipe(
                        Convert.ToInt32(dr["id"].ToString()),
                        dr["name"].ToString(),
                        dr["preparationMethod"].ToString(),
                        dr["preparationTime"].ToString(),
                        user,
                        difficulty,
                        category,
                        Convert.ToBoolean(dr["approved"].ToString()),
                        rating);
                    lRecipes.Add(recipe);
                }

            }
            catch (Exception ex)
            {

            }
            return lRecipes;

        }


        public List<Recipe> SearchRecipes(string searchTerm)
        {
            List<Recipe> lSearchedRecipes = new List<Recipe>();

            try
            {
                DataTable dt = _repository.SearchRecipes(searchTerm);

                foreach (DataRow dr in dt.Rows)
                {
                    User user = new User();
                    if (dr["userId"] != DBNull.Value)
                    {
                        int userId = Convert.ToInt32(dr["userId"]);
                        user = _userServices.GetUserById(userId);
                    }

                    Difficulty difficulty = new Difficulty();
                    if (dr["difficultyId"] != DBNull.Value)
                    {
                        int difficultyId = Convert.ToInt32(dr["difficultyId"]);
                        difficulty = _difficultyServices.GetDifficultyById(difficultyId);
                    }

                    Category category = new Category();
                    if (dr["categoryId"] != DBNull.Value)
                    {
                        int categoryId = Convert.ToInt32(dr["categoryId"]);
                        category = _categoryServices.GetCategoryById(categoryId);
                    }

                    int recipeId = Convert.ToInt32(dr["id"].ToString());
                    double rating = GetAverageRatingForRecipe(recipeId);

                    Recipe recipe = new Recipe(
                        Convert.ToInt32(dr["id"].ToString()),
                        dr["name"].ToString(),
                        dr["preparationMethod"].ToString(),
                        dr["preparationTime"].ToString(),
                        user,
                        difficulty,
                        category,
                        Convert.ToBoolean(dr["approved"].ToString()),
                        rating);

                    lSearchedRecipes.Add(recipe);
                }
            }
            catch (Exception ex)
            {
                
            }

            return lSearchedRecipes;
        }


        public List<Recipe> GetAllRecipesApproved()
        {
            List<Recipe> lRecipes = new List<Recipe>();

            try
            {
                int userId;
                int categoryId;
                int difficultyId;
                DataTable dt = new DataTable();
                dt = _repository.GetAllRecipesApproved();
                foreach (DataRow dr in dt.Rows)
                {

                    User user = new User();
                    if (dr["userId"] != DBNull.Value)
                    {
                        userId = Convert.ToInt32(dr["userId"]);
                        user = _userServices.GetUserById(userId);
                    }
                    Difficulty difficulty = new Difficulty();
                    if (dr["difficultyId"] != DBNull.Value)
                    {
                        difficultyId = Convert.ToInt32(dr["difficultyId"]);
                        difficulty = _difficultyServices.GetDifficultyById(difficultyId);
                    }
                    Category category = new Category();
                    if (dr["categoryId"] != DBNull.Value)
                    {
                        categoryId = Convert.ToInt32(dr["categoryId"]);
                        category = _categoryServices.GetCategoryById(categoryId);
                    }
                    int recipeId = Convert.ToInt32(dr["id"].ToString());
                    double rating = GetAverageRatingForRecipe(recipeId);

                    Recipe recipe = new Recipe(
                        Convert.ToInt32(dr["id"].ToString()),
                        dr["name"].ToString(),
                        dr["preparationMethod"].ToString(),
                        dr["preparationTime"].ToString(),
                        user,
                        difficulty,
                        category,
                        Convert.ToBoolean(dr["approved"].ToString()),
                        rating);
                    lRecipes.Add(recipe);
                }

            }
            catch (Exception ex)
            {

            }
            return lRecipes;

        }


        public List<Recipe> GetAllRecipesNotApproved()
        {
            List<Recipe> lRecipes = new List<Recipe>();

            try
            {
                int userId;
                int categoryId;
                int difficultyId;
                DataTable dt = new DataTable();
                dt = _repository.GetAllRecipesNotApproved();
                foreach (DataRow dr in dt.Rows)
                {

                    User user = new User();
                    if (dr["userId"] != DBNull.Value)
                    {
                        userId = Convert.ToInt32(dr["userId"]);
                        user = _userServices.GetUserById(userId);
                    }
                    Difficulty difficulty = new Difficulty();
                    if (dr["difficultyId"] != DBNull.Value)
                    {
                        difficultyId = Convert.ToInt32(dr["difficultyId"]);
                        difficulty = _difficultyServices.GetDifficultyById(difficultyId);
                    }
                    Category category = new Category();
                    if (dr["categoryId"] != DBNull.Value)
                    {
                        categoryId = Convert.ToInt32(dr["categoryId"]);
                        category = _categoryServices.GetCategoryById(categoryId);
                    }
                    int recipeId = Convert.ToInt32(dr["id"].ToString());
                    double rating = GetAverageRatingForRecipe(recipeId);

                    Recipe recipe = new Recipe(
                        Convert.ToInt32(dr["id"].ToString()),
                        dr["name"].ToString(),
                        dr["preparationMethod"].ToString(),
                        dr["preparationTime"].ToString(),
                        user,
                        difficulty,
                        category,
                        Convert.ToBoolean(dr["approved"].ToString()),
                        rating);
                    lRecipes.Add(recipe);
                }

            }
            catch (Exception ex)
            {

            }
            return lRecipes;

        }

        public Recipe GetRecipeById(int id)
        {


            DataTable dt = _repository.GetRecipeById(id);
            DataRow dr = dt.Rows[0];

            User user = new User();
            if (dr["userId"] != DBNull.Value)
            {
                int userId = Convert.ToInt32(dr["userId"]);
                user = _userServices.GetUserById(userId);
            }

            Difficulty difficulty = new Difficulty();
            if (dr["difficultyId"] != DBNull.Value)
            {
                int difficultyId = Convert.ToInt32(dr["difficultyId"]);
                difficulty = _difficultyServices.GetDifficultyById(difficultyId);
            }

            Category category = new Category();
            if (dr["categoryId"] != DBNull.Value)
            {
                int categoryId = Convert.ToInt32(dr["categoryId"]);
                category = _categoryServices.GetCategoryById(categoryId);
            }
            double rating = GetAverageRatingForRecipe(id);

            Recipe recipe = new Recipe(
                Convert.ToInt32(dr["id"].ToString()),
                dr["name"].ToString(),
                dr["preparationMethod"].ToString(),
                dr["preparationTime"].ToString(),
                user,
                difficulty,
                category,
                Convert.ToBoolean(dr["approved"].ToString()),
                rating);
            




            return recipe;
        }

        public List<Recipe> GetRecipesByUserId(int userId)
        {
            List<Recipe> recipes = new List<Recipe>();

            try
            {
                User user = _userServices.GetUserById(userId);
                int difficultyId;
                int categoryId;
                DataTable dt = _repository.GetRecipeByUserId(userId);
                foreach (DataRow dr in dt.Rows)
                {

                    Difficulty difficulty = new Difficulty();
                    if (dr["difficultyId"] != DBNull.Value)
                    {
                        difficultyId = Convert.ToInt32(dr["difficultyId"]);
                        difficulty = _difficultyServices.GetDifficultyById(difficultyId);
                    }

                    Category category = new Category();
                    if (dr["categoryId"] != DBNull.Value)
                    {
                        categoryId = Convert.ToInt32(dr["categoryId"]);
                        category = _categoryServices.GetCategoryById(categoryId);
                    }
                    

                    Recipe recipe = new Recipe(
                        Convert.ToInt32(dr["id"].ToString()),
                        dr["name"].ToString(),
                        dr["preparationMethod"].ToString(),
                        dr["preparationTime"].ToString(),
                        user,
                        difficulty,
                        category,
                        Convert.ToBoolean(dr["approved"].ToString()),
                        GetAverageRatingForRecipe(Convert.ToInt32(dr["id"].ToString())));


                    recipes.Add(recipe);
                }
            }
            catch (Exception ex)
            {

            }

            return recipes;

        }
        public List<Comment> GetCommentByRecipeId(int recipeId)
        {
            List<Comment> comments = new List<Comment>();

            try
            {
                int userId;
                DataTable dt = _commentRepository.GetCommentByRecipeId(recipeId);
                foreach (DataRow dr in dt.Rows)
                {

                    User user = new User();
                    if (dr["userId"] != DBNull.Value)
                    {
                        userId = Convert.ToInt32(dr["userId"]);
                        user = _userServices.GetUserById(userId);
                    }


                    Comment recipeComments = new Comment(
                        Convert.ToInt32(dr["id"].ToString()),
                        dr["text"].ToString(),
                        user
                        );

                    comments.Add(recipeComments);
                }
            }
            catch (Exception ex)
            {

            }

            return comments;
        }

        public List<Comment> GetCommentByUserId(int userId)
        {
            List<Comment> comments = new List<Comment>();
            try
            {
                int recipeId;
                DataTable dt = _commentRepository.GetCommentByUserId(userId);
                foreach (DataRow dr in dt.Rows)
                {

                    Recipe recipe = new Recipe();
                    if (dr["userId"] != DBNull.Value)
                    {
                        recipeId = Convert.ToInt32(dr["recipeId"]);
                        recipe = GetRecipeById(recipeId);
                    }


                    Comment recipeComments = new Comment(
                        Convert.ToInt32(dr["id"].ToString()),
                        dr["text"].ToString(),
                        _userServices.GetUserById(userId),
                        GetRecipeById(recipe.Id)
                        ); 

                    comments.Add(recipeComments);
                }
                return comments;
            }
            catch (Exception ex)
            {

            }
            return comments;
        }
        public Boolean InsertNewComment(Comment newComment)
        {
            bool inserted = false;

            try
            {
                bool userAlreadyCommentRecipe = false;
                List<Comment> comments = GetCommentByUserId(newComment.User.Id);
                foreach (Comment comment in comments)
                {
                    if(comment.Recipe.Id == newComment.Recipe.Id)
                    {
                        userAlreadyCommentRecipe = true;
                        break;
                    }
                }
                if(!userAlreadyCommentRecipe)
                {
                    _commentRepository.InsertNewComment(newComment);
                    inserted = true;
                }
               
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("This is not working");
            }
            return inserted;
        }

        public Boolean InsertNewRating(Rating newRating)
        {
            bool inserted = false;

            try
            {
                bool userAlreadyRatingRecipe = false;
                List<Rating> ratingList = GetRatingsByUserId(newRating.User.Id);
                foreach (Rating rating in ratingList)
                {
                    if(rating.Recipe.Id == newRating.Recipe.Id)
                    {
                        userAlreadyRatingRecipe = true;
                        break;
                    }
                }
                if(!userAlreadyRatingRecipe)
                {
                    _ratingRepository.InsertNewRating(newRating);
                    inserted = true;
                }
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("This is not working");
            }
            return inserted;
        }

        public List<RecipeIngredients> GetIngredientsByRecipeId(int recipeId)
        {
            List<RecipeIngredients> ingredients = new List<RecipeIngredients>();

            try
            {
                int ingredientId;
                int unitId;
                DataTable dt = _repository.GetIngredientsByRecipeId(recipeId);
                foreach (DataRow dr in dt.Rows)
                {

                    Ingredient ingredient = new Ingredient();
                    if (dr["ingredientId"] != DBNull.Value)
                    {
                        ingredientId = Convert.ToInt32(dr["ingredientId"]);
                        ingredient = _ingredientServices.GetIngredientById(ingredientId);
                    }

                    Unit unit = new Unit();
                    if (dr["unitId"] != DBNull.Value)
                    {
                        unitId = Convert.ToInt32(dr["unitId"]);
                        unit = _unitServices.GetUnitById(unitId);
                    }


                    RecipeIngredients recipeIngredients = new RecipeIngredients(
                        Convert.ToInt32(dr["id"].ToString()),                      
                        ingredient,
                        Convert.ToDouble(dr["quantity"]),
                        unit);

                    ingredients.Add(recipeIngredients);
                }
            }
            catch (Exception ex)
            {
                
            }

            return ingredients;
        }

        public List<UserFavorites> GetFavoritesRecipesByUserId(int userId)
        {
            List<UserFavorites> favoriteRecipes = new List<UserFavorites>();

            try
            {
                int recipeId;
                DataTable dt = _repository.GetFavoritesRecipesByUserId(userId);
                foreach (DataRow dr in dt.Rows)
                {

                    Recipe recipe = new Recipe();
                    if (dr["recipeId"] != DBNull.Value)
                    {
                        recipeId = Convert.ToInt32(dr["recipeId"]);
                        recipe = GetRecipeById(recipeId);
                    }




                    UserFavorites userFavorites = new UserFavorites(
                        Convert.ToInt32(dr["id"].ToString()),
                        recipe);

                    favoriteRecipes.Add(userFavorites);
                }

            }
            catch (Exception ex)
            {

            }

            return favoriteRecipes;
        }

        public List<UserFavorites> GetFavoritesRecipesByRecipeId(int recipeId)
        {
            List<UserFavorites> favoriteRecipes = new List<UserFavorites>();

            try
            {
                int userId;
                DataTable dt = _repository.GetFavoritesRecipesByRecipeId(recipeId);
                foreach (DataRow dr in dt.Rows)
                {
                    User user = new User();
                    if (dr["userId"] != DBNull.Value)
                    {
                        userId = Convert.ToInt32(dr["userId"]);
                        user = _userServices.GetUserById(userId);
                    }

                    UserFavorites userFavorites = new UserFavorites(
                       Convert.ToInt32(dr["id"].ToString()),
                       user,
                       GetRecipeById(recipeId)
                       );

                    favoriteRecipes.Add(userFavorites);


                }
            }
            catch (Exception ex)
            {
                
            }

            return favoriteRecipes;
        }

        public List<Rating> GetRatingsByUserId(int userId)
        {
            List<Rating> ratings = new List<Rating>();

            try
            {
                int recipeId;
                DataTable dt = _ratingRepository.GetRatingsByUserId(userId);
                foreach (DataRow dr in dt.Rows)
                {

                    Recipe recipe = new Recipe();
                    if (dr["recipeId"] != DBNull.Value)
                    {
                        recipeId = Convert.ToInt32(dr["recipeId"]);
                        recipe = GetRecipeById(recipeId);
                    }


                    Rating recipeRatings = new Rating(
                       Convert.ToInt32(dr["id"].ToString()),
                       Convert.ToDouble(dr["value"].ToString()),
                       _userServices.GetUserById(userId),
                       GetRecipeById(recipe.Id));

                    ratings.Add(recipeRatings);
                }
            }
            catch (Exception ex)
            {

            }

            return ratings;
        }

        public List<Rating> GetRatingsByRecipeId(int recipeId)
        {
            List<Rating> ratings = new List<Rating>();

            try
            {
                int userId;
                DataTable dt = _ratingRepository.GetRatingsByRecipeId(recipeId);
                foreach (DataRow dr in dt.Rows)
                {

                    User user = new User();
                    if (dr["userId"] != DBNull.Value)
                    {
                        userId = Convert.ToInt32(dr["userId"]);
                        user = _userServices.GetUserById(userId);
                    }


                    Rating recipeRatings = new Rating(
                        Convert.ToInt32(dr["id"].ToString()),
                        Convert.ToDouble(dr["value"].ToString()),
                        GetRecipeById(recipeId));

                    ratings.Add(recipeRatings);
                }
            }
            catch (Exception ex)
            {

            }

            return ratings;
        }

        //public Boolean InsertNewRecipe(Recipe newRecipe)
        //{
        //    bool inserted = false;

        //    try
        //    {

        //        _repository.InsertNewRecipe(newRecipe);
        //        newRecipe.Id = _repository.LastRecipeId();


        //        foreach (RecipeIngredients recipeIngredients in newRecipe.RecipeIngredients)
        //        {
        //            recipeIngredients.Recipe = newRecipe;
        //            recipeIngredients.Recipe.Id = newRecipe.Id;

        //            _repository.InsertNewRecipeIngredients(recipeIngredients);
        //        }
        //        inserted = true;
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.Message);
        //        Console.WriteLine("This is not working");
        //    }
        //    return inserted;
        //}

        

        public Boolean InsertNewRecipe(Recipe newRecipe)
        {
            bool inserted = false;

            try
            {

                _repository.InsertNewRecipe(newRecipe);
                inserted = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("This is not working");
            }
            return inserted;
        }

        public int LastRecipeId()
        {
            return _repository.LastRecipeId();
        }


        public Boolean InsertNewUserFavorites(UserFavorites newUserFavorites)
        {
            bool inserted = false;

            try
            {
                bool recipeAlreadyExists = false;
                List<UserFavorites> userFavorites = GetFavoritesRecipesByUserId(newUserFavorites.User.Id);
                foreach (UserFavorites favorite in userFavorites)
                {
                    if (favorite.Recipe.Id == newUserFavorites.Recipe.Id)
                    {
                        recipeAlreadyExists = true;
                        break;
                    }
                }
                if (!recipeAlreadyExists)
                {
                    
                    _repository.InsertNewUserFavorites(newUserFavorites);
                    inserted = true;
                }
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("This is not working");
            }
            return inserted;
        }

        public Boolean InsertNewRecipeIngredients(RecipeIngredients newRecipeIngredients)
        {
            bool inserted = false;

            try
            {
                if (newRecipeIngredients.Quantity > 0 && newRecipeIngredients.Ingredient != null &&
                    newRecipeIngredients.Unit != null)
                {
                    _repository.InsertNewRecipeIngredients(newRecipeIngredients);
                    inserted = true;
                }
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("This is not working");
            }
            return inserted;
        }

        public Boolean UpdateRecipe(Recipe updatedRecipe)
        {
            bool updated = false;

            try
            {
                _repository.UpdateRecipe(updatedRecipe);
                updated = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("This is not working");
            }
            return updated;
        }


        public Boolean UpdateRecipeForApproved(int id)
        {
            bool updated = false;

            try
            {
                _repository.UpdateRecipeForApproved(id);
                updated = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("This is not working");
            }
            return updated;
        }

        public bool UpdateRecipeApprovalStatus(int recipeId, bool approved)
        {
            bool updated = false;

            try
            {
                _repository.UpdateRecipeApprovalStatus(recipeId, approved);
                updated = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("This is not working");
            }

            return updated;
        }


        public Boolean UpdateRecipeIngredients(RecipeIngredients updatedRecipeIngredients)
        {
            bool updated = false;

            try
            {
                _repository.UpdateRecipeIngredients(updatedRecipeIngredients);
                updated = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("This is not working");
            }
            return updated;
        }


        public Boolean UpdateUserFavorites(UserFavorites updatedUserFavorites)
        {
            bool updated = false;

            try
            {
                _repository.UpdateUserFavorites(updatedUserFavorites);
                updated = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("This is not working");
            }
            return updated;
        }


        public Boolean DeleteRecipeIngredients(int deletedRecipeIngredientsId)
        {
            bool deleted = false;

            try
            {
                _repository.DeleteRecipeIngredients(deletedRecipeIngredientsId);
                deleted = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("This is not working");
            }
            return deleted;
        }

        public Boolean DeleteUserFavorites(int deletedUserFavoritesId)
        {
            bool deleted = false;

            try
            {
                _repository.DeleteUserFavorites(deletedUserFavoritesId);
                deleted = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("This is not working");
            }
            return deleted;
        }

        public double GetAverageRatingForRecipe(int recipeId)
        {
            DataTable dt = _ratingRepository.GetRatingsByRecipeId(recipeId);

            if (dt.Rows.Count > 0)
            {
                double sum = 0;

                foreach (DataRow row in dt.Rows)
                {
                    if (row["value"] != DBNull.Value)
                    {
                        sum += Convert.ToDouble(row["value"]);
                    }
                }

                return sum / dt.Rows.Count;
            }

            return 0; 
        }


        public void ViewRecipeDetails()
        {
            Console.WriteLine("Todas as receitas:");
            List<Recipe> allRecipes = GetAllRecipesApproved();
            foreach (Recipe recipes in allRecipes)
            {
                Console.WriteLine($"ID: {recipes.Id} Nome: {recipes.Name}");
            }

            Console.WriteLine("Id da receita para ver detalhes:");
            int recipeId = Convert.ToInt32(Console.ReadLine());
            Recipe recipe = GetRecipeById(recipeId);

            if (recipe != null)
            {
                Console.WriteLine($"ID: {recipe.Id}");
                Console.WriteLine($"Nome: {recipe.Name}");
                Console.WriteLine($"Método de preparação: {recipe.PreparationMethod}");
                Console.WriteLine($"Tempo de preparação: {recipe.PreparationTime}");
                Console.WriteLine($"User: {recipe.User.UserName} (UserID: {recipe.User.Id})");
                Console.WriteLine($"Dificuldade: {recipe.Difficulty.Name}");
                Console.WriteLine($"Categoria: {recipe.Category.Name}");
                Console.WriteLine($"Rating: {recipe.Rating:F1}");

                List<RecipeIngredients> recipeIngredients = GetIngredientsByRecipeId(recipeId);

                if (recipeIngredients.Count > 0)
                {
                    Console.WriteLine($"Ingredientes para a receita com ID {recipeId}:");
                    foreach (RecipeIngredients ingredient in recipeIngredients)
                    {
                        Console.WriteLine($"- {ingredient.Ingredient.Name} ({ingredient.Quantity} {ingredient.Unit.Name})");
                    }
                }
                else
                {
                    Console.WriteLine($"Nenhum ingrediente encontrado para a receita.");
                }

                List<Comment> comments = GetCommentByRecipeId(recipeId);
                if(comments.Count > 0 ) 
                {
                    Console.WriteLine($"Comentários:");
                    foreach (Comment comment in comments)
                    {
                        
                        Console.WriteLine($"Comentário: {comment.Text}, User: {comment.User.UserName}");
                    }
                }
                else
                {
                    Console.WriteLine("A receita não tem comentários");
                }

            }
            else
            {
                Console.WriteLine("A receita não existe.");
            }

        }
        public void InsertNewRecipeMenu(User authenticatedUser)
        {
            try
            {

                Console.WriteLine("Inserir nova receita");

                Console.Write("Nome da receita: ");
                string name = Console.ReadLine();
                Console.Write("Mêtodo de preparação: ");
                string preparationMethod = Console.ReadLine();
                Console.Write("Tempo de preparação: ");
                string preparationTime = Console.ReadLine();
                Console.Write("Dificuldade: ");
                int dificuldade = Convert.ToInt32(Console.ReadLine());
                Console.Write("Categoria: ");
                int categoria = Convert.ToInt32(Console.ReadLine());
                List<Ingredient> ingredients = _ingredientServices.GetAllIngredients();
                
                foreach (Ingredient ingredient in ingredients)
                {
                    Console.WriteLine($"ID: {ingredient.Id} - Name: {ingredient.Name}");
                }


                List<RecipeIngredients> recipeIngredients = new List<RecipeIngredients>();
                while (true)
                {
                    Console.WriteLine("Id do ingrediente");
                    int ingredientId = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Quantidade");
                    double quantity = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine("Unidade");
                    int unitId = Convert.ToInt32(Console.ReadLine());


                    Ingredient selectedIngredient = _ingredientServices.GetIngredientById(ingredientId);
                    Unit selectedUnit = _unitServices.GetUnitById(unitId);


                    RecipeIngredients recipeIngredients1 = new RecipeIngredients
                    {
                        Ingredient = selectedIngredient,
                        Quantity = quantity,
                        Unit = selectedUnit,


                    };

                    recipeIngredients.Add(recipeIngredients1);
                    Console.WriteLine("Para inserir mais ingredientes prima 1 / Para terminar prima 0");
                    int choice = Convert.ToInt32(Console.ReadLine());
                    if (choice == 0) { break; }
                }

                Recipe newRecipe = new Recipe
                {
                    Name = name,
                    PreparationMethod = preparationMethod,
                    PreparationTime = preparationTime,
                    User = authenticatedUser,
                    Difficulty = new Difficulty
                    {
                        Id = dificuldade,
                    },
                    Category = new Category
                    {
                        Id = categoria,
                    },
                    RecipeIngredients = recipeIngredients
                };
                InsertNewRecipe(newRecipe);
               
                Console.WriteLine("Receita adicionada com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Ocorreu um erro ao adicionar a Receita. Tente novamente.");
            }
        }
        public void InsertCommentRecipeMenu(User authenticatedUser)
        {
            
            Console.WriteLine("Todas as receitas");
            List<Recipe> allRecipes = GetAllRecipesApproved();
            foreach (Recipe recipe in allRecipes)
            {
                Console.WriteLine($"ID:{recipe.Id} Nome:{recipe.Name}");
            }
            Console.Write("Id da receita a comentar: ");
            int recipeId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Comentário:");
            string text = Console.ReadLine();

            Comment comment = new Comment
            {
                User = authenticatedUser,
                Recipe = new Recipe
                {
                    Id = recipeId,
                },
                Text = text

            };
            bool result = InsertNewComment(comment);
            if (result)
            {
                Console.WriteLine("Comentário inserido com sucesso!");
            }
            else
            {
                Console.WriteLine("Falha ao inserir comentário.");
            }
        }
        public void InsertNewUserFavoritesMenu(User authenticatedUser)
        {
            try
            {
                Console.WriteLine("Adicionar receita aos favoritos");
                List<Recipe> allRecipes = GetAllRecipesApproved();
                foreach (Recipe recipes in allRecipes)
                {
                    Console.WriteLine($"ID: {recipes.Id} - Nome: {recipes.Name}");
                }

                Console.Write("ID da receita para adicionar aos favoritos: ");
                int recipeId = Convert.ToInt32(Console.ReadLine());

                List<UserFavorites> myUserFavorites = GetFavoritesRecipesByRecipeId(recipeId);
                bool recipeAlreadyInFavorites = false;
                foreach (UserFavorites favoriteRecipe in myUserFavorites)
                {
                    if (favoriteRecipe.Recipe.Id == recipeId)
                    {
                        recipeAlreadyInFavorites = true;
                        
                    }                   
                }
                if (recipeAlreadyInFavorites)
                {
                    Console.WriteLine("Esta receita já se encontra nos favoritos");
                }
                else
                {
                    Recipe selectedRecipe = GetRecipeById(recipeId);
                    if (selectedRecipe != null)
                    {
                        UserFavorites newUserFavorites = new UserFavorites
                        {
                            User = authenticatedUser,
                            Recipe = selectedRecipe,
                        };
                        InsertNewUserFavorites(newUserFavorites);
                        Console.WriteLine("Receita adicionada aos favoritos com sucesso!");

                    }
                    else { Console.WriteLine("A receita selecionada não existe."); }

                }
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Ocorreu um erro ao adicionar a receita aos favoritos. Tente novamente.");

            }
            
            
            
            

        }
        public void ViewAllFavoriteRecipes(User authenticatedUser)
        {

            int userId = authenticatedUser.Id;


            List<UserFavorites> userFavorites = GetFavoritesRecipesByUserId(userId);
            Console.WriteLine($"As minhas receitas favoritas:");
            foreach (UserFavorites favoriteRecipe in userFavorites)
            {
                Console.WriteLine($"- {favoriteRecipe.Recipe.Name}");
            }
        }
        public void DeleteUserFavoritesMenu(User authenticatedUser)
        {
            int userId = authenticatedUser.Id;


            List<UserFavorites> userFavorites = GetFavoritesRecipesByUserId(userId);
            Console.WriteLine($"As minhas receitas favoritas:");
            foreach (UserFavorites favoriteRecipe in userFavorites)
            {
                Console.WriteLine($"ID - {favoriteRecipe.Id} {favoriteRecipe.Recipe.Name}");
            }
            
            Console.WriteLine("Qual o Id da receita que pretende eliminar:");
            int userFavoritesIdToDelete = Convert.ToInt32( Console.ReadLine());
            bool idExist = false;

            foreach (UserFavorites recipeExist in userFavorites)
            {
                if(recipeExist.Id == userFavoritesIdToDelete)
                {
                    idExist = true;                   
                    break;
                }
            }
            if(idExist)
            {
                bool deleteResult = DeleteUserFavorites(userFavoritesIdToDelete);
                if (deleteResult)
                {
                    Console.WriteLine("Receita removida dos favoritos com sucesso!");

                }
                else
                {
                    Console.WriteLine("Falha ao remover a receita dos favoritos.");

                }

            }


        }
        public void InsertRatingRecipeMenu(User authenticatedUser)
        {
            try
            {
                int userId = authenticatedUser.Id;
                User user = _userServices.GetUserById(authenticatedUser.Id);

                List<Recipe> allRecipes = GetAllRecipesApproved();
                foreach (Recipe recipe in allRecipes)
                {
                    Console.WriteLine($"ID: {recipe.Id} - Nome: {recipe.Name}");
                }
                Console.Write("ID da receita para dar rating: ");
                int recipeId = Convert.ToInt32(Console.ReadLine());

                List<Rating> userRatings = GetRatingsByUserId(authenticatedUser.Id);
                bool userAlreadyRated = false;
                foreach (Rating rating in userRatings)
                {
                    if (rating.Recipe.Id == recipeId)
                    {
                        userAlreadyRated = true;
                        break; // Sai do loop assim que encontrar um rating para a receita
                    }
                }
                if (userAlreadyRated)
                {
                    Console.WriteLine("Você já deu um rating para esta receita. Não é possível dar outro rating.");
                    return;
                }

                Recipe selectedRecipe = GetRecipeById(recipeId);
                if (selectedRecipe != null)
                {
                    Console.Write("Insira um valor de 1 a 5 para o rating: ");
                    int ratingValue = Convert.ToInt32(Console.ReadLine());

                    if (ratingValue >= 1 && ratingValue <= 5)
                    {
                        Rating newRating = new Rating
                        {
                            Value = ratingValue,
                            Recipe = selectedRecipe,
                            User = authenticatedUser
                        };
                        bool result = InsertNewRating(newRating);
                        if (result)
                        {
                            Console.WriteLine("Rating inserido com sucesso!");
                        }
                        else
                        {
                            Console.WriteLine("Falha ao inserir Rating.");
                        }
                    }
                  
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Ocorreu um erro. Tente novamente.");
            }
        }
        public void ApproveRecipesMenu()
        {
            List<Recipe> notApprovedRecipes = GetAllRecipesNotApproved();

            foreach (Recipe recipe in notApprovedRecipes)
            {
                Console.WriteLine($"ID: {recipe.Id} Nome: {recipe.Name}");
            }

            Console.Write("Digite o ID da receita para aprovar: ");
            int recipeIdToApprove = Convert.ToInt32(Console.ReadLine());

            bool result = UpdateRecipeApprovalStatus(recipeIdToApprove, true);

            if (result)
            {
                Console.WriteLine("Receita aprovada com sucesso!");
            }
            else
            {
                Console.WriteLine("Falha ao aprovar a receita.");
            }
        }

        public void SearchRecipesMenu()
        {
            Console.WriteLine("Insira um termo de pesquisa para encontrar a receita pretendida:");
            string searchTerm = Console.ReadLine();
            List<Recipe> searchedRecipes = SearchRecipes(searchTerm);


            foreach (Recipe recipe in searchedRecipes)
            {
                Console.WriteLine($"ID: {recipe.Id}, Nome: {recipe.Name}, Dificuldade: {recipe.Difficulty.Name}, Categoria: {recipe.Category.Name}");

            }
        }


    }
}
