namespace MyWallet.Application.UseCases.GetAccountDetails {
    using System.Threading.Tasks;
    using System;

    public interface IGetAccountDetailsUseCase {
        Task<AccountOutput> Execute (Guid accountId);
    }
}