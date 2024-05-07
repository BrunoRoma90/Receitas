using RecipeModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Drawing;
using Repositories.Interfaces;

namespace Repositories
{
    public class RecipeRepository : IRecipeRepository
    {
        //string connectionString = ConfigurationManager.ConnectionStrings["MyDBConnectionString"].ConnectionString.ToString();
        private static Generic _generic = new Generic();
        private static string connectionString = _generic.GetConnectionString();
        public DataTable GetAllRecipes()
        {
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    string query = "SELECT * FROM Recipe";

                    cmd.CommandText = query;
                    cmd.Connection = con;

                    if (con.State != ConnectionState.Open) //Ligação for diferente de aberto Abre
                        con.Open();

                    SqlDataAdapter da = new SqlDataAdapter();
                    da.SelectCommand = cmd;
                    da.Fill(dt);

                    if (con.State != ConnectionState.Open)
                        con.Open();

                }
            }

            return dt;
        }


        public DataTable GetAllRecipesApproved()
        {
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    string query = "SELECT * FROM Recipe WHERE approved = 1";

                    cmd.CommandText = query;
                    cmd.Connection = con;

                    if (con.State != ConnectionState.Open) //Ligação for diferente de aberto Abre
                        con.Open();

                    SqlDataAdapter da = new SqlDataAdapter();
                    da.SelectCommand = cmd;
                    da.Fill(dt);

                    if (con.State != ConnectionState.Open)
                        con.Open();

                }
            }

            return dt;
        }



        public DataTable GetAllRecipesNotApproved()
        {
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    string query = "SELECT * FROM Recipe WHERE approved = 0";

                    cmd.CommandText = query;
                    cmd.Connection = con;

                    if (con.State != ConnectionState.Open) //Ligação for diferente de aberto Abre
                        con.Open();

                    SqlDataAdapter da = new SqlDataAdapter();
                    da.SelectCommand = cmd;
                    da.Fill(dt);

                    if (con.State != ConnectionState.Open)
                        con.Open();

                }
            }

            return dt;
        }

        public DataTable GetRecipeById(int id)
        {
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(connectionString))
            {

                using (SqlCommand cmd = new SqlCommand())
                {
                    string query = "SELECT * FROM Recipe Where id = @recipeId";

                    cmd.CommandText = query;
                    cmd.Connection = con;
                    cmd.Parameters.Add("@recipeId", SqlDbType.Int).Value = id;  //Definimos o formato neste caso é um INT

                    if (con.State != ConnectionState.Open) //Ligação for diferente de aberto Abre
                        con.Open();

                    SqlDataAdapter da = new SqlDataAdapter();
                    da.SelectCommand = cmd;
                    da.Fill(dt);
                }// Comando/Instrução/Faz isto

            }
            return dt;
        }

        public DataTable GetRecipeByUserId(int userId)
        {
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    string query = "SELECT * FROM Recipe WHERE userId = @userId";

                    cmd.CommandText = query;
                    cmd.Connection = con;
                    cmd.Parameters.Add("@userId", SqlDbType.Int).Value = userId;

                    if (con.State != ConnectionState.Open)
                        con.Open();

                    SqlDataAdapter da = new SqlDataAdapter();
                    da.SelectCommand = cmd;
                    da.Fill(dt);
                }
            }

            return dt;

        }

        public DataTable GetIngredientsByRecipeId(int recipeId)
        {
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    string query = "SELECT * FROM RecipeIngredients WHERE recipeId = @recipeId";

                    cmd.CommandText = query;
                    cmd.Connection = con;
                    cmd.Parameters.Add("@recipeId", SqlDbType.Int).Value = recipeId;

                    if (con.State != ConnectionState.Open)
                        con.Open();

                    SqlDataAdapter da = new SqlDataAdapter();
                    da.SelectCommand = cmd;
                    da.Fill(dt);
                }
            }

            return dt;
        }


        public DataTable GetFavoritesRecipesByUserId(int userId)
        {
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    string query = "SELECT * FROM UserFavorites WHERE userId = @userId";

                    cmd.CommandText = query;
                    cmd.Connection = con;
                    cmd.Parameters.Add("@userId", SqlDbType.Int).Value = userId;

                    if (con.State != ConnectionState.Open)
                        con.Open();

                    SqlDataAdapter da = new SqlDataAdapter();
                    da.SelectCommand = cmd;
                    da.Fill(dt);
                }
            }

            return dt;
        }


        public DataTable GetFavoritesRecipesByRecipeId(int recipeId)
        {
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    string query = "SELECT * FROM UserFavorites WHERE recipeId = @recipeId";

                    cmd.CommandText = query;
                    cmd.Connection = con;
                    cmd.Parameters.Add("@recipeId", SqlDbType.Int).Value = recipeId;

                    if (con.State != ConnectionState.Open)
                        con.Open();

                    SqlDataAdapter da = new SqlDataAdapter();
                    da.SelectCommand = cmd;
                    da.Fill(dt);
                }
            }

            return dt;
        }

        public void InsertNewRecipe(Recipe recipe)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    string query = "INSERT INTO Recipe(name, preparationMethod, preparationTime, userId, difficultyId, categoryId, approved) VALUES(@name, @preparationMethod, @preparationTime, @userId, @difficultyId, @categoryId, @approved)";

                    cmd.CommandText = query;
                    cmd.Connection = con;

                    #region Insert query values
                    cmd.Parameters.Add("@name", SqlDbType.NVarChar).Value = recipe.Name;
                    cmd.Parameters.Add("@preparationMethod", SqlDbType.NVarChar).Value = recipe.PreparationMethod;
                    cmd.Parameters.Add("@preparationTime", SqlDbType.NVarChar).Value = recipe.PreparationTime;
                    cmd.Parameters.Add("@userId", SqlDbType.Int).Value = recipe.User.Id;
                    cmd.Parameters.Add("@difficultyId", SqlDbType.Int).Value = recipe.Difficulty.Id;
                    cmd.Parameters.Add("@categoryId", SqlDbType.Int).Value = recipe.Category.Id;
                    cmd.Parameters.Add("@approved", SqlDbType.Bit).Value = false;
                    #endregion

                    if (con.State != ConnectionState.Open)
                        con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }


        public void InsertNewUserFavorites(UserFavorites userFavorites)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    string query = "INSERT INTO UserFavorites(recipeId, userId ) VALUES(@recipeId, @userId)";

                    cmd.CommandText = query;
                    cmd.Connection = con;

                    #region Insert query values                    
                    cmd.Parameters.Add("@recipeId", SqlDbType.Int).Value = userFavorites.Recipe.Id;
                    cmd.Parameters.Add("@userId", SqlDbType.Int).Value = userFavorites.User.Id;
                    #endregion

                    if (con.State != ConnectionState.Open)
                        con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }


        public void InsertNewRecipeIngredients(RecipeIngredients recipeIngredients)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    string query = "INSERT INTO RecipeIngredients(recipeId, ingredientId, quantity, unitId ) VALUES(@recipeId, @ingredientId, @quantity , @unitId )";

                    cmd.CommandText = query;
                    cmd.Connection = con;

                    #region Insert query values                    
                    cmd.Parameters.Add("@recipeId", SqlDbType.Int).Value = recipeIngredients.Recipe.Id;
                    cmd.Parameters.Add("@ingredientId", SqlDbType.Int).Value = recipeIngredients.Ingredient.Id;
                    cmd.Parameters.Add("@quantity", SqlDbType.Decimal).Value = recipeIngredients.Quantity;
                    cmd.Parameters.Add("@unitId", SqlDbType.Int).Value = recipeIngredients.Unit.Id;

                    #endregion

                    if (con.State != ConnectionState.Open)
                        con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }


        public void UpdateRecipe(Recipe recipe)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    string query = "UPDATE Recipe SET name= @name, preparationMethod= @preparationMethod, preparationTime= @preparationTime, userId= @userId , difficultyId= @difficultyId, categoryId= @categoryId, approved= @approved WHERE id = @id " + Environment.NewLine;

                    cmd.CommandText = query;
                    cmd.Connection = con;

                    #region Insert query values
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = recipe.Id;
                    cmd.Parameters.Add("@name", SqlDbType.NVarChar).Value = recipe.Name;
                    cmd.Parameters.Add("@preparationMethod", SqlDbType.NVarChar).Value = recipe.PreparationMethod;
                    cmd.Parameters.Add("@preparationTime", SqlDbType.NVarChar).Value = recipe.PreparationTime;
                    cmd.Parameters.Add("@userId", SqlDbType.Int).Value = recipe.User.Id;
                    cmd.Parameters.Add("@difficultyId", SqlDbType.Int).Value = recipe.Difficulty.Id;
                    cmd.Parameters.Add("@categoryId", SqlDbType.Int).Value = recipe.Category.Id;
                    cmd.Parameters.Add("@approved", SqlDbType.Bit).Value = true;

                    #endregion

                    if (con.State != ConnectionState.Open)
                        con.Open();
                    cmd.ExecuteNonQuery();


                }
            }
        }


        public void UpdateRecipeForApproved(int id)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    string query = "UPDATE Recipe SET approved= @approved WHERE id = @id " + Environment.NewLine;

                    cmd.CommandText = query;
                    cmd.Connection = con;

                    #region Insert query values
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
                    cmd.Parameters.Add("@approved", SqlDbType.Bit).Value = true;

                    #endregion

                    if (con.State != ConnectionState.Open)
                        con.Open();
                    cmd.ExecuteNonQuery();


                }
            }
        }


        public void UpdateRecipeIngredients(RecipeIngredients recipeIngredients)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    string query = "UPDATE RecipeIngredients SET recipeId= @recipeId, ingredientId= @ingredientId, quantity= @quantity, unitId= @unitId WHERE id = @id " + Environment.NewLine;

                    cmd.CommandText = query;
                    cmd.Connection = con;

                    #region Insert query values
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = recipeIngredients.Id;
                    cmd.Parameters.Add("@recipeId", SqlDbType.Int).Value = recipeIngredients.Recipe.Id;
                    cmd.Parameters.Add("@ingredientId", SqlDbType.Int).Value = recipeIngredients.Ingredient.Id;
                    cmd.Parameters.Add("@quantity", SqlDbType.Decimal).Value = recipeIngredients.Quantity;
                    cmd.Parameters.Add("@unitId", SqlDbType.Int).Value = recipeIngredients.Unit.Id;

                    #endregion

                    if (con.State != ConnectionState.Open)
                        con.Open();
                    cmd.ExecuteNonQuery();


                }
            }
        }

        

        public void UpdateUserFavorites(UserFavorites userFavorites)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    string query = "UPDATE UserFavorites SET userId= @userId, recipeId= @recipeId WHERE id = @id " + Environment.NewLine;

                    cmd.CommandText = query;
                    cmd.Connection = con;

                    #region Insert query values
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = userFavorites.Id;
                    cmd.Parameters.Add("@recipeId", SqlDbType.Int).Value = userFavorites.Recipe.Id;
                    cmd.Parameters.Add("@userId", SqlDbType.Int).Value = userFavorites.User.Id;

                    #endregion

                    if (con.State != ConnectionState.Open)
                        con.Open();
                    cmd.ExecuteNonQuery();


                }
            }
        }

        public void DeleteRecipeIngredients(int recipeIngredientsId)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    string query = "DELETE FROM RecipeIngredients WHERE id = @id " + Environment.NewLine;

                    cmd.CommandText = query;
                    cmd.Connection = con;

                    #region Insert query values
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = recipeIngredientsId;
                    #endregion

                    if (con.State != ConnectionState.Open)
                        con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }



        public void DeleteUserFavorites(int userFavoritesId)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    string query = "DELETE FROM UserFavorites WHERE id = @id " + Environment.NewLine;

                    cmd.CommandText = query;
                    cmd.Connection = con;

                    #region Insert query values
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = userFavoritesId;                    
                    #endregion

                    if (con.State != ConnectionState.Open)
                        con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public int LastRecipeId()
        {
            int recipeId = 0;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    string query = "SELECT IDENT_CURRENT('Recipe');";

                    cmd.CommandText = query;
                    cmd.Connection = con;

                    if (con.State != ConnectionState.Open)
                        con.Open();
                    recipeId = Convert.ToInt32(cmd.ExecuteScalar());
                }
                return recipeId;
            }
          
        }


        public void UpdateRecipeApprovalStatus(int recipeId, bool approved)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    string query = "UPDATE Recipe SET approved = @approved WHERE id = @recipeId";

                    cmd.CommandText = query;
                    cmd.Connection = con;

                    cmd.Parameters.Add("@recipeId", SqlDbType.Int).Value = recipeId;
                    cmd.Parameters.Add("@approved", SqlDbType.Bit).Value = approved;

                    if (con.State != ConnectionState.Open)
                        con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public DataTable SearchRecipes(string searchTerm)
        {
            DataTable dt = new DataTable();

           
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        string query = "SELECT * FROM Recipe WHERE name LIKE '%' + @searchTerm + '%' OR preparationMethod LIKE '%' + @searchTerm + '%'";

                        cmd.CommandText = query;
                        cmd.Connection = con;

                        cmd.Parameters.Add("@searchTerm", SqlDbType.NVarChar).Value = searchTerm;

                        if (con.State != ConnectionState.Open)
                            con.Open();

                        SqlDataAdapter da = new SqlDataAdapter();
                        da.SelectCommand = cmd;
                        da.Fill(dt);
                    }
                }
            
            

            return dt;
        }

    }
}
