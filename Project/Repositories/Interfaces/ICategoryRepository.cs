using RecipeModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Interfaces
{
    public interface ICategoryRepository
    {
        public DataTable GetAllCategories();

        public DataTable GetCategoryById(int id);

        public void InsertNewCategory(Category category);

        public void UpdateCategory(Category category);
        public DataTable GetCategoryByName(string description);

    }
}
