using RecipeModels;
using Repositories;
using Repositories.Interfaces;
using Services.InterfacesServices;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class RatingServices : IRatingServices
    {
        private IRatingRepository _repository = new RatingRepository();
        
        

        public List<Rating> GetAllRatings()
        {

            List<Rating> lRatings = new List<Rating>();
            DataTable dt = _repository.GetAllRatings();

            foreach (DataRow row in dt.Rows)
            {
                Rating rating = new Rating()
                {
                    Id = Convert.ToInt32(row["id"]),
                    Value = Convert.ToDouble(row["Value"].ToString()),

                };

                lRatings.Add(rating);
            }

            return lRatings;
        }

        public Rating GetRatingById(int id)
        {


            DataTable dt = _repository.GetRatingById(id);
            DataRow dr = dt.Rows[0];
            Rating rating = new Rating(Convert.ToInt32(dr["id"].ToString()), Convert.ToDouble(dr["value"].ToString()));

            return rating;
        }


        





    }
}
