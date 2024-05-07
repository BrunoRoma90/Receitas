using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeModels
{
    public class UserFavorites
    {
        public int Id { get; set; } 
        public User User { get; set; }
        public Recipe Recipe { get; set; }
        public UserFavorites() { }

        public UserFavorites(int id, User user, Recipe recipe)
        {
            Id = id;
            User = user;
            Recipe = recipe;
            
        }

        public UserFavorites(int id, Recipe recipe)
        {
            Id = id;
            Recipe = recipe;
        }

        public UserFavorites(int id, User user)
        {
            Id = id;
            User = user;
        }
    }
}
