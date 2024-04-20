using Microsoft.AspNetCore.Mvc;
using TestTask.Services.Interfaces;

namespace TestTask.Controllers;

public class LinkController:Controller
{
    private readonly ILinkService _linkService;

    public LinkController(ILinkService linkService)
    {
        _linkService = linkService;
    }

    public async Task<IActionResult> GetAll()
    {
        var links = await _linkService.GetLinksAsync();
        return View("GetAll",links);
    }
}