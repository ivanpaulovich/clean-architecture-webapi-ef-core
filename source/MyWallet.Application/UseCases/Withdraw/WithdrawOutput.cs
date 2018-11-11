namespace MyWallet.Application.UseCases.Withdraw {
    using MyWallet.Domain.Accounts;
    using MyWallet.Domain.ValueObjects;

    public sealed class WithdrawOutput {
        public TransactionOutput Transaction { get; }
        public decimal UpdatedBalance { get; }

        public WithdrawOutput (Debit transaction, Amount updatedBalance) {
            Transaction = new TransactionOutput (
                transaction.Description,
                transaction.Amount,
                transaction.TransactionDate);

            UpdatedBalance = updatedBalance;
        }
    }
}