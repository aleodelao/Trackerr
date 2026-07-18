using Microsoft.AspNetCore.Mvc;
using Trackerr.Application.Abstractions.Services;
using Trackerr.Application.Features.Artists.DTOs;
using Trackerr.Application.Shared.Results;

namespace Trackerr.Api.Controllers.Artists;

[ApiController]
[Route("api/v1/artists")]
public class ArtistsController(IArtistService artistService) : ControllerBase
{
    private readonly IArtistService _artistService = artistService;


    /// <summary>
    /// Gets all artists
    /// </summary>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ArtistResponse>>> GetAll()
    {
        var artists = await _artistService.GetAllAsync(null);

        return Ok(artists);
    }


    /// <summary>
    /// Gets a single artist by id
    /// </summary>
    [HttpGet("{id:guid}")]
    public async Task<ActionResult<ArtistDetailResponse>> GetById(Guid id)
    {
        var artist = await _artistService.GetByIdAsync(id);

        if (artist is null)
            return NotFound();

        return Ok(artist);
    }
    
    
    /// <summary>
    /// Searches artists
    /// </summary>
    [HttpGet("search")]
    public async Task<ActionResult<List<ArtistResponse>>> Search(
        [FromQuery] string? search = null)
    {
        var artists = await _artistService.GetAllAsync(search);

        return Ok(artists);
    }


    /// <summary>
    /// Creates a new artits
    /// </summary>
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateArtistRequest request)
    {
        var result = await _artistService.AddAsync(request);
        
        if (result.IsFailure)
            return result.Error!.Type switch
            {
                ErrorType.Validation => BadRequest(result.Error),
                ErrorType.Conflict => Conflict(result.Error),
                _ => StatusCode(
                    StatusCodes.Status500InternalServerError,
                    result.Error
                )
            };

        return CreatedAtAction(nameof(GetById), new { id = result.Value!.Id }, result.Value);
    }

    [HttpPut]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateArtistRequest request)
    {
        var result = await _artistService.UpdateAsync(id, request);

        if (result.IsFailure)
            return result.Error!.Type switch
            {
                ErrorType.Validation => BadRequest(result.Error),
                ErrorType.NotFound => NotFound(result.Error),
                ErrorType.Conflict => BadRequest(result.Error),
                _ => StatusCode(
                    StatusCodes.Status500InternalServerError,
                    result.Error
                )
            };

        return Ok(result.Value);
    }
}