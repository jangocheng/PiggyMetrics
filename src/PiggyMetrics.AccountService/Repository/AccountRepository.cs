using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using PiggyMetrics.Common;

namespace PiggyMetrics.AccountService.Repository
{
    public class AccountRepository:BaseRepository
    {
        public AccountRepository(IOptions<DbOption> option):base(option.Value.AccountDbConStr){

        }

        internal Task SaveUserAsync(UserInfo user)
        {
            string sql ="INSERT INTO `user_info` (`account`,`last_seen_time`,`create_time`)	VALUES	(@Account,@LastSeenTime,@CreateTime)";
            return base.ExcuteAsync(sql,user);
        }

        internal  Task<UserInfo> FindByNameAsync(string account)
        {
            string sql ="SELECT `account` as Account,`last_seen_time` as LastSeenTime,`create_time` as CreateTime FROM `user_info` where account=@Account ";

            return base.GetAsync<UserInfo>(sql,new {Account = account});
        }

        internal Task<List<Item>> FindIncomesAsync(string account)
        {
            string sql ="SELECT `title` as Title,`amount` as Amount,`currency` as Currency,`time_period` as TimePeriod,`icon` as Icon FROM `user_income` where account=@Account";
            return base.QueryAsync<Item>(sql,new {Account = account});
        }

        internal Task<List<Item>> FindExpensesAsync(string account)
        {
            string sql ="SELECT `title` as Title,`amount` as Amount,`currency` as Currency,`time_period` as TimePeriod,`icon` as Icon FROM `user_expense` where account=@Account";
            return base.QueryAsync<Item>(sql,new {Account = account});
        }

        internal Task<Saving> FindSavingAsync(string account)
        {
            string sql = "SELECT `amount`,`currency`,`interest`,`deposit`,`capitalization`	FROM `user_saving` WHERE account=@Account";

            return base.GetAsync<Saving>(sql,new {Account = account});
        }

        internal Task SaveAccountSavingAsync(Saving saving)
        {
            string sql = @"INSERT INTO `user_saving`
                            (`account`,`amount`,`currency`,`interest`,`deposit`,`capitalization`)
                        VALUES
                            (@Account,@Amount,@Currency,@Interest,@Deposit,@Capitalization)";

            return base.ExcuteAsync(sql,saving);
        }

        internal Task UpdateUserInfoAsync(UserInfo userInfo)
        {
            string sql ="UPDATE `user_info` SET `last_seen_time`=@LastSeenTime WHERE account=@Account";
            return base.ExcuteAsync(sql,userInfo);
        }

        internal Task DeleteIncomesAsync(string account)
        {
            string sql = "DELETE FROM `user_income` WHERE account=@Account";
            return base.ExcuteAsync(sql,new {Account =account});
        }

        internal Task DeleteExpensesAsync(string account)
        {
            string sql = "DELETE FROM `user_expense` WHERE account=@Account";
            return base.ExcuteAsync(sql,new {Account =account});
        }

        internal Task UpdateAccountSavingAsync(Saving saving)
        {
            string sql = @"UPDATE `user_saving`
                            SET `amount`=@Amount,`currency`=@Currency,
                            `interest`=@Interest,`deposit`=@Deposit,`capitalization`=@Capitalization
                        WHERE account=@Account";

            return base.ExcuteAsync(sql,saving);
        }

        internal async Task AddIncomesAsync(IList<Item> incomes)
        {
           string sql =@"INSERT INTO `user_income`
            (`account`,`title`,`amount`,`currency`,`time_period`,`icon`)
        VALUES
            (@account,@Title,,@Amount,@Currency,@TimePeriod,@Icon, VARCHAR(50)";

            foreach(var item in incomes){
               await base.ExcuteAsync(sql,item);
            }

        }

        internal async Task AddExpensesAsync(IList<Item> expenses)
        {
            string sql =@"INSERT INTO `user_expense`
            (`account`,`title`,`amount`,`currency`,`time_period`,`icon`)
        VALUES
            (@account,@Title,,@Amount,@Currency,@TimePeriod,@Icon, VARCHAR(50)";

            foreach(var item in expenses){
               await base.ExcuteAsync(sql,item);
            }
        }
    }
}
