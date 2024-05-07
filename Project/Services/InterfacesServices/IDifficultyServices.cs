using RecipeModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.InterfacesServices
{
    public interface IDifficultyServices
    {
        public List<Difficulty> GetAllDifficulties();
        public Difficulty GetDifficultyById(int id);
        public Boolean InsertNewDifficulty(Difficulty newDifficulty);
        public Boolean UpdateDifficulty(Difficulty updatedDifficulty);
        public Difficulty GetDifficultyByName(string name);
    }
}
