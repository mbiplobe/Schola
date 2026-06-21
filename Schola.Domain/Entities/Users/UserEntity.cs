using Schola.Shared.Abstractions.Domains;

public class UserEntity : AggregateRoot<EntityID>
{
    public FullName Name { get; private set; } = default!;
    public Email Email { get; private set; } = default!;
    public Phone Mobile { get; private set; } = default!;
    public Password Password { get; private set; } = default!;

    // EF Core constructor
    private UserEntity()
    {
    }

    public UserEntity(
        EntityID entityId,
        FullName name,
        Email email,
        Phone mobile,
        Password password)
    {
        Id = entityId
            ?? throw new UserInvalidException("User Identity is required.");

        Name = name
            ?? throw new UserInvalidException("Name is required.");

        Email = email
            ?? throw new UserInvalidException("Email is required.");

        Mobile = mobile
            ?? throw new UserInvalidException("Mobile is required.");

        Password = password
            ?? throw new UserInvalidException("Password is required.");

        AddEvent(new UserRegisteredEvent(Name, Email, Mobile, Password));
    }

    public void ChangeEmail(Email newEmail)
    {
        if (Email == newEmail) return;

        var oldEmail = Email;
        Email = newEmail;

        AddEvent(new UserEmailChangedEvent(oldEmail, newEmail));
    }

    public void ChangeMobile(Phone newMobile)
    {
        if (Mobile == newMobile) return;

        var oldMobile = Mobile;
        Mobile = newMobile;

        AddEvent(new UserMobileChangedEvent(oldMobile, newMobile));
    }

    public void ChangeProfile(FullName newName)
    {
        if (Name == newName) return;

        Name = newName;

        AddEvent(new UserProfileUpdatedEvent(newName));
    }

    public void ChangePassword(Password newPassword)
    {
        if (Password == newPassword) return;

        var oldPassword = Password;
        Password = newPassword;

        AddEvent(new UserPasswordChangedEvent(newPassword, oldPassword));
    }

    public void DeactivateAccount()
    {
        AddEvent(new UserAccountDeactivatedEvent(Id ?? throw new InvalidOperationException("User ID is not set")));
    }

    public bool ValidatePassword(string password)
        => Password.Verify(password);
}

