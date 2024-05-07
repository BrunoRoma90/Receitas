using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeModels
{
    public class Comment
    {
        public int Id {  get; set; }
        public string Text { get; set; }    

        public User User { get; set; }
        public Recipe Recipe { get; set; }


        public Comment()
        {

        }

        public Comment(int id, string text)
        {
            Id = id;
            Text = text;
        }

        public Comment(int id, string text, User user, Recipe recipe)
        {
            Id = id;
            Text = text;
            User = user;
            Recipe = recipe;
        }

        public Comment(int id, string text, User user)
        {
            Id = id;
            Text = text;
            User = user;
           
        }
    }
}
