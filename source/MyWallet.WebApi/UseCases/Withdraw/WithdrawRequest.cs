namespace MyWallet.WebApi.UseCases.Withdraw {
    using System;
    public class WithdrawRequest {
        public Guid AccountId { get; set; }
        public decimal Amount { get; set; }
    }
}