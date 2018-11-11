namespace MyWallet.Infrastructure.EntityFrameworkDataAccess {
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using System;
    using MyWallet.Application.Repositories;
    using MyWallet.Domain.Customers;
    using Microsoft.EntityFrameworkCore;

    public class CustomerRepository : ICustomerReadOnlyRepository, ICustomerWriteOnlyRepository {
        private readonly MyWalletContext _context;

        public CustomerRepository (MyWalletContext context) {
            _context = context ??
                throw new ArgumentNullException (nameof (context));
        }

        public async Task Add (Customer customer) {
            Entities.Customer customerEntity = new Entities.Customer () {
                Id = customer.Id,
                Name = customer.Name,
                SSN = customer.SSN
            };

            await _context.Customers.AddAsync (customerEntity);
            await _context.SaveChangesAsync ();
        }

        public async Task<Customer> Get (Guid id) {
            Entities.Customer customer = await _context.Customers
                .FindAsync (id);

            List<Guid> accounts = await _context.Accounts
                .Where (e => e.CustomerId == id)
                .Select (p => p.Id)
                .ToListAsync ();

            AccountCollection accountCollection = new AccountCollection ();
            foreach (var accountId in accounts)
                accountCollection.Add (accountId);

            return Customer.LoadFromDetails (customer.Id, customer.Name, customer.SSN, accountCollection);
        }

        public async Task Update (Customer customer) {
            Entities.Customer customerEntity = new Entities.Customer () {
                Id = customer.Id,
                Name = customer.Name,
                SSN = customer.SSN
            };

            _context.Customers.Update (customerEntity);
            await _context.SaveChangesAsync ();
        }
    }
}