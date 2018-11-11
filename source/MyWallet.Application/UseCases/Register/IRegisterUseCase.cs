namespace MyWallet.Application.UseCases.Register {
    using System.Threading.Tasks;
    using MyWallet.Domain.ValueObjects;

    public interface IRegisterUseCase {
        Task<RegisterOutput> Execute (Personnummer personnummer, Name name, Amount initialAmount);
    }
}