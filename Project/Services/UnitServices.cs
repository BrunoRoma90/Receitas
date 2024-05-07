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
    public class UnitServices : IUnitServices
    {
       
        private IUnitRepository _repository = new UnitRepository();
      
        public List<Unit> GetAllUnits()
        {

            List<Unit> lUnits = new List<Unit>();
            DataTable dt = _repository.GetAllUnits();

            foreach (DataRow row in dt.Rows)
            {
                Unit unit = new Unit
                {
                    Id = Convert.ToInt32(row["id"]),
                    Name = row["name"].ToString(),

                };

                lUnits.Add(unit);
            }

            return lUnits;
        }

        public Unit GetUnitById(int id)
        {


            DataTable dt = _repository.GetUnitById(id);
            DataRow dr = dt.Rows[0];
            Unit unit = new Unit(Convert.ToInt32(dr["id"].ToString()), dr["name"].ToString());

            return unit;
        }

        public Boolean InsertNewUnit(Unit newUnit)
        {
            bool inserted = false;

            try
            {
                
                _repository.InsertNewUnit(newUnit);
                inserted = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("This is not working");
            }
            return inserted;
        }


        public Boolean UpdateUnit(Unit updatedUnit)
        {
            bool updated = false;

            try
            {
                _repository.UpdateUnit(updatedUnit);
                updated = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("This is not working");
            }
            return updated;
        }

        public Unit GetUnitByName(string name)
        {
            DataTable dt = _repository.GetUnitByName(name);

            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];
                return new Unit(
                    Convert.ToInt32(dr["id"]),
                    dr["name"].ToString()
                    );
            }

            return null;
        }

    }
}
