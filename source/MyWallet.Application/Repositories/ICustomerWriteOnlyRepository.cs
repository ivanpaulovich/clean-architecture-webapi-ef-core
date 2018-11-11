namespace MyWallet.Application.Repositories {
    using System.Threading.Tasks;
    using MyWallet.Domain.Customers;

    public interface ICustomerWriteOnlyRepository {
        Task Add (Customer customer);
        Task Update (Customer customer);
    }
}