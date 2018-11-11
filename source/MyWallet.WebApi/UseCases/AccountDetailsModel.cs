namespace MyWallet.WebApi.UseCases {
    using System.Collections.Generic;
    using System;

    public sealed class AccountDetailsModel {
        public Guid AccountId { get; }
        public decimal CurrentBalance { get; }
        public List<TransactionModel> Transactions { get; }

        public AccountDetailsModel (Guid accountId, decimal currentBalance, List<TransactionModel> transactions) {
            AccountId = accountId;
            CurrentBalance = currentBalance;
            Transactions = transactions;
        }
    }
}