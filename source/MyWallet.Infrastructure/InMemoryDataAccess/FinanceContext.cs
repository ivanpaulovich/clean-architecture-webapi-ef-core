namespace MyWallet.Infrastructure.InMemoryDataAccess {
    using System.Collections.ObjectModel;
    using MyWallet.Domain.Accounts;
    using MyWallet.Domain.Customers;

    public sealed class MyWalletContext {
        public Collection<Customer> Customers { get; set; }
        public Collection<Account> Accounts { get; set; }

        public MyWalletContext () {
            Customers = new Collection<Customer> ();
            Accounts = new Collection<Account> ();
        }
    }
}