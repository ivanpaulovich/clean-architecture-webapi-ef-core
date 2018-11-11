namespace MyWallet.Infrastructure.EntityFrameworkDataAccess.Entities {
    using System;

    public class Credit {
        public Guid Id { get; set; }
        public Guid AccountId { get; set; }
        public decimal Amount { get; set; }
        public DateTime TransactionDate { get; set; }
    }
}