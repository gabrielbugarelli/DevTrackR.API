using DevTrackR.API.Entities;
using DevTrackR.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace DevTrackR.API.Controllers;

[ApiController]
[Route("api/packages")]
public class PackagesController : ControllerBase
{
  [HttpGet]
  public IActionResult GetAllPackages() {
    var packages = new List<Package> {
      new Package("Pacote 1", 1.3M),
      new Package("Pacote 2", 1.4M)
    };

    return Ok(packages);
  }

  [HttpGet("{code}")]
  public IActionResult GetPackageByCode(string code) {
    var package = new Package("pacote 3", 1.50M);

    return Ok(package);
  }

  [HttpPost]
  public IActionResult CreatePackage(AddPackageInputModel model){
    var package = new Package(model.Title, model.Weight);

    return Ok(package);
  }

  [HttpPost("/updates/{code}")]
  public IActionResult UpdatePost(string code, AddPackageUpdateInputModel model) {
    var package = new Package("Pacote 1", 1.2M);
    package.AddUpdate(model.Status, model.Delivered);

    return Ok();
  }
}
