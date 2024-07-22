namespace Basic.Webapi;

public interface IHttpService
{
    Task<string> ReadAsync();
}
