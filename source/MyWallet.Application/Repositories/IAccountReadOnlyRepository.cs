namespace MyWallet.Application.Repositories {
    using System.Threading.Tasks;
    using System;
    using MyWallet.Domain.Accounts;

    public interface IAccountReadOnlyRepository {
        Task<Account> Get (Guid id);
    }
}