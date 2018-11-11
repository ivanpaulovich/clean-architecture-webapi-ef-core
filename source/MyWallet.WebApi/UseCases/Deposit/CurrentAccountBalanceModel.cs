namespace MyWallet.WebApi.UseCases.Deposit {
    using System;

    public class CurrentAccountBalanceModel {
        public decimal Amount { get; }
        public string Description { get; }
        public DateTime TransactionDate { get; }
        public decimal UpdateBalance { get; }

        public CurrentAccountBalanceModel (
            decimal amount,
            string description,
            DateTime transactionDate,
            decimal updatedBalance) {
            Amount = amount;
            Description = description;
            TransactionDate = transactionDate;
            UpdateBalance = updatedBalance;
        }
    }
}