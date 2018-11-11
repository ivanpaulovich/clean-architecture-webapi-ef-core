namespace MyWallet.WebApi.UseCases.GetCustomerDetails {
    using System.Threading.Tasks;
    using System;
    using MyWallet.Application.UseCases.GetCustomerDetails;
    using MyWallet.Application.UseCases;
    using Microsoft.AspNetCore.Mvc;

    [Route ("api/[controller]")]
    public class CustomersController : Controller {
        private readonly IGetCustomerDetailsUseCase _getCustomerDetailsUseCase;
        private readonly Presenter _presenter;

        public CustomersController (
            IGetCustomerDetailsUseCase getCustomerDetailsUseCase,
            Presenter presenter) {
            _getCustomerDetailsUseCase = getCustomerDetailsUseCase;
            _presenter = presenter;
        }

        /// <summary>
        /// Get a Customer details 
        /// </summary>
        [HttpGet ("{customerId}", Name = "GetCustomer")]
        public async Task<IActionResult> GetCustomer (Guid customerId) {
            CustomerOutput output = await _getCustomerDetailsUseCase.Execute (customerId);
            _presenter.Populate (output);
            return _presenter.ViewModel;
        }
    }
}