namespace MyWallet.Infrastructure.InMemoryDataAccess.Repositories {
    using System.Linq;
    using System.Threading.Tasks;
    using System;
    using MyWallet.Application.Repositories;
    using MyWallet.Domain.Customers;

    public class CustomerRepository : ICustomerReadOnlyRepository, ICustomerWriteOnlyRepository {
        private readonly MyWalletContext _context;

        public CustomerRepository (MyWalletContext context) {
            _context = context;
        }

        public async Task Add (Customer customer) {
            _context.Customers.Add (customer);
            await Task.CompletedTask;
        }

        public async Task<Customer> Get (Guid id) {
            Customer customer = _context.Customers
                .Where (e => e.Id == id)
                .SingleOrDefault ();

            return await Task.FromResult<Customer> (customer);
        }

        public async Task Update (Customer customer) {
            Customer customerOld = _context.Customers
                .Where (e => e.Id == customer.Id)
                .SingleOrDefault ();

            customerOld = customer;
            await Task.CompletedTask;
        }
    }
}