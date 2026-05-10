using Schola.Domain.Entities;
using Schola.Shared.Abstractions.Domains;
using Schola.Domain.ValueObjects;

namespace Schola.Domain.Events;

public record SampleEntityItemRemoved(SampleEntity sampleEntity, SampleEntityItem sampleEntityItem) : IDomainEvent;