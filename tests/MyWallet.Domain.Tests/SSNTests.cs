namespace MyWallet.DomainTests
{
    using MyWallet.Domain.ValueObjects;
    using Xunit;

    public class SSNTests
    {
        [Fact]
        public void Empty_SSN_Should_Not_Be_Created()
        {
            //
            // Arrange
            string empty = string.Empty;

            //
            // Act and Assert
            Assert.Throws<PersonnummerShouldNotBeEmptyException>(
                () => new Personnummer(empty));
        }

        [Fact]
        public void Valid_SSN_Should_Be_Created()
        {
            //
            // Arrange
            string valid = "08724050601";

            //
            // Act
            Personnummer SSN = new Personnummer(valid);

            // Assert
            Assert.Equal(valid, SSN);
        }
    }
}
