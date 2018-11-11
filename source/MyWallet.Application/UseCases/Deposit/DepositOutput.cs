namespace MyWallet.Application.UseCases.Deposit {
    using MyWallet.Domain.Accounts;
    using MyWallet.Domain.ValueObjects;

    public sealed class DepositOutput {
        public TransactionOutput Transaction { get; }
        public decimal UpdatedBalance { get; }

        public DepositOutput (
            Credit credit,
            Amount updatedBalance) {
            Transaction = new TransactionOutput (
                credit.Description,
                credit.Amount,
                credit.TransactionDate);

            UpdatedBalance = updatedBalance;
        }
    }
}