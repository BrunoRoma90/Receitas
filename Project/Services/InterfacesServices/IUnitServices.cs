using RecipeModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.InterfacesServices
{
    public interface IUnitServices
    {
        public List<Unit> GetAllUnits();
        public Unit GetUnitById(int id);
        public Boolean InsertNewUnit(Unit newUnit);
        public Boolean UpdateUnit(Unit updatedUnit);
        public Unit GetUnitByName(string name);

    }
}
