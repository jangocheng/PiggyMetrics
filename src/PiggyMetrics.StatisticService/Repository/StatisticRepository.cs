using Microsoft.Extensions.Options;
using PiggyMetrics.Common;

namespace PiggyMetrics.StatisticService.Repository
{
    public class StatisticRepository : BaseRepository
    {
        public StatisticRepository(IOptions<DbOption> Option) : base(Option.Value.StatDbConStr)
        {
        }
    }
}
