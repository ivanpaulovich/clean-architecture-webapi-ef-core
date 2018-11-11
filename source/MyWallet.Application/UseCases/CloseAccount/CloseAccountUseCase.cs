namespace MyWallet.Application.UseCases.CloseAccount {
    using System.Threading.Tasks;
    using System;
    using MyWallet.Application.Repositories;
    using MyWallet.Domain.Accounts;

    public sealed class CloseAccountUseCase : ICloseAccountUseCase {
        private readonly IAccountReadOnlyRepository _accountReadOnlyRepository;
        private readonly IAccountWriteOnlyRepository _accountWriteOnlyRepository;

        public CloseAccountUseCase (
            IAccountReadOnlyRepository accountReadOnlyRepository,
            IAccountWriteOnlyRepository accountWriteOnlyRepository) {
            _accountReadOnlyRepository = accountReadOnlyRepository;
            _accountWriteOnlyRepository = accountWriteOnlyRepository;
        }

        public async Task<Guid> Execute (Guid accountId) {
            Account account = await _accountReadOnlyRepository.Get (accountId);
            if (account == null)
                throw new AccountNotFoundException ($"The account {accountId} does not exists or is already closed.");

            account.Close ();

            await _accountWriteOnlyRepository.Delete (account);

            return account.Id;
        }
    }
}