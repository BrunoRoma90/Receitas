using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    internal class Generic
    {
        public string GetConnectionString()
        {

            string connectionString = "Data Source=db.assembly.pt;Initial Catalog=JD_JPA_BR_Project; User Id=Students;Password=SkillUpForTomorrow";
            return connectionString;
        }
    }
}
