namespace MyWallet.DomainTests
{
    using Xunit;
    using MyWallet.Domain.Accounts;
    using System;

    public class CreditTests
    {
        [Fact]
        public void Credit_Should_Be_Loaded()
        {
            Credit credit = Credit.LoadFromDetails(
                Guid.Empty,
                Guid.Empty,
                100,
                DateTime.Today);

            Assert.Equal(Guid.Empty, credit.Id);
            Assert.Equal(Guid.Empty, credit.AccountId);
            Assert.Equal(100, credit.Amount);
            Assert.Equal(DateTime.Today, credit.TransactionDate);
            Assert.Equal("Credit", credit.Description);
        }
    }
}
