using RecipeModels;
using Repositories;
using Repositories.Interfaces;
using Services.InterfacesServices;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class CategoryServices : ICategoryServices
    {
        private ICategoryRepository _repository = new CategoryRepository();
        

        public List<Category> GetAllCategories()
        {

            List<Category> lCategories = new List<Category>();
            DataTable dt = _repository.GetAllCategories();

            foreach (DataRow row in dt.Rows)
            {
                Category category = new Category
                {
                    Id = Convert.ToInt32(row["id"]),
                    Name = row["description"].ToString()

                };

                lCategories.Add(category);
            }

            return lCategories;
        }



        public Category GetCategoryById(int id)
        {

            
            DataTable dt = _repository.GetCategoryById(id);
            DataRow dr = dt.Rows[0];
            Category category = new Category(Convert.ToInt32(dr["id"].ToString()),dr["description"].ToString());

            return category;
        }



        public Boolean InsertNewCategory(Category newCategory)
        {
            bool inserted = false;

            try
            {

                _repository.InsertNewCategory(newCategory);
                inserted = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("This is not working");
            }
            return inserted;
        }


        public Boolean UpdateCategory(Category updatedCategory)
        {
            bool updated = false;

            try
            {
                _repository.UpdateCategory(updatedCategory);
                updated = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("This is not working");
            }
            return updated;
        }

        public Category GetCategoryByName(string description)
        {
            DataTable dt = _repository.GetCategoryByName(description);

            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];
                return new Category(
                    Convert.ToInt32(dr["id"]),
                    dr["description"].ToString()
                    );
            }

            return null;
        }


    }
}
