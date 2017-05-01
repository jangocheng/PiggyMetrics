using Vulcan.DataAccess.ORMapping.MySql;

namespace PiggyMetrics.Common
{
    public class BaseRepository:MySqlRepository
    {
        public BaseRepository(string constr):base(constr){

        }
    }
}
