using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeModels
{
    public class Recipe
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PreparationMethod { get; set; }

        public string PreparationTime { get; set; }

        public User User { get; set; }
        public Difficulty Difficulty { get; set; }
        public Category Category{ get; set; }
        public double Rating { get; set; }

        public bool Approved { get; set; }

        public List<Comment> Comments { get; set; }
        public List<RecipeIngredients> RecipeIngredients { get; set; }


        public Recipe() { }

        public Recipe(int id, string name, string preparationMethod, string preparationTime, User user, Difficulty difficulty, Category category, bool approved, double rating)
        {
            Id = id;
            Name = name;
            PreparationMethod = preparationMethod;
            PreparationTime = preparationTime;
            User = user;
            Difficulty = difficulty;
            Category = category;
            Approved = approved;
            Rating = rating;

        }

        public Recipe(int id, string name, List<RecipeIngredients> recipeIngredients, List<Comment> comments)
        {
            Id = id;
            Name = name;
            RecipeIngredients = recipeIngredients;
            Comments = comments;
        }

        

    }
}
