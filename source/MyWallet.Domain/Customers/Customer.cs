namespace MyWallet.Domain.Customers {
    using System;
    using MyWallet.Domain.ValueObjects;

    public sealed class Customer : IEntity, IAggregateRoot {
        public Guid Id { get; private set; }
        public Name Name { get; private set; }
        public Personnummer SSN { get; private set; }
        public AccountCollection Accounts { get; private set; }

        public Customer (Personnummer ssn, Name name) {
            Id = Guid.NewGuid ();
            SSN = ssn;
            Name = name;
            Accounts = new AccountCollection ();
        }

        public void Register (Guid accountId) {
            Accounts.Add (accountId);
        }

        private Customer () { }

        public static Customer LoadFromDetails (Guid id, Name name, Personnummer ssn, AccountCollection accounts) {
            Customer customer = new Customer ();
            customer.Id = id;
            customer.Name = name;
            customer.SSN = ssn;
            customer.Accounts = accounts;
            return customer;
        }
    }
}