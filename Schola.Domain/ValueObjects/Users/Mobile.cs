using System.Text.RegularExpressions;

public sealed record Mobile
{
    public string Value { get; }
    
    private static readonly Regex MobileRegex =
        new(@"^01[3-9]\d{8}$",
            RegexOptions.Compiled);

    public Mobile(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new UserInvalidException("Mobile number is required.");
        }

        value = value.Trim();

        if (!MobileRegex.IsMatch(value))
        {
            throw new UserInvalidException(
                "Mobile number must be a valid 11-digit Bangladesh number.");
        }

        Value = value;
    }

    public static implicit operator string(Mobile mobile)
        => mobile?.Value ?? string.Empty;

    public static implicit operator Mobile(string mobile)
        => new(mobile);

    public override string ToString()
        => Value;
}