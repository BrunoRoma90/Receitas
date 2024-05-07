using RecipeModels;
using Repositories;
using Repositories.Interfaces;
using Services.InterfacesServices;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class DifficultyServices : IDifficultyServices
    {
        
        private IDifficutyRepository _repository = new DifficultyRepository();

        public List<Difficulty> GetAllDifficulties()
        {

            List<Difficulty> lDifficulties = new List<Difficulty>();
            DataTable dt = _repository.GetAllDifficulties();

            foreach (DataRow row in dt.Rows)
            {
                Difficulty difficulty = new Difficulty
                {
                    Id = Convert.ToInt32(row["id"]),
                    Name = row["name"].ToString(),

                };

                lDifficulties.Add(difficulty);
            }

            return lDifficulties;
        }

        public Difficulty GetDifficultyById(int id)
        {


            DataTable dt = _repository.GetDifficultyById(id);
            DataRow dr = dt.Rows[0];
            Difficulty difficulty = new Difficulty(Convert.ToInt32(dr["id"].ToString()),dr["name"].ToString());

            return difficulty;
        }

        public Boolean InsertNewDifficulty(Difficulty newDifficulty)
        {
            bool inserted = false;

            try
            {

                _repository.InsertNewDifficulty(newDifficulty);
                inserted = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("This is not working");
            }
            return inserted;
        }


        public Boolean UpdateDifficulty(Difficulty updatedDifficulty)
        {
            bool updated = false;

            try
            {
                _repository.UpdateDifficulty(updatedDifficulty);
                updated = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("This is not working");
            }
            return updated;
        }

        public Difficulty GetDifficultyByName(string name)
        {
            DataTable dt = _repository.GetDifficultyByName(name);

            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];
                return new Difficulty(
                    Convert.ToInt32(dr["id"]),
                    dr["name"].ToString()
                    );
            }

            return null;
        }

    }
}
