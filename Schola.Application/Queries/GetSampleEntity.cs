using Schola.Application.DTOs;
using Schola.Shared.Abstractions.Queries;

namespace Schola.Application.Queries;

public class GetSampleEntity : IQuery<SampleEntityDto>
{
    public Guid Id { get; set; }
}
