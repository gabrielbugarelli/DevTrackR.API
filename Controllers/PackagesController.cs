using Microsoft.AspNetCore.Mvc;

namespace DevTrackR.API.Controllers;

[ApiController]
[Route("api/packages")]
public class PackagesController : ControllerBase
{
  [HttpGet]
  public IActionResult GetAll() {
    return Ok();
  }

  [HttpGet("{code}")]
  public IActionResult GetByCode(string code) {
    return Ok(code);
  }
}
