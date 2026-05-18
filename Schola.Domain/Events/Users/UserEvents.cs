using Schola.Shared.Abstractions.Domains;

public sealed record UserRegisteredEvent(FullName Name, Email Email, Mobile Mobile, Password Password):IDomainEvent;

public sealed record UserEmailChangedEvent(Email OldEmail, Email NewEmail):IDomainEvent;
public sealed record UserMobileChangedEvent(Mobile OldMobile, Mobile NewMobile):IDomainEvent;
public sealed record UserProfileUpdatedEvent(FullName NewName):IDomainEvent;
public sealed record UserAccountDeactivatedEvent(EntityID Id):IDomainEvent;

public sealed record UserPasswordChangedEvent(Password NewPassword, Password OldPassword):IDomainEvent;
// public sealed record UserLoginDetectedEvent(EntityID Id, Password NewPassword, Password OldPassword):IDomainEvent;

// public sealed record UserRoleAssignedEvent(EntityID Id, Role NewRole);
// public sealed record UserRoleRevokedEvent(EntityID Id, Role OldRole);