namespace MyWallet.UseCaseTests
{
    using Xunit;
    using MyWallet.Application.UseCases.Register;
    using MyWallet.Application.Repositories;
    using Moq;

    public class CustomerTests
    {
        [Theory]
        [InlineData(300)]
        [InlineData(100)]
        [InlineData(500)]
        [InlineData(3300)]
        public async void Register_Valid_User_Account(decimal amount)
        {
            string personnummer = "8608178888";
            string name = "Ivan Paulovich";

            var mockCustomerWriteOnlyRepository = new Mock<ICustomerWriteOnlyRepository>();
            var mockAccountWriteOnlyRepository = new Mock<IAccountWriteOnlyRepository>();

            RegisterUseCase sut = new RegisterUseCase(
                mockCustomerWriteOnlyRepository.Object,
                mockAccountWriteOnlyRepository.Object
            );

            RegisterOutput output = await sut.Execute(
                personnummer,
                name,
                amount);

            Assert.Equal(amount, output.Account.CurrentBalance);
        }
    }
}
