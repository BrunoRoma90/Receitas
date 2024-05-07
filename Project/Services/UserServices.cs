using Repositories;
using RecipeModels;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Net;
using Repositories.Interfaces;
using Services.InterfacesServices;

namespace Services
{
    public class UserServices : IUserServices
    {
     
        private IUserRepository _repository = new UserRepository();
        private IIngredientServices _ingredientServices = new IngredientServices();
        private ICategoryServices _categoryServices = new CategoryServices();
        private IDifficultyServices _difficultyServices = new DifficultyServices();
                            
        public List<User> GetAllUsers()
        {
            
            List<User> lUsers = new List<User>();
            DataTable dt = _repository.GetAllUsers();

            foreach (DataRow row in dt.Rows)
            {
                User user = new User
                {
                    Id = Convert.ToInt32(row["id"]),
                    UserName = row["userName"].ToString(),
                    Email = row["email"].ToString(),
                    Password = row["password"].ToString(),
                    IsAdmin = Convert.ToBoolean(row["isAdmin"]),
                };

                lUsers.Add(user);
            }

            return lUsers;
        }

        public User GetUserById(int id)
        {


            DataTable dt = _repository.GetUserById(id);
            DataRow dr = dt.Rows[0];
            User user = new User(Convert.ToInt32(dr["id"].ToString()), dr["username"].ToString(), dr["email"].ToString(), Convert.ToBoolean(dr["isAdmin"].ToString()));

            return user;
        }

        public Boolean InsertNewUser(User newUser)
        {
            bool inserted = false;            
            try
            {

                _repository.InsertNewUser(newUser);
                inserted = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("This is not working");
            }
            return inserted;
        }


        public Boolean UpdateUser(User updatedUser)
        {
            bool updated = false;

            try
            {
                _repository.UpdateUser(updatedUser);
                updated = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("This is not working");
            }
            return updated;
        }


        public User AuthenticateUser(string username, string password)
        {
            

            DataTable dt = _repository.GetUserByCredentials(username, password);


            foreach(DataRow row in dt.Rows)
            {
                User authenticatedUser = new User
                {
                    Id = Convert.ToInt32(row["id"]),
                    UserName = row["username"].ToString(),
                    //Password = row["password"].ToString(),
                    IsAdmin = Convert.ToBoolean(row["isAdmin"].ToString()),

                };
                return authenticatedUser;
            }
            return null;




        }


        public User GetUserByEmail(string email)
        {
            DataTable dt = _repository.GetUserByEmail(email);

            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];
                return new User(
                    Convert.ToInt32(dr["id"]),
                    dr["username"].ToString(),
                    dr["email"].ToString(),
                    Convert.ToBoolean(dr["isAdmin"])
                );
            }

            return null; 
        }


        public User GetUserByUsername(string username)
        {
            DataTable dt = _repository.GetUserByUsername(username);

            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];
                return new User(
                    Convert.ToInt32(dr["id"]),
                    dr["username"].ToString(),
                    dr["email"].ToString(),
                    Convert.ToBoolean(dr["isAdmin"])
                );
            }

            return null; 
        }










        public User LoginUserMenu()
        {
            User authenticatedUser = null;

            while (authenticatedUser == null)
            {

                Console.Write("Username: ");
                string username = Console.ReadLine();
                Console.Write("Password: ");
                string password = Console.ReadLine();

                

                authenticatedUser = AuthenticateUser(username, password);

                
                if (authenticatedUser != null)
                {
                    
                    Console.WriteLine($"ID - {authenticatedUser.Id} ");
                    Console.WriteLine($"Bem-vindo, {authenticatedUser.UserName}!");
                }
                else
                {
                    
                    Console.WriteLine("Credenciais de login incorretas. Tente novamente.");
                }

                return authenticatedUser;
            }
            return null;

        }

        public void RegisterUserMenu()
        {
            try
            {

                Console.Write("Username: ");
                string username = Console.ReadLine();

                Console.Write("Email: ");
                string email = Console.ReadLine();

                Console.Write("Password: ");
                string password = Console.ReadLine();
               

                User newUser = new User
                {
                    UserName = username,
                    Email = email,
                    Password = password,
                    
                };


                InsertNewUser(newUser);

                Console.WriteLine("User adicionado com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Ocorreu um erro ao adicionar o user. Tente novamente.");
            }
        }

        public void ViewPersonalInformationMenu(User authenticatedUser)
        {
            
            int userId = authenticatedUser.Id;
            User user = GetUserById(userId);
            Console.WriteLine($"Username: {user.UserName}");
            Console.WriteLine($"Email: {user.Email}");

        }

        public void UpdatePersonalInformationMenu(User authenticatedUser)
        {
            try
            {
                int userId = authenticatedUser.Id;
                User user = GetUserById(authenticatedUser.Id);
                Console.WriteLine("Atualizar informações pessoais");
                Console.Write("Novo email: ");
                string newEmail = Console.ReadLine();
                Console.Write("Nova senha: ");
                string newPassword = Console.ReadLine();

                User updatedUser = new User
                {
                    Id = userId,
                    UserName = user.UserName,
                    Email = newEmail,
                    Password = newPassword,

                };
                bool result = UpdateUser(updatedUser);
                if (result)
                {
                    Console.WriteLine("Dados pessoais actualizados com sucesso");
                }
                else
                {
                    Console.WriteLine("Falha na actualização de dados pessoais");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Ocorreu um erro. Tente novamente.");

            }


        }



        public void InsertNewCategoryMenuAdmin()
        {
            Console.WriteLine("Nome da nova Categoria");
            string name = Console.ReadLine();
            Category category = new Category
            {
                Name = name
            };
            _categoryServices.InsertNewCategory(category);
        }

        public void InsertNewIngredientMenuAdmin()
        {
            Console.WriteLine("Nome do novo Ingredient");
            string name = Console.ReadLine();
            Ingredient ingredient = new Ingredient
            {
                Name = name
            };
            _ingredientServices.InsertNewIngredient(ingredient);
        }

        public void InsertNewDifficultyMenuAdmin()
        {
            Console.WriteLine("Nome da nova Dificuldade");
            string name = Console.ReadLine();
            Difficulty difficulty = new Difficulty
            {
                Name = name
            };
            _difficultyServices.InsertNewDifficulty(difficulty);
        }


    }
}