using DevTrackR.API.Entities;

namespace DevTrackR.API.Persistence;

public class DevTrackRContext {
  public List<Package> Packages { get; set; }

  public DevTrackRContext() {
    this.Packages = new List<Package>();
  }
}