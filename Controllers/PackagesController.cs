using DevTrackR.API.Entities;
using DevTrackR.API.Models;
using DevTrackR.API.Persistence;
using Microsoft.AspNetCore.Mvc;

namespace DevTrackR.API.Controllers;

[ApiController]
[Route("api/packages")]
public class PackagesController : ControllerBase {
  private readonly DevTrackRContext _context;

  public PackagesController(DevTrackRContext context) {
    this._context = context;
  }

  [HttpGet]
  public IActionResult GetAllPackages() {
    var packages = _context.Packages;

    return Ok(packages);
  }

  [HttpGet("{code}")]
  public IActionResult GetPackageByCode(string code) {
    var package = _context.Packages.SingleOrDefault(item => {
      return item.Code == code;
    });

    if(package == null) {
      return NotFound();
    }

    return Ok(package);
  }

  [HttpPost]
  public IActionResult CreatePackage(AddPackageInputModel model){
    if(model.Title.Length < 10) {
      return BadRequest("Title length must be at least ten(10) characteres!");
    }

    var package = new Package(model.Title, model.Weight);

    this._context.Packages.Add(package);
    
    return CreatedAtAction("GetPackageByCode", new {code = package.Code}, package);
  }

  [HttpPost("/updates/{code}")]
  public IActionResult UpdatePost(string code, AddPackageUpdateInputModel model) {
    var package = _context.Packages.SingleOrDefault(item => {
      return item.Code == code;
    });

    if(package == null) {
      return NotFound();
    }

    package.AddUpdate(model.Status, model.Delivered);
    return NoContent();
  }
}
