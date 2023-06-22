using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Authorize]
[Route("api/play")]
[ApiController]
public class PlayController : ControllerBase
{
    [HttpGet("get-players")]
    public IActionResult Players()
    {
        return Ok(new JsonResult(new { message = "Only authorized users can view players" }));
    }


}
