using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[Route("api/[controller]")]
[ApiController]
public class HeatmapController : ControllerBase
{
    private readonly HeatmapDbContext _context;

    public HeatmapController(HeatmapDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Subject>>> Get()
    {
        return await _context.Subjects.ToListAsync();
    }

    [HttpPost]
    public async Task<ActionResult<Subject>> Post(Subject entity)
    {
        _context.Subjects.Add(entity);
        await _context.SaveChangesAsync();
        return CreatedAtAction("Get", new { id = entity.SubjectId }, entity);
    }
}
