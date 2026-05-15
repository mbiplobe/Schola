using Schola.Shared.Abstractions.Domains;

public sealed record UserRegisteredEvent(EntityID Id, FullName Name, Email Email, Mobile Mobile, Password Password):IDomainEvent;

public sealed record UserEmailChangedEvent(EntityID Id, Email OldEmail, Email NewEmail):IDomainEvent;
public sealed record UserMobileChangedEvent(EntityID Id, Mobile OldMobile, Mobile NewMobile):IDomainEvent;
public sealed record UserProfileUpdatedEvent(EntityID Id, FullName NewName):IDomainEvent;
public sealed record UserAccountDeactivatedEvent(EntityID Id):IDomainEvent;

public sealed record UserPasswordChangedEvent(EntityID Id, Password NewPassword, Password OldPassword):IDomainEvent;
// public sealed record UserLoginDetectedEvent(EntityID Id, Password NewPassword, Password OldPassword):IDomainEvent;

// public sealed record UserRoleAssignedEvent(EntityID Id, Role NewRole);
// public sealed record UserRoleRevokedEvent(EntityID Id, Role OldRole);