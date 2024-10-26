namespace PicPaySimplificado.Models;

public class ResponseModel<T>
{
    public string Message { get; set; } = string.Empty;
    public bool Status { get; set; } = true;
    public T? Data { get; set; }
}