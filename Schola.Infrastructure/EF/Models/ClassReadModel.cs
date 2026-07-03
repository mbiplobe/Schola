namespace Schola.Infrastructure.EF.Models;

internal class ClassReadModel 
{
    public long Id { get; set; }
    public string Name { get; set; } = default!;

    public string Description { get; set; } = default!;

}