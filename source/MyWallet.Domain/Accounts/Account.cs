namespace MyWallet.Domain.Accounts {
    using System;
    using MyWallet.Domain.ValueObjects;

    public sealed class Account : IEntity, IAggregateRoot {
        public Guid Id { get; private set; }
        public Guid CustomerId { get; private set; }
        public TransactionCollection Transactions { get; private set; }

        public Account (Guid customerId) {
            Id = Guid.NewGuid ();
            CustomerId = customerId;
            Transactions = new TransactionCollection ();
        }

        public void Deposit (Amount amount) {
            Credit credit = new Credit (Id, amount);
            Transactions.Add (credit);
        }

        public void Withdraw (Amount amount) {
            Amount balance = Transactions.GetBalance ();

            if (balance < amount)
                throw new InsuficientFundsException (
                    $"The account {Id} does not have enough funds to withdraw {amount}. Current Balance {balance}.");

            Debit debit = new Debit (Id, amount);
            Transactions.Add (debit);
        }

        public void Close () {
            Amount balance = Transactions.GetBalance ();

            if (balance > 0)
                throw new AccountCannotBeClosedException (
                    $"The account {Id} can not be closed because it has funds. Current Balance {balance}.");
        }

        public Amount GetCurrentBalance () {
            Amount balance = Transactions.GetBalance ();
            return balance;
        }

        public ITransaction GetLastTransaction () {
            ITransaction lastTransaction = Transactions.CopyOfLastTransaction ();
            return lastTransaction;
        }

        private Account () { }

        public static Account LoadFromDetails (Guid id, Guid customerId, TransactionCollection transactions) {
            Account account = new Account ();
            account.Id = id;
            account.CustomerId = customerId;
            account.Transactions = transactions;
            return account;
        }
    }
}