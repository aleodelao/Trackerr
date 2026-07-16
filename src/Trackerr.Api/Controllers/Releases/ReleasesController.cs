using Microsoft.AspNetCore.Mvc;
using Trackerr.Application.Abstractions.Services;
using Trackerr.Application.Features.Releases.DTOs;

namespace Trackerr.Api.Controllers.Releases;

[ApiController]
[Route("api/v1/releases")]
public class ReleasesController(IReleaseService releaseService) : ControllerBase
{
    private readonly IReleaseService _releaseService = releaseService;

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        return Ok(await _releaseService.GetAllAsync());
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateReleaseRequest request)
    {
        var release = await _releaseService.AddAsync(request);

        return CreatedAtAction(nameof(GetById), new { id = release.Id }, release);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var release = await _releaseService.GetByIdAsync(id);

        if (release is null)
            return NotFound();

        return Ok(release.ToResponse());
    }
}