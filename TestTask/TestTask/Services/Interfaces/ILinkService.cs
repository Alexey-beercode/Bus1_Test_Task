using TestTask.Models;

namespace TestTask.Services.Interfaces;

public interface ILinkService
{
    Task<Link> GetLinkAsync(int id);
    Task<Link> GetLinkByShortUrlAsync(string shortUrl);
    Task<Link> CreateLinkAsync(string longUrl);
    Task UpdateLinkAsync(Link link);
    Task DeleteLinkAsync(int id);
    Task<IEnumerable<Link>> GetLinksAsync();
}