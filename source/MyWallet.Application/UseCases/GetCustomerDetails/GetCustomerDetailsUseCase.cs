namespace MyWallet.Application.UseCases.GetCustomerDetails {
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using System;
    using MyWallet.Application.Repositories;
    using MyWallet.Domain.Accounts;
    using MyWallet.Domain.Customers;

    public sealed class GetCustomerDetailsUseCase : IGetCustomerDetailsUseCase {
        private readonly ICustomerReadOnlyRepository _customerReadOnlyRepository;
        private readonly IAccountReadOnlyRepository _accountReadOnlyRepository;

        public GetCustomerDetailsUseCase (
            ICustomerReadOnlyRepository customerReadOnlyRepository,
            IAccountReadOnlyRepository accountReadOnlyRepository) {
            _customerReadOnlyRepository = customerReadOnlyRepository;
            _accountReadOnlyRepository = accountReadOnlyRepository;
        }

        public async Task<CustomerOutput> Execute (Guid customerId) {
            Customer customer = await _customerReadOnlyRepository.Get (customerId);

            if (customer == null)
                throw new CustomerNotFoundException ($"The customer {customerId} does not exists or is not processed yet.");

            List<AccountOutput> accounts = new List<AccountOutput> ();

            foreach (Guid accountId in customer.Accounts.ToReadOnlyCollection ()) {
                Account account = await _accountReadOnlyRepository.Get (accountId);

                if (account != null) {
                    AccountOutput accountOutput = new AccountOutput (account);
                    accounts.Add (accountOutput);
                }
            }

            CustomerOutput output = new CustomerOutput (customer, accounts);
            return output;
        }
    }
}