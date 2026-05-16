public class ResponseMeta
{
    public DateTime? Timestamp { get; set; } = DateTime.UtcNow;
    public string? RequestId { get; set; } = Guid.NewGuid().ToString();
    public string? Version { get; set; }
}

public class Error
{
    public string? Code { get; set; }
    public List<string>? Message { get; set; }
}