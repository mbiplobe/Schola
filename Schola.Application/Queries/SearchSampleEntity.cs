using Schola.Application.DTOs;
using Schola.Shared.Abstractions.Queries;

namespace Schola.Application.Queries;

public class SearchSampleEntity : IQuery<IEnumerable<SampleEntityDto>>
{
    public string SearchPhrase { get; set; }
}
