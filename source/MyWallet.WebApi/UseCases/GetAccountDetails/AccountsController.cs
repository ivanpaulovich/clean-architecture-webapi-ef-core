namespace MyWallet.WebApi.UseCases.GetAccountDetails {
    using System.Threading.Tasks;
    using System;
    using MyWallet.Application.UseCases.GetAccountDetails;
    using MyWallet.Application.UseCases;
    using Microsoft.AspNetCore.Mvc;

    [Route ("api/[controller]")]
    public class AccountsController : Controller {
        private readonly IGetAccountDetailsUseCase _getAccountDetailsUseCase;
        private readonly Presenter _presenter;

        public AccountsController (
            IGetAccountDetailsUseCase getAccountDetailsUseCase,
            Presenter presenter) {
            _getAccountDetailsUseCase = getAccountDetailsUseCase;
            _presenter = presenter;
        }

        /// <summary>
        /// Get an account balance
        /// </summary>
        [HttpGet ("{accountId}", Name = "GetAccount")]
        public async Task<IActionResult> Get (Guid accountId) {
            AccountOutput output = await _getAccountDetailsUseCase.Execute (accountId);
            _presenter.Populate (output);
            return _presenter.ViewModel;
        }
    }
}