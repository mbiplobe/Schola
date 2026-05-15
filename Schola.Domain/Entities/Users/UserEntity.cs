using SchoolManagement.Domain.ValueObjects;
using Schola.Shared.Abstractions.Domains;// Ensure this is the correct namespace for UserRegisteredEvent

public class UserEntity : AggregateRoot<EntityID>
{
    public EntityID Id { get; private set; }
    public FullName Name { get; private set; }
    public Email Email { get; private set; }
    public Mobile Mobile { get; private set; }

    public Password Password { get; private set; }

    // public UserType TypeUser { get; private set; }

    public UserEntity(
        EntityID id,
        FullName name,
        Email email,
        Mobile mobile,
        Password password)
    {
        Id = id
            ?? throw new UserInvalidException("Id is required.");

        Name = name
            ?? throw new UserInvalidException("Name is required.");

        Email = email
            ?? throw new UserInvalidException("Email is required.");

        Mobile = mobile
            ?? throw new UserInvalidException("Mobile is required.");

        Password = password
            ?? throw new UserInvalidException("Password is required.");


        AddEvent(new UserRegisteredEvent(Id, Name, Email, Mobile, Password));
    }

    public void ChangeEmail(Email newEmail)
    {
        if (Email == newEmail) return;

        var oldEmail = Email;
        Email = newEmail;

        AddEvent(new UserEmailChangedEvent(Id, oldEmail, newEmail));
    }

    public void ChangeMobile(Mobile newMobile)
    {
        if (Mobile == newMobile) return;

        var oldMobile = Mobile;
        Mobile = newMobile;

        AddEvent(new UserMobileChangedEvent(Id, oldMobile, newMobile));
    }

    public void ChangeProfile(FullName newName)
    {
        if (Name == newName) return;

        var oldName = Name;
        Name = newName;

        AddEvent(new UserProfileUpdatedEvent(Id, newName));
    }

    public void DeactivateAccount()
    {
        AddEvent(new UserAccountDeactivatedEvent(Id));
    }

    public void ChangePassword(Password newPassword)
    {
        if (Password == newPassword) return;

        var oldPassword = Password;
        Password = newPassword;

        AddEvent(new UserPasswordChangedEvent(Id, newPassword, oldPassword));
    }

    // public void DetectLogin()
    // {
    //     AddEvent(new UserLoginDetectedEvent(Id, Password, Password));
    // }

}

// public sealed record UserRegisteredEvent(EntityID Id, FullName Name, Email Email, Mobile Mobile, Password Password) : IDomainEvent;