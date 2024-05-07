using RecipeModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Interfaces
{
    public interface IDifficutyRepository
    {
        public DataTable GetAllDifficulties();
        public DataTable GetDifficultyById(int id);
        public void InsertNewDifficulty(Difficulty difficulty);
        public void UpdateDifficulty(Difficulty difficulty);
        public DataTable GetDifficultyByName(string name);
    }
}
