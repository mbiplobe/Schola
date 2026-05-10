using Schola.Domain.ValueObjects;

namespace Schola.Domain.Policies;

    public interface ISampleEntityItemsPolicy
    {
        bool IsApplicable(PolicyData data);
        IEnumerable<SampleEntityItem> GenerateItems(PolicyData data);
    }
