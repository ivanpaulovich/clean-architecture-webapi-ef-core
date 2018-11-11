namespace MyWallet.UseCaseTests
{
    using Xunit;
    using System;
    using MyWallet.Domain.Accounts;
    using MyWallet.Application.Repositories;
    using MyWallet.Application.UseCases.Register;
    using Moq;
    using MyWallet.Application.UseCases.Deposit;
    using MyWallet.Application.UseCases.Withdraw;
    using System.Threading.Tasks;

    public class AccountTests
    {
        [Theory]
        [InlineData("c725315a-1de6-4bf7-aecf-3af8f0083681", 100)]
        public async void Deposit_Valid_Amount(string accountId, decimal amount)
        {
            var mockAccountReadOnlyRepository = new Mock<IAccountReadOnlyRepository>();
            var mockAccountWriteOnlyRepository = new Mock<IAccountWriteOnlyRepository>();

            Account account = new Account(Guid.Parse(accountId));

            mockAccountReadOnlyRepository.SetupSequence(e => e.Get(It.IsAny<Guid>()))
                .ReturnsAsync(account);
            
            DepositUseCase sut = new DepositUseCase(
                mockAccountReadOnlyRepository.Object,
                mockAccountWriteOnlyRepository.Object
            );

            DepositOutput output = await sut.Execute(
                Guid.Parse(accountId),
                amount);

            Assert.Equal(100, output.UpdatedBalance);
        }

        [Theory]
        [InlineData("c725315a-1de6-4bf7-aecf-3af8f0083681", 100)]
        public async void Withdraw_Valid_Amount(string accountId, decimal amount)
        {
            var mockAccountReadOnlyRepository = new Mock<IAccountReadOnlyRepository>();
            var mockAccountWriteOnlyRepository = new Mock<IAccountWriteOnlyRepository>();
            TransactionCollection transactions = new TransactionCollection();
            transactions.Add(new Credit(Guid.Empty, 4000));

            Account account = Account.LoadFromDetails(Guid.Parse(accountId), Guid.Empty, transactions);

            mockAccountReadOnlyRepository.SetupSequence(e => e.Get(It.IsAny<Guid>()))
                .ReturnsAsync(account);

            WithdrawUseCase sut = new WithdrawUseCase(
                mockAccountReadOnlyRepository.Object,
                mockAccountWriteOnlyRepository.Object
            );

            WithdrawOutput output = await sut.Execute(
                Guid.Parse(accountId),
                amount);

            Assert.Equal(3900, output.UpdatedBalance);
        }

        [Theory]
        [InlineData(100)]
        public void Account_With_Credits_Should_Not_Allow_Close(decimal amount)
        {
            Account account = new Account(Guid.NewGuid());
            account.Deposit(amount);

            Assert.Throws<AccountCannotBeClosedException>(
                () => account.Close());
        }
    }
}
