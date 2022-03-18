using API.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace API.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class ClipsController : Controller
  {
    private readonly IClipsService _clipsService;

    public ClipsController(IClipsService clipsService)
    {
      _clipsService = clipsService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllClips()
    {
      try
      {
        var clipsList = await _clipsService.GetClipsAsync(null);

        if (clipsList is null) return NotFound("Lista de clips vazia.");

        return Ok(clipsList);
      }

      catch (Exception)
      {
        return BadRequest("Erro na requisição.");
      }
    }

    [HttpGet("{quantity:int}")]
    public async Task<IActionResult> GetClips([FromRoute] int quantity)
    {
      try
      {
        var clipsList = await _clipsService.GetClipsAsync(quantity);

        if (clipsList is null) return NotFound("Lista de clips vazia.");

        return Ok(clipsList);
      }

      catch (Exception)
      {
        return BadRequest("Erro na requisição.");
      }
    }

    [HttpGet("game/{id}")]
    public async Task<IActionResult> GetAllClipsByGameId([FromRoute] string id)
    {
      try
      {
        var clipsList = await _clipsService.GetClipsByGameIdAsync(id, null);

        if (clipsList is null) return NotFound("Lista de clips vazia.");

        return Ok(clipsList);
      }

      catch (Exception)
      {
        return BadRequest("Erro na requisição.");
      }
    }

    [HttpGet("game/{id}/{quantity:int}")]
    public async Task<IActionResult> GetClipsByGameId([FromRoute] string id, int quantity)
    {
      try
      {
        var clipsList = await _clipsService.GetClipsByGameIdAsync(id, quantity);

        if (clipsList is null) return NotFound("Lista de clips vazia.");

        return Ok(clipsList);
      }

      catch (Exception)
      {
        return BadRequest("Erro na requisição.");
      }
    }

    [HttpGet("daily")]
    public async Task<IActionResult> GetAllDailyClips()
    {
      try
      {
        var clipsList = await _clipsService.GetDailyClipsAsync(null);

        if (clipsList is null) return NotFound("Lista de clips vazia.");

        return Ok(clipsList);
      }

      catch (Exception)
      {
        return BadRequest("Erro na requisição.");
      }
    }

    [HttpGet("daily/{quantity:int}")]
    public async Task<IActionResult> GetDailyClips([FromRoute] int quantity)
    {
      try
      {
        var clipsList = await _clipsService.GetDailyClipsAsync(quantity);

        if (clipsList is null) return NotFound("Lista de clips vazia.");

        return Ok(clipsList);
      }

      catch (Exception)
      {
        return BadRequest("Erro na requisição.");
      }
    }

    [HttpGet("weekly")]
    public async Task<IActionResult> GetAllWeeklyClips()
    {
      try
      {
        var clipsList = await _clipsService.GetWeeklyClipsAsync(null);

        if (clipsList is null) return NotFound("Lista de clips vazia.");

        return Ok(clipsList);
      }

      catch (Exception)
      {
        return BadRequest("Erro na requisição.");
      }
    }

    [HttpGet("weekly/{quantity:int}")]
    public async Task<IActionResult> GetWeeklyClips([FromRoute] int quantity)
    {
      try
      {
        var clipsList = await _clipsService.GetWeeklyClipsAsync(quantity);

        if (clipsList is null) return NotFound("Lista de clips vazia.");

        return Ok(clipsList);
      }

      catch (Exception)
      {
        return BadRequest("Erro na requisição.");
      }
    }
  }
}