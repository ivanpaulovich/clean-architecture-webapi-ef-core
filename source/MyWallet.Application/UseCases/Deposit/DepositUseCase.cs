namespace MyWallet.Application.UseCases.Deposit {
    using System.Threading.Tasks;
    using System;
    using MyWallet.Application.Repositories;
    using MyWallet.Domain.Accounts;
    using MyWallet.Domain.ValueObjects;

    public sealed class DepositUseCase : IDepositUseCase {
        private readonly IAccountReadOnlyRepository _accountReadOnlyRepository;
        private readonly IAccountWriteOnlyRepository _accountWriteOnlyRepository;

        public DepositUseCase (
            IAccountReadOnlyRepository accountReadOnlyRepository,
            IAccountWriteOnlyRepository accountWriteOnlyRepository) {
            _accountReadOnlyRepository = accountReadOnlyRepository;
            _accountWriteOnlyRepository = accountWriteOnlyRepository;
        }

        public async Task<DepositOutput> Execute (Guid accountId, Amount amount) {
            Account account = await _accountReadOnlyRepository.Get (accountId);
            if (account == null)
                throw new AccountNotFoundException ($"The account {accountId} does not exists or is already closed.");

            account.Deposit (amount);
            Credit credit = (Credit) account.GetLastTransaction ();

            await _accountWriteOnlyRepository.Update (account, credit);

            DepositOutput output = new DepositOutput (
                credit,
                account.GetCurrentBalance ());
            return output;
        }
    }
}