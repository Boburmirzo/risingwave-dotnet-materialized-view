using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RisingWaveDotnetMaterializedView.DbHelpers;

namespace RisingWaveDotnetMaterializedView.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MaterializedViewController : ControllerBase
{
    private readonly DataContext _context;

    public MaterializedViewController(DataContext context)
    {
        _context = context;
    }

    [HttpGet("AverageSpeedView")]
    public async Task<ActionResult<IEnumerable<AverageSpeedView>>> GetAverageSpeedView()
    {
        return await _context.AverageSpeedViews.ToListAsync();
    }
}
