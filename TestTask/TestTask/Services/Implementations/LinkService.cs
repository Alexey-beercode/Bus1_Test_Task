using Microsoft.EntityFrameworkCore;
using TestTask.DataManagment;
using TestTask.Models;
using TestTask.Services.Interfaces;

namespace TestTask.Services.Implementations;

public class LinkService : ILinkService
{
    private readonly ApplicationDbContext _dbContext;

    public LinkService(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Link> GetLinkAsync(int id)
    {
        return await _dbContext.Links.FindAsync(id);
    }

    public async Task<Link> GetLinkByShortUrlAsync(string shortUrl)
    {
        return await _dbContext.Links.FirstOrDefaultAsync(l => l.ShortUrl == shortUrl);
    }

    public async Task<Link> CreateLinkAsync(string longUrl)
    {
        var link = new Link
        {
            LongUrl = longUrl,
            ShortUrl = GenerateShortUrl(longUrl),
            CreatedDate = DateTime.UtcNow,
            Count = 0
        };

        _dbContext.Links.Add(link);
        await _dbContext.SaveChangesAsync();

        return link;
    }

    public async Task UpdateLinkAsync(Link link)
    {
        var linkFromDatabase =await _dbContext.Links.FindAsync(link.Id);
        if (linkFromDatabase.LongUrl!=link.LongUrl)
        {
            link.ShortUrl = GenerateShortUrl(link.LongUrl);
        }
        _dbContext.Update(link);
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteLinkAsync(int id)
    {
        var link = await _dbContext.Links.FindAsync(id);
        if (link != null)
        {
            _dbContext.Links.Remove(link);
            await _dbContext.SaveChangesAsync();
        }
    }

    public async Task<IEnumerable<Link>> GetLinksAsync()
    {
        var links = await _dbContext.Links.ToListAsync();
        return links;
    }

    public string GetShortUrlByLongurl(string longUrl)
    {
        return GenerateShortUrl(longUrl);
    }

    private string GenerateShortUrl(string longUrl)
    {
        // Берем первые 6 символов длинного URL
        string baseShortUrl = longUrl.Substring(0, Math.Min(longUrl.Length, 6));

        // Добавляем несколько случайных символов для уникальности
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
        Random random = new Random();
        string randomChars = new string(Enumerable.Repeat(chars, 5)
            .Select(s => s[random.Next(s.Length)]).ToArray());

        // Возвращаем короткий URL, объединяя часть длинного URL и случайные символы
        return baseShortUrl + randomChars;
    }

}