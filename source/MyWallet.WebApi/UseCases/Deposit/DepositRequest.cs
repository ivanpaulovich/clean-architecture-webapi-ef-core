namespace MyWallet.WebApi.UseCases.Deposit {
    using System;
    public class DepositRequest {
        public Guid AccountId { get; set; }
        public decimal Amount { get; set; }
    }
}