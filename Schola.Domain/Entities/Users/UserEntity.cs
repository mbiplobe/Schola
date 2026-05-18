using SchoolManagement.Domain.ValueObjects;
using Schola.Shared.Abstractions.Domains;// Ensure this is the correct namespace for UserRegisteredEvent

public class UserEntity : AggregateRoot<EntityID>
{
    public FullName Name { get; private set; }
    public Email Email { get; private set; }
    public Mobile Mobile { get; private set; }

    public Password Password { get; private set; }

    // public UserType TypeUser { get; private set; }

    public UserEntity(
        FullName name,
        Email email,
        Mobile mobile,
        Password password)
    {
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

    public void ChangeMobile(Mobile newMobile)
    {
        if (Mobile == newMobile) return;

        var oldMobile = Mobile;
        Mobile = newMobile;

        AddEvent(new UserMobileChangedEvent(oldMobile, newMobile));
    }

    public void ChangeProfile(FullName newName)
    {
        if (Name == newName) return;

        var oldName = Name;
        Name = newName;

        AddEvent(new UserProfileUpdatedEvent( newName));
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

        AddEvent(new UserPasswordChangedEvent(newPassword, oldPassword));
    }
    
    public bool ValidatePassword(string password)
    {
        return Password.Verify(password);
    }



    


    // public void DetectLogin()
    // {
    //     AddEvent(new UserLoginDetectedEvent(Id, Password, Password));
    // }

}

// public sealed record UserRegisteredEvent(EntityID Id, FullName Name, Email Email, Mobile Mobile, Password Password) : IDomainEvent;