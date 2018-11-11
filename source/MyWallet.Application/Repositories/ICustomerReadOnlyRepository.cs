namespace MyWallet.Application.Repositories {
    using System.Threading.Tasks;
    using System;
    using MyWallet.Domain.Customers;

    public interface ICustomerReadOnlyRepository {
        Task<Customer> Get (Guid id);
    }
}