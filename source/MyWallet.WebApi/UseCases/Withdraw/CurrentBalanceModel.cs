namespace MyWallet.WebApi.UseCases.Withdraw {
    using System;

    public class CurrentBalanceModel {
        public decimal Amount { get; }
        public string Description { get; }
        public DateTime TransactionDate { get; }
        public decimal UpdateBalance { get; }

        public CurrentBalanceModel (decimal amount, string description, DateTime transactionDate, decimal updatedBalance) {
            Amount = amount;
            Description = description;
            TransactionDate = transactionDate;
            UpdateBalance = updatedBalance;
        }
    }
}