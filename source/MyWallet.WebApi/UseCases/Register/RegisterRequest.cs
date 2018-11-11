namespace MyWallet.WebApi.UseCases.Register {
    public class RegisterRequest {
        public string Personnummer { get; set; }
        public string Name { get; set; }
        public decimal InitialAmount { get; set; }
    }
}