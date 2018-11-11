namespace MyWallet.WebApi.UseCases.Register {
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using MyWallet.Application.UseCases.Register;
    using MyWallet.Application.UseCases;
    using Microsoft.AspNetCore.Mvc;

    [Route ("api/[controller]")]
    public class CustomersController : Controller {
        private readonly IRegisterUseCase _registerUseCase;
        private readonly Presenter _presenter;

        public CustomersController (
            IRegisterUseCase registerUseCase,
            Presenter presenter) {
            _registerUseCase = registerUseCase;
            _presenter = presenter;
        }

        /// <summary>
        /// Register a new Customer
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Post ([FromBody] RegisterRequest request) {
            RegisterOutput output = await _registerUseCase.Execute (
                request.Personnummer,
                request.Name,
                request.InitialAmount);

            _presenter.Populate (output);
            return _presenter.ViewModel;
        }
    }
}