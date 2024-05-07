using RecipeModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.InterfacesServices
{
    public interface IUserServices
    {
        public List<User> GetAllUsers();
        public User GetUserById(int id);
        public Boolean InsertNewUser(User newUser);
        public Boolean UpdateUser(User updatedUser);
        public User AuthenticateUser(string username, string password);

        public User GetUserByEmail(string email);
        public User GetUserByUsername(string username);
        public User LoginUserMenu();
        public void RegisterUserMenu();
        public void ViewPersonalInformationMenu(User authenticatedUser);
        public void UpdatePersonalInformationMenu(User authenticatedUser);
        public void InsertNewCategoryMenuAdmin();
        public void InsertNewIngredientMenuAdmin();
        public void InsertNewDifficultyMenuAdmin();

    }
}
