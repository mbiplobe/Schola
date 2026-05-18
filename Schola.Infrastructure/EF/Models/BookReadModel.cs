namespace Schola.Infrastructure.EF.Models;

internal class BookReadModel : BaseModel
{

    public string? Title { get; set; }
    public string? Author { get; set; }
    public string? ISBN { get; set; }

    public int Quantity { get; set; }
}