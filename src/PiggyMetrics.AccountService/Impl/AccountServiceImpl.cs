using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DotBPE.Rpc.Client;
using DotBPE.Rpc.Logging;
using PiggyMetrics.AccountService.Repository;
using PiggyMetrics.Common;

namespace PiggyMetrics.AccountService.Impl
{
    public class AccountServiceImpl : AccountServiceBase
    {
        static ILogger Logger = DotBPE.Rpc.Environment.Logger.ForType<AccountServiceImpl>();
        private readonly AccountRepository _accountRep;
        public AccountServiceImpl(AccountRepository accountRep){
            this._accountRep = accountRep;
        }

        public override async Task<Account> CreateAsync(User user)
        {
            UserInfo existing = await this._accountRep.FindByNameAsync(user.Account);

            Assert.IsNull(user,"用户已经存在了");

            //调用远端
            var authClient = ClientProxy.GetClient<AuthServiceClient>();
            await authClient.CreateAsync(user);

            Saving saving = new Saving()
            {
                Amount = 0,
                Currency = Currency.Usd,
                Interest = 0,
                Deposit = false,
                Capitalization = false,
                Account = user.Account
            };
            Account account = new Account();
            account.UserInfo = new UserInfo();
            account.UserInfo.Account = user.Account;
            account.UserInfo.CreateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            account.UserInfo.LastSeenTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            await this._accountRep.SaveUserAsync(account.UserInfo);
            await this._accountRep.SaveAccountSavingAsync(saving);

            Logger.Info("new account has been created:{0} " , user.Account);

            return account;
        }

        public override async Task<Account> FindByNameAsync(FindAccountReq request)
        {
            Account account  = new Account();
            account.UserInfo = await this._accountRep.FindByNameAsync(request.Name);
            Assert.IsNotNull(account.UserInfo,"账号不存在");

            List<Item> incomes = await this._accountRep.FindIncomesAsync(account.UserInfo.Account);
            List<Item> expenses = await this._accountRep.FindExpensesAsync(account.UserInfo.Account);

            account.Saving = await this._accountRep.FindSavingAsync(account.UserInfo.Account);

            account.Incomes.AddRange(incomes);
            account.Expenses.Add(expenses);
            return account;
        }

        public override async Task<VoidRsp> SaveAsync(Account account)
        {
            await this._accountRep.UpdateUserInfoAsync(account.UserInfo);

            account.Saving.Account = account.UserInfo.Account;
            await this._accountRep.UpdateAccountSavingAsync(account.Saving);

            await this._accountRep.DeleteIncomesAsync(account.UserInfo.Account);
            await this._accountRep.DeleteExpensesAsync(account.UserInfo.Account);

            await this._accountRep.AddIncomesAsync(account.Incomes);
            await this._accountRep.AddExpensesAsync(account.Expenses);

            //调用远端服务
            var statClient = ClientProxy.GetClient<StatisticServiceClient>();
            await statClient.UpdateStatisticsAsync(account);

            return new VoidRsp();

        }
    }
}
