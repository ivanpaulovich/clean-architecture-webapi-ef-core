namespace MyWallet.DomainTests
{
    using Xunit;
    using MyWallet.Domain.ValueObjects;
    using MyWallet.Domain.Accounts;
    using System;
    using Moq;

    public class AccountTests
    {
        [Theory]
        [InlineData(100)]
        [InlineData(0)]
        [InlineData(400)]
        public void Deposit_Should_Change_Balance_The_Same_Amount(decimal amountToDeposit)
        {
            //
            // Arrange
            Guid customerId = Guid.NewGuid();
            Account sut = new Account(customerId);
            Amount amount = new Amount(amountToDeposit);

            //
            // Act
            sut.Deposit(amount);

            //
            // Assert
            Amount balance = sut.GetCurrentBalance();

            Assert.Equal(customerId, sut.CustomerId);
            Assert.Equal(amountToDeposit, (decimal)balance);
        }

        [Fact]
        public void Deposit_Should_Change_Balance_When_Account_Is_New()
        {
            //
            // Arrange
            Guid expectedCustomerId = Guid.Parse("ac608347-74ac-4607-abc2-7b95cdc8a122");
            Amount expectedAmount = new Amount(400m);

            //
            // Act
            Account sut = new Account(expectedCustomerId);
            sut.Deposit(expectedAmount);
            Amount balance = sut.GetCurrentBalance();

            //
            // Assert
            Assert.Equal(expectedCustomerId, sut.CustomerId);
            Assert.Equal(expectedAmount, balance);
            Assert.Single(sut.Transactions.ToReadOnlyCollection());
        }

        [Fact]
        public void Deposit_Should_Change_Balance_Equivalent_Amount()
        {
            //
            // Arrange
            Guid expectedCustomerId = Guid.Parse("ac608347-74ac-4607-abc2-7b95cdc8a122");
            Amount expectedAmount = new Amount(400m);

            //
            // Act
            Account sut = new Account(expectedCustomerId);
            sut.Deposit(expectedAmount);
            Amount balance = sut.GetCurrentBalance();

            //
            // Assert
            Assert.Equal(expectedAmount, balance);
        }

        [Fact]
        public void Deposit_Should_Add_Single_Transaction()
        {
            //
            // Arrange
            Guid expectedCustomerId = Guid.Parse("ac608347-74ac-4607-abc2-7b95cdc8a122");
            Amount expectedAmount = new Amount(400m);

            //
            // Act
            Account sut = new Account(expectedCustomerId);
            sut.Deposit(expectedAmount);

            //
            // Assert
            Assert.Single(sut.Transactions.ToReadOnlyCollection());
        }

        [Fact]
        public void NewAccount_Should_Return_The_Correct_CustomerId()
        {
            //
            // Arrange
            Guid expectedCustomerId = Guid.Parse("ac608347-74ac-4607-abc2-7b95cdc8a122");
            Amount expectedAmount = new Amount(400m);

            //
            // Act
            Account sut = new Account(expectedCustomerId);

            //
            // Assert
            Assert.Equal(expectedCustomerId, sut.CustomerId);
        }

        [Fact]
        public void New_Account_With_1000_Balance_Should_Have_900_Credit_After_Withdraw()
        {
            //
            // Arrange
            Account sut = new Account(Guid.NewGuid());
            sut.Deposit(1000.0m);

            //
            // Act
            sut.Withdraw(100);

            //
            // Assert
            Assert.Equal(900, sut.GetCurrentBalance());
        }

        [Fact]
        public void New_Account_Should_Allow_Closing()
        {
            //
            // Arrange
            Account sut = new Account(Guid.NewGuid());

            //
            // Act
            sut.Close();

            //
            // Assert
            Assert.True(true);
        }

        [Fact]
        public void Account_With_Funds_Should_Not_Allow_Closing()
        {
            //
            // Arrange
            Account sut = new Account(Guid.NewGuid());
            sut.Deposit(100);

            //
            // Act and Assert
            Assert.Throws<AccountCannotBeClosedException>(
                () => sut.Close());
        }


        [Fact]
        public void Account_With_200_Balance_Should_Not_Allow_50000_Withdraw()
        {
            //
            // Arrange
            Account sut = new Account(Guid.NewGuid());
            sut.Deposit(200);

            //
            // Act and Assert
            Assert.Throws<InsuficientFundsException>(
                () => sut.Withdraw(5000));
        }

        [Fact]
        public void Account_With_Three_Transactions_Should_Be_Consistent()
        {
            //
            // Arrange
            Account sut = new Account(Guid.NewGuid());
            sut.Deposit(200);
            sut.Withdraw(100);
            sut.Deposit(50);

            //
            // Act and Assert

            var transactions = sut.Transactions;

            Assert.Equal(3, transactions.ToReadOnlyCollection().Count); 
        }

        [Fact]
        public void Account_Should_Be_Loaded()
        {
            //
            // Arrange
            TransactionCollection transactions = new TransactionCollection();
            transactions.Add(new Debit(Guid.Empty, 100));

            //
            // Act
            Account account = Account.LoadFromDetails(
                Guid.Empty,
                Guid.Empty,
                transactions);

            //
            // Assert
            Assert.Single(account.Transactions.ToReadOnlyCollection());
            Assert.Equal(Guid.Empty, account.Id);
            Assert.Equal(Guid.Empty, account.CustomerId);
        }

        [Fact]
        public void Deposit_Should_Throw_Exception_When_NegativeAmount()
        {
            //
            // Arrange and Act
            Account sut = new Account(Guid.NewGuid());
            Exception ex = Record.Exception(() => sut.Deposit(-200));

            //
            // Assert
            Assert.NotNull(ex);
        }

        [Fact]
        public void Withdraw_Should_Throw_Exception_When_NegativeAmount()
        {
            //
            // Arrange and Act
            Account sut = new Account(Guid.NewGuid());
            Exception ex = Record.Exception(() => sut.Withdraw(-200));

            //
            // Assert
            Assert.NotNull(ex);
        }
    }
}
