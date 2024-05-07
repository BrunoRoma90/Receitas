using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeModels
{
    public class Rating
    {
        public int Id { get; set; }
        public double Value { get; set; }
        public User User { get; set; }
        public Recipe Recipe { get; set; }

        public Rating() { }

        public Rating(int id, double value)
        {
            Id = id;
            Value = value;
        }

        public Rating(int id, double value, User user, Recipe recipe)
        {
            Id = id;
            Value = value;
            User = user;
            Recipe = recipe;
        }
        public Rating(int id, double value, Recipe recipe)
        {
            Id = id;
            Value = value;
            Recipe = recipe;
        }

        public Rating(int id, double value, User user)
        {
            Id = id;
            Value = value;
            User = user;
        }
    }
}
