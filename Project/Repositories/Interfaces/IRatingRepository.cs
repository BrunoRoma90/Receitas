using RecipeModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Interfaces
{
    public interface IRatingRepository
    {
        public DataTable GetAllRatings();
        public DataTable GetRatingById(int id);
        public DataTable GetRatingsByRecipeId(int recipeId);
        public DataTable GetRatingsByUserId(int userId);
        public void InsertNewRating(Rating rating);
        public void UpdateRating(Rating rating);

    }
}
