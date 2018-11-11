namespace MyWallet.Application.UseCases.CloseAccount {
    using System.Threading.Tasks;
    using System;

    public interface ICloseAccountUseCase {
        Task<Guid> Execute (Guid accountId);
    }
}