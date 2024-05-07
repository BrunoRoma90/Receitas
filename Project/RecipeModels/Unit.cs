using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeModels
{
    public class Unit
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public Unit() { }
        public Unit(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
