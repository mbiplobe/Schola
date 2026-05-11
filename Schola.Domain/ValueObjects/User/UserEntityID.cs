public record UserEntityID
{
    public Guid Value { get; }

    public UserEntityID(Guid value)
    {
        if (value == Guid.Empty)
        {
            throw new UserInvalidException();
        }

        Value = value;
    }

    public static implicit operator Guid(UserEntityID id)
        => id.Value;

    public static implicit operator UserEntityID(Guid id)
        => new(id);
}