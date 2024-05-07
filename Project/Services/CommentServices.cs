using RecipeModels;
using Repositories;
using Repositories.Interfaces;
using Services.InterfacesServices;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class CommentServices : ICommentServices
    {

        private ICommentRepository _repository = new CommentRepository();       
        private IRecipeServices _recipeServices = new RecipeServices();

        public List<Comment> GetAllComments()
        {

            List<Comment> lComments = new List<Comment>();
            DataTable dt = _repository.GetAllComments();

            foreach (DataRow row in dt.Rows)
            {
                Comment comment = new Comment()
                {
                    Id = Convert.ToInt32(row["id"]),
                    Text = row["text"].ToString(),

                };

                lComments.Add(comment);
            }

            return lComments;
        }

        public Comment GetCommentById(int id)
        {


            DataTable dt = _repository.GetCommentById(id);
            DataRow dr = dt.Rows[0];
            Comment comment = new Comment(Convert.ToInt32(dr["id"].ToString()), dr["text"].ToString());

            return comment;
        }

       

        public List<Comment> GetCommentByUserId(int userId)
        {
            List<Comment> comments = new List<Comment>();

            try
            {
                int recipeId;
                DataTable dt = _repository.GetCommentByUserId(userId);
                foreach (DataRow dr in dt.Rows)
                {

                    Recipe recipe = new Recipe();
                    if (dr["recipeId"] != DBNull.Value)
                    {
                        recipeId = Convert.ToInt32(dr["recipeId"]);
                        recipe = _recipeServices.GetRecipeById(recipeId);
                    }


                    Comment recipeComments = new Comment(
                        Convert.ToInt32(dr["id"].ToString()),
                        dr["text"].ToString()
                        );

                    comments.Add(recipeComments);
                }
            }
            catch (Exception ex)
            {

            }

            return comments;
        }

        public Boolean UpdateComment(Comment updatedComment)
        {
            bool updated = false;

            try
            {
                _repository.UpdateComment(updatedComment);
                updated = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("This is not working");
            }
            return updated;
        }

    }
}
