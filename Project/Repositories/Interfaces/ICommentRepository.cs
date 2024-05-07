using RecipeModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Interfaces
{
    public interface ICommentRepository
    {
        public DataTable GetAllComments();
        public DataTable GetCommentById(int id);
        public DataTable GetCommentByRecipeId(int recipeId);
        public DataTable GetCommentByUserId(int userId);
        public void InsertNewComment(Comment comment);
        public void UpdateComment(Comment comment);






    }
}
