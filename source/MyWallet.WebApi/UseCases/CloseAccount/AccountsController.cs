namespace MyWallet.WebApi.UseCases.CloseAccount {
    using System.Threading.Tasks;
    using System;
    using MyWallet.Application.UseCases.CloseAccount;
    using Microsoft.AspNetCore.Mvc;

    [Route ("api/[controller]")]
    public class AccountsController : Controller {
        private readonly ICloseAccountUseCase _closeAccountUseCase;
        private readonly Presenter _presenter;

        public AccountsController (
            ICloseAccountUseCase closeAccountUseCase,
            Presenter presenter) {
            _closeAccountUseCase = closeAccountUseCase;
            _presenter = presenter;
        }

        /// <summary>
        /// Close the account
        /// </summary>
        [HttpDelete ("{accountId}")]
        public async Task<IActionResult> Close (Guid accountId) {
            Guid output = await _closeAccountUseCase.Execute (accountId);
            _presenter.Populate (output);
            return _presenter.ViewModel;
        }
    }
}