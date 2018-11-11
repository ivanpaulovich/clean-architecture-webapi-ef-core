namespace MyWallet.Domain.ValueObjects {
    using System.Text.RegularExpressions;

    public sealed class Personnummer {
        private string _text;
        const string RegExForValidation = @"^\d{6,8}[-|(\s)]{0,1}\d{4}$";

        public Personnummer (string text) {
            if (string.IsNullOrWhiteSpace (text))
                throw new PersonnummerShouldNotBeEmptyException ("The 'Personnummer' field is required");

            Regex regex = new Regex (RegExForValidation);
            Match match = regex.Match (text);

            if (!match.Success)
                throw new InvalidPersonnummerException ($"{text} its an invalid Personnummer value. Use the format YYMMDDNNNN.");

            _text = text;
        }

        public static implicit operator Personnummer (string text) {
            return new Personnummer (text);
        }

        public static implicit operator string (Personnummer ssn) {
            return ssn._text;
        }
    }
}