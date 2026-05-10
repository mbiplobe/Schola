using Schola.Domain.Entities;
using Schola.Shared.Abstractions.Domains;
using Schola.Domain.ValueObjects;

namespace Schola.Domain.Events;

public record SampleEntityItemTaken(SampleEntity sampleEntity, SampleEntityItem sampleEntityItem) : IDomainEvent;
