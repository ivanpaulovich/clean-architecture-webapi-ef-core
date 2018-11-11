namespace MyWallet.Application.UseCases.Withdraw {
    using System.Threading.Tasks;
    using System;
    using MyWallet.Domain.ValueObjects;

    public interface IWithdrawUseCase {
        Task<WithdrawOutput> Execute (Guid accountId, Amount amount);
    }
}