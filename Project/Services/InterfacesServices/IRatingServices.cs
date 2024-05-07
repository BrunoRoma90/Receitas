using RecipeModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.InterfacesServices
{
    public interface IRatingServices
    {
        public List<Rating> GetAllRatings();
        public Rating GetRatingById(int id);

    }
}
