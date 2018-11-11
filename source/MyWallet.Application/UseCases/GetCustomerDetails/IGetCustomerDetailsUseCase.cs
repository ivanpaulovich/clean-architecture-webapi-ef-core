namespace MyWallet.Application.UseCases.GetCustomerDetails {
    using System.Threading.Tasks;
    using System;

    public interface IGetCustomerDetailsUseCase {
        Task<CustomerOutput> Execute (Guid customerId);
    }
}