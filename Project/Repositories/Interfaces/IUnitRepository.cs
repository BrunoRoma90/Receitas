using RecipeModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Interfaces
{
    public interface IUnitRepository
    {
        public DataTable GetAllUnits();
        public DataTable GetUnitById(int id);
        public void InsertNewUnit(Unit unit);
        public void UpdateUnit(Unit unit);
        public DataTable GetUnitByName(string name);
    }
}
