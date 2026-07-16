using Microsoft.AspNetCore.Mvc;
using Trackerr.Application.Abstractions.Services;
using Trackerr.Application.Features.Artists.DTOs;

namespace Trackerr.Api.Controllers.Artists;

[ApiController]
[Route("api/v1/artists")]
public class ArtistsController : ControllerBase
{
    private readonly IArtistService _artistService;

    public ArtistsController(IArtistService artistService)
    {
        _artistService = artistService;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        return Ok(await _artistService.GetAllAsync());
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateArtistRequest request)
    {
        var artist = await _artistService.AddAsync(request);

        return CreatedAtAction(nameof(GetById), new { id = artist.Id }, artist);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var artist = await _artistService.GetByIdAsync(id);

        if (artist is null)
            return NotFound();

        return Ok(artist.ToResponse());
    }
}