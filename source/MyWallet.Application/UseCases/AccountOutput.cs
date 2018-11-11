namespace MyWallet.Application.UseCases {
    using System.Collections.Generic;
    using System;
    using MyWallet.Domain.Accounts;

    public sealed class AccountOutput {
        public Guid AccountId { get; }
        public decimal CurrentBalance { get; }
        public List<TransactionOutput> Transactions { get; }

        public AccountOutput (
            Guid accountId,
            decimal currentBalance,
            List<TransactionOutput> transactions) {
            AccountId = accountId;
            CurrentBalance = currentBalance;
            Transactions = transactions;
        }

        public AccountOutput (Account account) {
            AccountId = account.Id;
            CurrentBalance = account.GetCurrentBalance ();

            List<TransactionOutput> transactionResults = new List<TransactionOutput> ();
            foreach (ITransaction transaction in account.Transactions.ToReadOnlyCollection ()) {
                TransactionOutput transactionOutput = new TransactionOutput (
                    transaction.Description, transaction.Amount, transaction.TransactionDate);
                transactionResults.Add (transactionOutput);
            }

            Transactions = transactionResults;
        }
    }
}