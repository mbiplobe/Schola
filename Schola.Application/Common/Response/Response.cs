public class Response<T>
{
    public bool Success { get; set; }
    public int StatusCode { get; set; }
    public string? Message { get; set; }
    public T? Data { get; set; }
    public Error? Errors { get; set; } = new();
    public ResponseMeta Meta { get; set; } = new();
}