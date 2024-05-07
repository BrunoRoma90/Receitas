using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using RecipeModels;
using Repositories.Interfaces;

namespace Repositories
{
    public class UserRepository : IUserRepository
    {
        //string connectionString = ConfigurationManager.ConnectionStrings["MyDBConnectionString"].ConnectionString.ToString(); //Ligação à base de dados
        private static Generic _generic = new Generic();
        private static string connectionString = _generic.GetConnectionString();

        public DataTable GetAllUsers()
        {
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    string query = "SELECT * FROM Users";

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


        public DataTable GetUserById(int id)
        {
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(connectionString))
            {

                using (SqlCommand cmd = new SqlCommand())
                {
                    string query = "SELECT * FROM Users Where id = @userId";

                    cmd.CommandText = query;
                    cmd.Connection = con;
                    cmd.Parameters.Add("@userId", SqlDbType.Int).Value = id;  //Definimos o formato neste caso é um INT

                    if (con.State != ConnectionState.Open) //Ligação for diferente de aberto Abre
                        con.Open();

                    SqlDataAdapter da = new SqlDataAdapter();
                    da.SelectCommand = cmd;
                    da.Fill(dt);
                }// Comando/Instrução/Faz isto

            }
            return dt;
        }


        public void InsertNewUser(User user)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    string query = "INSERT INTO Users(username, email, password, isAdmin) VALUES(@username, @email, @password, @isAdmin )";

                    cmd.CommandText = query;
                    cmd.Connection = con;

                    #region Insert query values
                    cmd.Parameters.Add("@username", SqlDbType.NVarChar).Value = user.UserName;
                    cmd.Parameters.Add("@email", SqlDbType.NVarChar).Value = user.Email;
                    cmd.Parameters.Add("@password", SqlDbType.NVarChar).Value = user.Password;
                    cmd.Parameters.Add("@isAdmin", SqlDbType.Bit).Value = false;                   
                    #endregion

                    if (con.State != ConnectionState.Open)
                        con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }


        public void UpdateUser(User user)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    string query = "UPDATE Users SET username= @username, email= @email, password= @password, isAdmin= @isAdmin WHERE id = @id " + Environment.NewLine;

                    cmd.CommandText = query;
                    cmd.Connection = con;

                    #region Insert query values
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = user.Id;
                    cmd.Parameters.Add("@username", SqlDbType.NVarChar).Value = user.UserName;
                    cmd.Parameters.Add("@email", SqlDbType.NVarChar).Value = user.Email;
                    cmd.Parameters.Add("@password", SqlDbType.NVarChar).Value = user.Password;
                    cmd.Parameters.Add("@isAdmin", SqlDbType.Bit).Value = false;

                    #endregion

                    if (con.State != ConnectionState.Open)
                        con.Open();
                    cmd.ExecuteNonQuery();


                }
            }
        }


        public DataTable GetUserByCredentials(string username, string password)
        {
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    string query = "SELECT * FROM Users WHERE username = @username AND password = @password";

                    cmd.CommandText = query;
                    cmd.Connection = con;
                    cmd.Parameters.Add("@username", SqlDbType.NVarChar).Value = username;
                    cmd.Parameters.Add("@password", SqlDbType.NVarChar).Value = password;

                    if (con.State != ConnectionState.Open)
                        con.Open();

                    SqlDataAdapter da = new SqlDataAdapter();
                    da.SelectCommand = cmd;
                    da.Fill(dt);

                  
                
                }
            }
            return dt;


        }



        public DataTable GetUserByEmail(string email)
        {
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    string query = "SELECT * FROM Users WHERE email = @email";

                    cmd.CommandText = query;
                    cmd.Connection = con;
                    cmd.Parameters.Add("@email", SqlDbType.NVarChar).Value = email;

                    if (con.State != ConnectionState.Open)
                        con.Open();

                    SqlDataAdapter da = new SqlDataAdapter();
                    da.SelectCommand = cmd;
                    da.Fill(dt);
                }
            }
            return dt;
        }

        public DataTable GetUserByUsername(string username)
        {
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    string query = "SELECT * FROM Users WHERE username = @username";

                    cmd.CommandText = query;
                    cmd.Connection = con;
                    cmd.Parameters.Add("@username", SqlDbType.NVarChar).Value = username;

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