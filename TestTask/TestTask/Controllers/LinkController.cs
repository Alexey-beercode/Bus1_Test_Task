using Microsoft.AspNetCore.Mvc;
using TestTask.Models;
using TestTask.Services.Interfaces;

namespace TestTask.Controllers;

public class LinkController:Controller
{
    private readonly ILinkService _linkService;

    public LinkController(ILinkService linkService)
    {
        _linkService = linkService;
    }

    [HttpGet("redirect")]
    public async Task<IActionResult> RedirectByShortUrl(string shortUrl)
    {
        var link = await _linkService.GetLinkByShortUrlAsync(shortUrl);
        link.Count++;
        await _linkService.UpdateLinkAsync(link);

        return Redirect(link.LongUrl);
    }

    [HttpGet("/{longUrl}")]
    public async Task<IActionResult> GetShortUrlByLongUrl(string longUrl)
    {
       var shortUrl= _linkService.GetShortUrlByLongurl(longUrl);
       return Ok(shortUrl);
    }

    [HttpGet]
    public async Task<IActionResult> CreateLink()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> CreateLink(string url)
    {
        if (url==null || url=="")
        {
            return BadRequest("Неправильный Url");
        }
        await _linkService.CreateLinkAsync(url);
        return RedirectToAction("Index","Home");
    }

    public async Task<IActionResult> DeleteLink(int id)
    {
        if (id==null)
        {
            return BadRequest("Неправильный id");
        }

        await _linkService.DeleteLinkAsync(id);
        return RedirectToAction("Index","Home");
    }

    [HttpGet]
    public async Task<IActionResult> UpdateLink(int id)
    {
        var link =await _linkService.GetLinkAsync(id);
        return View("Update", link);
    }
    
}