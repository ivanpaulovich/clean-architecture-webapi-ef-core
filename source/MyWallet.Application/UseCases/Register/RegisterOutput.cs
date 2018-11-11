namespace MyWallet.Application.UseCases.Register {
    using System.Collections.Generic;
    using MyWallet.Domain.Accounts;
    using MyWallet.Domain.Customers;

    public sealed class RegisterOutput {
        public CustomerOutput Customer { get; }
        public AccountOutput Account { get; }

        public RegisterOutput (Customer customer, Account account) {
            List<TransactionOutput> transactionOutputs = new List<TransactionOutput> ();

            foreach (ITransaction transaction in account.Transactions.ToReadOnlyCollection ()) {
                transactionOutputs.Add (
                    new TransactionOutput (
                        transaction.Description,
                        transaction.Amount,
                        transaction.TransactionDate));
            }

            Account = new AccountOutput (account.Id, account.GetCurrentBalance (), transactionOutputs);

            List<AccountOutput> accountOutputs = new List<AccountOutput> ();
            accountOutputs.Add (Account);

            Customer = new CustomerOutput (customer, accountOutputs);
        }
    }
}