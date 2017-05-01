using System;
using System.Threading.Tasks;
using DotBPE.Rpc.Logging;
using PiggyMetrics.AuthService.Repository;
using PiggyMetrics.Common;


namespace PiggyMetrics.AuthService.Impl
{
    public class AuthServiceImpl:AuthServiceBase
    {
        static readonly ILogger Logger = DotBPE.Rpc.Environment.Logger.ForType<AuthServiceImpl>();
        private readonly AuthRepository _repo;
        public AuthServiceImpl(AuthRepository repo)
        {
            this._repo = repo;
        }
        public override async Task<VoidRsp> CreateAsync(User user)
        {
            User existing = await this._repo.FindByNameAsync(user.Account);
            if (existing !=null)
            {
                Logger.Debug("user alread exists:{0}", user.Account);
            }
            Assert.NotNull(existing, "user alread exists:"+ user.Account);

            user.Password = CryptographyManager.Md5Encrypt(user.Account + "$" + user.Password);

            await this._repo.SaveUserAsync(user);
            return new VoidRsp();
        }

        public override async Task<AuthRsp> AuthAsync(User user)
        {
            User existing = await this._repo.FindByNameAsync(user.Account);
            Assert.IsNull(existing, "user not found：" + user.Account);

            string  enpass = CryptographyManager.Md5Encrypt(user.Account + "$" + user.Password);
            var rsp = new AuthRsp();
            if (enpass == existing.Password)
            {
                await this._repo.UpdateLastSenTimeAsync(user.Account,DateTime.Now);
                rsp.Status = 0;
            }
            else
            {
                rsp.Status = -1;
            }
            return rsp;
        }
    }
}
