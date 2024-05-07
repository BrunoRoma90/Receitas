using RecipeModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repositories.Interfaces;

namespace Repositories
{
    public class DifficultyRepository : IDifficutyRepository
    {
        //string connectionString = ConfigurationManager.ConnectionStrings["MyDBConnectionString"].ConnectionString.ToString(); //Ligação à base de dados
        private static Generic _generic = new Generic();
        private static string connectionString = _generic.GetConnectionString();
        public DataTable GetAllDifficulties()
        {
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    string query = "SELECT * FROM Difficulty";

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
        public DataTable GetDifficultyById(int id)
        {
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(connectionString))
            {

                using (SqlCommand cmd = new SqlCommand())
                {
                    string query = "SELECT * FROM Difficulty Where id = @difficultyId";

                    cmd.CommandText = query;
                    cmd.Connection = con;
                    cmd.Parameters.Add("@difficultyId", SqlDbType.Int).Value = id;  //Definimos o formato neste caso é um INT

                    if (con.State != ConnectionState.Open) //Ligação for diferente de aberto Abre
                        con.Open();

                    SqlDataAdapter da = new SqlDataAdapter();
                    da.SelectCommand = cmd;
                    da.Fill(dt);
                }// Comando/Instrução/Faz isto

            }
            return dt;
        }

        public void InsertNewDifficulty(Difficulty difficulty)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    string query = "INSERT INTO Difficulty(name) VALUES(@name)";

                    cmd.CommandText = query;
                    cmd.Connection = con;

                    #region Insert query values
                    cmd.Parameters.Add("@name", SqlDbType.NVarChar).Value = difficulty.Name;
                    #endregion

                    if (con.State != ConnectionState.Open)
                        con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void UpdateDifficulty(Difficulty difficulty)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    string query = "UPDATE Difficulty SET name= @name WHERE id = @id" + Environment.NewLine;

                    cmd.CommandText = query;
                    cmd.Connection = con;

                    #region Insert query values
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = difficulty.Id;
                    cmd.Parameters.Add("@name", SqlDbType.NVarChar).Value = difficulty.Name;

                    #endregion

                    if (con.State != ConnectionState.Open)
                        con.Open();
                    cmd.ExecuteNonQuery();


                }
            }

        }

        public DataTable GetDifficultyByName(string name)
        {
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    string query = "SELECT * FROM Difficulty WHERE name = @name";

                    cmd.CommandText = query;
                    cmd.Connection = con;
                    cmd.Parameters.Add("@name", SqlDbType.NVarChar).Value = name;

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
