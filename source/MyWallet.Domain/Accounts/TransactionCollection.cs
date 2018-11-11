namespace MyWallet.Domain.Accounts {
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using MyWallet.Domain.ValueObjects;

    public sealed class TransactionCollection {
        private readonly IList<ITransaction> _transactions;

        public TransactionCollection () {
            _transactions = new List<ITransaction> ();
        }

        public IReadOnlyCollection<ITransaction> ToReadOnlyCollection () {
            IReadOnlyCollection<ITransaction> transactions = new ReadOnlyCollection<ITransaction> (_transactions);
            return transactions;
        }

        public ITransaction CopyOfLastTransaction () {
            ITransaction lastTransaction = _transactions[_transactions.Count - 1];
            ITransaction copyOfLastTransaction = null;

            if (lastTransaction is Credit) {
                copyOfLastTransaction = Credit.LoadFromDetails (
                    ((Credit) lastTransaction).Id,
                    ((Credit) lastTransaction).AccountId,
                    ((Credit) lastTransaction).Amount,
                    ((Credit) lastTransaction).TransactionDate
                );
            }

            if (lastTransaction is Debit) {
                copyOfLastTransaction = Debit.LoadFromDetails (
                    ((Debit) lastTransaction).Id,
                    ((Debit) lastTransaction).AccountId,
                    ((Debit) lastTransaction).Amount,
                    ((Debit) lastTransaction).TransactionDate
                );
            }

            return copyOfLastTransaction;
        }

        public void Add (ITransaction transaction) {
            _transactions.Add (transaction);
        }

        public void Add (IEnumerable<ITransaction> transactions) {
            foreach (var transaction in transactions) {
                Add (transaction);
            }
        }

        public Amount GetBalance () {
            Amount balance = 0;

            foreach (ITransaction item in _transactions) {
                if (item is Debit)
                    balance = balance - item.Amount;

                if (item is Credit)
                    balance = balance + item.Amount;
            }

            return balance;
        }
    }
}