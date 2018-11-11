namespace MyWallet.Domain.ValueObjects {
    internal sealed class InvalidPersonnummerException : DomainException {
        internal InvalidPersonnummerException (string message) : base (message) { }
    }
}