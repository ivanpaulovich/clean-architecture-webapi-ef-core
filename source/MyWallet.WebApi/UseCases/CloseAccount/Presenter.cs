namespace MyWallet.WebApi.UseCases.CloseAccount {
    using System;
    using Microsoft.AspNetCore.Mvc;

    public sealed class Presenter {
        public IActionResult ViewModel { get; private set; }

        public void Populate (Guid output) {
            if (output == null) {
                ViewModel = new NoContentResult ();
                return;
            }

            ViewModel = new OkResult ();
        }
    }
}