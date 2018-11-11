namespace MyWallet.Domain.Accounts {
    using System;
    using MyWallet.Domain.ValueObjects;

    public interface ITransaction {
        Amount Amount { get; }
        string Description { get; }
        DateTime TransactionDate { get; }
    }
}