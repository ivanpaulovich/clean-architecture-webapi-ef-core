namespace MyWallet.WebApi.UseCases {
    using System;

    public sealed class TransactionModel {
        public decimal Amount { get; }
        public string Description { get; }
        public DateTime TransactionDate { get; }
        public TransactionModel (decimal amount, string description, DateTime transactionDate) {
            Amount = amount;
            Description = description;
            TransactionDate = transactionDate;
        }
    }
}