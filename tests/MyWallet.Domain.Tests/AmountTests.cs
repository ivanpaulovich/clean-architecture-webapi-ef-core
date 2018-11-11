namespace MyWallet.DomainTests
{
    using MyWallet.Domain.ValueObjects;
    using System;
    using Xunit;

    public class AmountTests
    {
        [Theory]
        [InlineData(0)]
        [InlineData(100)]
        public void Create_Amount(decimal value)
        {
            //
            // Arrange
            decimal positiveAmount = value;

            //
            // Act
            Amount amount = new Amount(positiveAmount);

            //
            // Assert
            Assert.Equal<decimal>(positiveAmount, amount);
        }

        [Fact]
        public void Amount_With_100_Minus_70_Should_Be_30()
        {
            //
            // Arrange
            Amount hundred = new Amount(100);
            Amount seventy = new Amount(70);

            //
            // Act
            Amount amount = hundred - seventy;

            //
            // Assert
            Assert.Equal(30, amount);
        }

        [Fact]
        public void Amount_With_100_Larger_Than_70()
        {
            //
            // Arrange
            Amount hundred = new Amount(100);
            Amount seventy = new Amount(70);

            //
            // Act & Assert
            Assert.True(hundred > seventy);
        }

        [Fact]
        public void Amount_With_30_Less_Than_Equal_30()
        {
            //
            // Arrange
            Amount thirty = new Amount(30);
            Amount seventy = new Amount(70);

            //
            // Act & Assert
            Assert.True(thirty <= seventy);
        }

        [Fact]
        public void Amount_With_10_Larger_Than_Equal_10()
        {
            //
            // Arrange
            Amount thirty = new Amount(10);
            Amount seventy = new Amount(10);

            //
            // Act & Assert
            Assert.True(thirty >= seventy);
        }

        [Fact]
        public void Amount_With_Negative_Throws_Exception()
        {
            //
            // Arrange Act
            Exception ex = Record.Exception(() => new Amount(-10));

            Assert.NotNull(ex);
        }
    }
}
