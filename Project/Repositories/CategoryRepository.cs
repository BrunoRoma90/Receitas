using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repositories.Interfaces;
using RecipeModels;

namespace Repositories
{
    public class CategoryRepository : ICategoryRepository
    {

        // string connectionString = ConfigurationManager.ConnectionStrings["MyDBConnectionString"].ConnectionString.ToString(); //Ligação à base de dados

        private static Generic _generic = new Generic();
        private static string connectionString = _generic.GetConnectionString();


        public DataTable GetAllCategories()
        {
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    string query = "SELECT * FROM Category";

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


        public DataTable GetCategoryById(int id)
        {
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(connectionString))
            {

                using (SqlCommand cmd = new SqlCommand())
                {
                    string query = "SELECT * FROM Category Where id = @categoryId";

                    cmd.CommandText = query;
                    cmd.Connection = con;                    
                    cmd.Parameters.Add("@categoryId", SqlDbType.Int).Value = id;  //Definimos o formato neste caso é um INT

                    if (con.State != ConnectionState.Open) //Ligação for diferente de aberto Abre
                        con.Open();

                    SqlDataAdapter da = new SqlDataAdapter();
                    da.SelectCommand = cmd;
                    da.Fill(dt);
                }// Comando/Instrução/Faz isto

            }
            return dt;
        }



        public void InsertNewCategory(Category category)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    string query = "INSERT INTO Category(description) VALUES(@description)";

                    cmd.CommandText = query;
                    cmd.Connection = con;

                    #region Insert query values
                    cmd.Parameters.Add("@description", SqlDbType.NVarChar).Value = category.Name;
                    #endregion

                    if (con.State != ConnectionState.Open)
                        con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }


        public void UpdateCategory(Category category)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    string query = "UPDATE Category SET description= @description WHERE id = @id" + Environment.NewLine;

                    cmd.CommandText = query;
                    cmd.Connection = con;

                    #region Insert query values
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = category.Id;
                    cmd.Parameters.Add("@description", SqlDbType.NVarChar).Value = category.Name;
                    
                    #endregion

                    if (con.State != ConnectionState.Open)
                        con.Open();
                    cmd.ExecuteNonQuery();


                }
            }
        }


        public DataTable GetCategoryByName(string description)
        {
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    string query = "SELECT * FROM Category WHERE description = @description";

                    cmd.CommandText = query;
                    cmd.Connection = con;
                    cmd.Parameters.Add("@description", SqlDbType.NVarChar).Value = description;

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
