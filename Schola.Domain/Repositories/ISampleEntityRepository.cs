using Schola.Domain.Entities;
using Schola.Domain.ValueObjects;

namespace Schola.Domain.Repositories;

    public interface ISampleEntityRepository
    {
        Task<SampleEntity> GetAsync(SampleEntityId id);
        Task AddAsync(SampleEntity sampleEntity);
        Task UpdateAsync(SampleEntity sampleEntity);
        Task DeleteAsync(SampleEntity sampleEntity);
    }
