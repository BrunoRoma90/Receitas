using RecipeModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.InterfacesServices
{
    public interface ICommentServices
    {
        public List<Comment> GetAllComments();
        public Comment GetCommentById(int id);
        public List<Comment> GetCommentByUserId(int userId);
        public Boolean UpdateComment(Comment updatedComment);

    }
}
