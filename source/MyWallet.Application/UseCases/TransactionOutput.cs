namespace MyWallet.Application.UseCases {
    using System;
    public sealed class TransactionOutput {
        public string Description { get; }
        public decimal Amount { get; }
        public DateTime TransactionDate { get; }

        public TransactionOutput (
            string description,
            decimal amount,
            DateTime transactionDate) {
            Description = description;
            Amount = amount;
            TransactionDate = transactionDate;
        }
    }
}