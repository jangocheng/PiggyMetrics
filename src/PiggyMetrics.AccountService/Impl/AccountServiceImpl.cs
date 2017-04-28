using System;
using System.Threading.Tasks;
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

        public override Task<Account> CreateAsync(User request)
        {
            Account existing = repository.findByName(user.getUsername());
            Assert.isNull(existing, "account already exists: " + user.getUsername());

            authClient.createUser(user);

            Saving saving = new Saving();
            saving.setAmount(new BigDecimal(0));
            saving.setCurrency(Currency.getDefault());
            saving.setInterest(new BigDecimal(0));
            saving.setDeposit(false);
            saving.setCapitalization(false);

            Account account = new Account();
            account.setName(user.getUsername());
            account.setLastSeen(new Date());
            account.setSaving(saving);

            this._accountRep.Save(account);

            Logger.Info("new account has been created: " + account.getName());

            return account;
        }

        public override Task<Account> FindByNameAsync(FindAccountReq request)
        {
            throw new NotImplementedException();
        }

        public override Task<VoidRsp> SaveAsync(Account request)
        {
            throw new NotImplementedException();
        }
    }
}