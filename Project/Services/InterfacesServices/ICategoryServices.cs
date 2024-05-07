using RecipeModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.InterfacesServices
{
    public interface ICategoryServices
    {
        public List<Category> GetAllCategories();
        public Category GetCategoryById(int id);
        public Boolean InsertNewCategory(Category newCategory);
        public Boolean UpdateCategory(Category updatedCategory);

        public Category GetCategoryByName(string description);

    }
}
