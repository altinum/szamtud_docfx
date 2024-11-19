using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Heatmap.Data;
using Heatmap.Services;
using Heatmap.services;

namespace Heatmap.Controllers;

[Route("heatmap")]
[ApiController]
public class HeatmapController : ControllerBase
{
    private readonly HeatmapDbContext _context;
    private readonly Service _service;

    public HeatmapController(HeatmapDbContext context, Service service)
    {
        _context = context;
        _service = service;
    }

    [HttpGet("sites")]
    public async Task<ActionResult<IList<Site>>> GetSitesAsync( CancellationToken cancellationToken) =>
        await _context.Sites.ToListAsync(cancellationToken); 

    [HttpPut("currentHash/{siteId}")]
    public async Task<ActionResult<bool>> UpdateCurrentHash([FromBody] string hash, [FromRoute] int siteId,
        CancellationToken cancellationToken)
    {
        try
        {
            bool hashChanged = await _service.UpdateContentHashAsync(hash, siteId, cancellationToken);
            return Ok(hashChanged);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }


    [HttpPost("emptyDatabase/{siteId}")]
    public async Task<ActionResult> EmptyDatabase([FromRoute] int siteId, CancellationToken cancellationToken)
    {
        try
        {
            await _service.EmptyDatabaseAsync(siteId, cancellationToken);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }

        return Ok();
    }

    [HttpGet("types")]
    public async Task<ActionResult<IEnumerable<HtmlElementType>>> GetHtmlElementTypes(
        CancellationToken cancellationToken) =>
        await _context.HtmlElementTypes.ToListAsync(cancellationToken);


    [HttpGet("sections/{siteId}")]
    public async Task<ActionResult<IEnumerable<Section>>> GetSectionsBySiteIdAsync([FromRoute] int siteId,
        CancellationToken cancellationToken) =>
        await _context.Sections.Where(s => s.SiteId == siteId).ToListAsync(cancellationToken);

    [HttpPost("section")]
    public async Task<ActionResult<Section>> CreateSection([FromBody] CreateSectionDto htmlElement,
        CancellationToken cancellationToken)
    {
        try
        {
            Section section = await _service.CreateSectionAsync(htmlElement, cancellationToken);
            return Ok(section);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost("sites")]
    public async Task<ActionResult<Section>> CreateSite([FromBody] string siteUrl, CancellationToken cancellationToken)
    {
        try
        {
            return Ok(await _service.CreateSiteAsync(siteUrl, cancellationToken));
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost("position")]
    public async Task<ActionResult> CreatePositionInfo(Position position, CancellationToken cancellationToken)
    {
        try
        {
            await _service.CreatePositionInfoAsync(position, cancellationToken);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }

        return Ok();
    }

    [HttpGet("positions/{siteId}")]
    public async Task<IList<Position?>> GetPositionInfosBySiteUrl([FromRoute] int siteId, CancellationToken cancellationToken) =>
        await _service.GetPositionsBySiteIdAsync(siteId, cancellationToken);

    [HttpGet("visibilityInfos/{siteId}")]
    public async Task<IList<VisibilityInfo?>> GetVisibilityInfos([FromRoute] int siteId, CancellationToken cancellationToken) =>
        await _service.GetVisibilityInfosBySiteIdAsync(siteId, cancellationToken);

    [HttpPut("timingInfo/{sectionId}")]
    public async Task<ActionResult> UpdateTimingInfo([FromRoute] int sectionId, [FromBody] double visibleTime,
        CancellationToken cancellationToken)
    {
        try
        {
            await _service.UpdateVisibilityInfoAsync(sectionId, visibleTime, cancellationToken);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }

        return Ok();
    }
}