using RecipeModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Interfaces
{
    public interface IUserRepository
    {
        public DataTable GetAllUsers();
        public DataTable GetUserById(int id);
        public void InsertNewUser(User user);
        public void UpdateUser(User user);
        public DataTable GetUserByCredentials(string username, string password);

        public DataTable GetUserByEmail(string email);
        public DataTable GetUserByUsername(string username);

    }
}
