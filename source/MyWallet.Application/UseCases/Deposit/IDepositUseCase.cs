namespace MyWallet.Application.UseCases.Deposit {
    using System.Threading.Tasks;
    using System;
    using MyWallet.Domain.ValueObjects;

    public interface IDepositUseCase {
        Task<DepositOutput> Execute (Guid accountId, Amount amount);
    }
}